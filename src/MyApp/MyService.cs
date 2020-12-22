using System;

namespace MyApp {
    class MyService {
        private readonly MySettings _settings;

        public MyService(MySettings settings) {
            _settings = settings;
        }

        public void Start() {
            Console.WriteLine("Service start ...");
            Console.WriteLine(_settings.ConnectionString);
        }

    }
}
