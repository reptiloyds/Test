using ScriptableObjects;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameBalance _gameBalance;
        [SerializeField] private Prefabs _prefabs;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameBalance).AsSingle().NonLazy();
            Container.BindInstance(_prefabs).AsSingle().NonLazy();
        }
    }
}