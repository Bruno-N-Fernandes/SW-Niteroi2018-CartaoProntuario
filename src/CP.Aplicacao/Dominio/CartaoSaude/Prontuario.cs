using CP.Aplicacao.Infra;
using System;

namespace CP.Aplicacao.Dominio.CartaoSaude
{
	public class Prontuario : Entidade
	{
		public String AspNetUsersId { get; set; }
		public String CNS { get; set; }
		public Int64 CPF { get; set; }
		public String Nome { get; set; }
		public DateTime Nascimento { get; set; }
		public String NomeDaMae { get; set; }
		public Byte[] Foto { get; set; }
		public String TipoSanguineo { get; set; }
		public String Telefone { get; set; }
		public String ContatoEmergencia { get; set; }
		public DateTime DataRegistro { get; set; }

		public String QRCode { get => "https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=http://www.cartaoprontuario.co/Prontuario/Emergencia/" + AspNetUsersId; }
	}
}