namespace Checkout.Core.Logging
{

    using global::Checkout.Domain.Models;

    public interface ILogger
    {
        /// <summary>
        /// The trace.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="eventDescription">
        /// The event description.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Trace(EventType eventType, string eventDescription, params object[] args);

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="eventDescription">
        /// The event description.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Debug(EventType eventType, string eventDescription, params object[] args);

        /// <summary>
        /// Log information.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="eventDescription">
        /// The event description.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Info(EventType eventType, string eventDescription, params object[] args);

        /// <summary>
        /// Log warning.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="eventDescription">
        /// The event description.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Warn(EventType eventType, string eventDescription, params object[] args);

        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="eventDescription">
        /// The event description.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Error(EventType eventType, string eventDescription, params object[] args);

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="eventDescription">
        /// The event description.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Fatal(EventType eventType, string eventDescription, params object[] args);

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="exceptionDetails">The exception details.</param>
        /// <param name="logLevel">The log level.</param>
        void LogMessage(string eventDescription, string exceptionDetails, LogLevel logLevel);

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="logLevel">The log level.</param>
        void LogMessage(EventType eventType, string eventDescription, LogLevel logLevel);

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventDescription">The event description.</param>
        /// <param name="exceptionDetails">The exception details.</param>
        /// <param name="logLevel">The log level.</param>
        void LogMessage(EventType eventType, string eventDescription, string exceptionDetails, LogLevel logLevel);
    }
}