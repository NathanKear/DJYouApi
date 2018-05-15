using DJYou.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DJYou.Common.Extensions
{
    public static class IQueryableEvent
    {
        public static IQueryable<Event> WhereActiveEventHasCode(this IQueryable<Event> events, string code)
        {
            DateTime now = DateTime.Now;

            return events
                .Where(x => x.Code == code)
                .Where(x => x.StartTime < now && (x.EndTime > now || x.EndTime == default(DateTime)));
        }
    }
}
