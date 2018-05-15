using System;
using System.Collections.Generic;
using System.Text;

namespace DJYou.Data
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool HasFinished()
        {
            return EndTime < DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Event [id={Id}, code={Code}, startTime={StartTime}{(EndTime == default(DateTime) ? "" : $", endTime ={EndTime}")}]";
        }
    }
}
