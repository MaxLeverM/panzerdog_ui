using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace _Project.Code.Runtime.Views
{
    public class MessageBoxManager
    {
        private readonly ViewManager _viewManager;
        private MessageBoxViewModel _viewModel;
        private Queue<MessageBoxViewModel> _messageQueue;

        public MessageBoxManager(ViewManager viewManager)
        {
            _viewManager = viewManager;
            _messageQueue = new Queue<MessageBoxViewModel>();
        }

        public async UniTask Show(Action<MessageBoxResult> resultAction, string text, string caption,
            MessageBoxButtons buttons = MessageBoxButtons.Ok)
        {
            await Show(new MessageBoxViewModel(resultAction, text, caption, buttons));
        }

        private async UniTask Show(MessageBoxViewModel viewModel)
        {
            if (_viewModel != null)
            {
                _messageQueue.Enqueue(viewModel);
                return;
            }
            
            viewModel.ResultAction += CloseMessageBox;
            _viewModel = viewModel;
            await _viewManager.ShowAsync<MessageBoxView>(_viewModel);
        }

        private async void CloseMessageBox(MessageBoxResult result)
        {
            _viewModel.Dispose();
            _viewModel = null;
            await _viewManager.HideAsync<MessageBoxView>();

            if (_messageQueue.Count > 0)
            {
                var nextViewModel = _messageQueue.Dequeue();
                await Show(nextViewModel);
            }
        }
    }
}