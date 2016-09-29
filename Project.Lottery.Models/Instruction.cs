using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models
{
    public class Instruction
    {
        public int InstructionId { get; set; }
        public Lottery Lottery { get; set; }
        public string Description { get; set; }

        public Instruction()
        {
            this.Lottery = new Lottery();
        }

    }
}
