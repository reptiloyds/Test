using System;
using Enums;
using Factories;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Systems
{
     public class GameSystem : IGameParamOwner, IInitializable
     {
          [Inject] private GameParamFactory _params;
          [Inject] private GameBalance _gameBalance;

          private GameParam _skillPoints;
        
        
          public void Initialize()
          {
               _skillPoints = _params.CreateParam(this, GameParamType.SkillPoint, _gameBalance.StartSkillPoints); 
          }

          public void AddCurrency(GameParamType type, float value)
          {
               switch (type)
               {
                    case GameParamType.SkillPoint:
                         _skillPoints.Change(value);
                         break;
               }
          }
        
          public bool IsEnoughCurrency(GameParamType type, float needed)
          {
               switch (type)
               {
                    case GameParamType.SkillPoint:
                         return _skillPoints.Value >= needed;
               }

               return false;
          }

          public void SpendCurrency(GameParamType type, float value)
          {
               switch (type)
               {
                    case GameParamType.SkillPoint:
                         _skillPoints.Change(-value);
                         break;
               }
          }
     }
}
