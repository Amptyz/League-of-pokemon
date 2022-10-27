using LOP.Entities;
using LOP.Core;

namespace LOP.GameSystem
{
    public static class EntitySystem
    {
        public static Entity? Summon(String name)
        {
            if (EntityManager.Instance.entityDic.ContainsKey(name))
            {
                Entity ne = Activator.CreateInstance(EntityManager.Instance.entityDic[name]) as Entity;
                if (ne == null) return null;
                ne.OnSummon();
                EntityManager.Instance.AddEntity(ne);
                Console.WriteLine("Summon " + name + " successfully!");
                return ne;
            }
            else return null;
        }
        public static T? Summon<T>() where T : Entity, new()
        {
            T ne = new T();
            if (ne == null) return null;
            ne.OnSummon();
            EntityManager.Instance.AddEntity(ne);
            return ne;
        }
        public static void Destroy(Entity entity)
        {
            entity.OnDestroy();
            EntityManager.Instance.RemoveEntity(entity);
        }
        public static void ActivateAll()
        {
            foreach (var entity in EntityManager.Instance.entities)
            {
                entity.Activate();
            }
        }
    }
}
