﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CP.Aplicacao.Infra
{
	public class Conexao
	{
		// TODO: Melhorar o Gerenciamento de Conexão
		public static IDbConnection Ativa;

		static Conexao()
		{
			var stringConexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			Ativa = new SqlConnection(stringConexao);
			Ativa.Open();
			// TODO: Melhorar o Tratamento de exceção de conexão
		}
	}
}