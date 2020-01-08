using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorbenExample.ViewModels
{
    class ElementsViewModel : List<ElementViewModel>
    {
        public ElementsViewModel()
        {
            // Construct these from models objects from XML in real life :-)

            this.Add(new ComboBoxInfoViewModel
            {
                Name = "Element #1",
                Choices = new List<string> { "Pest", "Kolera" }
            });
            this.Add(new TextBoxInfoViewModel
            {
                Name = "Element #2",
                Value = "Here is something to edit..."
            });
            this.Add(new ListBoxInfoViewModel
            {
                Name = "Element #3",
                Items = new List<string> { "Beuvais", "Heinz", "AH Ketchup" }
            });
            this.Add(new TextBoxInfoViewModel
            {
                Name = "Element #4",
                Value = "Here is something to edit..."
            });
        }
    }
}
