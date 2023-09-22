using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Premium :State
    {
        public Premium()
        {
            this.Id = 3;
        }
        public override void validarEstado(BEUser user)
        {
            if (user.Points > 500 && user.Points < 1000)
            {
                user.setState(new Avanzado());
            }
            if (user.Points < 500)
            {
                user.setState(new Basico());
            }
        }

        public override string verBeneficios()
        {
            return this.beneficio;
        }
    }
}
