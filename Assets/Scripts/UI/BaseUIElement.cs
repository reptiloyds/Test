using Enums;
using Systems;
using UnityEngine;

namespace UI
{
    public class BaseUIElement : MonoBehaviour
    {
        [SerializeField] private BaseUIElementType _type;
        
        protected WindowsSystem Windows; 
        
        private Transform _parent;
        private RectTransform _rect;
        private Vector2 _defaultPos;
        
        public BaseUIElementType Type => _type;

        public virtual void Init(WindowsSystem windows)
        {
            Windows = windows;
            
            _parent = transform.parent;
            _rect = GetComponent<RectTransform>();
            _defaultPos = _rect.anchoredPosition;
        }

        public virtual void RestorePosition()
        {
            transform.SetParent(_parent);
            _rect.anchoredPosition = _defaultPos;
        }
    }
}
