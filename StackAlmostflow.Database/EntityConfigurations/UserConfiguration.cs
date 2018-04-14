using StackAlmostflow.Entity.Models;
using System.Data.Entity.ModelConfiguration;

namespace StackAlmostflow.Database.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("users");
            HasKey(x => x.Id);

            Property(x => x.Login).IsRequired();
            Property(x => x.Password).IsRequired();
        }
    }
}
