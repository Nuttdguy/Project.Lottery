using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models
{
    public class LotteryDetail
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public bool HasSpecialBall { get; set; }
        public bool HasRegularBall { get; set; }
        public int NumberOfBalls { get; set; } 

    }
}
