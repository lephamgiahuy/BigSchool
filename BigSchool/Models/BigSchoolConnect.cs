namespace BigSchool.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BigSchoolConnect : DbContext
    {
        public BigSchoolConnect()
            : base("name=BigSchoolConnect")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
