using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class MoveSkill : SkillSandbox
    {
        public MoveSkill()
        {
            _type = SkillType.Move;
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
