using System;
using Cysharp.Threading.Tasks;

namespace _Project.Code.Runtime
{
    public interface IScreenManager
    {
        public UniTask ShowAsync(Type ViewType);
        public UniTask HideAsync(Type ViewType);
    }
}