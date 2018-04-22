/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Wincubate.MvvmSolutions.Slide26.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Wincubate.MvvmSolutions.Slide26.Model;

namespace Wincubate.MvvmSolutions.Slide26.ViewModel
{
   /// <summary>
   /// This class contains static references to all the view models in the
   /// application and provides an entry point for the bindings.
   /// <para>
   /// See http://www.galasoft.ch/mvvm
   /// </para>
   /// </summary>
   public class ViewModelLocator
   {
      static ViewModelLocator()
      {
         ServiceLocator.SetLocatorProvider( () => SimpleIoc.Default );

         if ( ViewModelBase.IsInDesignModeStatic )
         {
            SimpleIoc.Default.Register<IParticipantService, Design.DesignParticipantService>();
         }
         else
         {
            SimpleIoc.Default.Register<IParticipantService, ParticipantService>();
         }

         SimpleIoc.Default.Register<MainViewModel>();
         SimpleIoc.Default.Register<ParticipantsViewModel>();
         SimpleIoc.Default.Register<ParticipantDetailViewModel>();
      }

      /// <summary>
      /// Gets the Main property.
      /// </summary>
      [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes." )]
      public MainViewModel Main
      {
         get
         {
            return ServiceLocator.Current.GetInstance<MainViewModel>();
         }
      }

      /// <summary>
      /// Gets the Participants property.
      /// </summary>
      [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes." )]
      public ParticipantsViewModel Participants
      {
         get
         {
            return ServiceLocator.Current.GetInstance<ParticipantsViewModel>();
         }
      }

      /// <summary>
      /// Gets the ParticipantDetail property.
      /// </summary>
      [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes." )]
      public ParticipantDetailViewModel ParticipantDetail
      {
         get
         {
            return ServiceLocator.Current.GetInstance<ParticipantDetailViewModel>();
         }
      }

      /// <summary>
      /// Cleans up all the resources.
      /// </summary>
      public static void Cleanup()
      {
      }
   }
}