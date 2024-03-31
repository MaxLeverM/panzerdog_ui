using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _Project.Code.Runtime.Models;
using _Project.Code.Runtime.Models.Items;
using _Project.Code.Runtime.Utils;
using _Project.Code.Runtime.ViewModels;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _Project.Code.Runtime.Views
{
    [AddressableView("ShopView")]
    public class ShopView : BaseView
    {
        [SerializeField] private RectTransform _showcaseContent;
        [SerializeField] private MoneyWidget _moneyWidget;
        [SerializeField] private ShopItemElement _shopItemPrefab;
        [SerializeField] private GameObject _blockPanel;

        private List<ShopItemElement> _shopItemElements;
        private ShopViewModel _shopViewModel;

        protected override UniTask Init(IViewModel viewModel, CancellationToken ct)
        {
            _shopViewModel = (ShopViewModel)viewModel;
            _shopItemElements = new List<ShopItemElement>();

            _shopViewModel.MoneyProperty.Subscribe(x => _moneyWidget.SetMoneyAmount(x));
            InitShopItems(_shopViewModel.ShopItems.ToArray());

            _shopViewModel.ShopItems.ObserveRemove().Subscribe(x => RemoveViewItem(x));
            _shopViewModel.IsBuyBlocked.Subscribe(x => _blockPanel.SetActive(x));
            
            return UniTask.CompletedTask;
        }

        private void InitShopItems(BaseItem[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                var shopItemView = GameObject.Instantiate(_shopItemPrefab, _showcaseContent);
                shopItemView.Init(i+1, items[i], BuyItem);
                _shopItemElements.Add(shopItemView);
            }
        }

        private void RemoveViewItem(CollectionRemoveEvent<BaseItem> collectionRemoveEvent)
        {
            var itemForRemove = _shopItemElements.First(x => x.Item == collectionRemoveEvent.Value);
            UpdateNumbers(collectionRemoveEvent.Index, -1);
            _shopItemElements.Remove(itemForRemove);
            Destroy(itemForRemove.gameObject);
        }

        private void UpdateNumbers(int from, int delta)
        {
            for (int i = from; i < _shopItemElements.Count; i++)
            {
                _shopItemElements[i].SetNumber(i+1+delta);
            }
        }

        private void BuyItem(BaseItem item)
        {
            _shopViewModel.TryBuyItem(item);
        }
    }
}