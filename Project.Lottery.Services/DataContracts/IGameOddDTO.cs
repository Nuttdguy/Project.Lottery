using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Services.DataContracts
{
    interface IGameOddDTO
    {
        int GameOddId { get; set; }
        string Match { get; set; }
        string CanWinAmount { get; set; }
        string Odds { get; set; }
    }
}
