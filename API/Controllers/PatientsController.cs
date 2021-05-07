using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IPatientService _service;
        private readonly IPatientRepository _repository;
        private int pageSize = 10;

        public PatientsController(IHostingEnvironment hostingEnvironment, IPatientService service, IPatientRepository repository)
        {
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet(Name = "GetPatients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Patient>> GetPatients([FromQuery] int page = 1)
        {
            var patients = _repository.GetAsync(page, pageSize);
            return Ok(patients);
        }

        [HttpGet("{patientId}", Name = "GetPatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Patient>> GetPatient(string patientId)
        {
            var patient = await _repository.GetByIdAsync(patientId);
            return Ok(patient);
        }

        [HttpPost(Name = "UploadCsv"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadCsv(IFormFile file)
        {
            try
            {
                string folderName = "csvfileupload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    if (!fileName.EndsWith(".csv"))
                        return BadRequest($"File extention with name {fileName} is not supported");

                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    await _service.ProcessCsvFile(fullPath);
                }
                return Ok("Upload Successful.");
            }
            catch (Exception ex)
            {
                return BadRequest("Upload Failed: " + ex.Message);
            }
        }
    }
}
