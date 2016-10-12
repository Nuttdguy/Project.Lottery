using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Services.DataContracts
{
    interface ICostDTO
    {
        string CostId { get; set; }
        string CostDescription { get; set; }
        string CostToPlay { get; set; }
    }
}
