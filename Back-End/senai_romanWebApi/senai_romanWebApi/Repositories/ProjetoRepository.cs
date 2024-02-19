using senai_roman_WebApi.Interfaces;
using senai_romanWebApi.Context;
using senai_romanWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_roman_WebApi.Repositories
{   

    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext(); 

        public void AtualizarUrl(int idProjeto, Projeto ProjetoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Projeto BuscarPorId(int idProjeto)
        {
            return ctx.Projetos
                .Select(p => new Projeto()
                {
                    IdProjeto = p.IdProjeto,
                    IdUsuario = p.IdUsuario,
                    IdTema = p.IdTema,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    IdTemaNavigation = new Tema()
                    {
                        Titulo = p.IdTemaNavigation.Titulo
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        IdTipoUsuario = p.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = p.IdUsuarioNavigation.Nome
                    }
                })
                .FirstOrDefault(p => p.IdProjeto == idProjeto);
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public void Deletar(int idProjeto)
        {
            ctx.Projetos.Remove(BuscarPorId(idProjeto));
        }

        public List<Projeto> ListarTodos()
        {

            return ctx.Projetos
                .Select(p => new Projeto()
                {
                    IdProjeto = p.IdProjeto,
                    IdUsuario = p.IdUsuario,
                    IdTema = p.IdTema,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    IdTemaNavigation = new Tema()
                    {
                        Titulo = p.IdTemaNavigation.Titulo
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        IdTipoUsuario = p.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = p.IdUsuarioNavigation.Nome
                    }
                })
                .ToList();

        }
    }
}
