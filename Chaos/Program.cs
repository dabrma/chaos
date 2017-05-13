using Chaos.Misc;
using Chaos.Properties;
using Chaos.Utility;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chaos
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Cursor.Current = CreateCursorFromStream.CreateCursor(Resources.Normal);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         //   Application.Run(new FormStart());
            Application.Run(new Form1());
        }
    }
}