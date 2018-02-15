using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext: DbContext
    {
        //create constructor
        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistorys { get; set; }
        public DbSet<LibraryBranch> LibraryBranchs { get; set; }
        public DbSet<BranchHours> BranchHourSS { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<LibraryAsset> LibraryAssets { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<Patron> pattrons { get; set; }



    }
}
