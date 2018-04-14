using StackAlmostflow.Entity.Models;
using System.Data.Entity.ModelConfiguration;

namespace StackAlmostflow.Database.EntityConfigurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("questions");
            HasKey(x => x.Id);

            Property(x => x.Body).IsRequired();
            Property(x => x.Title).IsRequired();

            HasRequired(a => a.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
