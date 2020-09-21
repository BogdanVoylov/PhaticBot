using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhaticBot.Lib
{
    public interface ITheme
    {
        void AddKey(string key, List<string> answers);
        bool TryProcessPhrase(string phrase, out string result);
    }
}