using Microsoft.AspNetCore.Mvc;

namespace HVACTopGun.UI.Components;
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public UploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost("save")]
    public async Task<IActionResult> Save(IFormFile file)
    {
        var filePath = Path.Combine(_environment.WebRootPath, "blog-images", file.FileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Ok();
    }

    [HttpPost("remove")]
    public IActionResult Remove(string fileName)
    {
        var filePath = Path.Combine(_environment.WebRootPath, fileName);

        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            return Ok();
        }

        return NotFound();
    }
}
