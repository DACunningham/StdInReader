using System;
using Autofac;
using StdInReader;

namespace StdInReaderExecutable
{
    class Program
    {
        private static IContainer _container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileManager>().As<IFileManager>();
            builder.RegisterType<StdInReader.StdInReader>().As<IStdInReader>();
            _container = builder.Build();

            Run();
        }

        private static void Run()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var fileManager = scope.Resolve<IFileManager>();
                StdInReader.StdInReader stdInReader = new StdInReader.StdInReader(fileManager);
                var arr = stdInReader.GetInputJaggedArray("FILE_PATH");
                Console.WriteLine(arr);
                Console.ReadLine();
            }
        }
    }
}
