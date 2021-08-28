using System;
using System.Collections.Generic;

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

                while (opcaoUsuario.ToUpper() != "x")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            //AtualizarSerie();
                            break;
                        case "4":
                            //ExcluirSerie();
                            break;
                        case "5":
                            //VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
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

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Vargas Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToString();
            Console.WriteLine();

            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var listaSerie = serieRepositorio.Lista();

            if (listaSerie.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
            }

            foreach (var serie in listaSerie)
            {
                Console.WriteLine("ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());

            }
        }

        private static void InserirSerie()
        {
            Console.Write("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", 1, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            serieRepositorio.Insere(novaSerie);
        }
    }
}
