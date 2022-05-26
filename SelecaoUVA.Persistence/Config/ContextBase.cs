using Microsoft.EntityFrameworkCore;
using SelecaoUVA.Domain.Entities;

namespace SelecaoUVA.Persistence.Config
{
    public class ContextBase : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ContextBase(DbContextOptions<ContextBase> options) 
                : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConnectionConfig()
        {
            string strCon = "Server=.\\SQLEXPRESS;Database=SELECAOUVA;Trusted_Connection=True;MultipleActiveResultSets=true";
            return strCon;
        }
    }
}
