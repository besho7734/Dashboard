using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoptask.Data;
using shoptask.Models;

namespace shoptask.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController(ApplicationDbContext _db,IMapper _Mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Blog>))]
        public IActionResult Get()
        {
            var blog = _db.blogs.Include(x=>x.type).ToList();
            return Ok(blog);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            var plog = _db.blogs.Include(x=>x.type).FirstOrDefault(x=>x.Id==id);
            if (plog == null) return NotFound();
            return Ok(plog);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        public IActionResult Post(Blog blog)
        {
            if (!ModelState.IsValid) return BadRequest();
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(Blog updatedblog)
        {
            var blog = _db.blogs.FirstOrDefault(x => x.Id == updatedblog.Id);
            if (blog == null) return NotFound();
            blog.Name = updatedblog.Name;
            blog.Description = updatedblog.Description;
            blog.type=updatedblog.type;
            blog.typeID = updatedblog.typeID;
            blog.Description=updatedblog.Description;
            blog.Price = updatedblog.Price;
            _db.blogs.Update(blog);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            var blog=_db.blogs.FirstOrDefault(x=>x.Id==id);
            if (blog == null) return NotFound();
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return Ok();
        }
    }
}