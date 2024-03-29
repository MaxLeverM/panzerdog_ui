using _Project.Code.Runtime.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Views
{
    [AddressableView("MessageBoxView")]
    public class MessageBoxView : BaseView
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;
    }
}