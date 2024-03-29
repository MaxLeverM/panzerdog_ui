using _Project.Code.Runtime.Models;
using _Project.Code.Runtime.ViewModel;
using _Project.Code.Runtime.Views;
using Cysharp.Threading.Tasks;
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

        private async void Start()
        {
            _financeModel = _walletSo.GetModelData();
            _shopModel = _showcaseSo.GetModelData(); 
            _viewManager = new ViewManager(_parentLayer);

            _shopViewModel = new ShopViewModel(_financeModel, _shopModel);

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
            _viewManager.HideAsync<ShopView>().Forget();
            _shopViewModel.Dispose();
        }
    }
}