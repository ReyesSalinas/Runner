using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using Random = System.Random;

namespace Runner.Enemy
{
    public class EnemyPhysics
    {
        private readonly float _moveSpeed = 150;
        private TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();
        private Vector2 node =>  new Vector2(80, 405);
        public void Initialize()
        {
            
        }               
        public void Update(EnemyController controller)
        {                  
            
            SetEnemyDirection(controller);
            var deltaMovement = GetTotalVelocity(controller) * Time.deltaTime;
            deltaMovement = GetAdjustedDistanceWithCollision(controller.BoxCollider, deltaMovement);
            controller.Mover.move(deltaMovement, controller.BoxCollider, _collisionState);            
        }

        public Vector2 GetTotalVelocity(EnemyController controller)
        {
            return controller.Velocity * _moveSpeed;
        }

        Vector2 GetAdjustedDistanceWithCollision(BoxCollider boxCollider, Vector2 distance)
        {
            return  new Vector2();
        }
        void SetEnemyDirection(EnemyController controller)
        {
            var entityPosition  = controller.BoxCollider.entity.position;
            if (node.X > entityPosition.X)
                controller.Velocity.X = 1;
            if(node.X < entityPosition.X)
                controller.Velocity.X = -1;
            if (node.Y > entityPosition.Y)
                controller.Velocity.Y = 1;
            if (node.Y < entityPosition.Y)
                controller.Velocity.Y = -1;
        }
       

    }


}
