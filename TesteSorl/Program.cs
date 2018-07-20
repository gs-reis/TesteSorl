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

			var resulta = AbreMenu();


			Console.WriteLine("Pressiona uma tecla para sair");
			Console.ReadKey();
		}

		private static String AbreMenu()
		{
			Console.WriteLine("Selecione uma opção:");
			Console.WriteLine();
			Console.WriteLine($"{(int)Collection.Livros} - {Collection.Livros.ToString()}");
			Console.WriteLine($"{(int)Collection.Filmes} - {Collection.Filmes.ToString()}");
			Console.WriteLine($"Esc para sair");


			return Console.ReadKey().ToString();

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


		private static bool Sair(string comand)
		{
			var comandoOut = new List<string> { "sair", "out", "quit" };
			return comandoOut.Contains(comand);
		}
	}
}
