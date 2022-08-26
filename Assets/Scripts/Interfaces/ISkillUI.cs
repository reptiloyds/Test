using Skills;

namespace Interfaces
{
    public interface ISkillUI
    {
        public SkillConfig Config { get; }
        public void Explore();
        public void Forget();
    }
}
