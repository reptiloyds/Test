using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentTools;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Systems
{
    [CreateAssetMenu(fileName = "Prefabs", menuName = "_Game/Prefabs", order = 1)]
    public class Prefabs : ScriptableObject
    {
        [SerializeField] private string[] _prefabsPaths;
        [SerializeField] private List<MonoBehaviour> _prefabs;

        private static Dictionary<Type, MonoBehaviour> _cachedPrefabsSingle;
        private static Dictionary<Type, List<MonoBehaviour>> _cachedPrefabsGroups;

        public void Initialize()
        {
            CachePrefabs();
        }
        
        [Button("Parse Prefabs")]
        public void ParsePrefabs()
        {
            _prefabs = UnityEditorTools.Find<MonoBehaviour>(_prefabsPaths, UnityEditorTools.FilterTypes.Prefab);
            //TODO:TEST 
            _prefabs.Sort((b1, b2) => string.CompareOrdinal(b1.GetType().Name, b2.GetType().Name));
            
            CachePrefabs();
        }

        private void CachePrefabs()
        {
            _cachedPrefabsSingle = new Dictionary<Type, MonoBehaviour>();
            _cachedPrefabsGroups = new Dictionary<Type, List<MonoBehaviour>>();

            if (_prefabs.Any(item => item == null))
            {
                Debug.LogError("Prefabs asset gas null entries");
                _prefabs.RemoveAll(item => item == null);
            }

            foreach (var prefab in _prefabs)
            {
                var type = prefab.GetType();
                if (_cachedPrefabsGroups.ContainsKey(type))
                {
                    _cachedPrefabsGroups[type].Add(prefab);
                    continue;
                }

                if (!_cachedPrefabsSingle.ContainsKey(type))
                {
                    _cachedPrefabsSingle.Add(type, prefab);
                    continue;
                }

                var existing = _cachedPrefabsSingle[type];
                _cachedPrefabsSingle.Remove(type);
                _cachedPrefabsGroups.Add(type, new List<MonoBehaviour>{existing, prefab});
            }
        }

        public T LoadPrefab<T>(Predicate<T> predicate = default) where T : MonoBehaviour
        {
            if (predicate != default) return LoadAllPrefabs<T>().Find(predicate);

            var type = typeof(T);
            return _cachedPrefabsSingle.ContainsKey(type) ? _cachedPrefabsSingle[type] as T
                : _cachedPrefabsGroups.ContainsKey(type) ? _cachedPrefabsGroups[type][0] as T
                : default;
        }

        private List<T> LoadAllPrefabs<T>() where T : MonoBehaviour
        {
            var type = typeof(T);

            return _cachedPrefabsGroups.ContainsKey(type)
                ? _cachedPrefabsGroups[type].Cast<T>().ToList()
                : _cachedPrefabsSingle.ContainsKey(type)
                    ? new List<T> { _cachedPrefabsSingle[type] as T }
                    : new List<T>();
        }
    }
}
