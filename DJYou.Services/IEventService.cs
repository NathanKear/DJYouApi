using DJYou.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DJYou.Services
{
    public interface IEventService
    {
        Event CreateEvent();
        Event GetEvent(string code);
    }
}
