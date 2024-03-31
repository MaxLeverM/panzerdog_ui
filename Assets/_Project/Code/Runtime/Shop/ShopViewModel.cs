using System;
using _Project.Code.Runtime.Economy;
using _Project.Code.Runtime.Economy.RewardProcessor;
using _Project.Code.Runtime.MessageBox;
using _Project.Code.Runtime.MessageBox.Enums;
using _Project.Code.Runtime.Shop.Models;
using _Project.Code.Runtime.Shop.Models.Items;
using _Project.Code.Runtime.Utils;
using _Project.Code.Runtime.ViewContracts;
using Cysharp.Threading.Tasks;
using UniRx;

namespace _Project.Code.Runtime.Shop
{
    public class ShopViewModel : IViewModel, IDisposable
    {
        private readonly FinanceModel _financeModel;
        private readonly ShopModel _shopModel;
        private readonly RewardProcessor _rewardProcessor;
        private readonly MessageBoxManager _messageBoxManager;
        private readonly CompositeDisposable _disposable = new();
        private BaseItem _itemToBuy;

        public ReactiveProperty<int> MoneyProperty { get; }
        public ReactiveCollection<BaseItem> ShopItems { get; }
        public ReactiveProperty<bool> IsBuyBlocked { get; }

        public ShopViewModel(FinanceModel financeModel, ShopModel shopModel, RewardProcessor rewardProcessor, MessageBoxManager messageBoxManager)
        {
            _financeModel = financeModel;
            _shopModel = shopModel;
            _rewardProcessor = rewardProcessor;
            _messageBoxManager = messageBoxManager;
            if (financeModel.GameResources.TryGetValue(GameResourceId.SoftCurrency, out var moneyData))
            {
                MoneyProperty = new ReactiveProperty<int>(moneyData.Amount.Value);
                moneyData.Amount.Subscribe(x => MoneyProperty.Value = x).AddTo(_disposable);
            }
            
            ShopItems = shopModel._shopItems;
            IsBuyBlocked = new ReactiveProperty<bool>(false);
        }
        
        public void TryBuyItem(BaseItem item)
        {
            if(IsBuyBlocked.Value)
                return;
            
            _itemToBuy = item;
            if (item.Price.ResourceData.Amount.Value == 0)
            {
                _rewardProcessor.Process(item.Rewards);
                _shopModel._shopItems.Remove(item);
                return;
            }

            if (_financeModel.IsEnough(GameResourceId.SoftCurrency, item.Price.ResourceData.Amount.Value))
            {
                _messageBoxManager.Show(BuyMessageBoxResult, TextConst.BuyDescription, TextConst.BuyCaption, MessageBoxButtons.YesNo).Forget();
                IsBuyBlocked.Value = true;
            }
            else
            {
                _messageBoxManager.Show(BuyMessageBoxResult, TextConst.NoMoneyDescription, TextConst.NoMoneyCaption, MessageBoxButtons.Ok).Forget();
                IsBuyBlocked.Value = true;
            }
        }

        private void BuyMessageBoxResult(MessageBoxResult result)
        {
            if (result == MessageBoxResult.Yes)
            {
                _financeModel.Change(_itemToBuy.Price.ResourceId, -_itemToBuy.Price.ResourceData.Amount.Value);
                _rewardProcessor.Process(_itemToBuy.Rewards);
                _shopModel._shopItems.Remove(_itemToBuy);
            }

            IsBuyBlocked.Value = false;
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}