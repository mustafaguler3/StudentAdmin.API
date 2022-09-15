using System;

namespace StudentAdmin.API.DomainModels
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //Navigation Property
        public Guid StudentId { get; set; }
    }
}
