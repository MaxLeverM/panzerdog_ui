using System;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Economy
{
    [Serializable]
    public class GameResource
    {
        [OdinSerialize] public GameResourceId ResourceId { get; set; }
        [OdinSerialize] public GameResourceData ResourceData { get; set; }
    }
}