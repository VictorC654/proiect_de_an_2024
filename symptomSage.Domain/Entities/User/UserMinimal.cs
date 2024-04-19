using System;

namespace symptomSage.Domain.Entities.User
{
    public class UserMinimal
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> LastLogin { get; set; }
        public string LasIp { get; set; }
    }
}