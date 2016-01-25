using System;

namespace MagtifunAPI
{
    public class MagtifunContact
    {
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
    public enum Gender
    {
        Female = 0,
        Male = 1
    }
}
