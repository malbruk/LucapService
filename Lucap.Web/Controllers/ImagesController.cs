using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lucap.Repositories.Entities;
using Lucap.Web.PostModels;

namespace Lucap.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly LucapDBContext _context;
        private readonly GoogleStorageManager _googleStorageManager;

        public ImagesController(LucapDBContext context, GoogleStorageManager googleStorageManager)
        {
            _context = context;
            _googleStorageManager = googleStorageManager;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(IFormFile file)
        {
          if (_context.Images == null)
          {
              return Problem("Entity set 'LucapDBContext.Images'  is null.");
          }
            if (file != null)
            {
                var uploadedFileLink = await _googleStorageManager.UploadFileAsync(file);
                var image = new Image() { Url = uploadedFileLink };
                _context.Images.Add(image);

                await _context.SaveChangesAsync();
                return CreatedAtAction("GetImage", new { id = image.Id }, image);

                //using (var memoryStream = new MemoryStream())
                //{
                //    await file.CopyToAsync(memoryStream);

                //    // Upload the file if less than 2 MB
                //    if (memoryStream.Length < 2097152)
                //    {
                //        var image = new Image()
                //        {
                //            Content = memoryStream.ToArray()
                //        };

                //        _context.Images.Add(image);

                //        await _context.SaveChangesAsync();
                //        return CreatedAtAction("GetImage", new { id = image.Id }, image);
                //    }
                //    else
                //    {
                //        ModelState.AddModelError("File", "The file is too large.");
                //    }
                //}
            }
            return NotFound();
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
