using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Pomodori
{
    public partial class Form1 : Form
    {
        Stopwatch pomodori = new Stopwatch();
        int vezParcial = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //zerar o cronometro
            pomodori.Reset();

            //iniciar o cronometro
            pomodori.Start();

            //zerar as variaveis
            tbParcial.Text = null;
            vezParcial = 0;

            //desativar botão iniciar e ativar os de parada
            btnParar.Enabled = true;
            btnIniciar.Enabled = false;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            //para o cronômetro
            pomodori.Stop();

            //desativar botões de paradas e ativar o de início
            btnParar.Enabled = false;
            btnIniciar.Enabled = true;
        }

        private void tbParcial_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            lblTempo.Text = String.Format("{0:00}:{1:00}:{2:00}", pomodori.Elapsed.Hours, pomodori.Elapsed.Minutes, pomodori.Elapsed.Seconds, pomodori.Elapsed.Milliseconds / 10);
            //:{3:00}

            if (lblTempo.Text == String.Format("{0:00}:{0:00}:{0:15}", pomodori.Elapsed.Hours, pomodori.Elapsed.Minutes, pomodori.Elapsed.Seconds, pomodori.Elapsed.Milliseconds / 10))
            {
                tbParcial.Text = "Hora da 1ºpausa" + Environment.NewLine;
                //para o cronômetro
                pomodori.Stop();
                pomodori.Start();
            }


            else if (lblTempo.Text == string.Format("{0:00}:{0:00}:{0:30}", pomodori.Elapsed.Hours, pomodori.Elapsed.Minutes, pomodori.Elapsed.Seconds, pomodori.Elapsed.Milliseconds / 10))
            {
                pomodori.Stop();
                tbParcial.Text = "Final da pausa";
                pomodori.Reset();
                pomodori.Stop();
                pomodori.Start();
            }

            else if (lblTempo.Text == String.Format("{0:00}:{0:00}:{0:45}", pomodori.Elapsed.Hours, pomodori.Elapsed.Minutes, pomodori.Elapsed.Seconds, pomodori.Elapsed.Milliseconds / 10))
            {
                tbParcial.Text = "Hora da 2ºpausa" + Environment.NewLine;
                //para o cronômetro
                pomodori.Stop();
                pomodori.Start();
                pomodori.Reset();
                pomodori.Stop();
            }
        }
    }
}
