using SQLite.Net.Attributes;
using System;

namespace Lisa.Quartets.Mobile
{
    public class RequestCardStats
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double TimeBeforeTap { get; set; }
        public int CardIndex { get; set; }
        public int DelaySetting { get; set; }
    }
}