using CBV.Core.Domain.Enum;
using System;

namespace CBV.Core.Domain.Shared
{
    public static class DataExtensions
    {
        public static DiaSemanaEnum GetWeekCurrent()
        {
            var week = ((int)DateTime.Now.DayOfWeek) + 1;
            return (DiaSemanaEnum)week;
        }

    }
}
