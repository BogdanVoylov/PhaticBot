using System;
using System.Collections.Generic;

namespace PhaticBot.Lib
{
    public class PhaticBot : IBot
    {
        private readonly List<ITheme> _themes;
        private ITheme _reserve;

        public static PhaticBot Build(Action<IBotBuilder<PhaticBot>> action)
        {
            IBotBuilder<PhaticBot> builder = new Builder();
            action.Invoke(builder);
            return builder.Build();
        }
        private PhaticBot()
        {
            _themes = new List<ITheme>();
        }
        
        public string ProcessPhrase(string phrase)
        {
            string res = "";
            foreach (ITheme theme in _themes)
            {
                if (theme.TryProcessPhrase(phrase, out  res))
                {
                    return res;
                }
            }
            _reserve.TryProcessPhrase(phrase, out res);
            return res;
        }

        private class Builder : IBotBuilder<PhaticBot>
        {
            private PhaticBot _phaticBot;

            public Builder()
            {
                _phaticBot = new PhaticBot();
            }


            public void AddThemes(List<ITheme> themes)
            {
                _phaticBot._themes.AddRange(themes);
            }

            public void SetReserve(ITheme reserve)
            {
                _phaticBot._reserve = reserve;
            }

            public PhaticBot Build()
            {
                return _phaticBot;
            }
        }
    }

    
}