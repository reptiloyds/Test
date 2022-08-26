using Enums;
using Factories;
using Systems;
using TMPro;
using UI.Base;
using UnityEngine;
using Zenject;
// ReSharper disable InconsistentNaming

namespace UI
{
    public class HUD : BaseWindow
    {
        [SerializeField] private TextMeshProUGUI _skillPointsText;
        [SerializeField] private BaseButton _skillUpgradeButton;
        
        private GameParamFactory _paramFactory;
        private WindowsSystem _windowsSystem;
        private GameParam _skillPointParam;
        
        [Inject]
        private void Construct(WindowsSystem windowsSystem, GameParamFactory paramFactory)
        {
            _paramFactory = paramFactory;
            _windowsSystem = windowsSystem;
            _skillUpgradeButton.SetCallback(OpenSkillUpgradeWindow);
        }

        private void Start()
        {
            _skillPointParam = _paramFactory.GetParam<GameSystem>(GameParamType.SkillPoint);
            _skillPointParam.UpdatedEvent += RedrawSkillPoint;

            RedrawSkillPoint();
            //TODO: ONLY TEST
            OpenSkillUpgradeWindow();
        }

        private void OpenSkillUpgradeWindow()
        {
            _windowsSystem.OpenWindow<UpgradeSkillWindow>();
        }

        private void RedrawSkillPoint()
        {
            _skillPointsText.text = $"{_skillPointParam.Value}<sprite name=SkillPoint>";
        }

        private void OnDestroy()
        {
            _skillPointParam.UpdatedEvent -= RedrawSkillPoint;
        }
    }
}
