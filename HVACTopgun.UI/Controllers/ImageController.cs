using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HVACTopGun.UI.Controllers
{
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment hostingEnv;
        private readonly ILogger<ImageController> _logger;

        public ImageController(IWebHostEnvironment env, ILogger<ImageController> logger)
        {
            this.hostingEnv = env;
            this._logger = logger;
        }

        [HttpPost]
        [Route("api/Image/Save")]
        public IActionResult Save(IList<IFormFile> UploadFiles)
        {
            try
            {
                if (UploadFiles == null || UploadFiles.Count == 0)
                {
                    return BadRequest("No files received.");
                }

                foreach (var file in UploadFiles)
                {
                    string targetPath = hostingEnv.ContentRootPath + "\\wwwroot\\Images";
                    string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    // Create a new directory, if it does not exists
                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    // Name which is used to save the image
                    filename = targetPath + $@"\{filename}";

                    if (!System.IO.File.Exists(filename))
                    {
                        // Upload a image, if the same file name does not exist in the directory
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                    else
                    {
                        return Conflict("A file with the same name already exists.");
                    }
                }

                return Ok(); // 200 status code
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred during file save.");
                return BadRequest(e.Message); // 400 status code with error message
            }
        }
    }
}