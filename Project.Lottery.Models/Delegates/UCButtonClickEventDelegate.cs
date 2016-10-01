using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Delegates
{
    public class UCButtonClickEventDelegate
    {
        public delegate void OnClickEvent(object sender, EventArgs e, string strTextBox);
        public static event OnClickEvent OnEvent;

        public virtual void OnRefreshClickEvent(object sender, EventArgs e, string strTextBox)
        {
            OnEvent?.Invoke(sender, e, strTextBox);
        }

    }
}
