using System.Collections.Generic;

namespace Users.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, строитель 
    /// </summary>
    /// <typeparam name="TRecipient">Обьект приемник</typeparam>
    /// <typeparam name="TSource">Обьект источник</typeparam>
    public interface IMapBuilder<TRecipient, TSource>
    {
        TRecipient GetMapOne(TSource source);

        List<TRecipient> GetMapList(List<TSource> source);
    }
}