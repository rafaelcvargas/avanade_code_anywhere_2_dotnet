using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeriesConsole.Interfaces
{
    /// <summary>
    /// Inteface Repositorio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Retorna uma Lista de T
        /// </summary>
        /// <returns>Lista de T</returns>
        List<T> Lista();

        /// <summary>
        /// Passando um id ele retorna um T
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        T RetornaPorId(int id);
        
        /// <summary>
        /// Insere no T
        /// </summary>
        /// <param name="entidade"></param>
        void Insere(T entidade);

        /// <summary>
        /// Exlui o T
        /// </summary>
        /// <param name="id"></param>
        void Exclui(int id);

        /// <summary>
        /// Atualiza o T
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entidade"></param>
        void Atualiza(int id, T entidade);

        /// <summary>
        /// Retorna proximo ID
        /// </summary>
        /// <returns>ID</returns>
        int ProximoId();

    }
}
