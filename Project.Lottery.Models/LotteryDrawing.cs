using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models
{
    public class LotteryDrawing
    {
        public int LotteryDrawingId { get; set; }
        public LotteryDetail Lottery { get; set; } = new LotteryDetail();
        public string Jackpot { get; set; }
        public DateTime LotteryDrawingDate { get; set; }


    }
}
