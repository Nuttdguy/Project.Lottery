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
        public LotteryDetail Lottery { get; set; } = new LotteryDetail();
        public string Description { get; set; }


    }
}
