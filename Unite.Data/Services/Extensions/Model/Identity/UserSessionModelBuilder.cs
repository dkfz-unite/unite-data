using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Identity;

namespace Unite.Data.Services.Extensions.Model.Identity
{
    public static class UserSessionModelBuilder
    {
        public static void BuildUserSessionModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSession>(entity =>
            {
                entity.ToTable("UserSessions");

                entity.HasKey(userSession => new { userSession.UserId, userSession.Session });

                entity.Property(userSession => userSession.UserId)
                      .IsRequired();

                entity.Property(userSession => userSession.Session)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(userSession => userSession.Token)
                      .IsRequired()
                      .HasMaxLength(100);


                entity.HasOne(userSession => userSession.User)
                      .WithMany(user => user.UserSessions)
                      .HasForeignKey(userSession => userSession.UserId)
                      .IsRequired();


                entity.HasIndex(userSession => userSession.Session);
            });
        }
    }
}
