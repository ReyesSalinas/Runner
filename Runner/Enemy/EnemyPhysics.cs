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
        private Queue<Actions> _actions = new Queue<Actions>();
        private Vector2 node;
        public void Initialize(EnemyController enemyController)
        {
            SetActions();
        }

        public void Update(EnemyController controller)
        {
            if(_actions.Count > 0)
                ApplyActions(controller);
      
            var velocity = GetTotalVelocity(controller);
            controller.Mover.move(velocity * Time.deltaTime, controller.BoxCollider, _collisionState);
            if (_actions.Count < 10)
            {
                SetActions();
            }
        }

        public Vector2 GetTotalVelocity(EnemyController controller)
        {
            return controller.Velocity * _moveSpeed;
        }

        void ApplyActions(EnemyController controller)
        {
            switch (_actions.Dequeue())
            {
                case Actions.MoveLeft:
                    controller.Velocity.X = -1;
                    break;
                case Actions.MoveRight:
                    controller.Velocity.X = 1;
                    break;
                case Actions.MoveDown:
                    controller.Velocity.Y = 1;
                    break;
                case Actions.MoveUp:
                    controller.Velocity.Y = -1;
                    break;
                case Actions.Nothing:
                    controller.Velocity.Normalize();
                    break;
            }
        }

        void SetActions()
        {
            var hash = GetHashCode();
            Nez.Random.setSeed(hash);
            var actionNumber = Nez.Random.range(0,6);            
            var instances = Nez.Random.range(1, 3);
            Actions action = (Actions)actionNumber ;
            for (int x = 0; x < instances; x++)
            {
                if (_actions.Count >= 10)
                {
                    break;
                }
                _actions.
                    Enqueue(action);
            }
           
        }

        void MoveToNode()
        {
            node
        }
       

    }


    public enum Actions
    {
        MoveLeft = 1,
        MoveRight = 2,
        MoveUp = 3,
        MoveDown = 4,
        Nothing = 0,
    }
}
