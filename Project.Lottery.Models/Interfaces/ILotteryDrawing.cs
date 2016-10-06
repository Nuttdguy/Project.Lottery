using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Interfaces
{
    interface ILotteryDrawing
    {
        int LotteryDrawingId { get; set; }
        string Jackpot { get; set; }
        DateTime LotteryDrawingDate { get; set; }
    }
}
