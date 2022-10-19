using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class ProductoDto
    {
        //Constructor que recibe un Objeto entity
        public ProductoDto(Producto entity)
        {
            if (entity == null) return;
            ProductID = entity.ProductID;
            ProductName = entity.ProductName;
            supplierID = entity.supplierID;
            CategoryID = entity.CategoryID;
            unit = entity.unit;
            Price = entity.Price;
            Categoria = entity.Categoria;
            DetallePedido = entity.DetallePedido;
            Proveedor = entity.Proveedor;

        }
        public ProductoDto()
        {
        }
        //Atributos Dto, se llaman ifual que los de la Entity
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> supplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual Categoria Categoria { get; set; } 
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        public virtual Proveedor Proveedor { get; set; }

    }
}
