using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace gestao_residuos_ASP.NET.Interface
{
    public interface IContatoService
    {
        ContatoExibicaoDto SalvarContato(ContatoDto contatoDto);
        List<Contato> ListarContatos();
        ContatoExibicaoDto BuscarContatoPorId(long id);
        ContatoExibicaoDto BuscarContatoPorEmail(string email);
        Contato Atualizar(long id, ContatoDto contato);
        void Excluir(long id);
    }
}
