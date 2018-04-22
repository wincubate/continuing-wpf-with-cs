using GalaSoft.MvvmLight;
using Wincubate.MvvmSolutions.Slide27.Model;

namespace Wincubate.MvvmSolutions.Slide27.ViewModel
{
   /// <summary>
   /// This class contains properties that the main View can data bind to.
   /// <para>
   /// See http://www.galasoft.ch/mvvm
   /// </para>
   /// </summary>
   public class MainViewModel : ViewModelBase
   {
      /// <summary>
      /// Initializes a new instance of the MainViewModel class.
      /// </summary>
      public MainViewModel( IParticipantService dataService )
      {
      }

      ////public override void Cleanup()
      ////{
      ////    // Clean up if needed

      ////    base.Cleanup();
      ////}
   }
}