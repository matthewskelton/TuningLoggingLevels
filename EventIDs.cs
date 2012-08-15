using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuning_Logging_Levels
{
    /// <summary>
    /// Categories of events suitable for the Event Log
    /// </summary>
    public enum EventCategory
    {
        NotSet = 0,
        Generic = 1,
        PageGeneration = 2,
        MessageQueueing = 3,
        // ...
        Reserved = 1000
    }

    /// <summary>
    /// The set of possible, known events in the system, including unknown
    /// </summary>
    public enum EventID
    {
        // Badly-initialised logging data
        NotSet = 0,

        // An unrecognised event has occurred
        UnexpectedError = 1000,

        #region Generic Events [1000 -> 1999]

        ApplicationStarted = 1001,
        ApplicationShutdownNoticeReceived = 1002,
        
        #endregion

        #region Page Generation Events [2000 -> 2999]

        PageGenerationStarted = 2000,
        PageGenerationCompleted = 2001,
        PageGenerationHTMLFragmentCacheHit = 2002,
        PageGenerationHTMLFragmentCacheMiss = 2003,

        #endregion

        #region Message Queueing Events	[3000 -> 3999]

        MessageQueued = 3000,
        MessagePeeked = 3001,

        MessagePopped = 3002,
        MessageMissing = 3003,
        MessageCopied = 3004,

        #endregion
        
        // ...

    }

    /// <summary>
    /// Helps to resolve Event Categories based on Event Type
    /// </summary>
    public class EventCategoryHelper
    {
        /// <summary>
        /// Returns the event category for the given event type
        /// </summary>
        /// <param name="eventType">The EventType whose Category is needed</param>
        /// <returns>The category for the given event type</returns>
        public static EventCategory ResolveEventCategory(EventID eventType)
        {
            EventCategory result = EventCategory.NotSet;
            int eventTypeInt = (int)eventType;
            if (eventTypeInt < 1000)
            {
                result = EventCategory.NotSet;
            }
            else if (eventTypeInt < 2000)
            {
                result = EventCategory.Generic;
            }
            else if (eventTypeInt < 3000)
            {
                result = EventCategory.PageGeneration;
            }
            else if (eventTypeInt < 4000)
            {
                result = EventCategory.MessageQueueing;
            }
            // ...
            else
            {
                result = EventCategory.Reserved;
            }

            return result;
        }
    }

}