using AppConfigJsonLibrary;
using System;

namespace TestConsole {

    class Program {

        static void Main(string[] args) {
            var jsonpath = @"C:\repos\dotnetcore30\AppConfigLibrarySolution\TestConsole\configdata.json";
            using(var json = new AppConfigJson<Json.ConfigData>(jsonpath)) {
                System.Diagnostics.Debug.WriteLine($"The next int is {json.AppConfig.nextInt}");
                System.Diagnostics.Debug.WriteLine($"The connStr is {json.AppConfig.connStr}");
                System.Diagnostics.Debug.WriteLine($"Debuggins is {json.AppConfig.debugging}");
                json.AppConfig.nextInt = 101;
            }
        }
        static void Test() { 
            var jsonfile = @"C:\repos\dotnetcore30\AppConfigLibrarySolution\TestConsole\appConfig.json";
            using(var cfg = new AppConfigJson<App.Config>(jsonfile)) {
                cfg.AppConfig.Name = "Greg";
                cfg.AppConfig.Sql = new App.Sql();
                cfg.AppConfig.Sql.Server = @"localhost\sqlexpress";
                cfg.AppConfig.Sql.Database = "AppDb";
                cfg.AppConfig.Sql.TrustedConnection = true;
            }
        }
    }
}

namespace App {
    public class Sql {
        public string Server { get; set; } = @"server\sqlexpress";
        public string Database { get; set; } = "AppDb";
        public bool TrustedConnection { get; set; } = true;
    }
    public class Config {
        public string Name { get; set; }
        public int Counter { get; set; } = 1;
        public bool Active { get; set; } = true;
        public DateTime DOB { get; set; } = new DateTime(1957, 8, 27);
        public Sql Sql { get; set; } = new Sql();
    }
}
