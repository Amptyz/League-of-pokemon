using LOP.Entities;

namespace LOP.Core
{
    public class EntityManager : Script
    {
        private static EntityManager instance;
        public static EntityManager Instance
        {
            get { return instance ??= new EntityManager(); }
        }
        public List<Entity> entities;
        public EntityManager()
        {
            entities = new List<Entity>();
        }
        public void AddEntity(Entity entity)
        {
            if (!entities.Contains(entity))
            {
                entities.Add(entity);
            }
        }
        public void RemoveEntity(Entity entity)
        {
            if (entities.Contains(entity))
            {
                entities.Remove(entity);
            }
        }
        public override void Update()
        {
            Console.WriteLine("EntityManager.Update()");
            foreach (var entity in entities)
            {
                entity.Update();
            }
        }
    }
}
