using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Host
{
    public class Program
    {

		public static void Main(string[] args)
		{
			System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(ReloadWS.Service.ReloadService));
			host.Open();
			Console.Read();
			host.Close();
		}

		
    }
}
