using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class JumpSkill : SkillSandbox
    {
        public JumpSkill()
        {
            _type = SkillType.Jump;
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
