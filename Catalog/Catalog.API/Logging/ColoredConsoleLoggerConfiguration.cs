using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Logging
{
    public class ColoredConsoleLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; }
        public int EventId { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }

    public class ColoredConsoleLogger : ILogger
    {
        private ColoredConsoleLoggerConfiguration configuration;
        private string name;

        public ColoredConsoleLogger(string name, ColoredConsoleLoggerConfiguration configuration )
        {
            this.configuration = configuration;
            this.name = name;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == configuration.LogLevel;
        }

        private object obj = new object();
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (obj)
            {
                if (configuration.EventId == 0 || configuration.EventId == eventId.Id)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = configuration.Color;

                    Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {name} - {formatter(state,exception)}");
                    Console.ForegroundColor = color;
                }
            }
        }
    }

    public class ColoredConsoleLoggerProvider : ILoggerProvider
    {
        private ColoredConsoleLoggerConfiguration configuration;

        private ConcurrentDictionary<string, ColoredConsoleLogger> loggers = new ConcurrentDictionary<string, ColoredConsoleLogger> ();

        public ColoredConsoleLoggerProvider(ColoredConsoleLoggerConfiguration configuration)
        {
            this.configuration = configuration;
        }

       
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new ColoredConsoleLogger(name, configuration));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
