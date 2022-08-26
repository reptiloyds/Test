using System.Collections.Generic;
using Skills;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameBalance", menuName = "_Game/Balance")]
    public class GameBalance : ScriptableObject
    {
        [Header("Skills Settings")]
        public int StartSkillPoints;
        public int SkillPointsForClick;
        public Color UnexploredSkillColor;
        public Color UnexploredOutlineColor;
        public Color ExploredOutlineColor;
        public List<SkillConfig> SkillConfigs;
    }
}