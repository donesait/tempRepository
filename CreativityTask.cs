using System;
using System.Linq;

namespace Names
{
    internal static class CreativityTask
    {
        public static HistogramData ShowYourStatistics(NameData[] names, string name, int day, int month)
        {
            var maxYear = int.MinValue;
            var minYear = int.MaxValue;

            foreach (var data in names)
            {
                minYear = Math.Min(minYear, data.BirthDate.Year);
                maxYear = Math.Max(maxYear, data.BirthDate.Year);
            }

            var years = new string[maxYear - minYear + 1];
            for (int i = 0; i < years.Length; i++)
            {
                years[i] = (minYear + i).ToString();
            }

            var birthsCounts = new double[maxYear - minYear + 1];

            foreach (var data in names)
            {
                if (data.Name == name && data.BirthDate.Month == month && data.BirthDate.Day == day)
                    birthsCounts[data.BirthDate.Year - minYear]++;
            }
            
            return new HistogramData($"Рождаемость людей с именем '{name}' с {minYear} по {maxYear} годы", years, birthsCounts);
            
        }

        
        
        
    }

}