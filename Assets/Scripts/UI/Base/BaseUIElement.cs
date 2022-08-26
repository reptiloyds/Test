using Enums;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace UI.Base
{
    public sealed class BaseUIElement : MonoBehaviour
    {
        [SerializeField] private BaseUIElementType _type;
        
        
        private Transform _parent;
        private RectTransform _rect;
        private Vector2 _defaultPos;
        
        public BaseUIElementType Type => _type;

        public void Init()
        {
            _parent = transform.parent;
            _rect = GetComponent<RectTransform>();
            _defaultPos = _rect.anchoredPosition;
        }

        public void RestorePosition()
        {
            transform.SetParent(_parent);
            _rect.anchoredPosition = _defaultPos;
        }
    }
}
