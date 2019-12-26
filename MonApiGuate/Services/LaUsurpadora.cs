using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace MonApiGuate.Services
{
    public class LaUsurpadora
    {
        public object Entra()
        {
            object[] ArchivosServidor = { };
            object[] guatemala = { };
            //var credentials = new UserCredentials("WORKGROUP", "GEAINT", "G3jRm5f1");
            //var credentials = new UserCredentials("WORKGROUP", "RODRIGO", "CAPUFE");
            var credentials = new UserCredentials("WORKGROUP", "DESARROLLO_MIKE", "CAPUFE");
            //Impersonation.RunAsUser(credentials, LogonType.Interactive, () =>
            Impersonation.RunAsUser(credentials, LogonType.NewCredentials, () => //cambiar de interactive a NewCredentials, arregla error con credenciales
            {//10.1.10.111
                //var files = Directory.GetFiles(@"\\192.168.1.175\geaint\PARAM\ACTUEL\");\\192.168.0.91\Users\Desarrollo_Mike\LSTABINTPruebas
                var files = Directory.GetFiles(@"\\192.168.0.91\Users\Desarrollo_Mike\LSTABINTPruebas");
                // do whatever you want as this user.
                foreach (var item in files)
                {
                    if (item.Contains("LSTABINT"))
                    {
                        FileInfo file = new FileInfo(item);
                        //int tamaño = Int32.Parse((file.Length * 0.00097656).ToString());
                        var tamaño = ((file.Length * 0.001) * 0.001).ToString() + "Mb";

                        var extension = file.Name.Substring(file.Name.Length - 3, 3);

                        long lines = File.ReadAllLines(file.FullName).LongLength - 1;

                        //extension = Path.GetExtension(extension);

                        var diferencia = (DateTime.Now - file.CreationTime).TotalHours;

                        var statusDesfase = diferencia <= 1 ? false : true;

                        guatemala = new object[]
                        {
                            ArchivosServidor = new object[] {
                            file.Name,
                            file.CreationTime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            tamaño,
                            statusDesfase,
                            lines,
                            extension
                            }
                        };
                        
                    }
                }
            });
            return guatemala;
        }
    }
}
