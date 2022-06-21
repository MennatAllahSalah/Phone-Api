using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace phoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class phoneBookController : ControllerBase
    {

        private readonly context Context;

        public phoneBookController(context Context)
        {
            this.Context = Context;

        }
        [HttpGet]
        public IActionResult getPhones()
        {
            List<BookPhone> bookPhones = Context.bookPhones.ToList();

            // List<category> categories = categoryReprosatory.GetAll();
            if (bookPhones == null)
            {
                return BadRequest("Empty");
            }
            return Ok(bookPhones);
        }
        [HttpGet("{id}", Name = "GetOneRoutePhones")]
        public IActionResult getById(int id)
        {
            BookPhone bookPhones = Context.bookPhones.FirstOrDefault(b => b.Id== id);
            //    category category = categoryReprosatory.GetById(id);
            if (bookPhones == null)
            {
                return BadRequest("Empty");
            }
            return Ok(bookPhones);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult getByName(string name)
        {
            BookPhone bookPhones = Context.bookPhones.FirstOrDefault(b => b.name == name);
            //    category category = categoryReprosatory.GetById(id);
            if (bookPhones == null)
            {
                return BadRequest("Empty");
            }
            return Ok(bookPhones);
        }
        [HttpPost]
        public IActionResult NEW(BookPhone book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Context.bookPhones.Add(book);
                    Context.SaveChanges();
                    string url = Url.Link("GetOneRoutePhones", new { id = book.Id });
                    return Created(url, book);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, BookPhone book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookPhone book1 = Context.bookPhones.FirstOrDefault(b => b.Id == id);
                    book1.name = book.name;
                    Context.SaveChanges();
                    return StatusCode(200, "Data saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           // if (ModelState.IsValid)
           // {
                try
                {
                    BookPhone book1 = Context.bookPhones.FirstOrDefault(b => b.Id == id);
                    Context.bookPhones.Remove(book1);
                    Context.SaveChanges();
                    // categoryReprosatory.delete(id);
                    return StatusCode(200, "Data saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            //}
            return BadRequest(ModelState);
        }
    }
}
