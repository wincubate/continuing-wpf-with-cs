using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Wincubate.MvvmPatternsExamples.Slide07.Models;

namespace Wincubate.MvvmPatternsExamples.Slide07.ViewModels
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
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register volatile dependencies
            SimpleIoc.Default.Register<IParticipantService, InMemoryParticipantService>();
            SimpleIoc.Default.Unregister<IMessenger>();
            SimpleIoc.Default.Register<IMessenger>( () => Messenger.Default);

            SimpleIoc.Default.Register<AllParticipantsViewModel>();
            SimpleIoc.Default.Register<ParticipantDetailViewModel>();
        }

        public AllParticipantsViewModel AllParticipants => 
            ServiceLocator.Current.GetInstance<AllParticipantsViewModel>();

        public ParticipantDetailViewModel ParticipantDetail =>
            ServiceLocator.Current.GetInstance<ParticipantDetailViewModel>();

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}