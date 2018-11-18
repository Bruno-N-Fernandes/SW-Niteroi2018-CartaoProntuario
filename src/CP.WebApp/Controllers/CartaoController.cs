using CP.Aplicacao.Servico;
using System;
using System.Web.Mvc;

namespace CP.WebApp.Controllers
{
	public class CartaoController : Controller
    {
		protected ProntuarioService ProntuarioService => ProntuarioService.Ativo;
		protected AccountService AccountService => AccountService.Ativo;

		public ActionResult Emergencia(String id)
		{
			var prontuarioId = ProntuarioService.ObterProntuarioId(id);
			if (prontuarioId.HasValue)
			{
				var prontuario = ProntuarioService.ObterProntuario(prontuarioId.Value);
				return View("Emergencia", prontuario);
			}
			return View();
		}
    }
}