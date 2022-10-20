using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOP.Entity
{
    public abstract class Entity : IUpdatable
    {
        public EntityData EntityData { get; private set; }
        public Entity()
        {
            EntityData = new EntityData(this); 
        }
        public abstract void Update();
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
