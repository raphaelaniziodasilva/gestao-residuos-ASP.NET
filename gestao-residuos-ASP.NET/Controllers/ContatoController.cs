using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace gestao_residuos_ASP.NET.Controllers
{
    [ApiController]
    [Route("api")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpPost("contato")]
        public ActionResult<ContatoExibicaoDto> SalvarContato([FromBody] ContatoDto contatoDto)
        {
            try
            {
                var contatoExibicaoDto = _contatoService.SalvarContato(contatoDto);
                return Ok(contatoExibicaoDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("contato")]
        public ActionResult<List<Contato>> ListarContatos()
        {
            return _contatoService.ListarContatos();
        }

        [HttpGet("contato/{id}")]
        public ActionResult<ContatoExibicaoDto> BuscarContatoPorId(long id)
        {
            try
            {
                var contato = _contatoService.BuscarContatoPorId(id);
                if (contato == null)
                {
                    return NotFound();
                }
                return Ok(contato);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("contato/email/{email}")]
        public ActionResult<ContatoExibicaoDto> BuscarContatoPorEmail(string email)
        {
            try
            {
                var contato = _contatoService.BuscarContatoPorEmail(email);
                if (contato == null)
                {
                    return NotFound();
                }
                return Ok(contato);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("contato/{id}")]
        public ActionResult<Contato> Atualizar(long id, [FromBody] ContatoDto contato)
        {
            try
            {
                var contatoAtualizado = _contatoService.Atualizar(id, contato);
                if (contatoAtualizado == null)
                {
                    return NotFound();
                }
                return Ok(contatoAtualizado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("contato/{id}")]
        public ActionResult Excluir(long id)
        {
            try
            {
                _contatoService.Excluir(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
