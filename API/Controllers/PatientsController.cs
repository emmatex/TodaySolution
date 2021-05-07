using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public PatientsController(IHostingEnvironment hostingEnvironment, IPatientService service)
        {
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> UploadCsv(IFormFile file)
        {
            try
            {
               // var file = Request.Form.Files[0];
                var moduleName = String.Empty;
                foreach (var key in Request.Form.Keys)
                {
                    if (key == "data[moduleName]")
                    {
                        var fileType = Request.Form[key];
                        moduleName = fileType.ToString();
                    }
                }
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
