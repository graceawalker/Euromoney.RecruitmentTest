using System;
using Autofac;
using ContentConsole.Application;
using ContentConsole.Repositories;
using ContentConsole.Services;
using ContentConsole.Wrapper;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BadWordService>().As<IBadWordService>();
            builder.RegisterType<BadWordRepository>().As<IBadWordRepository>();
            builder.RegisterType<ApplicationOptions>().As<IDisplayApplicationOptions>();
            builder.RegisterType<CuratorApplication>().As<ICuratorApplication>();
            builder.RegisterType<ReaderApplication>().As<IReaderApplication>();
            builder.RegisterType<ConsoleWrapper>().As<IConsoleWrapper>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var bannedWordService = scope.Resolve<IDisplayApplicationOptions>();
                bannedWordService.ShowApplicationOptions();
            }
        }

    }


}
