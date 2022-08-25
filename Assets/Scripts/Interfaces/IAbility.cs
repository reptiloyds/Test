using Enums;

namespace Interfaces
{
    public interface IAbility
    {
        public AbilityType Type { get; }
        public int Price { get; }
        public void Explore();
        public void Forget();
    }
}
