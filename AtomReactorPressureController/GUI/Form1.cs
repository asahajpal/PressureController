using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtomicReactor
{
    public partial class Form1 : Form
    {
        private IPressureController reactor;

        public Form1()
        {
            InitializeComponent();
            reactor = new PressureController();
            reactor.NotifyViews += UpdateNormalMode;
            reactor.NotifyValveAction += new NotifyValveActuation(UpdateValveActuation);
            Console.WriteLine("\nPress the \"Start Process\" button to start the application...\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* pressure build up process - increase pressure in boiler */
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            reactor.StartProcess();
            Console.WriteLine("\nPress any key to stop the application...\n");
            Console.ReadLine();
            reactor.StopProcess();
            Console.WriteLine("Terminating the application...");
        }

        void UpdateNormalMode(double p, double s)
        {
            Console.WriteLine("\nReactor Vessel Pressure : {0}", p.ToString("0.000"));
            Console.WriteLine("PressureSensor reading  : {0}", s.ToString("0.000"));
        }

        void UpdateValveActuation()
        {
            Console.WriteLine("\nReactor Vessel Pressure crossed Optimum Pressure limit !!");
            Console.WriteLine("Safety Valve will be Actuated to decrease pressure !!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
