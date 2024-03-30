using System;
using _Project.Code.Runtime.Models;
using _Project.Code.Runtime.Models.RewardProcessor;
using UniRx;
using UnityEngine;

namespace _Project.Code.Runtime.ViewModel
{
    public class ShopViewModel : IViewModel, IDisposable
    {
        private readonly FinanceModel _financeModel;
        private readonly ShopModel _shopModel;
        private readonly RewardProcessor _rewardProcessor;
        private readonly CompositeDisposable _disposable = new();

        public ReactiveProperty<int> MoneyProperty { get; }
        public ReactiveCollection<BaseItem> ShopItems { get; }

        public ShopViewModel(FinanceModel financeModel, ShopModel shopModel, RewardProcessor rewardProcessor)
        {
            _financeModel = financeModel;
            _shopModel = shopModel;
            _rewardProcessor = rewardProcessor;
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
            if (item.Price.ResourceData.Amount.Value == 0)
            {
                _rewardProcessor.Process(item.Rewards);
                _shopModel._shopItems.Remove(item);
                return;
            }

            if (_financeModel.IsEnough(GameResourceId.SoftCurrency, item.Price.ResourceData.Amount.Value))
            {
                Debug.Log($"Show MessageBox for confirm");
                _financeModel.Change(item.Price.ResourceId, -item.Price.ResourceData.Amount.Value);
                _rewardProcessor.Process(item.Rewards);
                _shopModel._shopItems.Remove(item);
            }
            else
            {
                Debug.Log($"Show no money MessageBox");
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}