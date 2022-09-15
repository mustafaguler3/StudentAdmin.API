using System;

namespace StudentAdmin.API.Data
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //Navigation Property
        public Guid StudentId { get; set; }
    }
}
