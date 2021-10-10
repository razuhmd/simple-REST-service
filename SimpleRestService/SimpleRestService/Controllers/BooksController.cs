using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRestService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestService.Controllers
{
    [Route("api/[controller]")]
    // the controller is available on ..../api/books
    // [controller] means the name of the controller minus "Controller"
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{ISBN13}")]
        public Book Get(string ISBN13)
        {
            return _manager.GetById(ISBN13);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] string title, string author, int pageNumber)
        {
            return _manager.Create(title, author, pageNumber);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{ISBN13}")]
        public Book Put([FromBody] Book value)
        {
            return _manager.Update(value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{ISBN13}")]
        public Book Delete(string ISBN13)
        {
            return _manager.Delete(ISBN13);
        }
    }
}
