using _Project.Code.Runtime.Models;
using _Project.Code.Runtime.Models.RewardProcessor;
using _Project.Code.Runtime.ViewModel;
using _Project.Code.Runtime.Views;
using UnityEngine;

namespace _Project.Code.Runtime
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private RectTransform _parentLayer;
        [SerializeField] private ShowcaseSO _showcaseSo;
        [SerializeField] private WalletSO _walletSo;
        
        private ViewManager _viewManager;
        private ShopViewModel _shopViewModel;
        private FinanceModel _financeModel;
        private ShopModel _shopModel;
        private RewardProcessor _rewardProcessor;
        private MessageBoxManager _messageBoxManager;

        //TODO рефакторинг, распределить по папкам, поправить неймспейсы
        //TODO ещё раз всё проверить
        private async void Start()
        {
            _financeModel = _walletSo.GetModelData();
            _shopModel = _showcaseSo.GetModelData(); 
            _viewManager = new ViewManager(_parentLayer);
            _messageBoxManager = new MessageBoxManager(_viewManager);

            _rewardProcessor = new RewardProcessor();
            var gameResourceProcessor = new GameResourceRewardProcessor(_financeModel);
            _rewardProcessor.RegisterProcessor(gameResourceProcessor);

            _shopViewModel = new ShopViewModel(_financeModel, _shopModel, _rewardProcessor, _messageBoxManager);

            await _viewManager.ShowAsync<ShopView>(_shopViewModel);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _financeModel.Change(GameResourceId.SoftCurrency, 500);
            }
        }

        private void OnDestroy()
        {
            _shopViewModel.Dispose();
        }
    }
}