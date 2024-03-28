using System;
using UnityEngine;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class GameResourceData
    {
        [SerializeField] private int _amount;

        public int Amount
        {
            get => Amount;
            set => Amount = value;
        }

        public GameResourceData(int amount)
        {
            _amount = amount;
        }
    }
}