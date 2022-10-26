using LOP.Core;
using LOP.GameSystem;
using LOP.Cards;

namespace LOP.Entities
{
    public abstract class Entity : IUpdatable
    {
        public EntityData EntityData { get; private set; }
        public bool IsActive { get; private set; }
        public SkillCard SkillCard { get; protected set; }
        public Entity()
        {
            EntityData = new EntityData(this); 
            IsActive = false;
        }
        public virtual void OnSummon() { }
        public virtual void Update()
        {
            if (IsActive)
            {
                if (EntityData.Health <= 0)
                {
                    OnDeath();
                }
            }
        }
        public virtual void OnDestroy() 
        { 
            IsActive = false;
        }
        public virtual void OnDeath()
        {
            Destroy();
        }
        public void Activate()
        {
            IsActive = true;
        }
        public void Destroy()
        {
            EntitySystem.Destroy(this);
        }
    }
    public enum Nature { Fire, Water, Grass, Normal };
    
    public class EntityData
    {
       
        public int MaxHealth;
        public int Health;
        public int Swiftness;
        public Nature nature;
        
        public Entity Entity { get; private set; }
        public EntityData(Entity entity)
        {
            Entity = entity;
        }
        public virtual EntityData Copy()
        {
            return new EntityData(Entity);
        }
    }

}
