using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AlmanyaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            optionsBuilder.UseMySql(@"Server=localhost; database=almanya; uid=esra; pwd=Esra.1513", serverVersion);
            //optionsBuilder.UseMySql(@"Server=localhost; database=almanya; uid=root; pwd=1513", serverVersion);
        }

        public DbSet<AgeRange> AgeRange { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<ApplicationForm> ApplicationForm { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<DocumentFile> DocumentFile { get; set; }
        public DbSet<GermanLanguageLevel> GermanLanguageLevel { get; set; }
        public DbSet<Graduation> Graduation { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<OtherLanguage> OtherLanguage { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<User> User { get; set; }

    }
}
