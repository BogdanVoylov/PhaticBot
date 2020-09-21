using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhaticBot.Lib;

namespace PhaticBot
{
    class Program
    {
        private static readonly string DATASET_PATH = "../../../dataset.json";
        private static readonly string RESERVE_THEME_NAME = "Reserve";
        static void Main(string[] args)
        {
            var json = "";
            try
            {
                json = File.ReadAllText(DATASET_PATH);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: bot has not found dataset.json file. Change DATASET_PATH in Program.cs .");
                return;
            }
            IBot bot = BuildBotFromJson(json);
            Console.WriteLine("Hello, you are welcome to write/n");
            while (true)
            {
                string phrase = Console.ReadLine();
                Console.WriteLine(bot.ProcessPhrase(phrase));
            }
        }

        static IBot BuildBotFromJson(string json)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<string>>>>(json);
            ITheme reserveTheme = new Theme(dictionary[RESERVE_THEME_NAME]);
            dictionary.Remove(RESERVE_THEME_NAME);
            return Lib.PhaticBot.Build(builder =>
            {
                builder.SetReserve(reserveTheme);
                List<ITheme> themes = dictionary.Select(p => (ITheme) new Theme(p.Value)).ToList();
                builder.AddThemes(themes);
            });
            
        }
    }
}