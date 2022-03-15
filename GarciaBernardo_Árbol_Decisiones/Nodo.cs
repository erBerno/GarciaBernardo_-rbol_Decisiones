using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaBernardo_Árbol_Decisiones
{
    class Nodo
    {
        public string pregunta;
        public int peso;
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(string p, int num)
        {
            pregunta = p;
            peso = num;
            izquierdo = null;
            derecho = null;
        }
    }
}
