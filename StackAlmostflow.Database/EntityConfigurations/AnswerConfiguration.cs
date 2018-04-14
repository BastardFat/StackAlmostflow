using StackAlmostflow.Entity.Models;
using System.Data.Entity.ModelConfiguration;

namespace StackAlmostflow.Database.EntityConfigurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            ToTable("answers");
            HasKey(x => x.Id);

            Property(x => x.Text).IsRequired();

            HasRequired(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId)
                .WillCascadeOnDelete(false);

        }
    }
}
