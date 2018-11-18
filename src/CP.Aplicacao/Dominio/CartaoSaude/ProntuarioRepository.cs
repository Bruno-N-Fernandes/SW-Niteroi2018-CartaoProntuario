using CP.Aplicacao.Infra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace CP.Aplicacao.Dominio.CartaoSaude
{
	public class ProntuarioRepository
	{
		private const String cSql_Select = @"Select Id, AspNetUsersId, CPF, CNS, Nome, Nascimento, NomeDaMae, Foto, TipoSanguineo, Telefone, ContatoEmergencia, DataRegistro From Prontuario ";
		private const String cSql_SelectById = cSql_Select + @" Where (Id = @Id)";

		private const String cSql_Insert = @"
Insert Into Prontuario(AspNetUsersId, CPF, CNS, Nome, Nascimento, NomeDaMae, TipoSanguineo, Telefone, ContatoEmergencia, DataRegistro)
Values (@AspNetUsersId, @CPF, @CNS, @Nome, @Nascimento, @NomeDaMae, @TipoSanguineo, @Telefone, @ContatoEmergencia, @DataRegistro);
Select Scope_Identity() As Id;";

		public IEnumerable<Prontuario> ObterTodosProntuarios()
		{
			return Conexao.Ativa.Query<Prontuario>(cSql_Select);
		}

		public void Incluir(Prontuario prontuario, IDbTransaction transacao)
		{
			prontuario.Id = Conexao.Ativa.ExecuteScalar<Int64>(cSql_Insert + ";", prontuario, transacao);
		}

		public Prontuario ObterPorId(long id)
		{
			return Conexao.Ativa.QueryFirstOrDefault<Prontuario>(cSql_SelectById + ";", new { Id = id });
		}
	}
}
