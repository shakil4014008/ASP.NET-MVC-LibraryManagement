using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public LibraryAsset libraryAsset { get; set; }
        [Required]
        public LibraryCard libraryCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

    }
}
