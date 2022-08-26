using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpriteResources", menuName = "_Game/SpriteResources", order = 2)]
    public class SpriteResources : ScriptableObject
    {
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private Sprite _placeholder;

        public Sprite GetSprite<T>(T type) where T: Enum
        {
            var result = _sprites.FirstOrDefault(s => s.name.Equals(type.ToString()));
            return result == null ? _placeholder : result;
        }
        
        public Sprite GetSprite(string key)
        {
            var result = _sprites.FirstOrDefault(s => s.name == key);
            return result == null ? _placeholder : result;
        }
    }
}
