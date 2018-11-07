using System.IO;
using JetBrains.Annotations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace sandbox {
    /// <summary>
    ///     https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments
    ///     <remarks>XML <c>reference</c> for documentation.</remarks>
    /// </summary>
    public class Program {
        /// <summary>
        ///     I can use the &lt;c&gt; <c>to show off</c> colors! This is the start point as you can see at the <see cref="Main"/> method.
        ///
        ///     Some links with great info!
        ///     <list type="number">
        ///         <item>
        ///             <description>https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.1
        ///                          Docs for IHostBuilder configurators. Logging, Service lifetime.</description>
        ///         </item>
        ///         <item>
        ///             <description>To learn this, and to get STARS at GitHub, thanks!</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
            CreateGenericHostBuilder(args).Build();
        }

        /// <summary>
        ///     A bullet list to show how to use it.
        ///     Type can be <c>bullet</c>, <c>number</c>, or <c>table</c>, which has another xml elements in it.
        ///
        ///     <list type="bullet">
        ///         <item><term>Does</term><description>Showing off which XML docs can be used.</description></item>
        ///         <item><term>Why</term><description>To learn this, and to get STARS at GitHub, thanks!</description></item>
        ///     </list>
        /// </summary>
        ///
        /// <param name="args"></param>
        /// <returns></returns>
        [PublicAPI]
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        /// <summary>
        /// Creates a generic host builder with:
        ///
        /// Appsettings.json, 
        /// environment variables (prefixed with "PREFIX_"), 
        /// command line attributes added, 
        /// logging to console and debug.
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.1
        ///     Docs for IHostBuilder configurators. Logging, Service lifetime
        ///
        ///     https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1
        ///     Servers to optionally add and configure
        ///
        ///     https://github.com/aspnet/Hosting/tree/release/2.1/samples
        ///     Implementation of code in examples above
        /// </remarks>
        /// <param name="args"></param>
        /// <returns ></returns>
        [PublicAPI]
        public static IHostBuilder CreateGenericHostBuilder(string[] args) => new HostBuilder()
            .ConfigureAppConfiguration(host => {
                host.SetBasePath(Directory.GetCurrentDirectory());
                host.AddJsonFile("appsettings.json", true);
                host.AddEnvironmentVariables("PREFIX_");
                host.AddCommandLine(args);
            })
            .ConfigureLogging((hostContext, configLogging) => {
                //configLogging.ClearProviders();
                configLogging.AddConsole();
                configLogging.AddDebug();
            });
    }
}