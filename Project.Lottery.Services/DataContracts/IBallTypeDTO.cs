using System.Runtime.Serialization;


namespace Project.Lottery.Services.DataContracts
{

    interface IBallTypeDTO
    {
        int BallTypeId { get; set; }
        string BallTypeDescription { get; set; }
    }
}
