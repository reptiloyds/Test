using Enums;
using UnityEngine;

namespace Skills
{
    public class SkillSandbox
    {
        protected SkillType _type;
        
        public SkillType Type => _type;
       

        public virtual void Execute()
        {
            Debug.Log($"Use {_type} skill");
        }

        public virtual void Cancel()
        {
            Debug.Log($"Cancel {_type} skill");
        }
    }
}
