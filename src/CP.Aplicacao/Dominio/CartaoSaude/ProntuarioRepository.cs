using CP.Aplicacao.Infra;
using Dapper;
using System.Collections.Generic;

namespace CP.Aplicacao.Dominio.CartaoSaude
{
	public class ProntuarioRepository
	{
		public IEnumerable<Prontuario> ObterTodosProntuarios()
		{
			return Conexao.Ativa.Query<Prontuario>(cSql_Select);
		}

		private string cSql_Select = @"Select Id, AspNetUsersId, CPF, CNS, Nome, Nascimento, NomeDaMae, Foto, TipoSanguineo, Telefone, ContatoEmergencia, DataRegistro From Prontuario;";
	}
}
