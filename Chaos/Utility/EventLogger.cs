using System;

namespace Chaos.Utility
{
    public static class EventLogger
    {
        private static readonly Logger logger;

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