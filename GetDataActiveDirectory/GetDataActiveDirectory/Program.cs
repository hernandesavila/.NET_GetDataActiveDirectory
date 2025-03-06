using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDataActiveDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Informe o nome de usuário e o nome do domínio como parâmetros.");
                return;
            }

            string userName = args[0];
            string domainName = args[1];

            Console.Clear();
            Console.WriteLine(" ============================ ");
            Console.WriteLine(" Obter Dados Active Directory ");
            Console.WriteLine(" ============================ ");
            Console.WriteLine();
            Console.WriteLine($" --> Usuário: {domainName}\\{userName}");
            Console.WriteLine();

            using (var context = new PrincipalContext(ContextType.Domain, domainName))
            {
                var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);

                if (user != null)
                {
                    DirectoryEntry entry = (DirectoryEntry)user.GetUnderlyingObject(); ;

                    Console.WriteLine("   > Nome: " + user.DisplayName);                   
                    Console.WriteLine("   > Descrição: " + user.Description);
                    Console.WriteLine("   > Cargo: " + entry.Properties["Title"]?.Value?.ToString());
                    Console.WriteLine("   > Companhia: " + entry.Properties["Company"]?.Value?.ToString());
                    Console.WriteLine("   > Divisão: " + entry.Properties["Division"]?.Value?.ToString());
                    Console.WriteLine("   > Departamento: " + entry.Properties["Department"]?.Value?.ToString());
                    Console.WriteLine("   > Endereço: " + entry.Properties["StreetAddress"]?.Value?.ToString() + " - " + entry.Properties["l"]?.Value?.ToString() + " - " + entry.Properties["st"]?.Value?.ToString() + " - " + entry.Properties["co"]?.Value?.ToString());
                    Console.WriteLine("   > E-mail: " + user.EmailAddress);
                    Console.WriteLine("   > Telefone: " + user.VoiceTelephoneNumber);
                    Console.WriteLine("   > Ativo: " + (user.Enabled.HasValue && user.Enabled.Value ? "S" : "N"));
                    Console.WriteLine("   > Bloqueado: " + (user.IsAccountLockedOut() ? "S" : "N"));                    
                    Console.WriteLine("   > Senha Expirada: " + (user.LastPasswordSet.Value < DateTime.Parse(entry.InvokeGet("PasswordExpirationDate").ToString()) ? "N" : "S"));
                    Console.WriteLine("   > Data Expiração Senha: " + DateTime.Parse(entry.InvokeGet("PasswordExpirationDate").ToString()).ToString("dd/MM/yyyy hh:m:ss"));
                    Console.WriteLine("   > Data Última Troca Senha: " + user.LastPasswordSet.Value.ToString("dd/MM/yyyy hh:mm:ss"));
                    Console.WriteLine("   > Data Último Logon: " + user.LastLogon?.ToString("dd/MM/yyyy hh:mm:ss"));                                       
                }
                else
                {
                    Console.WriteLine(" --> Usuário não encontrado no Active Directory.");
                }
            }

            Console.ReadLine();
        }
    }
}
