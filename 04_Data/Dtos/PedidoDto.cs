using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class PedidoDto
    {

        //Constructor que recibe un Objeto entity
        public PedidoDto(Pedido entity)
        {
            if (entity == null) return;
            CustomerID = entity.CustomerID;
            EmployeeID = entity.EmployeeID;
            OrderDate = entity.OrderDate;
            shipperID = entity.shipperID;
            Cliente = entity.Cliente;
            DetallePedido = entity.DetallePedido;
            Empleado = entity.Empleado;
            Naviera = entity.Naviera; 

        }
        public PedidoDto()
        {
        }
        //Atributos Dto, se llaman ifual que los de la Entity
        public int OrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> shipperID { get; set; }

        public virtual Cliente Cliente { get; set; } 
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Naviera Naviera { get; set; }

    }
}
