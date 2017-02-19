using System.Collections.Generic;
using MVCDemos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MVCDemos.Interfaces;

namespace MVCDemos.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsTestController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsTestController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET api/authorstest/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author;
        }
        // GET api/authorstest/5
        [HttpGet("getjson/{id}")]
        public async Task<JsonResult> GetJson(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return Json(author);
        }
    }
}