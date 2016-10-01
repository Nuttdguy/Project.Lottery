using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Interfaces
{
    interface IWinningNumber
    {

        int WinningNumberId { get; set; }
        int BallNumber { get; set; }
    }
}
