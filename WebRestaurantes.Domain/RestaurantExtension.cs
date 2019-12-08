using System;

namespace WebRestaurantes.Domain
{
    public class RestaurantExtension
    {
        public int Id { get; set; }

        public Guid? OptionId { get; set; }

        public int RestaurantId { get; set; }

        public bool IsActive { get; set; }

        public DomainValue DomainInfo { get; set; }

        public RestaurantExtension()
        {
            IsActive = true;
        }
    }
}