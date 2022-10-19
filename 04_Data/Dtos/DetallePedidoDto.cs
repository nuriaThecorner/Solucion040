using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class DetallePedidoDto
    {

        //Constructor que recibe un Objeto entity
        public DetallePedidoDto(DetallePedido entity)
        {
            if (entity == null) return;
            OrderDetailID = entity.OrderDetailID;
            OrderID = entity.OrderID;
            ProductID = entity.ProductID;
            Quantity = entity.Quantity;
            Pedido = entity.Pedido;
            Producto = entity.Producto;

        }
        public DetallePedidoDto()
        {
        }
        //Atributos Dto, se llaman ifual que los de la Entity
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }

    }
}
