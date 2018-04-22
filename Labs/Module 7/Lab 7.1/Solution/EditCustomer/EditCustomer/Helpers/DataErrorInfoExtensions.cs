using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditCustomer
{
   public static class DataErrorInfoExtensions
   {
      public static bool HasOverallError( this IDataErrorInfo that )
      {
         PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( that );
         foreach ( PropertyDescriptor property in properties )
         {
            if ( !string.IsNullOrEmpty( that[ property.Name ] ) )
            {
               return true;
            }
         }
         return false;
      }
   }
}
