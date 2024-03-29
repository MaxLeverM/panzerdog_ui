using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Views
{
    public class ShopItemElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private RectTransform _dataPanel;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private List<GameObject> _dataPrefabs; //TODO Тут нужно подумать как лучше сделать, можно использовать словарь (Odin) можно список с объектами и перебирать его
        //TODO А вообще лучше всего сделать фабрику, которая будет создавать дата префабы
    }
}