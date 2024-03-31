using System.Threading;
using _Project.Code.Runtime.ViewModels;
using _Project.Code.Runtime.Views;
using Cysharp.Threading.Tasks;

namespace _Project.Code.Runtime.ScreenManager
{
    public interface IViewManager
    {
        public UniTask ShowAsync<TView>(IViewModel viewModel, CancellationToken ct) where TView : BaseView;
        public UniTask HideAsync<TView>(CancellationToken ct) where TView : BaseView;
    }
}