using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhaticBot.Lib
{
    public class Theme : ITheme
    {
        private Dictionary<string, List<string>> _dictionary;

        public Theme()
        {
            _dictionary = new Dictionary<string, List<string>>();
        }

        public Theme(Dictionary<string, List<string>> dictionary)
        {
            _dictionary = dictionary;
        }
        
        public void AddKey(string key, List<string> answers)
        {
            List<string> val;
            if (_dictionary.TryGetValue(key,out val))
            {
                answers.AddRange(val);
            }
            _dictionary.Add(key,answers);
        }

        public bool TryProcessPhrase(string phrase, out string res)
        {
            Random random = new Random();
            foreach (KeyValuePair<string,List<string>> keyValuePair in _dictionary)
            {
                MatchCollection matches = Regex.Matches( phrase,keyValuePair.Key);
                if (matches.Count > 0)
                {
                    string answer = keyValuePair.Value[random.Next(keyValuePair.Value.Count-1)];
                    string[] parameters = matches.AsEnumerable()
                        .Select(i => i.Groups.Values)
                        .Aggregate(new List<string>(), (acc, x) =>
                        {
                            foreach (var group in x)
                            {
                                acc.Add(group.Value);
                            }

                            return acc;
                        }).ToArray();
                    res = String.Format(answer, parameters);
                    return true;
                }
            }

            res = "";
            return false;
        }
    }
}