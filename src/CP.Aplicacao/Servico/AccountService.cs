using CP.Aplicacao.Dominio.Account;
using CP.Aplicacao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CP.Aplicacao.Servico
{
	public class AccountService
	{
		public static readonly AccountService Ativo = new AccountService();
		private readonly Cache _cache = new Cache(TimeSpan.FromMinutes(5));

		private IEnumerable<AspNetUser> AspNetUsers => _cache.Setup(() => new AspNetUserRepository().ObterTodosAspNetUsers());

		public String ObterAspNetUserId(String userName)
		{
			return AspNetUsers.FirstOrDefault(u => u.Email == userName)?.Id;
		}
	}
}