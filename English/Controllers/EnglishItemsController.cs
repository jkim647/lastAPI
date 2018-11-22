using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using English.Models;

namespace English.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnglishItemsController : ControllerBase
    {
        private readonly EnglishContext _context;

        public EnglishItemsController(EnglishContext context)
        {
            _context = context;
        }

        // GET: api/EnglishItems
        [HttpGet]
        public IEnumerable<EnglishItems> GetEnglishItems()
        {
            return _context.EnglishItems;
        }

        // GET: api/EnglishItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnglishItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var englishItems = await _context.EnglishItems.FindAsync(id);

            if (englishItems == null)
            {
                return NotFound();
            }

            return Ok(englishItems);
        }

        // GET: api/Meme/Tags
        [Route("English")]
        [HttpGet]
        public async Task<List<string>> GetTags()
        {
            var english = (from m in _context.EnglishItems
                         select m.English).Distinct();

            var returned = await english.ToListAsync();

            return returned;
        }

        // GET: api/Meme/Tags

        [HttpGet]
        [Route("tag")]
        public async Task<List<EnglishItems>> GetTagsItem([FromQuery] string tags)
        {
            var english = from m in _context.EnglishItems
                        select m; //get all the memes


            if (!String.IsNullOrEmpty(tags)) //make sure user gave a tag to search
            {
                english = english.Where(s => s.English.ToLower().Equals(tags.ToLower())); // find the entries with the search tag and reassign
            }

            var returned = await english.ToListAsync(); //return the memes

            return returned;
        }

        // PUT: api/EnglishItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnglishItems([FromRoute] int id, [FromBody] EnglishItems englishItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != englishItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(englishItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnglishItemsExists(id))
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

        // POST: api/EnglishItems
        [HttpPost]
        public async Task<IActionResult> PostEnglishItems([FromBody] EnglishItems englishItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EnglishItems.Add(englishItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnglishItems", new { id = englishItems.Id }, englishItems);
        }

        // DELETE: api/EnglishItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnglishItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var englishItems = await _context.EnglishItems.FindAsync(id);
            if (englishItems == null)
            {
                return NotFound();
            }

            _context.EnglishItems.Remove(englishItems);
            await _context.SaveChangesAsync();

            return Ok(englishItems);
        }

        private bool EnglishItemsExists(int id)
        {
            return _context.EnglishItems.Any(e => e.Id == id);
        }
    }
}