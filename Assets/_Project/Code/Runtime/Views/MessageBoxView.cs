using _Project.Code.Runtime.Utils;
using _Project.Code.Runtime.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Views
{
    [AddressableView("MessageBoxView")]
    public class MessageBoxView : MonoBehaviour //: BaseView
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;
    }
}