using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using gestao_residuos_ASP.NET.Data;
using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace gestao_residuos_ASP.NET.Services
{
    public class LixoService : ILixoService
    {
        private readonly GestaoResiduosContext _context;
        private readonly IMapper _mapper;

        public LixoService(GestaoResiduosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public LixoExibicaoDTO SalvarLixo(LixoDTO lixoDto)
        {
            try
            {
                var novoLixo = _mapper.Map<Lixo>(lixoDto);
                _context.Lixo.Add(novoLixo);
                _context.SaveChanges();
                return _mapper.Map<LixoExibicaoDTO>(novoLixo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao salvar lixo: {ex.Message}", ex);
            }
        }

        public List<Lixo> ListarLixos()
        {
            try
            {
                return _context.Lixo.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao listar lixos: {ex.Message}", ex);
            }
        }

        public LixoExibicaoDTO BuscarLixoPorId(long id)
        {
            try
            {
                var lixo = _context.Lixo.Find(id);
                if (lixo == null)
                {
                    throw new InvalidOperationException("Lixo não encontrado!");
                }
                return _mapper.Map<LixoExibicaoDTO>(lixo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar lixo por ID: {ex.Message}", ex);
            }
        }

        public List<LixoExibicaoDTO> BuscarLixoPorTipo(string tipo)
        {
            try
            {
                return _context.Lixo
                    .Where(l => l.Tipo == tipo)
                    .Select(l => _mapper.Map<LixoExibicaoDTO>(l))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar lixo por tipo: {ex.Message}", ex);
            }
        }

        public List<LixoExibicaoDTO> BuscarLixoPorLocalizacao(string localizacao)
        {
            try
            {
                return _context.Lixo
                    .Where(l => l.Localizacao == localizacao)
                    .Select(l => _mapper.Map<LixoExibicaoDTO>(l))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar lixo por localização: {ex.Message}", ex);
            }
        }

        public LixoExibicaoDTO Atualizar(long id, LixoDTO lixoDto)
        {
            try
            {
                var lixoExistente = _context.Lixo.Find(id);
                if (lixoExistente == null)
                {
                    throw new InvalidOperationException("Lixo não encontrado!");
                }
                _mapper.Map(lixoDto, lixoExistente);
                _context.Lixo.Update(lixoExistente);
                _context.SaveChanges();
                return _mapper.Map<LixoExibicaoDTO>(lixoExistente);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao atualizar lixo: {ex.Message}", ex);
            }
        }

        public void Excluir(long id)
        {
            try
            {
                var lixo = _context.Lixo.Find(id);
                if (lixo == null)
                {
                    throw new InvalidOperationException("Lixo não encontrado!");
                }
                _context.Lixo.Remove(lixo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao excluir lixo: {ex.Message}", ex);
            }
        }
    }
}
