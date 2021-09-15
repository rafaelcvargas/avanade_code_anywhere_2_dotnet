using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogosRafa.ViewModel
{
    public class JogoViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Produtora
        /// </summary>
        public string Produtora { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        public double Preco { get; set; }
    }
}
