using System;
using System.Runtime.Serialization;



namespace Project.Lottery.Services.DataContracts
{
    [DataContract]
    public class LotteryDetailDTO : ILocationDTO, ILotteryDrawingDTO, IWinningNumberDTO, IBallTypeDTO
    {
        [DataMember]
        public string LotteryId { get; set; }

        [DataMember]
        public string LotteryName { get; set; }

        [DataMember]
        public bool HasSpecialBall { get; set; }

        [DataMember]
        public bool HasRegularBall { get; set; }

        [DataMember]
        public string NumberOfBalls { get; set; }

        #region INTERFACE 1 ||=======  ILocationDTO
        [DataMember]
        public string LocationId { get; set; }

        [DataMember]
        public string State { get; set; }
        #endregion

        #region INTERFACE 2 ||=======  ILotteryDrawingDTO
        [DataMember]
        public string LotteryDrawingId { get; set; }

        [DataMember]
        public string Jackpot { get; set; }

        [DataMember]
        public string DrawDates { get; set; }
        #endregion

        #region INTERFACE 3 ||=======  IWinningNumberDTO
        [DataMember]
        public string WinningNumberId { get; set; }

        [DataMember]
        public string BallNumber { get; set; }
        #endregion

        #region INTERFACE 4 ||=======  IBallTypeDTO
        [DataMember]
        public string BallTypeId { get; set; }

        [DataMember]
        public string BallTypeDescription { get; set; }

        #endregion 

    }
}