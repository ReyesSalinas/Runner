using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;
using Runner.Core;

namespace Runner.Enemy
{
    public class EnemyController: Controller, IUpdatable
    {
        private EnemyPhysics Physics => new EnemyPhysics();

        public EnemyController()
        {

        }

        public override void onAddedToEntity()
        {
            Mover = this.getComponent<TiledMapMover>();
            BoxCollider = entity.getComponent<BoxCollider>();
           // var nodManager = entity.getComponent<NodeManager>();
            Physics.Initialize();
        }

        public void update()
        {
            Physics.Update(this);
        }
    }
}
