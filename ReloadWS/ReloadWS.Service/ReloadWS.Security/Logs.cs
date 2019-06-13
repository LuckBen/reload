using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Security
{
    public static class Logs
    {
        public static void grabar(Exception ex)
        {

            try
            {
                string dir = System.IO.Directory.GetCurrentDirectory() + "\\logs\\";
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }

                int cantidad = System.IO.Directory.GetFiles(dir).Length + 1;

                System.IO.File.WriteAllText(dir + "log_" + cantidad + ".txt", DateTime.Now + Environment.NewLine + ex.Message + Environment.NewLine + ex.ToString());

            }
            catch (Exception) { }
        }       
    }
}
