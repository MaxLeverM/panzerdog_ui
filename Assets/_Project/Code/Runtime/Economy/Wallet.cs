using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class Wallet
    {
        [SerializeField] private List<Currency> _currencies;
    }
}