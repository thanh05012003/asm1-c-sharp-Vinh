﻿namespace asm1_c_sharp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public string Status { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
