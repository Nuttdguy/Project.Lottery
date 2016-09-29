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
        public Lottery Lottery { get; set; }
        public string Jackpot { get; set; }
        public DateTime DrawDate { get; set; }

        public LotteryDrawing()
        {
            this.Lottery = new Lottery();
        }

    }
}
