using Autofac;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Extensions.Autofac.DependencyInjection;

namespace Core.Aspects.Autofac.Logging
{
    public static class LoggerExtension
    {
        public static void RegisterLogger(ContainerBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .CreateLogger();

            var loggingLevelSwitch = new LoggingLevelSwitch(); 

            builder.RegisterInstance(logger); 
            builder.RegisterInstance(loggingLevelSwitch); 
        }
    }
}
