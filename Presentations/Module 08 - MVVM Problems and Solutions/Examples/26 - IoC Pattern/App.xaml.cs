using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace Wincubate.MvvmSolutions.Slide26
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      static App()
      {
         DispatcherHelper.Initialize();
      }
   }
}
