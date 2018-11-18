using CP.Aplicacao.Servico;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace CP.WebApp.App_Code
{
	public class BaseWebController: Controller
	{
		protected ProntuarioService ProntuarioService => ProntuarioService.Ativo;
		protected AccountService AccountService => AccountService.Ativo;

		protected String AspNetUserId => AccountService.ObterAspNetUserId(User.Identity.GetUserName());

		protected Int64? ProntuarioId => ProntuarioService.ObterProntuarioId(AspNetUserId);
	}
}