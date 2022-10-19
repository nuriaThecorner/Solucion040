using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class ClienteDto
    {
        //Constructor que recibe un Objeto entity
        public ClienteDto(Cliente entity)
        {
            if (entity == null) return;
            CustomerID = entity.CustomerID;
            CustomerName = entity.CustomerName;
            ContactName = entity.ContactName;
            Address = entity.Address;
            City = entity.City;
            PostalCode = entity.PostalCode;
            Country = entity.Country;

        }
        public ClienteDto()
        {
        }
        //Atributos Dto, se llaman ifual que los de la Entity
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    
        
    }
}
