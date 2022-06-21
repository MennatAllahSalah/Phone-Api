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
    public class PhonesController : ControllerBase
    {

        private readonly context Context;

        public PhonesController (context Context)
        {
            this.Context = Context;

        }
        [HttpGet]
        public IActionResult getPhones()
        {
            List<Phones>phones = Context.Phones.ToList();

            // List<category> categories = categoryReprosatory.GetAll();
            if (phones == null)
            {
                return BadRequest("Empty");
            }
            return Ok(phones);
        }
        [HttpGet("{id}", Name = "GetOnePhone")]
        public IActionResult getById(int id)
        {
           Phones phones= Context.Phones.FirstOrDefault(b => b.id == id);
            //    category category = categoryReprosatory.GetById(id);
            if (phones == null)
            {
                return BadRequest("Empty");
            }
            return Ok(phones);
        }
        [HttpPost]
        public IActionResult NEW(Phones phones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Context.Phones.Add(phones);
                    Context.SaveChanges();
                    string url = Url.Link("GetOneRoutePhones", new { id = phones.id });
                    return Created(url, phones);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Phones phones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Phones phone1 = Context.Phones.FirstOrDefault(b => b.id == id);
                   phone1.phone = phones.phone;
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

            try
            {
                Phones phone1 = Context.Phones.FirstOrDefault(b => b.id == id);
                Context.Phones.Remove(phone1);
                Context.SaveChanges();
                return StatusCode(200, "Data saved");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
            //return BadRequest(ModelState);
        }
        /*
        public List<Product> GetByCatID(int cat_ID)
        {
            List<Product> products =
                context.products.Where(p => p.categoryid == cat_ID).ToList();
            return products;
        }*/
        [HttpGet("{id}", Name = "GetPhonesByBookId")]
        public IActionResult getByBookId(int Book_id)
        {
            List<Phones> phones =
                Context.Phones.Where(p => p.bookid == Book_id).ToList();
            

            if (phones == null)
            {
                return BadRequest("Empty");
            }
            return Ok(phones);
        }
    }
}
