using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace WoF
{
    [ImplementPropertyChanged]
    public class GameQuestion
    {
        public string Question { get; set; }

        public string NormalizedQuestion { get; set; }

        public string Category { get; set; }

        public string NormalizedCategory { get; set; }

    }
}
