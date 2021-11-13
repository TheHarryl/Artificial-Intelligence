using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NLProcessing
{
    public static class Compiler
    {
        public static Word DataToWord(string word, JToken data)
        {
            if (data.Type == JTokenType.Object)
            {
                return new Word(word, new List<string>() { "noun" });
            }
            List<string> possiblePartsOfSpeech = new List<string>();
            foreach (JToken meaning in data[0]["meanings"])
            {
                possiblePartsOfSpeech.Add(meaning["partOfSpeech"].ToObject<string>());
            }
            return new Word(data[0]["word"].ToObject<string>(), possiblePartsOfSpeech);
        }

        public static Word FetchWord(String word)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string cachePath = Path.Combine(currentPath, "cache");
            string dictionaryPath = Path.Combine(cachePath, "dictionary.json");
            if (!Directory.Exists(cachePath))
                Directory.CreateDirectory(cachePath);

            using (StreamWriter sw = (File.Exists(dictionaryPath)) ? File.AppendText(dictionaryPath) : File.CreateText(dictionaryPath))
            {
                sw.Write("{}");
            }

            JObject dictionary;
            using (StreamReader file = File.OpenText(dictionaryPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                dictionary = (JObject)JToken.ReadFrom(reader);
            }

            if (!dictionary.ContainsKey(word.ToLower()))
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create("https://api.dictionaryapi.dev/api/v2/entries/en/" + word);

                WebProxy myProxy = new WebProxy("myproxy", 80);
                myProxy.BypassProxyOnLocal = true;

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                JToken data = JToken.Parse(objReader.ReadToEnd());

                dictionary.Add(word.ToLower(), data);

                File.WriteAllText(Path.Combine(cachePath, "dictionary.json"), dictionary.ToString());
            }

            return DataToWord(word, dictionary.GetValue(word));
        }

        public static List<Word> Run(string text)
        {
            List<Word> words = new List<Word>();

            for (int i = 0; i < text.Split(" ").Length; i++)
            {
                words.Add(FetchWord(text.Split(" ")[i]));
            }
            return words;
        }
    }
}
