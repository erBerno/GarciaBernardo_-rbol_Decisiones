using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaBernardo_Árbol_Decisiones
{
    class Arbol
    {
        Nodo raiz;
        List<Nodo> lista = new List<Nodo>();

        public Arbol() { raiz = null; }
        public Nodo getRaiz() { return raiz; }

        public void Insertar(string dato, int peso)
        {
            Nodo rz = getRaiz();
            insertarEn(rz, dato, peso);
        }
        public void insertarEn(Nodo rz, string dato, int num) 
        {
            if (rz == null)
                raiz = new Nodo(dato, num);
            else if (num < rz.peso)
            {
                if (rz.izquierdo != null) { insertarEn(rz.izquierdo, dato, num); }
                else { rz.izquierdo = new Nodo(dato, num); }
            }
            else if (num > rz.peso) 
            {
                if (rz.derecho != null) { insertarEn(rz.derecho, dato, num); }
                else { rz.derecho = new Nodo(dato, num); }
            }
        }
        public List<Nodo> Mostrar()
        {
            Nodo rz = getRaiz();
            lista.Clear();
            enOrden(rz); 
            return lista;
        }
        public void enOrden(Nodo rz)
        {
            if (rz != null)
            {
                enOrden(rz.izquierdo);
                lista.Add(rz);
                enOrden(rz.derecho);
            }
        }
        public void buscarPregunta(Nodo rz, Del del)
        {
            bool respuesta;

            if (rz != null)
            {
                if (rz.izquierdo == null && rz.derecho == null)
                {
                    del(rz.peso, rz.pregunta, true);
                }
                else
                {
                    respuesta = del(rz.peso, rz.pregunta, false);

                    if (respuesta)
                    {
                        buscarPregunta(rz.izquierdo, del);
                    }
                    else
                    {
                        buscarPregunta(rz.derecho, del);
                    }

                }
            }           
        }
        public void Cuestionario(Del delegado)
        {
            Nodo rz = getRaiz();
            buscarPregunta(rz, delegado);
        }
    }
}
