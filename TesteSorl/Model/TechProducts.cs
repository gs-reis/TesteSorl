﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet.Attributes;

namespace TesteSorl.Model
{
	public class TechProducts
	{
		#region Constantes

		public string collectionName = "techproducts";

		#endregion

		#region Propriedades
		[SolrUniqueKey("id")]
		public string Id { get; set; }

		[SolrField("name")]
		public String Nome { get; set; }

		[SolrField("author")]
		public String Autor { get; set; }

		[SolrField("cat")]
		public ICollection<string> Categorias { get; set; }

		[SolrField("price")]
		public decimal Preco { get; set; }
		#endregion

		#region Métodos

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"");
			sb.AppendLine($"Identificador: {this.Id}");
			sb.AppendLine($"Nome: {this.Nome}");
			sb.AppendLine($"Autor: {this.Autor}");
			sb.AppendLine($"Preço: {this.Preco}");
			if (this.Categorias != null)
			{
				sb.AppendLine($"Categoria(s):");
				foreach (var item in this.Categorias)
				{
					sb.AppendLine($"{item,-20}");
				}
			}
			else
			{
				sb.AppendLine($" ### Sem Categoria ### ");
			}

			sb.AppendLine($"");
			return sb.ToString();
		}

		#endregion

		#region Construtor

		public TechProducts()		{
		}

		#endregion
	}
}
