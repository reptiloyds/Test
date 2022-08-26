using System;
using Enums;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace Skills
{
    [Serializable]
    public sealed class SkillConfig
    {
        [SerializeField] private SkillType _type;
        [SerializeField] private int _price;
        [SerializeField] private bool _exploredOnStart;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public SkillType Type => _type;
        public int Price => _price;
        public bool ExploredOnStart => _exploredOnStart;
        public string Name => _name;
        public string Description => _description;
    }
}
