using System.IO;
using Module2_Task5.Models;
using Module2_Task5.Services.Contracts;
using Newtonsoft.Json;

namespace Module2_Task5.Services
{
    public class ConfigService : IConfigService
    {
        public Config Read(string path)
        {
            var configFile = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<Config>(configFile);

            return config;
        }
    }
}
