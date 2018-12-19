using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using nucleocs.Models;
using System;
using nucleocs.DTO;
using nucleocs.Data;
using nucleocs.Services;
using nucleocs.MVDTO;
using nucleocs.Services.Interfaces;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}", Name = "GetCategoryByID")]
        public ActionResult<MVCategory> GetCategoryByID(int id) {
            
            CategoryDTO category =  _service.GetCategoryByID(id);

            if(category == null){
                return NotFound();
            }else{
                return Ok(MVCategory.From(category));
            }

        }

        [HttpGet(Name = "GetAllCategories")]
        public ActionResult<List<CategoryDTO>> GetAll()
        {   
            return  Ok(_service.GetAllCategories());
        }

        //GET Category por nome
        [HttpGet("{name}", Name = "GetCategoryNome")]
        public ActionResult<List<MVCategory>> GetCategoryByName(string name)
        {
            var item =  _service.GetCategoryByName(name);

            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //POST: /api/category/ || BODY: {}
        [HttpPost(Name = "CreateCategory")]
        public ActionResult<MVCategory> PostCategory(CategoryDTO category)
        {
            var item =  _service.CreateCategory(category);
                                
            if(item == null){
               return BadRequest();
            }else{
                return Ok(MVCategory.From(item));
            }
            
        }

        [HttpPut(Name = "UpdateCategory")]
        public IActionResult UpdateCategory(CategoryDTO category)
        {
            var item =  _service.UpdateCategory(category);

            if (item == null)
            {
                return BadRequest();
            }else{
                return Ok(MVCategory.From(item));
            }
            
        }

        [HttpDelete(Name = "DeleteCategory")]
        public IActionResult DeleteCategory(CategoryDTO category)
        {
            var item =  _service.DeleteCategory(category);
            if (item)
            {
                return Ok();
            }else{                
                return NotFound("Categoria nao existe: "+category.CategoryId);
            }            
        }

    }
}