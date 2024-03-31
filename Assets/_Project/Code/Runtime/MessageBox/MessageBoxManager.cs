using System;
using System.Collections.Generic;
using _Project.Code.Runtime.MessageBox.Enums;
using Cysharp.Threading.Tasks;

namespace _Project.Code.Runtime.MessageBox
{
    public class MessageBoxManager
    {
        private readonly ViewManager.ViewManager _viewManager;
        private MessageBoxViewModel _viewModel;
        private Queue<MessageBoxViewModel> _messageQueue;

        public MessageBoxManager(ViewManager.ViewManager viewManager)
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
            
            viewModel.ResultAction += OnCloseMessageBox;
            _viewModel = viewModel;
            await _viewManager.ShowAsync<MessageBoxView>(_viewModel);
        }

        private async void OnCloseMessageBox(MessageBoxResult result)
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