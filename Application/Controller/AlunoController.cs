using Rgm.ServiceInterfaceLayer.Dto;
using AutoMapper;
using Rgm.Domain.Entities.Entities;
using Rgm.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Rgm.BusinessEntities.Entities;
using Microsoft.AspNetCore.Authorization;
using Application.Dto;

namespace Rgm.Application.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IAluno _service { get; set; }
        public IMapper _mapper;

        public AlunoController(IAluno service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        //[Authorize("Bearer")]
        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetAll());

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetById(id));

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Aluno_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Aluno_Entity>(dto);
                return Ok(await _service.Post(entity));

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut("")]
        public async Task<ActionResult> Put([FromBody] Aluno_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Aluno_Entity>(dto);
                return Ok(await _service.Put(entity));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //[Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
