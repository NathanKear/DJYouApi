using DJYou.Common.Exceptions;
using DJYou.Data;
using System;

namespace DJYou.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly Random _random;

        public EventService(IEventRepository eventRepository, Random random)
        {
            _eventRepository = eventRepository;
            _random = random;
        }

        public Event CreateEvent()
        {
            Event evnt = null;
            int codeLength = 6;

            do
            {
                try
                {
                    evnt = _eventRepository.CreateEvent(GenerateEventCode(codeLength));
                } catch (EventCodeActiveException ex)
                {
                    codeLength++;
                }

            } while (evnt == null);

            return evnt;
        }

        private string GenerateEventCode(int length)
        {
            int maxCode = (int)(Math.Pow(10, length) + 0.001); // Ensure loss of precision doesn't effect result
            return _random.Next(maxCode / 10, maxCode).ToString().PadLeft(length, '0');
        }

        public Event GetEvent(string code)
        {
            return _eventRepository.GetEvent(code);
        }
    }
}
