using Microsoft.AspNetCore.Mvc;
using nucleocs.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using nucleocs.DTO;
using Microsoft.EntityFrameworkCore;
using nucleocs.Data;
using nucleocs.Services;
using nucleocs.MVDTO;
using nucleocs.Services.Interfaces;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}", Name = "GetMaterialById")]
        public ActionResult<MVMaterial> GetMaterialById(int id){
            var item = _service.GetMaterialByID(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVMaterial.From(item));
        }

        //Get all materials
        [HttpGet(Name = "GetAllMaterials")] 
        public ActionResult<List<MaterialDTO>> GetAll()
        {
            return Ok(_service.GetAllMaterials());
        }

        //GET Material por nome
        [HttpGet("{name}", Name = "GetMaterialNome")]
        public ActionResult<List<MaterialDTO>> GetMaterialByName(string name)
        {
            var item = _service.GetMateriaByName(name);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost(Name = "CreateMaterial")]
        public ActionResult<MVMaterial> PostMaterial(MaterialDTO material)
        {   
            var item = _service.CreateMaterial(material);

            if(item == null){
                return BadRequest();
            }             
            else{
                return Ok(MVMaterial.From(item));
            }            
        }

        [HttpPut(Name = "UpdateMaterial")]
        public IActionResult UpdateMaterial(MaterialDTO material)
        {
           var item = _service.UpdateMaterial(material);

            if(item == null){
                return BadRequest();
            }             
            else{
                return Ok(MVMaterial.From(item));
            }    
        }

        [HttpDelete(Name = "DeleteMaterial")]
        public IActionResult DeleteMaterial(MaterialDTO material)
        {
            var item = _service.DeleteMaterial(material);
            if (item)
            {
                return Ok();                
            }else{
                return NotFound("Produto nao existe: "+ material.MaterialId);
            }    
        }
    }
}