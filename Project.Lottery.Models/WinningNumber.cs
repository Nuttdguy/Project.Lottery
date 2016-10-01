using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models
{
    public class WinningNumber
    {
        public int WinningNumberId { get; set; }
        public LotteryDrawing LotteryDrawing { get; set; } = new LotteryDrawing();
        public BallType BallType { get; set; } = new BallType();
        public int BallNumber { get; set; }


    }
}
