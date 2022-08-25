using Factories;
using Scene;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    [RequireComponent(typeof(SceneData))]
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private SceneData _sceneData;

        private const int PARAM_CAPACITY = 10;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_sceneData).AsSingle().NonLazy();

            BindSystems();
            BindFactories();
            BindPools();
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WindowsSystem>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<GameParamFactory>().AsSingle().NonLazy();
        }

        private void BindPools()
        {
            Container.BindMemoryPool<GameParam, GameParam.Pool>().WithInitialSize(PARAM_CAPACITY);
        }
    }
}