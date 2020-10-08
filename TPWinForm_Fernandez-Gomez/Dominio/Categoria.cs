using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Categoria
    {
        public int ID { get; set; }
        public String Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
