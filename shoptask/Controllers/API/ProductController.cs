using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoptask.Data;
using shoptask.Models;
using shoptask.Models.DTO;

namespace shoptask.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ApplicationDbContext _db, IMapper _Mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDTO>))]
        public IActionResult get()
        {
            var products = _db.products.Include(p => p.company).ToList();
            return Ok(_Mapper.Map<List<ProductDTO>>(products));
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            var product = _db.products.Include(x => x.company).FirstOrDefault(d => d.Id == id);
            if (product == null)
                return NotFound();
            return Ok(_Mapper.Map<ProductDTO>(product));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult createProduct(ProductDTO productdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var product = _Mapper.Map<Product>(productdto);
            product.EnableSize = true;
            product.Quantity = 20;
            _db.products.Add(product);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProduct(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var product = _db.products.FirstOrDefault(x => x.Id == id);
            _db.products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduct(ProductDTO updateproductdto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            Product product = _db.products.FirstOrDefault(x => x.Id == updateproductdto.Id);
            if(product == null) {return NotFound();}
            //product.Name=updateproductdto.Name;
            //product.Price=updateproductdto.Price;
            //product.companyID=updateproductdto.companyID;
            //product.Description=updateproductdto.Description;
            _Mapper.Map<ProductDTO,Product>(updateproductdto,product);
            _db.products.Update(product);
            _db.SaveChanges();
            return Ok();
        }
    }
}
