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
        private readonly float _moveSpeed = 50;
        private TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();
        private Vector2 node => new Vector2(80, 405);

        public void Initialize()
        {
        }

        public void Update(EnemyController controller)
        {
            if (Vector2.Distance(controller.BoxCollider.entity.position, node) > 16)
            {
                SetEnemyDirection(controller);
                var deltaMovement = GetTotalVelocity(controller) * Time.deltaTime;


                controller.Mover.move(deltaMovement, controller.BoxCollider, _collisionState);
            }
        }


        public Vector2 GetTotalVelocity(EnemyController controller)
        {
            return controller.Velocity * _moveSpeed;
        }

        Vector2 AdjustForCollision(EnemyController controller, Vector2 movement)
        {
            Edge edgeX = movement.X > 0f ? Edge.Right : Edge.Left;
            Edge edgeY = movement.Y > 0f ? Edge.Bottom : Edge.Top;
            var origin = controller.BoxCollider.entity.position;
            var ray = new Vector2();

            ray = new Vector2(0, -16);
            var vector = new Vector2(origin.X + 16, origin.Y);
            var top = Physics.linecast(vector, vector + ray);

            ray = new Vector2(0, 16);
            vector = new Vector2(origin.X + 16, origin.Y + 32);
            var bottom = Physics.linecast(vector, vector + ray);

            ray = new Vector2(16, 0);
            vector = new Vector2(origin.X + 32, origin.Y + 16);
            var right = Physics.linecast(vector, vector + ray);

            ray = new Vector2(-16, 0);
            vector = new Vector2(origin.X, origin.Y + 16);
            var left = Physics.linecast(vector, vector + ray);

            ray = new Vector2(-4, -4);
            vector = origin;
            var topLeft = Physics.linecast(vector, vector + ray);

            ray = new Vector2(4, -4);
            vector = new Vector2(origin.X + 32, origin.Y);
            var topRight = Physics.linecast(vector, vector + ray);

            ray = new Vector2(-4, 4);
            vector = new Vector2(origin.X, origin.Y + 32);
            var bottomLeft = Physics.linecast(vector, vector + ray);

            ray = new Vector2(4, 4);
            vector = new Vector2(origin.X + 32, origin.Y + 32);
            var bottomRight = Physics.linecast(vector, vector + ray);

            if (edgeX == Edge.Left)
            {
                if (left.collider != null && left.distance > 0)
                {
                    var position = controller.BoxCollider.entity.position;
                    position.X = node.X;
                    movement = node - position;
                }
                else if (edgeY == Edge.Top)
                {
                    if (top.collider != null || topRight.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.Y = node.Y;
                        movement = node - position;
                    }
                    else if (bottomLeft.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.X = node.X;
                        movement = node - position;
                    }
                }
                else if (edgeY == Edge.Bottom)
                {
                    if (bottom.collider != null || bottomRight.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.Y = node.Y;
                        movement = node - position;
                    }

                    if (topLeft.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.X = node.X;
                        movement = node - position;
                    }
                }
            }

            if (edgeX == Edge.Right)
            {
                if (right.collider != null && right.distance > 0)
                {
                    var position = controller.BoxCollider.entity.position;
                    position.X = node.X;
                    movement = node - position;
                }
                else if (edgeY == Edge.Top)
                {
                    if (top.collider != null || topLeft.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.Y = node.Y;
                        movement = node - position;
                    }
                    else if (bottomRight.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.X = node.X;
                        movement = node - position;
                    }
                }
                else if (edgeY == Edge.Bottom)
                {
                    if (bottom.collider != null || bottomLeft.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.Y = node.Y;
                        movement = node - position;
                    }
                    else if (topRight.collider != null)
                    {
                        var position = controller.BoxCollider.entity.position;
                        position.X = node.X;
                        movement = node - position;
                    }
                }
            }

            return movement;
        }

        Vector2 AdjustDistance()
        {
            var adjustedDistance = new Vector2();
            if (_collisionState.above)
                adjustedDistance.Y += 16;
            if (_collisionState.below)
                adjustedDistance.Y -= 16;
            if (_collisionState.left)
                adjustedDistance.X += 16;
            if (_collisionState.right)
                adjustedDistance.X -= 16;

            return adjustedDistance;
        }

        void SetEnemyDirection(EnemyController controller)
        {
            var desiredVelocity = node - controller.BoxCollider.entity.position;            
            //desiredVelocity = AdjustForCollision(controller, desiredVelocity);
            desiredVelocity.Normalize();
            controller.Velocity = desiredVelocity;
        }
    }
}