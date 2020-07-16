using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using Nez.UI;
using Runner.Core;

namespace Runner.Player
{
    public class PlayerController : Controller, IUpdatable
    {
        private PlayerPhysics Physics => new PlayerPhysics();
        private PlayerInput Input => new PlayerInput();
        public static Vector2 currentPosition;

        public PlayerController()
        {
            
        }

        public override void onAddedToEntity()
        {
            Mover = this.getComponent<TiledMapMover>();
            _boxCollider = entity.getComponent<BoxCollider>();
            Physics.Initialize(this);
            currentPosition = entity.position;
        }

         
       
        public void update()
        {
            Input.Update(this);
            Physics.Update(this);
            currentPosition = entity.position;
        }

    }
}