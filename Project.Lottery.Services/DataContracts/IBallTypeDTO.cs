using System.Runtime.Serialization;


namespace Project.Lottery.Services.DataContracts
{

    public interface IBallTypeDTO
    {
        int BallTypeId { get; set; }
        string BallTypeDescription { get; set; }
    }
}
