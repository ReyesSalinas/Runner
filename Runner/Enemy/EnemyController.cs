using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Nez.AI.Pathfinding;
using Nez.Sprites;
using Nez.Tiled;
using Runner.Core;

namespace Runner.Enemy
{
    public class EnemyController: Controller, IUpdatable
    {
        private EnemyPhysics Physics;
        public TiledMapComponent _tiledMapComponent;
        public Mover _mover;
        public AstarGridGraph astarGridGraph;
        public EnemyBehavior behavior = EnemyBehavior.Normal;
        public override void onAddedToEntity()
        {
            addAnimation();
            addNodes(_tiledMapComponent.collisionLayer);
            addPhysics();
        }

        void IUpdatable.update()
        {            
            Physics.update(this);
        }

        private void addNodes(TiledTileLayer collisionLayer)
        {
            astarGridGraph = new AstarGridGraph(collisionLayer);
        }

        private void addAnimation()
        {
            _tiledMapComponent = entity
                .scene.findEntity("tiled-map")
                .getComponent<TiledMapComponent>();
            Mover = this.getComponent<TiledMapMover>();
            // _mover = this.getComponent<Mover>();
        }

        private void addPhysics()
        {
            
            _boxCollider = entity.getComponent<BoxCollider>();
            Physics = new EnemyPhysics();
            Physics.initialize(this, new List<Point>());
        }

       

        
    }
}
