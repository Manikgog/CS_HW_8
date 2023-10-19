using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    internal class Judge
    {
        public event FinishDelegate FinishEvent;
        public void Finish(string task)
        {
            if (FinishEvent != null)
            {
                FinishEvent(task);
            }
        }
    }
}
