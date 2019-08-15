using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleColmeia
{
    class Worker
    {
        private string currentJob = "";
        public string CurrentJob { get { return currentJob; } }

        public int ShiftsLeft { get { return shiftsToWork - shiftsWorked; } }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public Worker(string[] jobs){ jobsICanDo = jobs; }

        public bool DoThisJob(string job, int shifts)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;

            foreach (string jobs in jobsICanDo)
            {
                if (jobs == job && String.IsNullOrEmpty(CurrentJob))
                {
                    currentJob = jobs;
                    shiftsToWork = shifts;
                    shiftsWorked = 0;
                    return true;
                }               
            }
            return false;
        }

        public bool WorkOneShift()
        {
            if (String.IsNullOrEmpty(CurrentJob))
                return false;

            shiftsWorked++;
            if (shiftsWorked >= shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            return false;
        }
    }
}
