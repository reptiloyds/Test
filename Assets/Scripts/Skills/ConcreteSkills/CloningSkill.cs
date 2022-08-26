using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class CloningSkill : SkillSandbox
    {
        public CloningSkill()
        {
            _type = SkillType.Cloning;
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Cancel()
        {
            base.Cancel();
        }
    }
}
