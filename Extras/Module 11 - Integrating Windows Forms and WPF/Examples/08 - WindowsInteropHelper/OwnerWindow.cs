using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wincubate.Module11.Slide08
{
    class OwnerWindow : System.Windows.Forms.IWin32Window
    {
        public IntPtr Handle { get; set; }
    }
}
