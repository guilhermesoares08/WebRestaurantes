using System;
using System.Collections.Generic;
using WebRestaurantes.Domain;
using System.ComponentModel.DataAnnotations;

namespace WebRestaurantes.WebAPI.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage="O Campo {0} é Obrigatório")]
        public string Description { get; set; }
        [Required (ErrorMessage="O Campo {0} é Obrigatório")]
        public string Email { get; set; }        
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string VendorId { get; set; }        
        public string EnvironmentId { get; set; }        
        public List<ImageDto> Images { get; set; }
        public List<RestaurantAddressDto> Address { get; set; }
        public List<RestaurantExtensionDto> Extensions { get; set; }
        public List<TableDto> Tables { get; set; }
    }
}