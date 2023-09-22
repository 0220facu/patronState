using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public  class Avanzado : State
    {
        public Avanzado()
        {
            this.Id = 2;
        }
        public override void validarEstado(BEUser user)
        {
            if (user.Points < 500 )
            {
                user.setState(new Basico());
            }
            if (user.Points > 1000)
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
