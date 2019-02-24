using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroelsBechQuotes.Pcl.Services
{
   /// <summary>
   /// Provides an abstraction for platform-specific user messaging capabilities.
   /// </summary>
   public interface IDialogService
   {
     Task<DialogResult> ShowAsync(string message, string title);
     Task<DialogResult> ShowAsync(string message, string title, DialogButtons buttons);
   }
}
