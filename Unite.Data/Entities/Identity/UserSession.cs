using System;

namespace Unite.Data.Entities.Identity
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Client { get; set; }
        public string Session { get; set; }
        public string Token { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }
}
