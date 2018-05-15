using System;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using MongoDB.Driver.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DJYou.Common.Extensions;
using DJYou.Common.Exceptions;

//// Build connection string
//SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//builder.DataSource = @"localhost\SQLEXPRESS01";   // update me
//builder.UserID = "dj_you";              // update me
//builder.Password = "Wu8AjjCrzLU6U3s4krp3UGKM";      // update me
//builder.InitialCatalog = "master";

namespace DJYou.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly DJYouContext _djYouContext;

        public EventRepository(DJYouContext djYouContext)
        {
            _djYouContext = djYouContext;
        }

        public Event CreateEvent(string code)
        {
            if (_djYouContext.Events.AsQueryable().WhereActiveEventHasCode(code).Any())
                throw new EventCodeActiveException(code);

            Event newEvent = new Event { Id = Guid.NewGuid(), Code = code, StartTime = DateTime.Now };

            var result = _djYouContext.Events.Add(newEvent);
            _djYouContext.SaveChanges();
            
            return newEvent;
        }

        public Event GetEvent(string code)
        {
            var now = DateTime.Now;

            return _djYouContext.Events
                .AsQueryable()
                .WhereActiveEventHasCode(code)
                .SingleOrDefault();
        }

    }
}
