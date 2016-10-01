using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Interfaces
{
    interface IBallType
    {
        int BallTypeId { get; set; }
        string BallTypeDescription { get; set; }
    }
}
