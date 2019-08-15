using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleColmeia
{
    class Queen
    {
        private Worker[] workers;
        private int shiftNumbers = 0;        

        public Queen(Worker[] workers)
        {
            this.workers = workers;
        }

        public bool AssignWork(string job, int shift)
        {
            for(int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, shift))
                    return true;
            }
            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumbers++;
            string report = "Report for shift #" + shiftNumbers;
#pragma warning disable CS0162 // Código inacessível detectado
            for (int i = 0; i < workers.Length; i++)
#pragma warning restore CS0162 // Código inacessível detectado
            {
                if (workers[i].WorkOneShift())
                    report += "\r\nWorker #" + (i + 1) + " finished the job." + "\r\nWorker #" + (i + 1) + " is not working!";                    
                else if(String.IsNullOrEmpty(workers[i].CurrentJob))
                    report +=  "\r\nWorker #" + (i + 1) + " is not working!";
                else
                    report += "\r\nWorker #" + (i + 1) + " is doing '" + workers[i].CurrentJob + "' for " + workers[i].ShiftsLeft + " more shifts.";
            }            
            return report;
        }
    }
}
