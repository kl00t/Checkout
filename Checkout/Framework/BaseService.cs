namespace Checkout.Core.Framework
{

    using System;
    using System.Diagnostics;
    using System.ServiceModel;
    using global::Checkout.Domain.Models;
    using Logging;

    /// <summary>
    /// Base WCF Service class.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Gets or sets the logger wrapper class.
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">logger</exception>
        protected BaseService(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            Logger = logger;
        }

        /// <summary>
        /// Provides basic heartbeat check to allow monitoring of service health.
        /// </summary>
        /// <returns>
        /// Current date and time.
        /// </returns>
        public DateTime Heartbeat()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Calls the engine.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="engineCall">The engine call.</param>
        /// <param name="exceptionEventType">Type of the exception event.</param>
        /// <param name="exceptionEventDescription">The exception event description.</param>
        /// <returns></returns>
        protected ServiceResponse<T> CallEngine<T>(
            Func<T> engineCall,
            EventType exceptionEventType,
            string exceptionEventDescription = null)
                {
                    return CallEngine(
                        () => new ServiceResponse<T>(engineCall()),
                        exceptionEventType,
                        exceptionEventDescription);
        }

        /// <summary>
        /// Calls the engine.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="engineCall">The engine call.</param>
        /// <param name="exceptionEventType">Type of the exception event.</param>
        /// <param name="exceptionEventDescription">The exception event description.</param>
        /// <returns></returns>
        protected ServiceResponse<T> CallEngine<T>(
            Func<ServiceResponse<T>> engineCall,
            EventType exceptionEventType,
            string exceptionEventDescription = null)
        {
            // Get call stack
            StackTrace stackTrace = new StackTrace();

            // Get calling method name
            string callingMethodName = stackTrace.GetFrame(2).GetMethod().Name;
            var declaringType = stackTrace.GetFrame(2).GetMethod().DeclaringType;

            if (declaringType != null)
            {
                string callingMethodClass = declaringType.Name;

                if (exceptionEventDescription == null)
                {
                    exceptionEventDescription = string.Format(
                        "Error in {0}.{1}()",
                        callingMethodClass,
                        callingMethodName);
                }

                Logger.LogMessage(
                    exceptionEventType,
                    string.Format("{0}.{1}() starting.", callingMethodClass, callingMethodName),
                    string.Empty,
                    LogLevel.Debug);
            }

            var sw = Stopwatch.StartNew();
            try
            {
                var response = engineCall();
                var performanceTimingMsg = string.Format(
                    "{0} completed in {1:N0}ms",
                    callingMethodName,
                    sw.ElapsedMilliseconds);
                Logger.LogMessage(EventType.PerformanceTiming, performanceTimingMsg, LogLevel.Info);
                return response;
            }
            catch (FaultException faultException)
            {
                Logger.LogMessage(
                    exceptionEventType,
                    exceptionEventDescription,
                    faultException.ToString(),
                    LogLevel.Error);
                return new ServiceResponse<T>(ServiceError.Unknown);
            }
            catch (ArgumentException argumentException)
            {
                Logger.LogMessage(exceptionEventType, exceptionEventDescription, argumentException.ToString(), LogLevel.Error);
                return new ServiceResponse<T>(ServiceError.InvalidArgument);
            }
            catch (Exception exception)
            {
                Logger.LogMessage(exceptionEventType, exceptionEventDescription, exception.ToString(), LogLevel.Error);
                return new ServiceResponse<T>(ServiceError.Unknown);
            }
        }
    }
}