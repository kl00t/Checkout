namespace Checkout.Core.Logging
{

    using global::Checkout.Domain.Models;

    public class Logger : ILogger
    {
        /// <summary>
        /// The trace.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="args">The arguments.</param>
        public void Trace(EventType eventType, string eventDescription, params object[] args)
        {
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="args">The arguments.</param>
        public void Debug(EventType eventType, string eventDescription, params object[] args)
        {
        }

        public void Info(EventType eventType, string eventDescription, params object[] args)
        {
        }

        /// <summary>
        /// Log warning.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="args">The arguments.</param>
        public void Warn(EventType eventType, string eventDescription, params object[] args)
        {
        }

        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="args">The arguments.</param>
        public void Error(EventType eventType, string eventDescription, params object[] args)
        {
        }

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="args">The arguments.</param>
        public void Fatal(EventType eventType, string eventDescription, params object[] args)
        {
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="exceptionDetails">The exception details.</param>
        /// <param name="logLevel">The log level.</param>
        public void LogMessage(string eventDescription, string exceptionDetails, LogLevel logLevel)
        {
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="logLevel">The log level.</param>
        public void LogMessage(EventType eventType, string eventDescription, LogLevel logLevel)
        {
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="exceptionDetails">The exception details.</param>
        /// <param name="logLevel">The log level.</param>
        public void LogMessage(EventType eventType, string eventDescription, string exceptionDetails, LogLevel logLevel)
        {
        }
    }
}