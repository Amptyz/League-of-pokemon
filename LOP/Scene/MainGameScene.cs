using LOP.Core;
using LOP.GameSystem;

namespace LOP.Scene
{
    public class MainGameScene : SceneState
    {
        public MainGameScene(SceneManager manager) : base(manager)
        {
            Name = "MainGameScene";
        }
        public override void OnEnter()
        {
            GameSceneSystem.mainScene = this;
            Console.WriteLine("Enter Main Scene!");
        }
        public override void Update()
        {
            Console.WriteLine(Time.DeltaTime);
        }
        public override void OnExit()
        {
            GameSceneSystem.mainScene = null;
        }
    }
}
