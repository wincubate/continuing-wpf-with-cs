using System;
using System.Collections.Generic;
using System.Linq;

namespace Wincubate.IntroducingMvvmExamples.Data
{
    public class Participants : List<Participant>
    {
        public Participants()
        {
            this.Add(new Participant("Gulmann Henriksen",
                                       "Jesper",
                                       "Wincubate ApS",
                                       new Uri("pack://application:,,,/Wincubate.IntroducingMvvmExamples.Data;component/JGH.jpg")));
            this.Add(new Participant("Grønfeldt",
                                       "Hans",
                                       "Codeblenderiet"));
            this.Add(new Participant("Finsen",
                                       "Kim",
                                       "Onomatopoietikon A/S"));
            this.Add(new Participant("Bastrup",
                                       "Rasmus",
                                       "Onomatopoietikon A/S"));
            this.Add(new Participant("Sanaa",
                                       "Armin",
                                       "Onomatopoietikon A/S"));
            this.Add(new Participant("Besson",
                                       "Luc",
                                       "Tools for Fools A/S"));
            this.Add(new Participant("Besson",
                                       "Beth",
                                       "Tools for Fools A/S"));
        }

        public Participants( int number )
        {
            for (int i = 0; i < number; i++)
            {
                this.Add(new Participant("Deltagersen",
                                          "Deltager" + i,
                                          "Virksomhed",
                                          new Uri("pack://application:,,,/Wincubate.IntroducingMvvmExamples.Data;component/nophoto.gif")));
            }
        }

        public Participants CloneFirst( int number )
        {
            Participants clone = new Participants();
            clone.Clear();
            foreach (var p in this.Take(number))
            {
                clone.Add(p);
            }

            return clone;
        }
    }
}
