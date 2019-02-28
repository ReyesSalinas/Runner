
using Nez;


namespace Runner
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Nez.Core
    {
        public Game1() : base(640*2,480*2)
        {
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            Scene.setDefaultDesignResolution(640, 480, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            scene = new MasterScene();
       
        }
    }
}
