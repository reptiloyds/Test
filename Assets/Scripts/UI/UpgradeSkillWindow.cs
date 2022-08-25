using Enums;
using Systems;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UpgradeSkillWindow : BaseWindow
    {
        private WindowsSystem _windowsSystem;
        
        [Inject]
        private void Construct(WindowsSystem windows)
        {
            _windowsSystem = windows;
        }
        
        public override void Open(params object[] list)
        {
            base.Open(list);
            
            _windowsSystem.MoveToOverlay(BaseUIElementType.SkillPointPanel);
        }

        public override void Close()
        {
            base.Close();

            _windowsSystem?.ReturnFromOverlay(BaseUIElementType.SkillPointPanel);
        }
    }
}
