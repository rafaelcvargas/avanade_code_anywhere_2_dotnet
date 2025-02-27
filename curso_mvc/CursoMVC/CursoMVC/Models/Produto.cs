﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Produto
    {
        #region propriedades    

        public int Id { get; set; }
        [Display(Name ="Descrição")]
        [Required(ErrorMessage ="O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo quantidade é obrigatório")]
        [Range(1,10,ErrorMessage ="Valor dora da faixa de 1 a 10")]
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        #endregion
    }
}
