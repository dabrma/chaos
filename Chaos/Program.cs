using System;
using System.Windows.Forms;
using Chaos.Misc;
using Chaos.Properties;

namespace Chaos

   /* TODO: {oprogramować ilosc tur dodac endgame window, zrobić strzelanie
            i moze jak zycia i checi starczy, to dodac wsiadanie na konia xD, o i jeszcze jedna bardzo wazna rzecz jest
            jak stoisz obok potwora, to nie mozesz sie juz ruszyć.Blokada dopóki nie pokonasz,
            albo inaczej mozesz sie cofnac, ale nie mozesz przejsc na pole obok potwora.
*/

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
            Application.Run(new FormStart());
//<<<<<<< master
            // Application.Run(new Form1());
//=======
            // Application.Run(new GameForm());
//>>>>>>> master
        }
    }
}