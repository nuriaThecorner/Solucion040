﻿using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class CategoriaDto
    {
        //Constructor que recibe un Objeto entity
        public CategoriaDto(Categoria entity)
        {
            if (entity == null) return;
            CategoryID = entity.CategoryID;
            CategoryName = entity.CategoryName;
            Description = entity.Description; 

        }
        public CategoriaDto()
        {
        }
        //Atributos Dto, se llaman ifual que los de la Entity
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }


    }


}

