using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class HealthRegenerationSkill : SkillSandbox
    {
        public HealthRegenerationSkill()
        {
            _type = SkillType.HealthRegeneration;
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
