using System;
using SQLite;

namespace WorkApp.Models
{
    public class Worker
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Birthday.ToString("dd-MM-yyyy")}, {Id}, {Phone}, {Email}, {Address})";
        }
    }
}
