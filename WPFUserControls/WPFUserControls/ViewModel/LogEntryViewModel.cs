using System;

namespace WPFUserControls.ViewModel
{
    public class LogEntryViewModel
    {
        public string ResourceName { get; set; }

        public DateTime Date { get; set; }

        public int ThreadId { get; set; }

        public LogLevels Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }
    }
}
