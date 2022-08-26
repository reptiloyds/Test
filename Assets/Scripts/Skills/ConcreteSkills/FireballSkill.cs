using Enums;

namespace Skills.ConcreteSkills
{
    public sealed class FireballSkill : SkillSandbox
    {
        public FireballSkill()
        {
            _type = SkillType.Fireball;
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
