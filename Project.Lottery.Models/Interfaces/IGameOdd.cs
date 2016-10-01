using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Interfaces
{
    interface IGameOdd
    {
        int GameOddId { get; set; }
        string Match { get; set; }
        string CanWinAmount { get; set; }
        string Odds { get; set; }

    }
}
