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

        public ContatoService(GestaoResiduosContext context)
        {
            _context = context;
        }

        public ContatoExibicaoDto SalvarContato(ContatoDto contatoDto)
        {
            var contatoExistente = _context.Contato.SingleOrDefault(c => c.Email == contatoDto.Email);

            if (contatoExistente != null)
            {
                throw new InvalidOperationException("Contato já existe!");
            }

            var novoContato = new Contato
            {
                Nome = contatoDto.Nome,
                Email = contatoDto.Email,
                Telefone = contatoDto.Telefone,
                Rua = contatoDto.Rua,
                Cidade = contatoDto.Cidade,
                Estado = contatoDto.Estado,
                Cep = contatoDto.Cep
            };

            _context.Contato.Add(novoContato);
            _context.SaveChanges();

            return new ContatoExibicaoDto(novoContato);
        }

        public List<Contato> ListarContatos()
        {
            return _context.Contato.ToList();
        }

        public ContatoExibicaoDto BuscarContatoPorId(long id)
        {
            var contato = _context.Contato.Find(id);

            if (contato == null)
            {
                throw new InvalidOperationException("Contato não existe!");
            }

            return new ContatoExibicaoDto(contato);
        }

        public ContatoExibicaoDto BuscarContatoPorEmail(string email)
        {
            var contato = _context.Contato.SingleOrDefault(c => c.Email == email);

            if (contato == null)
            {
                throw new InvalidOperationException("Contato não existe!");
            }

            return new ContatoExibicaoDto(contato);
        }

        public Contato Atualizar(long id, ContatoDto contato)
        {
            var contatoExistente = _context.Contato.Find(id);

            if (contatoExistente == null)
            {
                throw new InvalidOperationException("Contato não encontrado!");
            }

            contatoExistente.Nome = contato.Nome;
            contatoExistente.Email = contato.Email;
            contatoExistente.Telefone = contato.Telefone;
            contatoExistente.Rua = contato.Rua;
            contatoExistente.Cidade = contato.Cidade;
            contatoExistente.Estado = contato.Estado;
            contatoExistente.Cep = contato.Cep;

            _context.Contato.Update(contatoExistente);
            _context.SaveChanges();

            return contatoExistente;
        }

        public void Excluir(long id)
        {
            var contato = _context.Contato.Find(id);

            if (contato == null)
            {
                throw new InvalidOperationException("Contato não encontrado!");
            }

            _context.Contato.Remove(contato);
            _context.SaveChanges();
        }
    }
}
