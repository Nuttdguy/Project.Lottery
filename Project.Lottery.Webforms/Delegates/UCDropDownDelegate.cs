using System;
using System.Collections.Generic;



namespace Project.Lottery.Webforms.Delegates
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
