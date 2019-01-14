using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using Runner.Enemy;
using Runner.Player;

namespace Runner
{
    class MasterScene : Scene
    {        
        public override void initialize()
        {
            clearColor = Color.LightGray;
            addRenderer(new DefaultRenderer());
            var tiledMap = content.Load<TiledMap>("maps/TiledMap");
            var objectLayer = tiledMap.getObjectGroup("objects");
            
            var spawn = objectLayer.objectWithName("spawn");
            var tiledEntity = createEntity("tiled-map");
            tiledEntity.addComponent(new TiledMapComponent(tiledMap,"main"));

            var player = createEntity("player");           
            player.transform.setPosition(spawn.x, spawn.y);
            player.addComponent(new PrototypeSprite(32, 32)).setColor(Color.Red);
            player.addComponent<PlayerController>();
            player.addComponent(new TiledMapMover(tiledMap.getLayer<TiledTileLayer>("main")));
            player.addComponent(new BoxCollider(32,32));

            var enemy = createEntity("enemy");
            enemy.transform.setPosition(320, 320);
            enemy.addComponent(new PrototypeSprite(32, 32)).setColor(Color.Purple);
            enemy.addComponent<EnemyController>();
            enemy.addComponent(new TiledMapMover(tiledMap.getLayer<TiledTileLayer>("main")));
            enemy.addComponent(new BoxCollider(32,32));
        }
    }
}
