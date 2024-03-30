using System;
using _Project.Code.Runtime.ViewModel;

namespace _Project.Code.Runtime.Views
{
    public class MessageBoxViewModel : IViewModel, IDisposable
    {
        private Action<MessageBoxResult> _resultAction;
        private readonly string _text;
        private readonly string _caption;
        private readonly MessageBoxButtons _buttons;

        public Action<MessageBoxResult> ResultAction
        {
            get => _resultAction;
            set => _resultAction = value;
        }

        public string Text => _text;

        public string Caption => _caption;

        public MessageBoxButtons Buttons => _buttons;

        public MessageBoxViewModel(Action<MessageBoxResult> resultAction, string text, string caption,
            MessageBoxButtons buttons = MessageBoxButtons.Ok)
        {
            _resultAction = resultAction;
            _text = text;
            _caption = caption;
            _buttons = buttons;
        }

        public void Dispose()
        {
            ResultAction = null;
        }
    }
}