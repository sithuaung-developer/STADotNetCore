using Microsoft.EntityFrameworkCore;
using STADotNetCore.RestApi;
using STADotNetCore.RestApi.Model;

namespace STADotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //connection
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; } //Table
    }
}
