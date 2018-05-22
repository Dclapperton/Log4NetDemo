using log4net.Appender;
using log4net.Core;
using System.IO;
using System.Threading.Tasks;

namespace Log4NetDemo.Appenders
{
    public class AsyncFileAppender : AppenderSkeleton
    {
        private StreamWriter writer;
        private TextWriter wrapper;

        public AsyncFileAppender()
        {
            writer = new StreamWriter("C:\\async-log.txt");
            wrapper = TextWriter.Synchronized(writer);
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            Task.Run(() => wrapper.WriteLine(loggingEvent.RenderedMessage));
        }

        protected override void OnClose()
        {
            wrapper.Dispose();
            writer.Dispose();
            base.OnClose();
        }
    }
}
