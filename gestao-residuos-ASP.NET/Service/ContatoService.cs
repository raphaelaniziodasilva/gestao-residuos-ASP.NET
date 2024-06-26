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
    public class ContatoService : IContatoService
    {
        private readonly GestaoResiduosContext _context;
        private readonly IMapper _mapper;

        public ContatoService(GestaoResiduosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ContatoExibicaoDto SalvarContato(ContatoDto contatoDto)
        {
            try
            {
                var contatoExistente = _context.Contato.SingleOrDefault(c => c.Email == contatoDto.Email);

                if (contatoExistente != null)
                {
                    throw new InvalidOperationException("Contato já existe!");
                }

                var novoContato = _mapper.Map<Contato>(contatoDto);

                _context.Contato.Add(novoContato);
                _context.SaveChanges();

                return _mapper.Map<ContatoExibicaoDto>(novoContato);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao salvar contato: {ex.Message}", ex);
            }
        }

        public List<Contato> ListarContatos()
        {
            try
            {
                return _context.Contato.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao listar contatos: {ex.Message}", ex);
            }
        }

        public ContatoExibicaoDto BuscarContatoPorId(long id)
        {
            try
            {
                var contato = _context.Contato.Find(id);

                if (contato == null)
                {
                    throw new InvalidOperationException("Contato não existe!");
                }

                return _mapper.Map<ContatoExibicaoDto>(contato);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar contato por ID: {ex.Message}", ex);
            }
        }

        public ContatoExibicaoDto BuscarContatoPorEmail(string email)
        {
            try
            {
                var contato = _context.Contato.SingleOrDefault(c => c.Email == email);

                if (contato == null)
                {
                    throw new InvalidOperationException("Contato não existe!");
                }

                return _mapper.Map<ContatoExibicaoDto>(contato);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar contato por email: {ex.Message}", ex);
            }
        }

        public Contato Atualizar(long id, ContatoDto contatoDto)
        {
            try
            {
                var contatoExistente = _context.Contato.Find(id);

                if (contatoExistente == null)
                {
                    throw new InvalidOperationException("Contato não encontrado!");
                }

                _mapper.Map(contatoDto, contatoExistente);

                _context.Contato.Update(contatoExistente);
                _context.SaveChanges();

                return contatoExistente;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao atualizar contato: {ex.Message}", ex);
            }
        }

        public void Excluir(long id)
        {
            try
            {
                var contato = _context.Contato.Find(id);

                if (contato == null)
                {
                    throw new InvalidOperationException("Contato não encontrado!");
                }

                _context.Contato.Remove(contato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao excluir contato: {ex.Message}", ex);
            }
        }
    }
}
