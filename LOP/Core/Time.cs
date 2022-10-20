namespace LOP.Core
{
    public static class Time
    {
        public static float DeltaTime { get; private set; }
        private static DateTime lastTime;
        public static void Start()
        {
            lastTime = DateTime.Now;
        }
        public static void Update()
        {
            DeltaTime = (float)(DateTime.Now - lastTime).Milliseconds / 1000;
            lastTime = DateTime.Now;
        }
    }
}
