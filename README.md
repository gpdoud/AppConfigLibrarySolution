# AppConfigJson class

The AppConfigJson class provides persistence of data as a JSON file. It can be used for storing and retrieving application configuration data or any data that must persist, but is not stored in a database. It is a generic class so it is adaptable to any configuration data that can be stored as JSON data.

The class uses the new System.Text.Json class released with .Net Core 3.0.

## Example

Start with a class that defines the data to be persisted. Because of a restriction in the System.Text.Json class, make sure all the data is defined as properties. Fields are _not_ supported in the current version of System.Text.Json.

    public class ConfigData {
        public int nextInt { get; set }
        public string connStr { get; set; }
        public bool debugging { get; set; }
    }

Create a JSON file whose contents are defined by the AppConfig class.

    {
        "nextInt": 100,
        "connStr": "server=localhost\sqlexpress;database=AppDb;trusted_connection=true;",
        "debugging": true
    }

Add the following code to a class:

    var jsonpath = @"c:\application\configdata.json";
    using(var json = new AppConfigJson<Json.ConfigData>(jsonpath)) {
        Console.WriteLine($"The next int is {json.AppConfig.nextInt}");
        Console.WriteLine($"The connStr is {json.AppConfig.connStr}");
        Console.WriteLine($"Debugging is {json.AppConfig.debugging}");
    }

## Updating the JSON data

AppConfigJson supports programmatically updating the data. If the data is updated, the `Dispose()` method must be called directly or implicitly through a `using()` construct. The data is written back to the same file where it was read.