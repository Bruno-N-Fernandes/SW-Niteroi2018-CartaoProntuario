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
		private readonly ProntuarioRepository _prontuarioRepository = new ProntuarioRepository();
		private readonly Cache _cache = new Cache(TimeSpan.FromMinutes(5));


		private IEnumerable<Prontuario> Prontuarios => _cache.Setup(() => _prontuarioRepository.ObterTodosProntuarios());

		public Int64? ObterProntuarioId(String aspNetUsersId)
		{
			return Prontuarios.FirstOrDefault(p => p.AspNetUsersId == aspNetUsersId)?.Id;
		}

		public void RegistrarProntuario(Prontuario prontuario)
		{
			var transacao = Conexao.Ativa.BeginTransaction();
			try
			{
				_prontuarioRepository.Incluir(prontuario, transacao);
				_cache.Incluir(prontuario);
				transacao.Commit();
			}
			catch (Exception)
			{
				transacao.Rollback();
				throw;
			}
		}

		public Prontuario ObterProntuario(Int64 id)
		{
			return _prontuarioRepository.ObterPorId(id);
		}
	}
}