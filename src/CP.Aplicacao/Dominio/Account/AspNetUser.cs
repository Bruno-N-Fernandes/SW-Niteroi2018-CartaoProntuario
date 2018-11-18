using CP.Aplicacao.Infra;
using System;

namespace CP.Aplicacao.Dominio.Account
{
	public class AspNetUser : IUniqueId
	{
		public String Id { get; set; }
		public String Email { get; set; }
		long IUniqueId.UId { get => Id.GetHashCode(); set { } }
	}
}
