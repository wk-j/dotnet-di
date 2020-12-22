using System;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp {

    class MyService2 {
        private readonly MySettings _settings;
        private readonly MyService _service;
        public MyService2(MyService service, MySettings settings) {
            _settings = settings;
            _service = service;
        }

        public void Start() {
            Console.WriteLine("Service 2 start ...");
            _service.Start();
        }
    }

    class Program {
        static void Manual() {
            var settings = new MySettings {
                ConnectionString = "Host=localhost"
            };

            var service = new MyService(settings);

            var service2 = new MyService2(service, settings);
            service2.Start();
        }

        static void Di() {

        }

        static void Main(string[] args) {
            var collection = new ServiceCollection();
            var settings = new MySettings {
                ConnectionString = "Host=127.0.0.1"
            };

            collection.AddSingleton(settings);
            collection.AddSingleton<MyService>();
            collection.AddSingleton<MyService2>();

            var provider = collection.BuildServiceProvider();
            var myService2 = provider.GetService<MyService2>();
            myService2.Start();
        }
    }
}
