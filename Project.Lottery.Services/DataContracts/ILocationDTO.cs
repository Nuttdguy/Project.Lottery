using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Services.DataContracts
{
    interface ILocationDTO
    {
        string LocationId { get; set; }
        string State { get; set; }
    }
}
