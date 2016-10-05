using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Services.DataContracts
{
    interface ILotteryDrawingDTO
    {
        int LotteryDrawingId { get; set; }
        string Jackpot { get; set; }
        DateTime DrawDate { get; set; }
    }
}
