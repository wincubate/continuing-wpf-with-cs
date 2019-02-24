using System.Collections.Generic;

namespace UpdatingCastMembers
{
    class All
    {
        private readonly IList<CastMember> _all;
        private int _currentIndex = 0;

        public All()
        {
            _all = new List<CastMember>
            {
                new CastMember
                {
                    ActorName = "Bruce Campbell",
                    Character = "Ash Williams",
                    Image = "Images/Ash.jpg"
                },
                new CastMember
                {
                    ActorName = "Ray Santiago",
                    Character = "Pablo Simon Bolivar",
                    Image = "Images/Pablo.jpg"
                },
                new CastMember
                {
                    ActorName = "Dana DeLorenzo",
                    Character = "Kelly Maxwell",
                    Image = "Images/Kelly.jpg"
                },
                new CastMember
                {
                    ActorName = "Lucy Lawless",
                    Character = "Ruby Knowby",
                    Image = "Images/Ruby.jpg"
                }
            };
        }

        public CastMember First() => _all[0];

        public CastMember Next()
        {
            _currentIndex = (_currentIndex + 1) % _all.Count;
            return _all[_currentIndex];
        }
    }
}
