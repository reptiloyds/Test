using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class TelekinesisSkill : SkillSandbox
    {
        public TelekinesisSkill()
        {
            _type = SkillType.Telekinesis;
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
