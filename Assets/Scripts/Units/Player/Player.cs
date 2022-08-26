using System.Collections.Generic;
using System.Linq;
using Enums;
using Interfaces;
using Skills;
using UnityEngine;

namespace Units.Player
{
    public sealed class Player : BaseUnit, IGameParamOwner, ISkillOwner
    {
        private readonly List<SkillSandbox> _skills = new List<SkillSandbox>();

        public void AddSkill(SkillSandbox skillSandbox)
        {
            if(_skills.Contains(skillSandbox)) return;
            _skills.Add(skillSandbox);
            Debug.Log($"Add {skillSandbox.Type}");
        }

        public void RemoveSkill(SkillType skillType)
        {
            var skill = _skills.FirstOrDefault(item => item.Type == skillType);
            if (skill == null) return;
            _skills.Remove(skill);
            Debug.Log($"Remove {skillType}");
        }

        public void UseSkill(SkillType skillType)
        {
            var skillCommand = _skills.FirstOrDefault(item => item.Type == skillType);
            skillCommand?.Execute();
        }

        public void Cancel(SkillType skillType)
        {
            var skillCommand = _skills.FirstOrDefault(item => item.Type == skillType);
            skillCommand?.Cancel();
        }
    }
}
