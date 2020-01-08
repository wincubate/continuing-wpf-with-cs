using System.Collections.Generic;

namespace TorbenExample.ViewModels
{
    class ComboBoxInfoViewModel : ElementViewModel
    {
        public IEnumerable<string> Choices { get; set; }
    }
}
