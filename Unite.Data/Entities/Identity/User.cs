using System.Collections.Generic;

namespace Unite.Data.Entities.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserSession> UserSessions { get; set; }
    }
}
