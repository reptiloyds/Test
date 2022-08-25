using System;
using Enums;

namespace Abilities
{
    [Serializable]
    public sealed class AbilityConfig
    {
        public AbilityType Type;
        public int Price;
        public bool ExploredOnStart;
    }
}
