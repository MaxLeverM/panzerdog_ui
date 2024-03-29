using System;

namespace _Project.Code.Runtime.Utils
{
    public class AddressableViewAttribute : Attribute
    {
        public string Name;

        public AddressableViewAttribute(string name)
        {
            Name = name;
        }
    }
}