/*
 * Created by SharpDevelop.
 * User: Luck
 * Date: 11/02/2017
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Mail;
using System.Net;

namespace ReloadWS.Security
{
	/// <summary>
	/// Clase utilizada para enviar Mails.
	/// </summary>
	public class cEmail
	{
		private MailMessage Correo;
		private SmtpClient client;
		private string _Emisor;
		private string _PassEmisor;
		private string _Receptor;
        private System.Collections.Generic.List<string> _listaReceptores;
		private string _Asunto;
		private string _Desarrollo;
		private string _Host;
		private int _Puerto;
		private bool IsHtml;
		
		public cEmail()
		{
			//_Emisor
			//_PassEmisor=_pe;
			//_Receptor=_r;
			//_Puerto = 2525;
			//_Host= "Mail.cladd.com.ar";
            _listaReceptores = new System.Collections.Generic.List<string>();
            IsHtml =true;
		}
		
		public int Puerto{
			set{_Puerto=value;}
			get{return _Puerto;}
		}
		
		public string Host{
			set{_Host=value;}
			get{return _Host;}
		}
		
		
		public string Asunto{
			set{_Asunto=value;}
			get{return _Asunto;}
		}
		
		public string Desarrollo{
			set{_Desarrollo=value;}
			get{return _Desarrollo;}
		}
		
		public string Receptor{
			set{_Receptor=value;}
			get{return _Receptor;}
		}
		
		public string Emisor{
			set{_Emisor=value;}
			get{return _Emisor;}
		}

		public string PassEmisor{
			set{_PassEmisor=value;}
			get{return _PassEmisor;}
		}
		
		public bool Html{
			set{IsHtml=value;}
		}

        public System.Collections.Generic.List<string> ListaReceptores
        {
            get
            {
                return _listaReceptores;
            }

            set
            {
                _listaReceptores = value;
            }
        }

		public bool Enviar(){
			try{
				Correo = new MailMessage();
				Correo.To.Add(Receptor);
                Correo.From = new MailAddress(Emisor);
                Correo.Priority = MailPriority.High;
                Correo.Subject = _Asunto;
				Correo.Body= _Desarrollo;
				Correo.Priority = MailPriority.High;
				Correo.IsBodyHtml=IsHtml;
				client = new SmtpClient();
				client.UseDefaultCredentials = false;
	            client.Credentials = new NetworkCredential(_Emisor,_PassEmisor);
	            client.Port = _Puerto;
	            client.Host = _Host;
				client.EnableSsl = true;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
                
				client.Send(Correo);
			
			}catch(Exception ex){
				return false;
			}
			
			Correo.Dispose();
			client.Dispose();
			
			return true;
		}

        public bool EnviarConCopias()
        {
            try
            {
                Correo = new MailMessage();
                foreach(string rep in _listaReceptores) { 
                    Correo.To.Add(rep);
                }
                Correo.From = new MailAddress(Emisor);
                Correo.Priority = MailPriority.High;
                Correo.Subject = _Asunto;
                Correo.Body = _Desarrollo;
                Correo.Priority = MailPriority.Normal;
                Correo.IsBodyHtml = IsHtml;
                client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_Emisor, _PassEmisor);
                client.Port = _Puerto;
                client.Host = _Host;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(Correo);

            }
            catch (Exception ex)
            {
                return false;
            }

            Correo.Dispose();
            client.Dispose();

            return true;
        }


    }
}
