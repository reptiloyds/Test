using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Enums;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Abilities
{
    public enum AbilityState
    {
        None,
        Explored,
        Unexplored,
    }
    
    public class BaseAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private AbilityType _type;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Color _exploredColor = Color.green;
        private Color _unExploredColor = Color.blue;
        private const float _transitionColorTime = 0.5f;

        private AbilityConfig _config;
        private AbilityState _state;
        
        public AbilityType Type => _type;
        public int Price => _config.Price;

        [Inject]
        public void Construct(GameBalance gameBalance)
        {
            _config = gameBalance.AbilityConfigs.FirstOrDefault(item => item.Type == _type);
            if (_config == null)
            {
                Debug.LogError($"Can`t find AbilityConfig type of {_type}");
            }
        }
        
        public void Explore()
        {
            
        }

        public void Forget()
        {
            
        }

        private void Start()
        {
            if (_config != null)
            {
                SetState(_config.ExploredOnStart ? AbilityState.Explored : AbilityState.Unexplored);
            }
        }

        private void SetState(AbilityState state)
        {
            if(_state == state) return;
            _state = state;

            switch(_state)
            {
                case AbilityState.Explored:
                    _meshRenderer.material.DOColor(_exploredColor, _transitionColorTime);
                    break;
                case AbilityState.Unexplored:
                    _meshRenderer.material.DOColor(_unExploredColor, _transitionColorTime);
                    break;
            }
        }
    }
}
