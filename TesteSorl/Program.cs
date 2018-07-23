using System;
using System.Collections.Generic;

namespace TesteSorl
{
	class Program
	{
		private enum Collection
		{
			Livros = 1,
			Filmes = 2
		}

		static void Main()
		{
			Console.WriteLine("Inicio de Testes!");

			AbreMenu();


        }

		private static void AbreMenu()
		{
            Console.WriteLine("Selecione uma opção:");
			Console.WriteLine();
			Console.WriteLine($"{(int)Collection.Livros} - {Collection.Livros.ToString()}");
			Console.WriteLine($"{(int)Collection.Filmes} - {Collection.Filmes.ToString()}");
			Console.WriteLine($"Esc para sair");
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.L:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Consulta de Produtos");
                        Console.WriteLine(ConsultaProduto());
                        Finaliza();

                        break;
                    }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.F:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Consulta de Filmes");
                        Console.WriteLine(ConsultaFilmes());
                        Finaliza();
                        break;
                    }

                default:
                    return;
            }

        }

        private static void Finaliza()
        {
            Console.WriteLine();
            Console.WriteLine($"Pressione qualquer tecla para começar ou Esc para sair");

            var key = Console.ReadKey().Key;

            if (key != ConsoleKey.Escape)
            {
                AbreMenu();
            }
        }

		private static string ConsultaFilmes()
		{
			try
			{
				var film = new Model.Films();
				var query2 = new SolrQueryResults<Model.Films>(film.collectionName);
				return query2.Results();

			}
			catch (Exception ex)
			{

				throw new Exception("Erro de consulta de Filmes", ex);
			}

		}

		private static string ConsultaProduto()
		{
			try
			{
				var pr = new Model.TechProducts();
				var query = new SolrQueryResults<Model.TechProducts>(pr.collectionName);
				return query.Results();
			}
			catch (Exception ex)
			{

				throw new Exception("Erro de consulta de Produtos", ex);
			}


		}
	}
}
