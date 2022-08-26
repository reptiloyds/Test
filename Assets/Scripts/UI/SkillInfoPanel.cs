using DevelopmentTools;
using Enums;
using Factories;
using Interfaces;
using ScriptableObjects;
using Systems;
using TMPro;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
// ReSharper disable InconsistentNaming

namespace UI
{
    public class SkillInfoPanel : MonoBehaviour
    {
        [SerializeField] private SkillTree _skillTree;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private BaseButton _exploreButton;
        [SerializeField] private BaseButton _forgetButton;

        private GameSystem _gameSystem;
        private GameParamFactory _paramFactory;
        private SpriteResources _spriteResources;
        private ISkillUI _currentSkill;

        private bool _canExplore;
        private bool _canForget;

        [Inject]
        private void Construct(GameSystem gameSystem, SpriteResources spriteResources, GameParamFactory paramFactory)
        {
            _gameSystem = gameSystem;
            _spriteResources = spriteResources;
            _paramFactory = paramFactory;

            _exploreButton.SetCallback(ExploreSkill);
            _forgetButton.SetCallback(ForgetSkill);
        }

        private void Start()
        {
            var skillPointParam = _paramFactory.GetParam<GameSystem>(GameParamType.SkillPoint);
            skillPointParam.UpdatedEvent += SkillPointOnUpdated;
        }

        private void SkillPointOnUpdated()
        {
            RedrawButton();
        }

        public void Show(ISkillUI skillUI)
        {
            _currentSkill = skillUI;
            _image.sprite = _spriteResources.GetSprite(_currentSkill.Config.Type);
            _name.text = _currentSkill.Config.Name;
            _description.text = _currentSkill.Config.Description;
            
            _exploreButton.SetText($"Buy\n{_currentSkill.Config.Price}<sprite name=SkillPoint>");
            _forgetButton.SetText($"Forget\n{_currentSkill.Config.Price}<sprite name=SkillPoint>");
            
            RedrawAll();
        }

        private void ExploreSkill()
        {
            _currentSkill.Explore();

            RedrawAll();
        }
        
        private void ForgetSkill()
        {
            _currentSkill.Forget();

            RedrawAll();
        }

        public void RedrawAll()
        {
            RedrawState();
            RedrawButton();
        }
        
        private void RedrawState()
        {
            _canExplore = _skillTree.CanExploreSelectedSkill();
            _canForget = _skillTree.CanForgetSelectedSkill();
            _exploreButton.SetActive(_canExplore);
            _forgetButton.SetActive(_canForget); 
        }
        
        private void RedrawButton()
        {
            _exploreButton.SetInteractable(_canExplore && _gameSystem.IsEnoughCurrency(GameParamType.SkillPoint, _currentSkill.Config.Price));
        }
    }
}
