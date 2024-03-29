using System;
using _Project.Code.Runtime.Models;
using UniRx;
using UnityEngine;

namespace _Project.Code.Runtime.ViewModel
{
    public class ShopViewModel : IViewModel, IDisposable
    {
        private readonly FinanceModel _financeModel;
        private readonly ShopModel _shopModel;
        private readonly CompositeDisposable _disposable = new();

        public ReactiveProperty<int> MoneyProperty { get; }
        public ReactiveCollection<BaseItem> ShopItems { get; }

        public ShopViewModel(FinanceModel financeModel, ShopModel shopModel)
        {
            _financeModel = financeModel;
            _shopModel = shopModel;
            if (financeModel.GameResources.TryGetValue(GameResourceId.SoftCurrency, out var moneyData))
            {
                MoneyProperty = new ReactiveProperty<int>(moneyData.Amount.Value);
                moneyData.Amount.Subscribe(x => MoneyProperty.Value = x).AddTo(_disposable);
            }
            
            ShopItems = shopModel._shopItems;
        }

        //TODO Добавить логику покупки
        //TODO Добавить MessageBox логику
        public void TryBuyItem(BaseItem item)
        {
            Debug.Log($"Buy pressed {item.Price}");
            _shopModel._shopItems.Remove(item);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}