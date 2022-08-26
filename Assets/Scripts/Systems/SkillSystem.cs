using Enums;
using Interfaces;
using Skills;
using Skills.ConcreteSkills;
using Units.Player;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class SkillSystem
    {
        private ISkillOwner _skillOwner;
        
        [Inject]
        private void Construct(Player player)
        {
            _skillOwner = player;
        }

        public void AppendSkill(SkillType skillType)
        {
            var skill = CreateSkill(skillType);
            if (skill == null)
            {
                Debug.LogError($"Can`t create Skill type of {skillType}");
            }
            _skillOwner.AddSkill(skill);
        }

        public void RemoveSkill(SkillType skillType)
        {
            _skillOwner.RemoveSkill(skillType);
        }

        private SkillSandbox CreateSkill(SkillType skillType)
        {
            SkillSandbox skillSandbox = null;
            switch (skillType)
            {
                case SkillType.Fireball:
                    skillSandbox = new FireballSkill();
                    break;
                case SkillType.Fly:
                    skillSandbox = new FlySkill();
                    break;
                case SkillType.Invisible:
                    skillSandbox = new InvisibleSkill();
                    break;
                case SkillType.Jump:
                    skillSandbox = new JumpSkill();
                    break;
                case SkillType.Move:
                    skillSandbox = new MoveSkill();
                    break;
                case SkillType.Telekinesis:
                    skillSandbox = new TelekinesisSkill();
                    break;
                case SkillType.Teleportation:
                    skillSandbox = new TeleportationSkill();
                    break;
                case SkillType.Vampirism:
                    skillSandbox = new VampirismSkill();
                    break;
                case SkillType.Cloning:
                    skillSandbox = new CloningSkill();
                    break;
                case SkillType.EagleVision:
                    skillSandbox = new EagleVisionSkill();
                    break;
                case SkillType.HealthRegeneration:
                    skillSandbox = new HealthRegenerationSkill();
                    break;
            }
            
            return skillSandbox;
        }
    }
}
