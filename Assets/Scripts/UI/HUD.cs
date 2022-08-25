using System;
using System.Globalization;
using Enums;
using Factories;
using Systems;
using TMPro;
using Units.Player;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HUD : BaseWindow
    {
        [SerializeField] private TextMeshProUGUI _skillPointsText;
        [SerializeField] private BaseButton _skillUpgradeButton;

        private Player _player;
        private GameParamFactory _paramFactory;
        private WindowsSystem _windowsSystem;
        private GameParam _skillPointParam;
        
        [Inject]
        private void Construct(WindowsSystem windowsSystem, GameParamFactory paramFactory, Player player)
        {
            _paramFactory = paramFactory;
            _player = player;
            _windowsSystem = windowsSystem;
            _skillUpgradeButton.SetCallback(OpenSkillUpgradeWindow);
        }

        private void Start()
        {
            _skillPointParam = _paramFactory.GetParam(_player, GameParamType.SkillPoint);
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
            _skillPointsText.text = _skillPointParam.Value.ToString(CultureInfo.InvariantCulture);
        }

        private void OnDestroy()
        {
            _skillPointParam.UpdatedEvent -= RedrawSkillPoint;
        }
    }
}
