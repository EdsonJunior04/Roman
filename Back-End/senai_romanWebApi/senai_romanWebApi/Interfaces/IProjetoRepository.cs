using senai_romanWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_roman_WebApi.Interfaces
{
    interface IProjetoRepository
    {
        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <returns></returns>
        List<Projeto> ListarTodos();

        /// <summary>
        /// Busca um projeto atráves do id
        /// </summary>
        /// <param name="idProjeto">Id do projeto a ser buscado</param>
        /// <returns></returns>
        Projeto BuscarPorId(int idProjeto);

        /// <summary>
        /// Cadastrar um novo projeto
        /// </summary>
        /// <param name="novoProjeto">Objeto Projeto a ser cadastrado</param>
        void Cadastrar(Projeto novoProjeto);

        /// <summary>
        /// Deleta um projeto atráves do id
        /// </summary>
        /// <param name="idProjeto">Id do projeto a ser deletado</param>
        void Deletar(int idProjeto);


        /// <summary>
        /// Atualizar 
        /// um projeto atráves do id
        /// </summary>
        /// <param name="idProjeto">Id do projeto a ser atualizado</param>
        /// <param name="ProjetoAtualizado">Objeto projeto a ser atualizado</param>
        void AtualizarUrl(int idProjeto, Projeto ProjetoAtualizado);

    }
}
