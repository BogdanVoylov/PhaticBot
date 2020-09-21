using System.Collections.Generic;

namespace PhaticBot.Lib
{
    public interface IBotBuilder<T> where T:IBot
    {
        void AddThemes(List<ITheme> themes);
        void SetReserve(ITheme reserve);
        T Build();
    }
}