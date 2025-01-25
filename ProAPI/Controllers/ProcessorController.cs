using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.Entity;
using RestAPI.Models.Dto;
using RestAPI.Repository;
using RestAPI.Repository.IRepository;
using ApiPelicula.Models.DTOs;

namespace RestAPI.Controllers
{
    [Route("api/processors")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IProcessorRepository _processorRepository;
        private readonly IMapper _mapper;
        protected ResponseApi _responseApi;

        public ProcessorController(IProcessorRepository processorRepository, IMapper mapper)
        {
            _processorRepository = processorRepository;
            _responseApi = new ResponseApi();
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProcessors()
        {
            var processorList = _processorRepository.GetProcessors();
            var processorListDto = _mapper.Map<List<ProcessorDto>>(processorList);

            return Ok(processorListDto);
        }

        [HttpGet("{id:int}", Name = "GetProcessor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProcessor(int id)
        {
            var processor = _processorRepository.GetProcessor(id);
            if (processor == null)
            {
                return NotFound();
            }

            var processorDto = _mapper.Map<ProcessorDto>(processor);
            return Ok(processorDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateProcessor([FromBody] ProcessorDto processorDto)
        {
            if (processorDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var processorEntity = _mapper.Map<ProcessorEntity>(processorDto);

            if (!_processorRepository.CreateProcessor(processorEntity))
            {
                ModelState.AddModelError("Error", "Error creating the processor.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProcessor", new { id = processorEntity.Id }, processorEntity);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProcessor(int id, [FromBody] ProcessorDto processorDto)
        {
            if (processorDto == null || processorDto.Id != id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var processorEntity = _mapper.Map<ProcessorEntity>(processorDto);

            if (!_processorRepository.UpdateProcessor(processorEntity))
            {
                ModelState.AddModelError("Error", "Error updating the processor.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
