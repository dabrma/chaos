using System.IO;
using System.Windows.Forms;

namespace Chaos.Misc
{
    public class CreateCursorFromStream
    {
        public static Cursor CreateCursor(byte[] cursorFile)
        {
            var byteStream = new MemoryStream(cursorFile);

            return new Cursor(byteStream);
        }
    }
}