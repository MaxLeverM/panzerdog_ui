using System.Globalization;
using TMPro;
using UnityEngine;

namespace _Project.Code.Runtime.Views
{
    public class MoneyWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyText;
        [SerializeField] private TMP_Text _moneyText;

        public void SetMoneyAmount(int amount)
        {
            _moneyText.text = amount.ToString("N0", CultureInfo.InvariantCulture);
        }

        public void SetCurrency(string currencySymbol)
        {
            _currencyText.text = currencySymbol;
        }
    }
}