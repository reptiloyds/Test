using UnityEngine;

namespace Scene
{
    public sealed class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _ui;
        [SerializeField] private Transform _windowsOverlay;

        public Transform UI => _ui;
        public Transform WindowsOverlay => _windowsOverlay;
    } 
}
