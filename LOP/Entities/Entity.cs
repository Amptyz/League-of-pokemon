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
        public EntityStateController controller { get; private set; }
        public Entity()
        {
            EntityData = new EntityData(this); 
            IsActive = false;
            controller = new EntityStateController(this);
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
                controller.Update();
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
        public void NormalAttack()
        {
            Console.WriteLine(EntityData.Name + " : NormalAttack");
        }
    }
    public enum Nature { Fire, Water, Grass, Normal };
    
    public class EntityData
    {
        public String Name;
        public int MaxHealth;
        public int Health;
        public int Attack;
        private int _attackSpeed;
        public int AttackSpeed
        {
            get { return _attackSpeed; }
            set
            {
                if(value <= 0)
                {
                    _attackSpeed = 0;
                    AttackInterval = 99999;
                }
                else
                {
                    _attackSpeed = value;
                    AttackInterval = (float)(9.0 / Math.Sqrt(value));
                }
            }
        }
        public float AttackInterval { get; private set; }
        public Nature Nature;
        
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
