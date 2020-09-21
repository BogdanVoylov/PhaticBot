using System.Collections.Generic;

namespace PhaticBot.Lib
{
    public interface IBot
    {
        string ProcessPhrase(string phrase);
    }
}