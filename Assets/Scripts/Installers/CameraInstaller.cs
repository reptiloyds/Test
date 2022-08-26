using Systems;
using UnityEngine;
using Zenject;
// ReSharper disable InconsistentNaming

namespace Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraSystem _cameraSystem;
        public override void InstallBindings()
        {
            Container.BindInstance(_cameraSystem).AsSingle().NonLazy();
        }
    }
}
