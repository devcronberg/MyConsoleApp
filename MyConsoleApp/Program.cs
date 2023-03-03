using Microsoft.Extensions.Configuration;
using Serilog;

namespace MyConsoleApp
{
    internal class Program
    {

        internal static AppSettings? appSettings;
        internal static ILogger? logger;
        // If async use:
        // static async Task Main(string[] args) 
        static void Main()  // If needed add (string[] args)
        {
            try
            {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
                logger = Log.Logger;

                logger.Debug("App start");

                TestClass1 testClass1 = new TestClass1();
                testClass1.Test();
                TestClass2 testClass2 = new TestClass2(logger);
                testClass2.Test();

                // In VS - remember to clean solution when
                // you change appsettings (see Build-menu)
                logger.Debug("Getting configuration");
                appSettings = new AppSettings();
                configuration.Bind("AppSettings",appSettings);
                logger.Debug($"MyInt: {appSettings.MyInt}");
                logger.Debug($"MyString: {appSettings.MyString}");
                logger.Debug($"MyBool: {appSettings.MyBool}");
                logger.Debug($"MyDate: {appSettings.MyDate}");

            }
            catch (Exception ex)
            {
                logger?.Error(ex, "Error in main err handler: " + ex.Message);
            }
            finally
            {
                logger?.Debug("App end");
            }
        }
    }
}