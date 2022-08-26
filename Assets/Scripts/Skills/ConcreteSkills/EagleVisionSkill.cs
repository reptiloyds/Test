using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class EagleVisionSkill : SkillSandbox
    {
        public EagleVisionSkill()
        {
            _type = SkillType.EagleVision;
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
