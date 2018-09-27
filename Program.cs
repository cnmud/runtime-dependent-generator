using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] files = Directory.GetFiles(@"E:\git\GMFE\EM2-CE2-aspnet-core\CE.Service\bin\Release\net471\win81-x64", "*.dll");
            //string[] files = Directory.GetFiles(@"R:\CE2.Service.STG", "*.dll");
            //string[] files = Directory.GetFiles(@"E:\git\GMFE\EM2-UBS\UBS.Service\bin\Debug\net471\win81-x64", "*.dll");
            //string[] files = Directory.GetFiles(@"E:\git\GMFE\EM2-UBS\UBS.UnitTest\bin\Debug", "*.dll");
            string[] files = Directory.GetFiles(@"E:\git\GMFE\EM2-CE2\CE.UnitTest\bin\Debug\net471\win81-x64", "*.dll");
            //string[] files = Directory.GetFiles(@"E:\git\GMFE\EM2-CE2\CE.Service\bin\Debug\net471\win81-x64", "*.dll");

            StringBuilder sb = new StringBuilder();
            foreach( string file in files)
            {
                AssemblyName assemblyName;
                try
                {
                    assemblyName = AssemblyName.GetAssemblyName(file);
                }
                catch{ continue; }

                

                // EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089

                Match m = Regex.Match(assemblyName.FullName, @"^(?<name>[^\,]+)\,\s*Version\=(?<version>[^\,]+)\,\s*Culture\=(?<culture>[^\,]+)\,\s*PublicKeyToken\=(?<token>[^\,]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (!m.Success)
                    continue;
                string token = m.Groups["token"].Value;
                if (string.Equals(token, "null"))
                    continue;

                string name = m.Groups["name"].Value;
                string version = m.Groups["version"].Value;
                string culture = m.Groups["culture"].Value;


                sb.Append($@"
<dependentAssembly>
  <assemblyIdentity name=""{name}"" publicKeyToken=""{token}"" culture=""{culture}"" />
  <bindingRedirect oldVersion=""0.0.0.0-999.9.9.9"" newVersion=""{version}"" />
</dependentAssembly>");
            }

            string content = sb.ToString();
            System.Diagnostics.Debug.WriteLine(content);
            Console.Write(content);
        }


        static async Task AAA()
        {
            int afds = 321321;

            await Task.Delay(20000);

            await Task.Delay(30000);
        }
    }
}
