using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;

namespace CACDemoNetCore3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
             => WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
             .ConfigureKestrel(options =>
             {
                 //var cert = new X509Certificate2(Path.Combine("root_ca_dev_damienbod.pfx"), "1234");
                 options.ConfigureHttpsDefaults(o =>
                 {
                     //o.ServerCertificate = cert;
                     o.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
                 });
             })
             .Build();
    }
}
