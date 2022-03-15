using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GarciaBernardo_Árbol_Decisiones
{
    /// <summary>
    /// Diseñar un árbol de decisiones que contenga preguntas sobre un tema elegido.
    /// Elaborar un programa que almacene estas preguntas en un árbol binario de búsqueda (2 puntos) 
    /// y luego las muestre a un usuario que irá respondiendo a ellas (2 puntos). Finalmente el programa debe mostrar 
    /// una conclusión de acuerdo a las respuesta recibidas (1 puntos).
    /// </summary>
    
    public delegate bool Del(int peso, string cadena, bool conclusion);

    public partial class MainWindow : Window
    {
        Arbol a = new Arbol();
        Del delegadoParaMostrar;

        public MainWindow()
        {
            InitializeComponent();
            delegadoParaMostrar += VisualizarPregunta;
            CargarPreguntas();
            Visualizar();
        }

        void CargarPreguntas()
        {
            a.Insertar("Tiene Autos?", 500);
            a.Insertar("Tiene más de uno?", 400);
            a.Insertar("Entonces no necestita más.", 350);
            a.Insertar("Piense en uno más.", 450);
            a.Insertar("Quisiera comprar uno?", 600);
            a.Insertar("Le recomiendo uno grande.", 550);
            a.Insertar("Deberia comprar uno.", 650);
        }

        void Visualizar()
        {
            List<Nodo> listaResultante = a.Mostrar();
            lstShow.Items.Clear();
            foreach (Nodo nodo in listaResultante)
            {
                lstShow.Items.Add("Pregunta: " + nodo.pregunta + " - Peso: " + nodo.peso);
            }
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            a.Cuestionario(delegadoParaMostrar);
        }

        public bool VisualizarPregunta(int peso, string cadena, bool conclusion)
        {
            int respuesta;

            if (conclusion)
            {
                MessageBox.Show(cadena.ToUpper());
                return false;
            }
            else
            {
                respuesta = int.Parse(Microsoft.VisualBasic.Interaction.InputBox(cadena, "Escriba 0 para NO y 1 para SI"));

                if (respuesta == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
