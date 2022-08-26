using Factories;
using Scene;
using Systems;
using UnityEngine;
using Zenject;
// ReSharper disable InconsistentNaming

namespace Installers
{
    [RequireComponent(typeof(SceneData))]
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private SceneData _sceneData;

        private const int PARAM_POOL_CAPACITY = 10;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_sceneData).AsSingle().NonLazy();

            BindSystems();
            BindFactories();
            BindPools();
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<WindowsSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SkillSystem>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<GameParamFactory>().AsSingle().NonLazy();
        }

        private void BindPools()
        {
            Container.BindMemoryPool<GameParam, GameParam.Pool>().WithInitialSize(PARAM_POOL_CAPACITY);
        }
    }
}