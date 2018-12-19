using Microsoft.AspNetCore.Mvc;
using nucleocs.Models;
using System.Linq;
using System.Collections.Generic;
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
    public class FinishingController : ControllerBase
    {
        private readonly IFinishingService _service;

        public FinishingController(IFinishingService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAllFinishings")] 
        public ActionResult<List<FinishingDTO>> GetAll()
        {
            return  Ok(_service.GetAllFinishings());
        }

        [HttpGet("{id:int}", Name = "GetFinishingById")]
        public ActionResult<MVFinishing> GetById(int id)
        {   
            var finishing =  _service.GetFinishingByID(id);

            if (finishing == null)
            {
                return NotFound();
            }
            return MVFinishing.From(finishing);
        }

        [HttpGet("{name}", Name = "GetFinishingNome")]
        public ActionResult<MVFinishing> GetFinishingNome(string name)
        {
            var item =  _service.GetFinishingByName(name);

            if (item == null)
            {
                return NotFound();
            }
            
            return Ok(item);
        }

        [HttpPost(Name = "CreateFinishing")]
        public ActionResult<MVFinishing> PostFinishing(FinishingDTO finishing)
        {
            var item =  _service.CreateFinishing(finishing);
                                
            if(item == null){
               return BadRequest();
            }else{
                return Ok(MVFinishing.From(item));
            }
        }

        [HttpPut(Name = "UpdateFinishing")]
        public IActionResult UpdateFinishing(FinishingDTO finishing)
        {
            var item =  _service.UpdateFinishing(finishing);

            if (item == null)
            {
                return NotFound();
            }else{
                return Ok(MVFinishing.From(item));
            }
        }

        [HttpDelete(Name = "DeleteFinishing")]
        public IActionResult DeleteFinishing(FinishingDTO finishing)
        {
            var item =  _service.DeleteFinishing(finishing);
            if(item)
            {
                return Ok();
            }else{                
                return NotFound("Material nao existe: "+ finishing.FinishingId);
            }     
        }
    }
}

