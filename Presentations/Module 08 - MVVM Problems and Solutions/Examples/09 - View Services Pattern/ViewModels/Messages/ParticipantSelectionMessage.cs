namespace Wincubate.MvvmPatternsExamples.Slide09.ViewModels.Messages
{
    public class ParticipantSelectionMessage
    {
        public int ParticipantId { get; }

        public ParticipantSelectionMessage( int participantId ) =>
            ParticipantId = participantId;
    }
}
