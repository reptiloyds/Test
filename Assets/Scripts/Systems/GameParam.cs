using System;
using Enums;
using Interfaces;
using Zenject;

namespace Systems
{
    public class GameParam
    {
        public event Action UpdatedEvent;
        
        public IGameParamOwner Owner { get; private set; }
        public GameParamType Type { get; private set; }
        public float Value { get; private set; }

        private void Init(IGameParamOwner owner, GameParamType type, float value)
        {
            Owner = owner;
            Type = type;
            Value = value;
        }

        public void Change(float value)
        {
            Value += value;
            UpdatedEvent?.Invoke();
        }
        
        public virtual void SetValue(float value, bool updateEvent = true)
        {
            Value = value;
            if (updateEvent) UpdatedEvent?.Invoke();
        }
        
        public class Pool : MemoryPool<IGameParamOwner, GameParamType, float, GameParam>
        {
            protected override void Reinitialize(IGameParamOwner owner, GameParamType type, float target, GameParam param)
            {
                param.Init(owner, type, target);
            }
        }
    }
}
