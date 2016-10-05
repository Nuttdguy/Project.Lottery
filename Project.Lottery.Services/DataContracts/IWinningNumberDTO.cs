using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Services.DataContracts
{
    interface IWinningNumberDTO
    {
        int WinningNumberId { get; set; }
        int BallNumber { get; set; }
    }
}
