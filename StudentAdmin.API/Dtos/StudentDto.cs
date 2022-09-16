using System;

namespace StudentAdmin.API.DomainModels
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }


        //Navigation Property
        public GenderDto Gender { get; set; }
        public AddressDto Address { get; set; }
    }
}
