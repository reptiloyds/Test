using System.Collections.Generic;
using System.Linq;
using DevelopmentTools;
using Enums;
using Scene;
using UI;
using UI.Base;

namespace Systems
{
    public sealed class WindowsSystem
    {
        private readonly SceneData _sceneData;

        private readonly List<BaseWindow> _all = new List<BaseWindow>();
        private readonly List<BaseUIElement> _gamePlayElements = new List<BaseUIElement>();

        private BaseWindow _openedWindow;

        public WindowsSystem(SceneData sceneData)
        {
            _sceneData = sceneData;
            InitWindows();
            InitGamePlayElements();
            CloseAllWindows();
        }

        private void InitWindows()
        {
            var windows = _sceneData.UI.GetComponentsInChildren<BaseWindow>(true);
            foreach (var window in windows)
            {
                AddWindow(window);
            }
        }

        private void InitGamePlayElements()
        {
            var elements = _sceneData.UI.GetComponentsInChildren<BaseUIElement>(true);
            foreach (var element in elements)
            {
                element.Init();
                _gamePlayElements.Add(element);
            }
        }
        
        private void AddWindow(BaseWindow window)
        {
            _all.Add(window);
            window.Init();
        }
        
        private void AddWindow<T>() where T : BaseWindow
        {
            var window = _sceneData.GetComponentInChildren<T>(true);
            if (window == null) return;
            window.Init();
            _all.Add(window);
        }

        public BaseWindow OpenWindow<T>(params object[] list)
        {
            _openedWindow = _all.FirstOrDefault(w => w.GetType() == typeof(T));
            if (_openedWindow == null) return null;
            if (_openedWindow.IsOpened) return null;
            
            _openedWindow.Open(list);

            return _openedWindow;
        }
        

        private void CloseAllWindows()
        {
            foreach (var window in _all)
            {
                window.Close();
            }
            OpenWindow<HUD>();
        }

        public void CloseWindow<T>()
        {
            var window = _all.FirstOrDefault(w => w.GetType() == typeof(T));
            CloseWindow(window);
        }

        public void CloseWindow(BaseWindow window)
        {
            if (window == null) return;
            if (window.IsClosed) return;
            if (window == _openedWindow) _openedWindow = null;
            
            window.Close();
        }

        public BaseWindow GetWindow<T>()
        {
            return _all.FirstOrDefault(w => w.GetType() == typeof(T));
        }

        public void MoveToOverlay(params BaseUIElementType[] elements)
        {
            foreach (var element in elements)
            {
                var gamePlayElement = _gamePlayElements.Find(e => e.Type == element);
                if (gamePlayElement == null) continue;
                
                if (gamePlayElement.transform.parent == _sceneData.WindowsOverlay) continue;
                gamePlayElement.transform.SetParent(_sceneData.WindowsOverlay, true);
                gamePlayElement.Activate();
            }
        }
        
        public void ReturnFromOverlay(params BaseUIElementType[] elements)
        {
            foreach (var element in elements)
            {
                var gamePlayElement = _gamePlayElements.Find(e => e.Type == element);
                if (gamePlayElement != null)
                {
                    gamePlayElement.RestorePosition();
                }
            }
        }
    }
}
