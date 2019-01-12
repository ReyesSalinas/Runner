using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
namespace Runner.Core
{
    public abstract class Controller : Component
    {
        public Vector2 Velocity;
        public BoxCollider BoxCollider;
        public TiledMapMover Mover;      
    }
    
}
