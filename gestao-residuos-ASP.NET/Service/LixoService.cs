﻿using System.Collections.Generic;
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
            var novoLixo = _mapper.Map<Lixo>(lixoDto);
            _context.Lixo.Add(novoLixo);
            _context.SaveChanges();
            return _mapper.Map<LixoExibicaoDTO>(novoLixo);
        }

        public List<Lixo> ListarLixos()
        {
            return _context.Lixo.ToList();
        }

        public LixoExibicaoDTO BuscarLixoPorId(long id)
        {
            var lixo = _context.Lixo.Find(id);
            if (lixo == null)
            {
                throw new InvalidOperationException("Lixo não encontrado!");
            }
            return _mapper.Map<LixoExibicaoDTO>(lixo);
        }

        public List<LixoExibicaoDTO> BuscarLixoPorTipo(string tipo)
        {
            return _context.Lixo
                .Where(l => l.Tipo == tipo)
                .Select(l => _mapper.Map<LixoExibicaoDTO>(l))
                .ToList();
        }

        public List<LixoExibicaoDTO> BuscarLixoPorLocalizacao(string localizacao)
        {
            return _context.Lixo
                .Where(l => l.Localizacao == localizacao)
                .Select(l => _mapper.Map<LixoExibicaoDTO>(l))
                .ToList();
        }

        public LixoExibicaoDTO Atualizar(long id, LixoDTO lixoDto)
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

        public void Excluir(long id)
        {
            var lixo = _context.Lixo.Find(id);
            if (lixo == null)
            {
                throw new InvalidOperationException("Lixo não encontrado!");
            }
            _context.Lixo.Remove(lixo);
            _context.SaveChanges();
        }
    }
}
