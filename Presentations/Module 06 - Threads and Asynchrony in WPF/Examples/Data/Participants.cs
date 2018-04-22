using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Wincubate.ThreadsAndAsynchronyExamples.Data
{
   public class Participants : ObservableCollection<Participant>
   {
      public Participants()
      {
         this.Add( new Participant( "Gulmann Henriksen",
                                    "Jesper",
                                    "Wincubate",
                                    new Uri( "pack://application:,,,/Wincubate.ThreadsAndAsynchronyExamples.Data;component/JGH.jpg" ) ) );
         this.Add( new Participant( "Møller Grønfeldt",
                                    "Mads",
                                    "Codeblend" ) );
         this.Add( new Participant( "Foged",
                                    "Kim",
                                    "DSE Airport Solutions A/S" ) );
         this.Add( new Participant( "Bjerner",
                                    "Rasmus",
                                    "DSE Airport Solutions A/S" ) );
         this.Add( new Participant( "Nazarian",
                                    "Armen",
                                    "DSE Airport Solutions A/S" ) );
         this.Add( new Participant( "Bresson",
                                    "Bo",
                                    "HRtools A/S" ) );
         this.Add( new Participant( "Bresson",
                                    "Lene Rikke",
                                    "HRtools A/S" ) );
      }

      public Participants( int number )
      {
         for( int i = 0 ; i < number ; i++ )
         {
            this.Add( new Participant( "Deltagersen",
                                      "Deltager" + i,
                                      "Virksomhed",
                                      new Uri( "pack://application:,,,/Wincubate.ThreadsAndAsynchronyExamples.Data;component/nophoto.gif" ) ) );
         }
      }

      public Participants CloneFirst( int number )
      {
         Participants clone = new Participants();
         clone.Clear();
         foreach( var p in this.Take( number ) )
         {
            clone.Add( p );
         }

         return clone;
      }
   }
}
