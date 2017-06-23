namespace Checkout.Core.Logging
{

    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Enum to identify Level of entry to be logged.
    /// </summary>
    [Serializable]
    public enum LogLevel
    {
        /// <summary>
        /// The FATAL level designates very severe error events that will presumably lead the application to abort.
        /// </summary>
        [EnumMember]
        Fatal,

        /// <summary>
        /// The ERROR level designates error events that might still allow the application to continue running.
        /// </summary>
        [EnumMember]
        Error,

        /// <summary>
        /// The WARN level designates potentially harmful situations.
        /// </summary>
        [EnumMember]
        Warn,

        /// <summary>
        /// The INFO level designates informational messages that highlight the progress of the application at coarse-grained level.
        /// </summary>
        [EnumMember]
        Info,

        /// <summary>
        /// The DEBUG Level designates fine-grained informational events that are most useful to debug an application.
        /// </summary>
        [EnumMember]
        Debug,

        /// <summary>
        /// The TRACE Level designates finer-grained informational events than the DEBUG.
        /// </summary>
        [EnumMember]
        Trace
    }
}