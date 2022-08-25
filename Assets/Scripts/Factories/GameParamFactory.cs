using System.Collections.Generic;
using System.Linq;
using Enums;
using Interfaces;
using Systems;

namespace Factories
{
    public class GameParamFactory
    {
        private readonly GameParam.Pool _paramsPool;
        private readonly List<GameParam> _params = new List<GameParam>();

        
        public GameParamFactory(GameParam.Pool paramsPool)
        {
            _paramsPool = paramsPool;
        }

        public GameParam CreateParam(IGameParamOwner owner, GameParamType type, float value)
        {
            var param = _params.Find(p => p.Owner == owner && p.Type == type);
            
            if (param != null) return param;
            param = _paramsPool.Spawn(owner, type, value);

            _params.Add(param);
            
            return param;
        }

        public void RemoveParams(IGameParamOwner owner)
        {
            var ownerParams = _params.FindAll(p => p.Owner == owner);
            foreach (var ownerParam in ownerParams)
            {
                RemoveParam(ownerParam);
            }
        }
        
        public void RemoveParam(GameParam param)
        {
            _paramsPool.Despawn(param);
            _params.Remove(param);
            _params.Remove(param);
        }

        public GameParam GetParam(IGameParamOwner owner, GameParamType type)
        {
            var param = _params.FirstOrDefault(p => p.Owner == owner && p.Type == type);
            return param;
        }
        
        public GameParam GetParam<T>(GameParamType type)
        {
            var param = _params.FirstOrDefault(p => p.Owner is T && p.Type == type);
            return param;
        }
        

        public float GetParamValue(IGameParamOwner owner, GameParamType type)
        {
            var param = _params.FirstOrDefault(p => p.Owner == owner && p.Type == type)?.Value ?? 0;
            return param;
        }
        
        public float GetParamValue<T>(GameParamType type)
        {
            var param = _params.FirstOrDefault(p => p.Owner is T && p.Type == type)?.Value ?? 0;
            return param;
        }
    }
}
