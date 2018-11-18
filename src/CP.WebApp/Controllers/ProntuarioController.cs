using CP.Aplicacao.Dominio.CartaoSaude;
using CP.WebApp.App_Code;
using System;
using System.Web.Mvc;

namespace CP.WebApp.Controllers
{
	public class ProntuarioController : AuthWebController
	{
		public ActionResult Index()
		{
			if (ProntuarioId.HasValue)
			{
				var prontuario = ProntuarioService.ObterProntuario(ProntuarioId.Value);
				return View("Cartao", prontuario);
			}
			else
			{
				var prontuario = new Prontuario { AspNetUsersId = AspNetUserId, DataRegistro = DateTime.Now };
				return View("Registrar", prontuario);
			}
		}

		public ActionResult Registrar()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Registrar(FormCollection collection)
		{
			try
			{
				var prontuario = new Prontuario
				{
					AspNetUsersId = AspNetUserId,
					CNS = collection.Get("CNS"),
					ContatoEmergencia = collection.Get("ContatoEmergencia"),
					CPF = Convert.ToInt64(collection.Get("CPF")),
					Nascimento = Convert.ToDateTime(collection.Get("Nascimento")),
					Nome = collection.Get("Nome"),
					NomeDaMae = collection.Get("NomeDaMae"),
					Telefone = collection.Get("Telefone"),
					TipoSanguineo = collection.Get("TipoSanguineo"),
					DataRegistro = DateTime.Now
				};

				ProntuarioService.RegistrarProntuario(prontuario);

				return RedirectToAction("Cartao", prontuario);
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Alterar(int id)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Alterar(int id, FormCollection collection)
		{
			try
			{
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Cartao(int id)
		{
			return View();
		}
	}
}