using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class NavieraDto
    {

        //Constructor que recibe un Objeto entity
        public NavieraDto(Naviera entity)
        {
            if (entity == null) return;
            shipperID = entity.shipperID;
            shipperName = entity.shipperName;
            Phone = entity.Phone;
            Pedido = entity.Pedido;

        }
        public NavieraDto()
        {
        }
        //Atributos Dto, se llaman ifual que los de la Entity
        public int shipperID { get; set; }
        public string shipperName { get; set; }
        public string Phone { get; set; }
         
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
