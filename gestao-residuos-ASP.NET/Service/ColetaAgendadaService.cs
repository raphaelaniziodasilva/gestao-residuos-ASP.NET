using AutoMapper;
using gestao_residuos_ASP.NET.Data;
using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gestao_residuos_ASP.NET.Services
{
    public class ColetaAgendadaService : IColetaAgendadaService
    {
        private readonly GestaoResiduosContext _context;
        private readonly IMapper _mapper;
        private readonly IContatoService _contatoService;
        private readonly ILixoService _lixoService;

        public ColetaAgendadaService(GestaoResiduosContext context, IMapper mapper, IContatoService contatoService, ILixoService lixoService)
        {
            _context = context;
            _mapper = mapper;
            _contatoService = contatoService;
            _lixoService = lixoService;
        }

        public ColetaAgendadaExibicaoDTO SalvarColetaAgendada(ColetaAgendadaDTO coletaAgendadaDto)
        {
            try
            {
                var novaColetaAgendada = _mapper.Map<ColetaAgendada>(coletaAgendadaDto);

                var contato = _context.Contato.Find(coletaAgendadaDto.ContatoId)
                                ?? throw new InvalidOperationException("Contato não encontrado!");

                novaColetaAgendada.Contato = contato;

                var lixo = _context.Lixo.Find(coletaAgendadaDto.LixoId)
                            ?? throw new InvalidOperationException("Lixo não encontrado!");

                novaColetaAgendada.Lixo = lixo;

                _context.ColetaAgendada.Add(novaColetaAgendada);
                _context.SaveChanges();

                return _mapper.Map<ColetaAgendadaExibicaoDTO>(novaColetaAgendada);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao salvar coleta agendada: {ex.Message}", ex);
            }
        }

        public List<ColetaAgendadaExibicaoDTO> ListarColetasAgendadas()
        {
            try
            {
                var coletas = _context.ColetaAgendada
                    .Include(c => c.Contato)
                    .Include(l => l.Lixo)
                    .ToList();

                return _mapper.Map<List<ColetaAgendadaExibicaoDTO>>(coletas);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao listar coletas agendadas: {ex.Message}", ex);
            }
        }

        public ColetaAgendadaExibicaoDTO BuscarColetaAgendadaPorId(long id)
        {
            try
            {
                var coletaAgendada = _context.ColetaAgendada
                    .Include(c => c.Contato)
                    .Include(l => l.Lixo)
                    .FirstOrDefault(a => a.Id == id);

                if (coletaAgendada == null)
                {
                    throw new InvalidOperationException("Coleta agendada não encontrada!");
                }

                return _mapper.Map<ColetaAgendadaExibicaoDTO>(coletaAgendada);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar coleta agendada por ID: {ex.Message}", ex);
            }
        }

        public List<ColetaAgendadaExibicaoDTO> BuscarColetasPorData(string dataColeta)
        {
            try
            {
                DateTime dataConvertida;
                if (!DateTime.TryParse(dataColeta, out dataConvertida))
                {
                    throw new ArgumentException("Data de coleta inválida.");
                }

                return _context.ColetaAgendada
                    .Include(c => c.Contato)
                    .Include(l => l.Lixo)
                    .Where(c => c.DataColeta.Date == dataConvertida.Date)
                    .Select(c => _mapper.Map<ColetaAgendadaExibicaoDTO>(c))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar coletas agendadas por data: {ex.Message}", ex);
            }
        }

        public List<ColetaAgendadaExibicaoDTO> BuscarColetasPorStatus(string status)
        {
            try
            {
                return _context.ColetaAgendada
                    .Include(c => c.Contato)
                    .Include(l => l.Lixo)
                    .Where(c => c.Status == status)
                    .Select(c => _mapper.Map<ColetaAgendadaExibicaoDTO>(c))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar coletas agendadas por status: {ex.Message}", ex);
            }
        }

        public ColetaAgendada Atualizar(long id, ColetaAgendadaDTO coletaAgendadaDto)
        {
            try
            {
                var coletaAgendadaExistente = _context.ColetaAgendada.Find(id)
                    ?? throw new InvalidOperationException("Coleta agendada não encontrada!");

                coletaAgendadaExistente.DataColeta = coletaAgendadaDto.DataColeta;
                coletaAgendadaExistente.Status = coletaAgendadaDto.Status;
                coletaAgendadaExistente.Observacoes = coletaAgendadaDto.Observacoes;

                var contato = _context.Contato.Find(coletaAgendadaDto.ContatoId)
                           ?? throw new InvalidOperationException("Contato não encontrado!");

                coletaAgendadaExistente.Contato = contato;

                var lixo = _context.Lixo.Find(coletaAgendadaDto.LixoId)
                            ?? throw new InvalidOperationException("Lixo não encontrado!");

                coletaAgendadaExistente.Lixo = lixo;

                _context.ColetaAgendada.Update(coletaAgendadaExistente);
                _context.SaveChanges();

                return coletaAgendadaExistente;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao atualizar coleta agendada: {ex.Message}", ex);
            }
        }

        public void Excluir(long id)
        {
            try
            {
                var coletaAgendada = _context.ColetaAgendada.Find(id)
                    ?? throw new InvalidOperationException("Coleta agendada não encontrada!");

                _context.ColetaAgendada.Remove(coletaAgendada);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao excluir coleta agendada: {ex.Message}", ex);
            }
        }

        public long ContarColetasPorContato(long contatoId)
        {
            try
            {
                return _context.ColetaAgendada
                    .Count(c => c.Contato.Id == contatoId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao contar coletas por contato: {ex.Message}", ex);
            }
        }
    }
}
