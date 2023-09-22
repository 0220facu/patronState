using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
     public class Basico : State
    {
        public Basico()
        {
            this.Id = 1;
        }
        public override void validarEstado(BEUser user)
        {
            if(user.Points > 500 && user.Points < 1000)
            {
                user.setState(new Avanzado());
            }
            if(user.Points > 1000)
            {
                user.setState(new Premium());
            }
        }

        public override string verBeneficios()
        {
        return this.beneficio;
        }
    }
}
