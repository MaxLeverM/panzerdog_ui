using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace _Project.Code.Runtime.Shop.Models
{
    [CreateAssetMenu(menuName = "Project/Showcase", fileName = "Showcase")]
    public class ShowcaseSO : SerializedScriptableObject
    {
        [OdinSerialize] private ShopModel _shopModel;

        public ShopModel GetModelData()
        {
            return (ShopModel)_shopModel.Clone();
        }
    }
}