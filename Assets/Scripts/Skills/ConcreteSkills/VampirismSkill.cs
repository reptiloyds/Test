using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class VampirismSkill : SkillSandbox
    {
        public VampirismSkill()
        {
            _type = SkillType.Vampirism;
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
