using CP.Aplicacao.Servico;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace CP.WebApp.App_Code
{
	public class BaseController: Controller
	{
		public String AspNetUserId => AccountService.Ativo.ObterAspNetUserId(User.Identity.GetUserName());

		public Int64? ProntuarioId => ProntuarioService.Ativo.ObterProntuarioId(AspNetUserId);
	}
}