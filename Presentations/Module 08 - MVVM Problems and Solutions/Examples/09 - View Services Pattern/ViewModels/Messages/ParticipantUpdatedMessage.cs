namespace Wincubate.MvvmPatternsExamples.Slide09.ViewModels.Messages
{
    public class ParticipantUpdatedMessage
    {
        public int ParticipantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Company { get; }

        public ParticipantUpdatedMessage(
            int participantId,
            string firstName,
            string lastName,
            string company 
        )
        {
            ParticipantId = participantId;
            FirstName = firstName;
            LastName = lastName;
            Company = company;
        }
    }
}
