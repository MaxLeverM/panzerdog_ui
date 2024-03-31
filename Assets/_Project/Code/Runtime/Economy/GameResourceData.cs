using System;
using Sirenix.Serialization;
using UniRx;

namespace _Project.Code.Runtime.Economy
{
    [Serializable]
    public class GameResourceData : ICloneable
    {
        [OdinSerialize] public ReactiveProperty<int> Amount { get; private set; }
        
        public GameResourceData(int amount)
        {
            Amount = new ReactiveProperty<int>(amount);
        }

        public object Clone()
        {
            return new GameResourceData(Amount.Value);
        }
    }
}