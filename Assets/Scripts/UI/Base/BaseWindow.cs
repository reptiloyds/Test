using DevelopmentTools;
using UnityEngine;

namespace UI.Base
{
    public class BaseWindow : MonoBehaviour
    {
        private enum WindowState
        {
            Opened,
            Closed
        }

        private WindowState _state;
        private WindowBack _windowBack;
        protected CloseWindowButton _closeButton;
        
        public bool IsOpened => _state == WindowState.Opened;
        public bool IsClosed => _state == WindowState.Closed;

        public virtual void Init()
        {
            _state = WindowState.Closed;
            
            _closeButton = GetComponentInChildren<CloseWindowButton>(true);
            _windowBack = GetComponentInChildren<WindowBack>(true);

            if (_closeButton != null) _closeButton.SetCallback(Close);
            if (_windowBack != null && _closeButton != null) _windowBack.Init(_closeButton);
            
            this.Deactivate();
        }
        
        public virtual void Open(params object[] list)
        {
            this.Activate();
            OnOpened();
        }

        private void OnOpened()
        {
            SetState(WindowState.Opened);
        }

        public virtual void Close()
        {
            OnClosed();
        }

        private void OnClosed()
        {
            this.Deactivate();
            SetState(WindowState.Closed);
        }

        private void SetState(WindowState state)
        {
            _state = state;
        }
    }
}
