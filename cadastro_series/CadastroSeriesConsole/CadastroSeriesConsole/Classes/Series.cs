using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeriesConsole
{
    public class Serie : EntidadeBase
    {
        #region Construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public Serie(Serie serie)
        {
            this.Id = serie.Id;
            this.Genero = serie.Genero;
            this.Titulo = serie.Titulo;
            this.Descricao = serie.Descricao;
            this.Ano = serie.Ano;
            this.Excluido = false;
        }
        #endregion

        #region Atributos

        /// <summary>
        /// Genero
        /// </summary>
        private Genero Genero { get; set; }
        
        /// <summary>
        /// Título
        /// </summary>
        private string Titulo { get; set; }
        
        /// <summary>
        /// Descrição
        /// </summary>
        private string Descricao { get; set; }
        
        /// <summary>
        /// Ano de inicio da série
        /// </summary>
        private int Ano { get; set; }
        
        /// <summary>
        /// Status - excluido
        /// </summary>
        private bool Excluido { get; set; }
        #endregion


        #region Metodos

        /// <summary>
        /// Retorna a série formatada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine();
            retorno.AppendFormat("Genero: {0}", this.Genero).AppendLine();
            retorno.AppendFormat("Titulo: {0}", this.Titulo).AppendLine();
            retorno.AppendFormat("Descrição: {0}", this.Descricao).AppendLine();
            retorno.AppendFormat("Ano: {0}", this.Ano).AppendLine();
            retorno.AppendFormat("Excluído: {0}", this.Excluido ? "Sim":"Não").AppendLine();

            return retorno.ToString();
        }

        /// <summary>
        /// Retorna um título da série
        /// </summary>
        /// <returns></returns>
        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        /// <summary>
        /// Retorna o id da série
        /// </summary>
        /// <returns></returns>
        public int RetornaId()
        {
            return this.Id;
        }

        /// <summary>
        /// Seta a série com status de excluida
        /// </summary>
        public void Excluir()
        {
            this.Excluido = true;
        }

        /// <summary>
        /// Retorna status da série
        /// </summary>
        /// <returns></returns>
        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        #endregion
    }
}
