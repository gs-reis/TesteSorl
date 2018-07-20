using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Commands.Parameters;
using TesteSorl.Model;

namespace TesteSorl
{
	public class SolrQueryResults<T>
	{
		public string solrUrl = "http://localhost:8983/solr/";
		public string queryAll = "*:*";

		public SolrQueryResults(string collection)
		{
			solrUrl += collection;
		}

		public string Results()
		{
			StringBuilder sb = new StringBuilder();
			Startup.Init<T>(solrUrl);
			var solr = ServiceLocator.Current.GetInstance<ISolrOperations<T>>();
			var query = new SolrQuery(queryAll);
			var options = new QueryOptions{
				Rows = 10
			};

			var results = solr.Query(query, options);

			foreach (var item in results){
				sb.AppendLine(item.ToString());
			}

			return sb.ToString();
		}
	}
}
