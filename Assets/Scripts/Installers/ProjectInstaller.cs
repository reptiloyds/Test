using ScriptableObjects;
using UnityEngine;
using Zenject;
// ReSharper disable InconsistentNaming

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameBalance _gameBalance;
        [SerializeField] private SpriteResources _spriteResources;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameBalance).AsSingle().NonLazy();
            Container.BindInstance(_spriteResources).AsSingle().NonLazy();
        }
    }
}