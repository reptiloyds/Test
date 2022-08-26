using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class FlySkill : SkillSandbox
    {
        public FlySkill()
        {
            _type = SkillType.Fly;
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
