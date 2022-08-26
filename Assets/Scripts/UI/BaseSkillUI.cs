using System;
using System.Linq;
using DG.Tweening;
using Enums;
using Interfaces;
using ScriptableObjects;
using Skills;
using Systems;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
// ReSharper disable InconsistentNaming

namespace UI
{
    public enum SkillState
    {
        None,
        Explored,
        Unexplored,
    }
    
    public class BaseSkillUI : MonoBehaviour, ISkillUI
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _outlineImage;
        [SerializeField] private SkillType _type;
        [SerializeField] private BaseButton _pickButton;
        
        private GameBalance _gameBalance;
        private SpriteResources _spriteResources;
        private GameSystem _gameSystem;
        private SkillSystem _skillSystem;
        private SkillConfig _config;
        private SkillState _state;
        private Sequence _effectSequence;

        private const float SELECET_ANIMATION_TIME = 1.2F;

        public SkillConfig Config => _config;
        public SkillState State => _state;
        
        public event Action<BaseSkillUI> OnSkillClick;

        [Inject]
        public void Construct(GameBalance gameBalance, SpriteResources spriteResources, GameSystem gameSystem, SkillSystem skillSystem)
        {
            _gameBalance = gameBalance;
            _spriteResources = spriteResources;
            _gameSystem = gameSystem;
            _skillSystem = skillSystem;
            
            
            _config = _gameBalance.SkillConfigs.FirstOrDefault(item => item.Type == _type);
            if (_config == null)
            {
                Debug.LogError($"Can`t find SkillConfig type of {_type}");
                return;
            }

            _image.sprite = _spriteResources.GetSprite(_type);
        }

        private void Start()
        {
            if (_config.ExploredOnStart)
            {
                SetState(SkillState.Explored);
                _skillSystem.AppendSkill(_config.Type);
            }
            else
            {
                SetState(SkillState.Unexplored);
            }

            _pickButton.SetCallback(OnSkillClicked);
        }

        private void OnSkillClicked()
        {
            OnSkillClick?.Invoke(this);
        }

        public void Select()
        {
            SelectEffect();
        }

        public void Deselect()
        {
            CancelSelectEffect();
        }

        public void Explore()
        {
            SetState(SkillState.Explored);
            _gameSystem.SpendCurrency(GameParamType.SkillPoint, _config.Price);
            _skillSystem.AppendSkill(_config.Type);
        }

        public void Forget()
        {
            SetState(SkillState.Unexplored);
            _gameSystem.AddCurrency(GameParamType.SkillPoint, _config.Price);
            _skillSystem.RemoveSkill(_config.Type);
        }

        private void SetState(SkillState state)
        {
            if(_state == state) return;
            _state = state;

            switch(_state)
            {
                case SkillState.Explored:
                    _image.color = Color.white;
                    _outlineImage.color = _gameBalance.ExploredOutlineColor;
                    break;
                case SkillState.Unexplored:
                    _image.color = _gameBalance.UnexploredSkillColor;
                    _outlineImage.color = _gameBalance.UnexploredOutlineColor;
                    break;
            }
        }

        private void SelectEffect()
        {
            _effectSequence = DOTween.Sequence();
            _effectSequence.Append(transform.DOScale(Vector3.one * 0.95f, SELECET_ANIMATION_TIME * 0.25F).SetEase(Ease.Linear));
            _effectSequence.Append(transform.DOScale(Vector3.one * 1.05f, SELECET_ANIMATION_TIME * 0.5f).SetEase(Ease.Linear));
            _effectSequence.Append(transform.DOScale(Vector3.one, SELECET_ANIMATION_TIME * 0.25f).SetEase(Ease.Linear));
            _effectSequence.SetLoops(-1);
        }

        private void CancelSelectEffect()
        {
            _effectSequence?.Kill();
            transform.localScale = Vector3.one;
        }
    }
}
