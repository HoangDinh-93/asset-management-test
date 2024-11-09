using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AssetManagement.Core.Utilities
{
    public class JsonFileUtility
    {
        public static string ReadJsonFile(string path)
        {
            if (!Directory.Exists(path))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), path);

                if (!File.Exists(path))
                {
                    throw new Exception("Can't find file " + path);
                }
            }

            return File.ReadAllText(path);
        }

        public static T ReadAndParse<T>(string path)
            where T : class
        {
            var jsonContent = ReadJsonFile(path);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
