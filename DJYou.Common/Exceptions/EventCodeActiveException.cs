using System;
using System.Collections.Generic;
using System.Text;

namespace DJYou.Common.Exceptions
{
    [Serializable]
    public class EventCodeActiveException : Exception
    {
        public EventCodeActiveException(string code) : base($"The event code ${code} is already in use at ${DateTime.Now}") { }
    }
}
