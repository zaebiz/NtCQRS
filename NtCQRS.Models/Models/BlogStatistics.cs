using System;

namespace NtCQRS.Models.Models
{
    /// <summary>
    /// модель данных для возврата из запроса статистики по блогам
    /// </summary>
    public class BlogStatistics
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }

        public DateTime FirstPost { get; set; }
        public DateTime LastPost { get; set; }

        public int PostCount2014 { get; set; }
        public int PostCount2015 { get; set; }
        public int PostCount2016 { get; set; }
    }
}
