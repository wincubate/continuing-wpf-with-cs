namespace Wincubate.MvvmPatternsExamples.Slide07.ViewModels.Messages
{
    public class ParticipantSelectionMessage
    {
        public int ParticipantId { get; }

        public ParticipantSelectionMessage( int participantId ) =>
            ParticipantId = participantId;
    }
}
