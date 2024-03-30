using System;
using System.Collections.Generic;
using System.Threading;
using _Project.Code.Runtime.Utils;
using _Project.Code.Runtime.ViewModel;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Views
{
    [AddressableView("MessageBoxView")]
    public class MessageBoxView : BaseView
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private List<ButtonTypeUIButton> _buttons;
        private MessageBoxViewModel _viewModel;
        
        protected override UniTask Init(IViewModel viewModel, CancellationToken ct)
        {
            _viewModel = (MessageBoxViewModel)viewModel;
            _titleText.text = _viewModel.Caption;
            _messageText.text = _viewModel.Text;
            InitButtons(_viewModel.ResultAction, _viewModel.Buttons);
            
            
            return UniTask.CompletedTask;
        }

        private void InitButtons(Action<MessageBoxResult> resultAction, MessageBoxButtons buttons = MessageBoxButtons.Ok)
        {
            foreach (var button in _buttons)
            {
                button.UIButton.gameObject.SetActive(false);
                button.UIButton.onClick.RemoveAllListeners();
                
                if (buttons == button.ButtonType)
                {
                    button.UIButton.gameObject.SetActive(true);
                    button.UIButton.onClick.AddListener(()=>resultAction?.Invoke(button.MessageBoxResult));
                }
            }
        }
    }

    [Serializable]
    public class ButtonTypeUIButton
    {
        [SerializeField] private MessageBoxButtons _buttonType;
        [FormerlySerializedAs("_button")] [SerializeField] private Button _uiButton;
        [SerializeField] private MessageBoxResult _messageBoxResult;

        public MessageBoxButtons ButtonType => _buttonType;

        public Button UIButton => _uiButton;

        public MessageBoxResult MessageBoxResult => _messageBoxResult;
    }
}