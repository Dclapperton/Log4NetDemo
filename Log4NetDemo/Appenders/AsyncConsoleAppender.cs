using log4net.Appender;
using log4net.Core;
using System.IO;
using System.Threading.Tasks;

namespace Log4NetDemo.Appenders
{
    public class AsyncConsoleAppender : AppenderSkeleton
    {
        private StreamWriter writer;
        private TextWriter wrapper;

        public AsyncConsoleAppender()
        {
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            Task.Run(() => ConsoleAppender.ConsoleOut);
        }

        protected override void OnClose()
        {
            wrapper.Dispose();
            writer.Dispose();
            base.OnClose();
        }
    }
}
