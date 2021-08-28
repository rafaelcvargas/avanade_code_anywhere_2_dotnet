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
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        #endregion


        #region Metodos
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine();
            retorno.AppendFormat("Genero: {0}", this.Genero);
            retorno.AppendFormat("Titulo: {0}", this.Titulo);
            retorno.AppendFormat("Descrição: {0}", this.Titulo);
            retorno.AppendFormat("Ano: {0}", this.Titulo);
            retorno.AppendFormat("Excluido: {0}", this.Excluido);

            return retorno.ToString();
        }
        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        #endregion
    }
}
