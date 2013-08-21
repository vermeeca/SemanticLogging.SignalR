using System;
using System.Diagnostics.Tracing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;

namespace SemanticLogging.SignalR
{
    public static class SignalRLog
    {
        /// <summary>
        /// Subscribes to an <see cref="T:System.IObservable`1"/> using a <see cref="T:Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks.ConsoleSink"/>.
        /// 
        /// </summary>
        /// <param name="eventStream">The event stream. Typically this is an instance of <see cref="T:Microsoft.Practices.EnterpriseLibrary.SemanticLogging.ObservableEventListener"/>.</param><param name="formatter">The formatter.</param><param name="colorMapper">The color mapper instance.</param>
        /// <returns>
        /// A subscription to the sink that can be disposed to unsubscribe the sink, or to get access to the sink instance.
        /// </returns>
        public static SinkSubscription<SignalRSink> LogToSignalR(this IObservable<EventEntry> eventStream, IEventTextFormatter formatter = null)
        {
            var sink = new SignalRSink();
            formatter = formatter ?? new JsonEventTextFormatter();

            return new SinkSubscription<SignalRSink>(EventEntryExtensions.SubscribeWithFormatter(eventStream, formatter, sink), sink);
        }

        /// <summary>
        /// Creates an event listener that logs using a <see cref="T:Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks.ConsoleSink"/>.
        /// 
        /// </summary>
        /// <param name="formatter">The formatter.</param><param name="colorMapper">The color mapper instance.</param>
        /// <returns>
        /// An event listener that uses <see cref="T:Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks.ConsoleSink"/> to display events.
        /// </returns>
        public static EventListener CreateListener(IEventTextFormatter formatter = null)
        {
            ObservableEventListener observableEventListener = new ObservableEventListener();
            LogToSignalR((IObservable<EventEntry>)observableEventListener, formatter);
            return (EventListener)observableEventListener;
        }
    }
}