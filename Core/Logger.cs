using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Server.Model;

namespace Server.Core {
    public class Logger {
        private static Logger _instance;
        private static readonly object padlock = new object();

        public static Logger Instance {
            get{
                lock (padlock) {
                    if (_instance == null)
                        _instance = new Logger();
                    return _instance;
                }
            }
        }
        
        private ICollection<LogMessage> _logMessages;

        private Logger() {
            _logMessages = new List<LogMessage>();
        }

        public void AddMessage(string message) {
            _logMessages.Add(new LogMessage(DateTime.Now, message));
        }

        public string[] GetLog() {
            ICollection<string> log = new List<string>();
            foreach (var logMsg in _logMessages) {
                string message = $"{logMsg.time.ToString()} - {logMsg.message}";
                log.Add(message);
            }

            return log.ToArray();
        }
    }
}