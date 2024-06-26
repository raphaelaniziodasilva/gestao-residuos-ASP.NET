using System;
using System.Collections.Generic;
using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Models;
using gestao_residuos_ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace gestao_residuos_ASP.NET.Controllers
{
    [ApiController]
    [Route("api")]
    public class ColetaAgendadaController : ControllerBase
    {
        private readonly IColetaAgendadaService _coletaAgendadaService;

        public ColetaAgendadaController(IColetaAgendadaService coletaAgendadaService)
        {
            _coletaAgendadaService = coletaAgendadaService;
        }

        [HttpPost("coleta-agendada")]
        public IActionResult SalvarColetaAgendada([FromBody] ColetaAgendadaDTO coletaAgendadaDto)
        {
            try
            {
                var resultado = _coletaAgendadaService.SalvarColetaAgendada(coletaAgendadaDto);
                return CreatedAtAction(nameof(BuscarColetaAgendadaPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("coleta-agendada")]
        public ActionResult<List<ColetaAgendadaExibicaoDTO>> ListarColetasAgendadas()
        {
            try
            {
                var coletas = _coletaAgendadaService.ListarColetasAgendadas();
                return Ok(coletas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("coleta-agendada/{id}")]
        public ActionResult<ColetaAgendadaExibicaoDTO> BuscarColetaAgendadaPorId(long id)
        {
            try
            {
                var coleta = _coletaAgendadaService.BuscarColetaAgendadaPorId(id);
                return Ok(coleta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("coleta-agendada/data/{dataColeta}")]
        public ActionResult<List<ColetaAgendadaExibicaoDTO>> BuscarColetasPorData(string dataColeta)
        {
            try
            {
                var coletas = _coletaAgendadaService.BuscarColetasPorData(dataColeta);
                return Ok(coletas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("coleta-agendada/status/{status}")]
        public ActionResult<List<ColetaAgendadaExibicaoDTO>> BuscarColetasPorStatus(string status)
        {
            try
            {
                var coletas = _coletaAgendadaService.BuscarColetasPorStatus(status);
                return Ok(coletas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("coleta-agendada/{id}")]
        public ActionResult<ColetaAgendada> Atualizar(long id, [FromBody] ColetaAgendadaDTO coletaAgendadaDto)
        {
            try
            {
                var coleta = _coletaAgendadaService.Atualizar(id, coletaAgendadaDto);
                return Ok(coleta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("coleta-agendada/{id}")]
        public IActionResult Excluir(long id)
        {
            try
            {
                _coletaAgendadaService.Excluir(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("coleta-agendada/contar/{contatoId}")]
        public ActionResult<long> ContarColetasPorContato(long contatoId)
        {
            try
            {
                var count = _coletaAgendadaService.ContarColetasPorContato(contatoId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
