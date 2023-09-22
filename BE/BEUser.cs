using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUser
    {
        State _state { get; set; }

       public BEUser()
        {
            _state = new Basico();
        }
        public BEUser(int id,string name,int points, string beneficio,string stateName)
        {
            _state = new Basico();
            Id = id;
            Name= name;
            Points= points;
            _state.validarEstado(this);
            _state.beneficio = beneficio;
            _state.Name = stateName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string conocerBeneficios()
        {
            return "Este es un usuario del tipo " + _state.Name + " y tiene los siguientes beneficios en nuestra tienda: " + _state.beneficio;
        }
        public int getStateId()
        {
            return _state.Id;
        }
        public BEUser sumarPuntos(int puntos)
        {
            this.Points = this.Points + puntos;
            _state.validarEstado(this);
            return this;
        }
        public BEUser restarPuntos(int puntos)
        {
            this.Points = this.Points - puntos;
            _state.validarEstado(this);
            return this;
        }
        public void setState(State estado)
        {
            _state = estado;
        }
    }
}
