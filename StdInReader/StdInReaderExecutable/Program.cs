using System;
using Autofac;
using InputReader;

namespace StdInReaderExecutable
{
    class Program
    {
        private static IContainer _container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileManager>().As<IFileManager>();
            builder.RegisterType<StdInReader>().As<IStdInReader>();
            _container = builder.Build();

            Run();
        }

        private static void Run()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var fileManager = scope.Resolve<IFileManager>();
                StdInReader stdInReader = new StdInReader(fileManager);
                Environment.SetEnvironmentVariable("INPUT_FILE", "C:\\test.txt");
                var arr = stdInReader.GetInputJaggedArray("");
                Array.ForEach(arr, a => Array.ForEach(a, b => Console.WriteLine(b)));
                Console.ReadLine();
            }
        }
    }
}
