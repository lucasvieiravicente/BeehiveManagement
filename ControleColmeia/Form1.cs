using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleColmeia
{
    public partial class Form1 : Form
    {
        Worker[] workers;
        Queen queen;

        public Form1()
        {
            InitializeComponent();

            workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Nectar collector","Honey manufacturing"});
            workers[1] = new Worker(new string[] { "Egg care", "Baby bee tutoring" });
            workers[2] = new Worker(new string[] { "Hive maintenance", "Honey manufacturing" });
            workers[3] = new Worker(new string[] { "Nectar colector", "Honey manufacturing", "Egg care", "Baby bee tutoring", "Hive maintenance", "Sting patrol" });
            queen = new Queen(workers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botão para atribur o trabalho.
            if (queen.AssignWork(workerBeeJob.Text, (int)numberOfShiftsUpDown.Value))
                MessageBox.Show("The job '" + workerBeeJob.Text + "' will be done in " + numberOfShiftsUpDown.Value + " shifts", "The Queen says...", MessageBoxButtons.OK);
            else
                MessageBox.Show("All the workers can't do this job right now...", "The Queen says...", MessageBoxButtons.OK);
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
