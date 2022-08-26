using Skills;
using UI;

namespace Interfaces
{
    public interface ISkillUI
    {
        public SkillState State { get; }
        public SkillConfig Config { get; }
        public void Explore();
        public void Forget();
    }
}
