using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Wincubate.IntroducingMvvmExamples.Data
{
   public class ParticipantComparer : IComparer
   {
      public int Compare( object x, object y )
      {
         Participant px = x as Participant;
         Participant py = y as Participant;

         if( px != null && py != null )
         {
            return string.Compare(
               px.FavoriteModules[ 0 ].Title,
               py.FavoriteModules[ 0 ].Title );
         }

         throw new ArgumentException( "Can only compare Participant objects" );
      }
   }
}
