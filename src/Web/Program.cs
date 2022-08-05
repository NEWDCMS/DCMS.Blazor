using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DCMS.Web.Extensions;
using System.Diagnostics;
//using Microsoft.Extensions.Logging;
//using Serilog.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;


namespace DCMS.Web
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                //var builder = WebAssemblyHostBuilder.CreateDefault(args);
                //builder.RootComponents.Add<App>("#app");


                var builder = WebAssemblyHostBuilder
                                          .CreateDefault(args)
                                          .AddRootComponents()
                                          .AddClientServices();


                //���� Serilog level ���ƶ���,Ĭ��Ϊ Info level
                var logLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug); 

                //����һ��ȫ�ֵ� Logger
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.BrowserConsole()
                    .MinimumLevel.ControlledBy(logLevelSwitch)
                    .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                    .CreateLogger();

                await builder.Build().RunAsync();
            }
            catch (Exception ex)
            {
                Serilog.Log.Debug(ex.Message);
                Debug.Print(ex.Message);
            }
        }

    }
}

