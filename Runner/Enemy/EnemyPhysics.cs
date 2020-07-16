using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using Runner.Core;

namespace Runner.Enemy
{
    public class EnemyPhysics
    {
        private readonly float _chasingSpeed = 96;
        private readonly TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();
        private readonly float _normalSpeed = 32;
        private CollisionResult _collisionResult;
        private Node _currentMapNode;
        private int _currentPathNode;
        private NodeCollection _mapNodes;
        private Vector2 _moveDir;
        private float _moveSpeed = 32;
        private List<Point> _pathNodes;

        private Vector2 currentDestination => new Vector2(_pathNodes[_currentPathNode].X * 32 + 16,
            _pathNodes[_currentPathNode].Y * 32 + 16);

        public void initialize(EnemyController controller, List<Point> nodes)
        {
            _mapNodes = controller.entity.scene.findEntity("node-collections").getComponent<NodeCollection>();
            var spawn = _mapNodes.Nodes.randomItem();
            controller.entity.transform.setPosition(spawn.Position);
            _currentMapNode = spawn.GetNextNode();
            setPath(controller);
        }

        public void update(EnemyController controller)
        {
            if (controller.behavior == EnemyBehavior.Normal)
            {
                if (_currentPathNode >= _pathNodes.Count)
                {
                    _currentPathNode = 0;
                    setCurrentMapNode();
                    setPath(controller);
                }
                setCurrentPathNode(controller._boxCollider.bounds);
                setEnemyDirection(controller);
            }

            if (controller.behavior == EnemyBehavior.PlayerAggressive)
            {
                _pathNodes = controller.astarGridGraph.search((controller.entity.position / 32).ToPoint(),
                    (getPlayerPosition(controller) / 32).ToPoint());
                if (_currentPathNode >= _pathNodes.Count) _currentPathNode = 0;
                setCurrentPathNode(controller._boxCollider.bounds);
                setEnemyDirection(controller);
            }

            if (controller.behavior != EnemyBehavior.Attacking)
            {
                move(controller);
            }
            

            updateBehavior(controller);
        }


        public void setPath(EnemyController controller)
        {
            var path = controller.astarGridGraph.search(
                (controller.entity.position / 32).ToPoint(),
                _currentMapNode.TiledPosition);
            _pathNodes = path;
        }

        public void move(EnemyController controller)
        {
            try
            {
                var deltaMovement = getTotalVelocity() * Time.deltaTime;
                if (float.IsNaN(deltaMovement.X) || float.IsNaN(deltaMovement.Y))
                {
                    deltaMovement = Vector2.Zero;
                    _currentPathNode++;
                }
                // if (controller.behavior == EnemyBehavior.PlayerAggressive)
                //     controller._mover.move(deltaMovement, out _collisionResult);
                // if (controller.behavior == EnemyBehavior.Normal)
                controller.Mover.move(deltaMovement, controller._boxCollider, _collisionState);
            }
            catch (Exception e)
            {
            }
        }

        public Vector2 getTotalVelocity()
        {
            return _moveDir * _moveSpeed;
        }

        private void setCurrentPathNode(Rectangle rectangle)
        {
            var hitPath = rectangle.Contains(currentDestination);
            if (hitPath && _currentPathNode < _pathNodes.Count - 1) _currentPathNode++;
        }

        private void setCurrentMapNode()
        {
            _currentMapNode = _currentMapNode.GetNextNode();
        }

        private void setEnemyDirection(EnemyController controller)
        {
            var desiredVelocity = Vector2.Subtract(currentDestination, controller.entity.position);
                desiredVelocity.Normalize();
                _moveDir = desiredVelocity;
        }


        private void getNearestNode(Vector2 entityPosition)
        {
            _currentMapNode = _mapNodes
                .Nodes
                .OrderBy(
                    x => Vector2.Distance(entityPosition, x.Position))
                .FirstOrDefault();
        }

        private void updateBehavior(EnemyController controller)
        {
            var distance = Vector2.Distance(controller.entity.position, getPlayerPosition(controller));
            if (distance <= 32f && controller.behavior != EnemyBehavior.Attacking)
            {
                controller.behavior = EnemyBehavior.Attacking;
            }
            if (distance >
                32f && distance <= 96f && controller.behavior != EnemyBehavior.PlayerAggressive)
            {
                controller.behavior = EnemyBehavior.PlayerAggressive;
                _currentPathNode = 0;
                _moveSpeed = _chasingSpeed;
            }
            if (!(distance > 96f) || controller.behavior == EnemyBehavior.Normal) return;
            controller.behavior = EnemyBehavior.Normal;
            getNearestNode(controller.entity.position);
            _currentPathNode = 0;
            _moveSpeed = _normalSpeed;
        }

        private Vector2 getPlayerPosition(EnemyController controller)
        {
            return controller.entity.scene.findEntity("player").position;
        }
    }
}