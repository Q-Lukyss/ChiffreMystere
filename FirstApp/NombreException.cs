using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    public class NombreException : Exception
    {
        public override string Message => "Le nombre doit être entre 0 et 9.";
    }

}