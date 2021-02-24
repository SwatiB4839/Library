using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        public BookController(BookService service)
        {
            _bookService = service;
        }
        
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var Books = _bookService.GetAllAsync();
            return Ok(Books);
        }
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Book>> GetById(string id)
        {
            var Book = await _bookService.GetByIdAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Ok(Book);
        }
       
        [HttpPost, Authorize] 
        public async Task<IActionResult> Create([Required]Book Book)
        {
            await _bookService.CreateAsync(Book);
            return Ok(Book);
        }
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Update(string id, [Required]Book updatedBook)
        {
            var queriedBook = await _bookService.GetByIdAsync(id);
            if (queriedBook == null)
            {
                return NotFound();
            }
            await _bookService.UpdateAsync(id, updatedBook);
            return NoContent();
        }
        [HttpDelete(), Authorize]
        public async Task<IActionResult> Delete([Required]  string id)
        {
            var Book = await _bookService.GetByIdAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
