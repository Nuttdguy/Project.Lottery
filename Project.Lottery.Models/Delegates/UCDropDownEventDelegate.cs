using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Delegates
{
    public class UCDropDownEventDelegate
    {
        public delegate void OnSelectedChangeEvent(object sender, EventArgs e);
        public static event OnSelectedChangeEvent selectedEvent;

        public virtual void OnEventRefresh(object sender, EventArgs e)
        {
            selectedEvent?.Invoke(sender, e);
        }

    }
}
