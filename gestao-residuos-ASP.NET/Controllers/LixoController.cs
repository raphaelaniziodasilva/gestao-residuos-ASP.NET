using System;
using System.Collections.Generic;
using System.Linq;
using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace gestao_residuos_ASP.NET.Controllers
{
    [ApiController]
    [Route("api")]
    public class LixoController : ControllerBase
    {
        private readonly ILixoService _lixoService;

        public LixoController(ILixoService lixoService)
        {
            _lixoService = lixoService;
        }

        [HttpPost("lixo")]
        public ActionResult<LixoExibicaoDTO> SalvarLixo([FromBody] LixoDTO lixoDTO)
        {
            try
            {
                var novoLixo = _lixoService.SalvarLixo(lixoDTO);
                return CreatedAtAction(nameof(BuscarLixoPorId), new { id = novoLixo.Id }, novoLixo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("lixo")]
        public ActionResult<List<LixoExibicaoDTO>> ListarLixos()
        {
            var lixos = _lixoService.ListarLixos();
            return lixos.Select(lixo => new LixoExibicaoDTO(lixo)).ToList();
        }

        [HttpGet("lixo/{id}")]
        public ActionResult<LixoExibicaoDTO> BuscarLixoPorId(long id)
        {
            try
            {
                var lixo = _lixoService.BuscarLixoPorId(id);
                return lixo;
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("lixo/tipo/{tipo}")]
        public ActionResult<List<LixoExibicaoDTO>> BuscarLixoPorTipo(string tipo)
        {
            var lixos = _lixoService.BuscarLixoPorTipo(tipo);
            return lixos;
        }

        [HttpGet("lixo/localizacao/{localizacao}")]
        public ActionResult<List<LixoExibicaoDTO>> BuscarLixoPorLocalizacao(string localizacao)
        {
            var lixos = _lixoService.BuscarLixoPorLocalizacao(localizacao);
            return lixos;
        }

        [HttpPut("lixo/{id}")]
        public ActionResult<LixoExibicaoDTO> Atualizar(long id, [FromBody] LixoDTO lixoDto)
        {
            try
            {
                var lixo = _lixoService.Atualizar(id, lixoDto);
                return lixo;
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("lixo/{id}")]
        public IActionResult Excluir(long id)
        {
            try
            {
                _lixoService.Excluir(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
