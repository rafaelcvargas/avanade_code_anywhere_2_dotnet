using System;
using System.Collections.Generic;
using System.Globalization;

namespace CadastroSeriesConsole
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            try
            {
                string opcaoUsuario = ObterOpcaoUsuario();

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario.ToUpper())
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                    }
                    opcaoUsuario = ObterOpcaoUsuario();
                }
                Console.WriteLine("Obrigado por utilizar nossos serviços");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mostra as opções da Tela
        /// </summary>
        /// <returns></returns>
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Vargas Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToString();
            Console.WriteLine();

            return opcaoUsuario;
        }

        /// <summary>
        /// Lista as séries
        /// </summary>
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var listaSerie = serieRepositorio.Lista();

            if (listaSerie.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
            }

            foreach (var serie in listaSerie)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("ID {0}: - {1}{2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? " - Excluído" : string.Empty));

            }
        }

        /// <summary>
        /// Insere série
        /// </summary>
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opções acima: ");
            string entradaGeneroString = Console.ReadLine();
            int entradaGenero;
            
            if (int.TryParse(entradaGeneroString, out entradaGenero))
            {
                //verifica se a entradaGenero é valida para o Enum de Genero
                if (!Enum.IsDefined(typeof(Genero), entradaGenero))
                {
                    Console.WriteLine("Genero inválido!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Genero inválido!");
                return;
            }

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            string entradaAnoString = Console.ReadLine();
            int entradaAno;
            if (ValidaAno(entradaAnoString))
            {
                entradaAno = int.Parse(entradaAnoString);
            }
            else
            {
                Console.WriteLine("Ano inválido!");
                return;
            }

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                       );

            serieRepositorio.Insere(novaSerie);
            Console.WriteLine("Série inserida com sucesso!");

        }

        /// <summary>
        /// Atualiza série
        /// </summary>
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            string indiceSerie = Console.ReadLine();

            if (ValidaIdSerie(indiceSerie))
            {
                int indice = int.Parse(indiceSerie);
                if (serieRepositorio.RetornaPorId(indice).RetornaExcluido())
                {
                    Console.WriteLine("Falha ao atualizar,  a série está excluida.");
                }
                else
                {
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                    }

                    Console.WriteLine("Digite o genero entre as opções acima: ");
                    string entradaGeneroString = Console.ReadLine();
                    int entradaGenero;

                    if (int.TryParse(entradaGeneroString, out entradaGenero))
                    {
                        //verifica se a entradaGenero é valida para o Enum de Genero
                        if (!Enum.IsDefined(typeof(Genero), entradaGenero))
                        {
                            Console.WriteLine("Genero inválido!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Genero inválido!");
                        return;
                    }

                    Console.WriteLine("Digite o Título da Série: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.WriteLine("Digite o Ano de Inicio da Série: ");
                    string entradaAnoString = Console.ReadLine();
                    int entradaAno;
                    if (ValidaAno(entradaAnoString))
                    {
                        entradaAno = int.Parse(entradaAnoString);
                    }
                    else
                    {
                        Console.WriteLine("Ano inválido!");
                        return;
                    }

                    Console.WriteLine("Digite a Descrição da Série: ");
                    string entradaDescricao = Console.ReadLine();

                    Serie atualizaSerie = new Serie(id: indice,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);
                    serieRepositorio.Atualiza(indice, atualizaSerie);
                    Console.WriteLine("Série atualizada com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Digite um indice valido.");
            }
        }

        /// <summary>
        /// Exclui uma série
        /// </summary>
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");

            string indiceSerie = Console.ReadLine();

            if (ValidaIdSerie(indiceSerie))
            {
                int indice = int.Parse(indiceSerie);
                if (serieRepositorio.RetornaPorId(indice).RetornaExcluido())
                {
                    Console.WriteLine("Erro: Série já está excluida");
                }
                else
                {
                    serieRepositorio.Exclui(indice);
                    Console.WriteLine("Série excluida com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Digite um indice valido.");
            }
        }

        /// <summary>
        /// Visualizar uma série
        /// </summary>
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            string indiceSerie = Console.ReadLine();

            if (ValidaIdSerie(indiceSerie))
            {
                int indice = int.Parse(indiceSerie);
                var serie = serieRepositorio.RetornaPorId(indice);
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Digite um indice valido.");
            }
        }

        /// <summary>
        /// Valida se o indice é valido, e se existe na lista
        /// </summary>
        /// <param name="indiceSerie"></param>
        /// <returns></returns>
        private static bool ValidaIdSerie(string indiceSerie)
        {
            int indice;

            if (int.TryParse(indiceSerie, out indice))
            {
                if (indice >= 0)
                {
                    var serie = serieRepositorio.RetornaPorId(indice);

                    if (serie != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida se a string contem um ano valido
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        private static bool ValidaAno(String ano)
        {
            try
            {
                string[] formats = { "yyyy" };
                DateTime parsedDateTime;
                bool anoOk = DateTime.TryParseExact(ano, formats, new CultureInfo("en-US"),
                                               DateTimeStyles.None, out parsedDateTime);

                //Console.WriteLine(parsedDateTime.ToString());

                return anoOk;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
