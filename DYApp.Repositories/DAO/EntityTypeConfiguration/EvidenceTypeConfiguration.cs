using DYApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Repositories.DAO.EntityTypeConfiguration
{
   public class EvidenceTypeConfiguration:TypeConfiguration<Evidence>
    {
        public EvidenceTypeConfiguration()
        {
            HasOptional(p => p.Filing)
                .WithOptionalDependent(p => p.Evidence)
                .WillCascadeOnDelete(false);
        }
    }
}
