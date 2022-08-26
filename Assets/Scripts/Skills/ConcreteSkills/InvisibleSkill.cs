using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class InvisibleSkill : SkillSandbox
    {
        public InvisibleSkill()
        {
            _type = SkillType.Invisible;
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
