using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Runner.Player
{
    public class PlayerPhysics
    {
        private readonly float _moveSpeed = 150;
        private TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();
        
        public PlayerPhysics()
        {

        }

        public void Initialize(PlayerController player)
        {

            
        }
        public void Update(PlayerController player)
        {           
         
            player.Velocity = GetTotalVelocity(player.Velocity);
            player.Mover.move(player.Velocity * Time.deltaTime,player.BoxCollider,_collisionState);
            
        }
              
        private Vector2 GetTotalVelocity(Vector2 playerVelocity)
        {
            var velocity = playerVelocity * _moveSpeed;
            return velocity;
        }
    }
}