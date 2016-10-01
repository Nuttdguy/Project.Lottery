using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Interfaces
{
    interface IInstruction
    {
        int InstructionId { get; set; }
        string Description { get; set; }
    }
}
