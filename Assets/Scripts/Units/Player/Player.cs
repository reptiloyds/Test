using System;
using DevelopmentTools;
using Enums;
using Factories;
using Interfaces;
using Zenject;

namespace Units.Player
{
    public sealed class Player : BaseUnit, IGameParamOwner
    {
        private GameParamFactory _paramFactory;

        private const float START_SKILLPOINTS = 0; 
        
        [Inject]
        private void Construct(GameParamFactory paramFactory)
        {
            _paramFactory = paramFactory;
            _paramFactory.CreateParam(this, GameParamType.SkillPoint, START_SKILLPOINTS);
        }

        private void Start()
        {
        }
    }
}
