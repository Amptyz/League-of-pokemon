using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOP.Entities
{
    public class FireDragon : Entity
    {
        public FireDragon()
        {
            EntityData.MaxHealth = 1000;
            EntityData.Health = 1000;
            EntityData.Swiftness = 8;
            EntityData.nature = Nature.Fire;
        }
        
    }
}
