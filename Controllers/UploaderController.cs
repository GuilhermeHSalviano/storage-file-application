using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_for_uploading_files;

namespace MyApp.Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        //The method receives a files whose type is IFormfile
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            return Ok(new UploadHandler().Upload(file)); 
        }

        [HttpGet("{fileName}")]
        public IActionResult DownloadFile(string fileName) {

            try {
                var path = DownloadHandler.Download(fileName);
                return PhysicalFile(path, "image/jpg", "my-image");
            } catch(Exception error) {
                return NotFound(error.Message);
            }
        }
    }
}
