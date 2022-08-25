using System.Collections.Generic;
using Abilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameBalance", menuName = "_Game/Balance")]
    public class GameBalance : ScriptableObject
    {
        [Header("Ability Settings")]
        public List<AbilityConfig> AbilityConfigs;
    }
}