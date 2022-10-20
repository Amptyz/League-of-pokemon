using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOP
{
    public abstract class Entity : IUpdatable
    {
        public abstract void Update();
    }

    public class EntityData
    {
        public int MaxHealth;
        public int Health;
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
