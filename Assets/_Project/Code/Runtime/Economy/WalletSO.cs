using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace _Project.Code.Runtime.Economy
{
    [CreateAssetMenu(menuName = "Project/Wallet", fileName = "Wallet")]
    public class WalletSO : SerializedScriptableObject
    {
        [OdinSerialize] private FinanceModel _financeModel;

        public FinanceModel GetModelData()
        {
            return (FinanceModel)_financeModel.Clone();
        }
    }
}