using CP.Aplicacao.Dominio.CartaoSaude;
using CP.Aplicacao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CP.Aplicacao.Servico
{
	public class ProntuarioService
	{
		public static readonly ProntuarioService Ativo = new ProntuarioService();
		private readonly Cache _cache = new Cache(TimeSpan.FromMinutes(5));

		private IEnumerable<Prontuario> Prontuarios => _cache.Setup(() => new ProntuarioRepository().ObterTodosProntuarios());

		public Int64? ObterProntuarioId(String aspNetUsersId)
		{
			return Prontuarios.FirstOrDefault(p => p.AspNetUsersId == aspNetUsersId)?.Id;
		}
	}
}