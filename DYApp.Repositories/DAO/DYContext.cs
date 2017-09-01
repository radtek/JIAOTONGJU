using DYApp.Domain.Model;
using DYApp.Repositories.DAO.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Repositories.DAO
{
   public  class DYContext:DbContext
    {
        //public DYContext() : base("name=DyConnection")
        //{ }
        public DYContext() : base("Server=127.0.0.1;Database=BDHEnforcement;User ID=sa;Password=aaaa1111!;")
        { }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<SceneRecord> SceneRecord { get; set; }
        public DbSet<Involved> Involved { get; set; }
        public DbSet<Filing> Filing { get; set; }
        public DbSet<AskRecord> AskRecord { get; set; }
        public DbSet<CaseHandling> CaseHandling { get; set; }
        public DbSet<WorkFlow> WorkFlow { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<EvidenceDetail> EvidenceDetail { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoTypeConfiguration())
                .Add(new RoleTypeConfiguration())
                .Add(new FunctionTypeConfiguration())
                .Add(new SceneRecordTypeConfiguration())
                .Add(new InvolvedTypeConfiguration())
                .Add(new FilingTypeConfiguration())
                .Add(new AskRecordTypeConfiguration())
                .Add(new CaseHandlingTypeConfiguration())
                .Add(new WorkFlowTypeConfiguration())
                .Add(new EvidenceTypeConfiguration())
                .Add(new EvidenceDetailTypeConfiguration());
            Database.SetInitializer(new DatabaseInitialize());
            base.OnModelCreating(modelBuilder);
        }
    }
}
