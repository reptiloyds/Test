using Enums;
using ScriptableObjects;
using Systems;
using UI.Base;
using UnityEngine;
using Zenject;
// ReSharper disable InconsistentNaming

namespace UI
{
    public class UpgradeSkillWindow : BaseWindow
    {
        [SerializeField] private SkillTree _skillTree;
        [SerializeField] private SkillInfoPanel _skillInfoPanel;
        [SerializeField] private BaseButton _earnButton;
        [SerializeField] private BaseButton _forgetButton;
        
        private WindowsSystem _windowsSystem;
        private GameSystem _gameSystem;
        private int _skillPointForClick;

        [Inject]
        private void Construct(WindowsSystem windows, GameSystem gameSystem, GameBalance gameBalance)
        {
            _gameSystem = gameSystem;
            _windowsSystem = windows;
            _skillPointForClick = gameBalance.SkillPointsForClick;
        }

        private void Start()
        {
            _earnButton.SetText($"Earn {_skillPointForClick}<sprite name=SkillPoint>");
            _earnButton.SetCallback(EarnSkillPoints);
            _forgetButton.SetCallback(ForgetAllSkills);
        }

        public override void Open(params object[] list)
        {
            base.Open(list);
            
            _windowsSystem.MoveToOverlay(BaseUIElementType.SkillPointPanel);
            _skillTree.SelectSkillOnStart();
        }

        public override void Close()
        {
            base.Close();

            _windowsSystem?.ReturnFromOverlay(BaseUIElementType.SkillPointPanel);
        }

        private void EarnSkillPoints()
        {
            _gameSystem.AddCurrency(GameParamType.SkillPoint, _skillPointForClick);
        }

        private void ForgetAllSkills()
        {
            _skillTree.ForgetAllSkills();
            _skillInfoPanel.RedrawAll();
        }
    }
}
