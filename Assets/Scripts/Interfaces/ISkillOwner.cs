using Enums;
using Skills;

namespace Interfaces
{
    public interface ISkillOwner
    {
        public void AddSkill(SkillSandbox skillSandbox);
        public void RemoveSkill(SkillType skillType);

        public void UseSkill(SkillType skillType);
        public void Cancel(SkillType skillType);
    }
}
