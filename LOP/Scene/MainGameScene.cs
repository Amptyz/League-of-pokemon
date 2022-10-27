using LOP.Core;
using LOP.GameSystem;
using LOP.Entities;

namespace LOP.Scene
{
    public class MainGameScene : SceneState
    {
        public MainGameScene(SceneManager manager) : base(manager)
        {
            Name = "MainGameScene";
            numberCounted = new bool[4];
        }
        public override void OnEnter()
        {
            GameSceneSystem.mainScene = this;
            Console.WriteLine("Enter Main Scene!");
            EntitySystem.Summon("FireDragon");
            /*
             * 在这里添加Entity
             */
        }
        private float countDown = 3.1f;
        private bool[] numberCounted;
        public override void Update()
        {
            if(countDown > 0)
            {
                countDown -= Time.DeltaTime;
            }
            for (int i=3;i > 0;--i)
            {
                if (countDown < i && !numberCounted[i])
                {
                    Console.WriteLine(i);
                    numberCounted[i] = true;
                }
            }
            if(countDown <= 0 && !numberCounted[0])
            {
                Console.WriteLine("Game Start!");
                numberCounted[0] = true;
                EntitySystem.ActivateAll();
            }
        }
        public override void OnExit()
        {
            GameSceneSystem.mainScene = null;
        }
    }
}
