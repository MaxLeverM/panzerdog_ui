using _Project.Code.Runtime.Utils;
using UnityEngine;

namespace _Project.Code.Runtime.Views
{
    [AddressableView("ShopView")]
    public class ShopView : BaseView
    {
        [SerializeField] private RectTransform _showcaseContent;
        [SerializeField] private MoneyWidget _moneyWidget;
        [SerializeField] private GameObject _shopItemPrefab;
    }
}