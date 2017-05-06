using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Utility
{
    public static class EventLogger
    {
        private static Logger logger;

        static EventLogger()
        {
            logger = new Logger();
            logger.Show();
        }



        public static void WriteLog(string message, bool autoClean = false)
        {
            if (autoClean)
            {
                logger.logField.Text = string.Format("{0}" + Environment.NewLine, message);
            }
            else
            {
                logger.logField.Text += string.Format("{0}" + Environment.NewLine, message);
                logger.Update();
            }

        }

        public static void ShowLog()
        {
            logger.Show();
        }


    }
}
