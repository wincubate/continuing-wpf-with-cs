namespace Wincubate.MvvmPatternsExamples.Slide08.ViewModels.Messages
{
    public class ParticipantSelectionMessage
    {
        public int ParticipantId { get; }

        public ParticipantSelectionMessage( int participantId ) =>
            ParticipantId = participantId;
    }
}
