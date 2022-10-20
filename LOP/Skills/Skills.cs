using LOP.Core;
using LOP.Entities;

namespace LOP.Skills
{
    public class Skill : IUpdatable
    {
        public Entity Entity { get; private set; }
        public float CoolDown;
        public Skill(Entity entity)
        {
            Entity = entity;
        }
        public virtual void Update()
        {
            CoolDown -= Time.DeltaTime;
            if (CoolDown < 0)
            {
                CoolDown = 0;
            }
        }
        public virtual void OnEquipped() {}
        public virtual void OnOccur() {}
    }
}
