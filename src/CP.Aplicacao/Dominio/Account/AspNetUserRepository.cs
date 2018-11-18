using CP.Aplicacao.Infra;
using Dapper;
using System.Collections.Generic;

namespace CP.Aplicacao.Dominio.Account
{
	public class AspNetUserRepository
	{
		public IEnumerable<AspNetUser> ObterTodosAspNetUsers()
		{
			return Conexao.Ativa.Query<AspNetUser>(cSql_Select);
		}

		private string cSql_Select = @"Select Id, EMail From AspNetUsers;";
	}
}