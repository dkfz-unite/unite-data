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

                entity.Property(userSession => userSession.UserId)
                      .IsRequired();

                entity.Property(userSession => userSession.Session)
                      .IsRequired();

                entity.Property(userSession => userSession.Token)
                      .IsRequired();


                entity.HasOne(userSession => userSession.User)
                      .WithMany(user => user.UserSessions)
                      .HasForeignKey(userSession => userSession.UserId)
                      .IsRequired();


                entity.HasIndex(userSession => userSession.Session);
            });
        }
    }
}
