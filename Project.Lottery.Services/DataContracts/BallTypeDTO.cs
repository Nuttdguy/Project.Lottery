using System;
using System.Runtime.Serialization;

namespace Project.Lottery.Services.DataContracts
{
    [DataContract]
    public class BallTypeDTO : IBallTypeDTO
    {
        [DataMember]
        public int BallTypeId { get; set; }

        [DataMember]
        public string BallTypeDescription { get; set; }
    }
}