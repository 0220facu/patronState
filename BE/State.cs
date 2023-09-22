using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string beneficio { get; set; }
        public abstract void validarEstado(BEUser user);
        public abstract string verBeneficios() ;
    }
}
