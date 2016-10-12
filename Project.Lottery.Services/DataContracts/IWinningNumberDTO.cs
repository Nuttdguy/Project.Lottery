using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Services.DataContracts
{
    interface IWinningNumberDTO
    {
        string WinningNumberId { get; set; }
        string BallNumber { get; set; }
    }
}
