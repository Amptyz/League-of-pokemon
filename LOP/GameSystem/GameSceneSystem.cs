using LOP.Core;
using LOP.Scene;

namespace LOP.GameSystem
{
    public static class GameSceneSystem
    {
        public static MainGameScene? mainScene;
        public static void ChangeScene(SceneState scene)
        {
            SceneManager.Instance.ChangeState(scene);
        }
        public static bool IsInMainGameScene()
        {
            return mainScene != null;
        }
    }
}
