using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalWebAPI.DAL.Context;
using TraversalWebAPI.DAL.Entities;

namespace TraversalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using(var c=new VisitorContext())
            {
                var values = c.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult AddVisitor( Visitor visitor)
        {
            using (var c = new VisitorContext())
            {
                c.Add(visitor);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]

        public IActionResult VisitorById(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    c.Remove(values);
                    c.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Find<Visitor>(visitor.VisitorId);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.City = visitor.City;
                    values.Name = visitor.Name;
                    values.SurName = visitor.SurName;
                    values.Mail = visitor.Mail;
                    values.Country = visitor.Country;
                    c.Update(values);
                    c.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
