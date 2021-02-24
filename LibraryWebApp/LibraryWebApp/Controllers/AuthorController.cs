using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
   
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;



        public AuthorController(AuthorService service)
        {
            _authorService = service;
        }
        
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<AuthorController>>> GetAll()
        {
            var author = _authorService.GetAllAsync();
            return Ok(author);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<AuthorController>> GetById(string id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([Required] Author author)
        {
            await _authorService.CreateAsync(author);
            return Ok(author);
        }
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Update(string id, [Required] Author updatedAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var queriedAuthor = await _authorService.GetByIdAsync(id);
            if (queriedAuthor == null)
            {
                return NotFound();
            }
            await _authorService.UpdateAsync(id, updatedAuthor);
            return NoContent();
        }
        [HttpDelete(), Authorize]
        public async Task<IActionResult> Delete([Required] string id)
        {
            var Author = await _authorService.GetByIdAsync(id);
            if (Author == null)
            {
                return NotFound();
            }
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
