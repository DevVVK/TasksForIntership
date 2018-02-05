using System;
using System.Collections.Generic;

namespace Emulator.ViewModels.Helpers
{
    /// <summary>
    /// Статический класс объединяющий методы генерации числовых последовательностей
    /// </summary>
    public static class RowGenerator
    {
        /// <summary>
        /// Получает список чисел в указанном интервале с определенным шагом
        /// </summary>
        /// <param name="recipient">приемник данных</param>
        /// <param name="begin">начало интервала</param>
        /// <param name="end">конец интервала</param>
        /// <param name="step">шаг</param>
        /// <returns></returns>
        public static void Initialize(ICollection<int> recipient, int begin, int end, int step)
        {
            if (recipient == null)
                throw new ArgumentException($"{recipient} имеет значение {null}");

            recipient.Clear();

            for(var item = begin; item < end; item++)
                recipient.Add(item);
        }
    }
}