using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Lottery.Models.Interfaces;

namespace Project.Lottery.Models
{
    //==|| EXPERIMENT > UTILIZE INTERFACES INSTEAD OF CLASSES == ALSO POSSIBLE, UTILIZE ABSTRACT CLASSES ||==\\
    public class LotteryDetail : ILocation, IInstruction, IGameOdd, ICost, ILotteryDrawing, IWinningNumber, IBallType
    {

        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public bool HasSpecialBall { get; set; }
        public bool HasRegularBall { get; set; }
        public int NumberOfBalls { get; set; }

        public int LocationId { get; set; }
        public string State { get; set; }

        public int InstructionId { get; set; }
        public string Description { get; set; }

        public int GameOddId { get; set; }
        public string Match { get; set; }
        public string CanWinAmount { get; set; }
        public string Odds { get; set; }

        public int CostId { get; set; }
        public string CostDescription { get; set; }
        public string CostToPlay { get; set; }

        public int LotteryDrawingId { get; set; }
        public string Jackpot { get; set; }
        public DateTime DrawDate { get; set; }

        public int WinningNumberId { get; set; }
        public int BallNumber { get; set; }

        public int BallTypeId { get; set; }
        public string BallTypeDescription { get; set; }

    }
}
