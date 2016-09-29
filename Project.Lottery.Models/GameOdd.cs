using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models
{
    public class GameOdd
    {
        public int GameOddId { get; set; }
        public Lottery Lottery { get; set; }
        public string Match { get; set; }
        public string CanWinAmount { get; set; }
        public string Odds { get; set; }

        public GameOdd()
        {
            this.Lottery = new Lottery();
        }

    }
}
