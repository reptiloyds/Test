using Cinemachine;
using UnityEngine;

namespace Systems
{
    public sealed class CameraSystem : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public void Follow(Transform target)
        {
            _cinemachineVirtualCamera.Follow = target;
        }

        public void LookAt(Transform target)
        {
            _cinemachineVirtualCamera.LookAt = target;
        }

        public void StopFollow()
        {
            _cinemachineVirtualCamera.Follow = null;
        }

        public void StopLookAt()
        {
            _cinemachineVirtualCamera.LookAt = null;
        }
    }
}
