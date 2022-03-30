using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class OnlineLibraryDbContext : IdentityDbContext
    {
        public OnlineLibraryDbContext(DbContextOptions<OnlineLibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<LibraryUnit> LibraryUnits { get; set; }
        public DbSet<MovementOfUnit> MovementsOfUnits { get; set; }
      //  public virtual DbSet<BookSection> BookSection { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookImage>(bi =>
            {
                bi.HasKey(x => x.ImageId);

                bi.HasOne(x => x.Book).WithMany(y => y.BookImages).HasForeignKey(x => x.BookId);
            });

            builder.Entity<LibraryUnit>(lu =>
            {
                lu.HasKey(x => x.InventoryId);

                lu.HasOne(x => x.Movement).WithMany(y => y.LibraryUnits).HasForeignKey(x => x.MovementId);
            });

            builder.Entity<MovementOfUnit>(mu =>
            {
                mu.HasKey(x => x.MovementId);
            });

            builder.Entity<BookSection>(bs =>
            {
                bs.HasKey(x => new { x.BookId, x.SectionId });

                bs.HasOne(x => x.Book).WithMany(y => y.Sections).HasForeignKey(z => z.BookId);
                bs.HasOne(x => x.Section).WithMany(y => y.Books).HasForeignKey(z => z.SectionId);

            });
            builder.Entity<BookLibraryUnit>(blu =>
            {
                blu.HasKey(x => new { x.BookId, x.InventoryId });

                blu.HasOne(x => x.Book).WithMany(y => y.Units).HasForeignKey(z => z.BookId);
                blu.HasOne(x => x.LibraryUnit).WithMany(y => y.Books).HasForeignKey(z => z.InventoryId);
            });

            builder.Entity<Section>().HasData(
                new Section { SectionId = 1, Name = "Classics", Description = "The classics have been around for decades, and were often groundbreaking stories at their publish time, but have continued to be impactful for generations, serving as the foundation for many popular works we read today." },
                new Section { SectionId = 2, Name = "Mystery", Description = "The plot always revolves around a crime of sorts that must be solved—or foiled—by the protagonists." },
                new Section { SectionId = 3, Name = "Historical Fiction", Description = "These books are based in a time period set in the past decades, often against the backdrop of significant (real) historical events." }


                );
          //  builder.SharedTypeEntity<BookSection>
        }
    }
}
