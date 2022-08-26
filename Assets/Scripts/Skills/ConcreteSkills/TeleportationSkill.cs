using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class TeleportationSkill : SkillSandbox
    {
        public TeleportationSkill()
        {
            _type = SkillType.Teleportation;
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
