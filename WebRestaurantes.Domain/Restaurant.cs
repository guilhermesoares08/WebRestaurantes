using System;
using System.Collections.Generic;


namespace WebRestaurantes.Domain
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string VendorId { get; set; }
        public string EnvironmentId { get; set; }
        public List<Image> Images { get; set; }

    }
}