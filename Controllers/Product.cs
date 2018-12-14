using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using nucleocs.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using nucleocs.DTO;
using Microsoft.EntityFrameworkCore;
using nucleocs.Data;
using nucleocs.MVDTO;
using nucleocs.Services;
using nucleocs.Models.Strategy;
using nucleocs.Services.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        //return all
        [HttpGet(Name = "GetAllProducts")]
        public ActionResult<List<MVProduct>> GetAllProducts()
        {
            return Ok(_service.GetAllProducts());
        }

        //GET api/Product/{id}
        [HttpGet("{id:int}", Name = "GetProductById")]
        public ActionResult<MVProduct> GetProductById(int id)
        {
            var item = _service.GetProductByID(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVProduct.FromFull(item));
        }


        //GET: api/Product/{name}
        [HttpGet("{name}", Name = "GetProductByName")]
        public ActionResult<List<MVProduct>> GetProductByName(string name)
        {
            var item = _service.GetProductByName(name);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //POST: /api/product/litle/ || BODY: {}
        [HttpPost("litle/", Name = "CreateLitleProduct")]
        public ActionResult<MVProduct> PostLitleProduct(ProductDTO product)
        {
            var prod = _service.CreateLitleProduct(product);
            
            if(prod == null){ //se não existir irá criar um produto novo
                return BadRequest();
            }else{
                return Ok(MVProduct.FromLitle(prod));
            }            
        }

        //POST: /api/product/ || BODY: {}
        [HttpPost(Name = "CreateFullProduct")]
        public ActionResult<ProductDTO> PostFullProduct(ProductDTO product)
        {
            var prod = _service.CreateFullProduct(product);
            
            if(prod == null){ //se não existir irá criar um produto novo
                return BadRequest();
            }else{
                return Ok(MVProduct.FromFull(prod));
            }       
        }

        [HttpPut(Name = "UpdateProduct")]
        public IActionResult UpdateProduct(ProductDTO product)
        {
           var item = _service.UpdateProduct(product);

            if(item == null){
                return BadRequest();
            }             
            else{
                return Ok(MVProduct.FromFull(item));
            }    
        }

        [HttpDelete(Name = "DeleteProduto")]
        public IActionResult DeleteProduto(ProductDTO product)
        {
            var item = _service.DeleteProduct(product);
            if (item)
            {
                return Ok();
            }else{
                return NotFound("Produto nao existe: "+product.ProductId);
            }
        }
    }
}