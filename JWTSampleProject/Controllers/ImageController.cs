using JWTSampleProject.Context;
using JWTSampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JWTSampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly SampleDbContext _dbContext;

        public ImageController(SampleDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var imageEntity = new ImageEntity
            {
                FileName = file.FileName
            };

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                imageEntity.Data = memoryStream.ToArray();
            }

            await _dbContext.ImageEntities.AddAsync(imageEntity);
            await _dbContext.SaveChangesAsync();

            return Ok(imageEntity.Id);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var imageEntity = await _dbContext.ImageEntities.FirstOrDefaultAsync(image => image.Id == id);

            if (imageEntity == null)
                return NotFound();

            var fileContentResult = new FileContentResult(imageEntity.Data, "application/octet-stream")
            {
                FileDownloadName = imageEntity.FileName
            };

            return fileContentResult;
        }
    }

}
