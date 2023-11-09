using System;
using System.Collections.Generic;

namespace Patterns.EventQueueWithObserver
{
    public interface EventObserver
    {
        void Process(EventData eventData);
    }
}