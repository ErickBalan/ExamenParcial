using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenParcial
{
    public partial class Form1 : Form
    {
        List<Ciudadanos> ciudadano = new List<Ciudadanos>();
        List<PartidosPoliticos> partidos = new List<PartidosPoliticos>();
        List<Datos> dato = new List<Datos>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerCiudadanos();

            leerPartidosPoliticos();

        }

        private void leerCiudadanos()
        {
            FileStream stream = new FileStream("Ciudadanos.txt", FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Ciudadanos ciudadanos = new Ciudadanos();
                ciudadanos.Dpi = reader.ReadLine();
                ciudadanos.Nombre = reader.ReadLine();
                ciudadanos.Dirección = reader.ReadLine();
                ciudadano.Add(ciudadanos);

            }
            reader.Close();
        }




        private void leerPartidosPoliticos()
        {
            FileStream stream = new FileStream("PartidosPoliticos.txt", FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                PartidosPoliticos partidosPoliticos = new PartidosPoliticos();
                partidosPoliticos.NombrePartido = reader.ReadLine();
                partidosPoliticos.Dpi = reader.ReadLine();
                partidosPoliticos.Fecha = reader.ReadLine();
                partidos.Add(partidosPoliticos);

            }
            reader.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ciudadano.Count; i++)
            {
                for (int j = 0; j < partidos.Count; j++)
                {
                    if (ciudadano[i].Dpi == partidos[j].Dpi)
                    {
                        Datos datos = new Datos();
                        datos.Nombre = ciudadano[i].Nombre;
                        datos.NombrePartido = partidos[j].NombrePartido;

                        dato.Add(datos);

                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dato;
            dataGridView1.Refresh();
        
         }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
