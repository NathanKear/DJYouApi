using System;
using System.Collections.Generic;
using System.Text;

namespace DJYou.Data
{
    public interface IEventRepository
    {
        Event CreateEvent(string code);
        Event GetEvent(string code);
    }
}
