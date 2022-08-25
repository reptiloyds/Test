using Units.Player;
using UnityEngine;
using Zenject;

namespace Installers
{
   public sealed class PlayerInstaller : MonoInstaller
   {
      [SerializeField] private Player _player;
      [SerializeField] private Transform _spawnPoint;
      public override void InstallBindings()
      {
         var playerInstance = Container.InstantiatePrefabForComponent<Player>
            (_player, _spawnPoint.position, Quaternion.identity, null);

         Container.BindInstance(playerInstance).AsSingle().NonLazy();
      }
   }
}