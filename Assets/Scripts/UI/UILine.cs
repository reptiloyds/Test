using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(RectTransform))]
    
    public class UILine : MonoBehaviour
    {
        private Image _image;
        private RectTransform _rectTransform;
        private RectTransform _firstObject;
        private RectTransform _secondObject;
        private float _thickness;
        
        public void CreateLineBetween(GameObject first, GameObject second, float thickness = 20f, Color color = default)
        {
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();

            _thickness = thickness;
            _image.color = color;
            
            _firstObject = first.GetComponent<RectTransform>();
            _secondObject = second.GetComponent<RectTransform>();

            if (_firstObject.localPosition.x > _secondObject.localPosition.x)
            {
                (_firstObject, _secondObject) = (_secondObject, _firstObject);
            }

            RotateImage();
        }
        
        private void RotateImage()
        {
            if (!_firstObject.gameObject.activeSelf || !_secondObject.gameObject.activeSelf) return;
            _rectTransform.localPosition = (_firstObject.localPosition + _secondObject.localPosition) / 2;
            var dif = _secondObject.localPosition - _firstObject.localPosition;
            _rectTransform.sizeDelta = new Vector3(dif.magnitude, _thickness);
            _rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
        }
    }
}
