using CadastroSeriesConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeriesConsole
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        #region Metodos

        /// <summary>
        /// Atualiza a serie da lista
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serie"></param>
        public void Atualiza(int id, Serie serie)
        {
            listaSerie[id] = serie;
        }

        /// <summary>
        /// Exclui a serie da lista
        /// </summary>
        /// <param name="id"></param>
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        /// <summary>
        /// Insere uma serie na lista
        /// </summary>
        /// <param name="serie"></param>
        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
        }

        /// <summary>
        /// Retorna a lista de series
        /// </summary>
        /// <returns></returns>
        public List<Serie> Lista()
        {
            return listaSerie;
        }

        /// <summary>
        /// Retorna proximo ID (indice) da serie
        /// </summary>
        /// <returns>ID</returns>
        public int ProximoId()
        {
            //Count retorna quantidade e como o a lista começa no indice 0, o Count ira retornar o numero certo, isso porque não usamos o RemoveAt que ajustaria os indices. 
            return listaSerie.Count;
        }

        /// <summary>
        /// Retorna a serie por id da lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Serie</returns>
        public Serie RetornaPorId(int id)
        {
            if(listaSerie.FindIndex(s => s.Id == id) != -1)
            {
                return listaSerie[id];
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
