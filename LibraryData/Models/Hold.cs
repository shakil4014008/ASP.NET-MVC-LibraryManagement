using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public virtual LibraryAsset libraryAsset { get; set; }
        public virtual LibraryCard libraryCard { get; set; }
        public DateTime HoldPlaced { get; set; }


    }
}
