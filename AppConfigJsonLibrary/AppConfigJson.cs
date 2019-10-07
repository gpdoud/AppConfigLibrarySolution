using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AppConfigJsonLibrary {

    public class AppConfigJson<T> : IDisposable {

        string jsonfile = default(string);
        public T AppConfig = default(T);

        private void Serialize(T AppConfig, string jsonfile) {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize<T>(AppConfig, options);
            System.IO.File.WriteAllText(jsonfile, json);
        }
        private void Deserialize(T AppConfig, string jsonfile) {
            var json = System.IO.File.ReadAllText(jsonfile);
            this.AppConfig = JsonSerializer.Deserialize<T>(json);
        }
        public AppConfigJson(string jsonfile) {
            this.jsonfile = jsonfile;
            Deserialize(this.AppConfig, jsonfile);
        }
        public void Dispose() {
            Serialize(this.AppConfig, this.jsonfile);
        }
    }
}
