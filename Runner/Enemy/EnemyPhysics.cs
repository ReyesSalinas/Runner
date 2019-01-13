using System;
using System.Collections.Generic;
using System.Linq;
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
        private Vector2 node;
        public void Initialize(EnemyController enemyController)
        {
        }

        public void Update(EnemyController controller)
        {                  
            var velocity = GetTotalVelocity(controller);
            controller.Mover.move(velocity * Time.deltaTime, controller.BoxCollider, _collisionState);            
        }

        public Vector2 GetTotalVelocity(EnemyController controller)
        {
            return controller.Velocity * _moveSpeed;
        }

      
//        void MoveToNode()
//        {
//            node
//        }
       

    }


}
