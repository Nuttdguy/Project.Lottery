using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Interfaces
{
    interface ILocation
    {

        int LocationId { get; set; }
        string State { get; set; }

    }
}
