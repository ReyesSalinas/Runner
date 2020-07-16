using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using Runner.Enemy;
using Runner.Player;
using System;
using Runner.Core;

namespace Runner
{
    class MasterScene : Scene
    {
        public TiledMap Map;
        public static float spawnTimer = 0;
        public static int enemyCounter = 1;      

        public override void initialize()
        {            
            clearColor = Color.LightGray;
            addRenderer(new DefaultRenderer());            
            Map = content.Load<TiledMap>("maps/TiledMap");
            AddTiledMapEntity();
            AddToNodeCollectionEntity(Map.getObjectGroup("slimeNode"));
            var spawn = Map.getObjectGroup("objects").objectWithName("spawn");
            AddPlayerEntity(spawn, "player");
            AddEnemyEntity($"enemy{enemyCounter}");
        }

        public override void update()
        {
            base.update();
            handleEnemyUpdate();                    
        }
      
        private void handleEnemyUpdate()
        {
            if (spawnTimer <= 5f)
            {
                spawnTimer += Time.deltaTime;
            } 
            else
            {
                spawnTimer = 0;
                if (enemyCounter < 6)
                {
                    AddEnemyEntity($"enemy{enemyCounter}");
                }
            }
        }
        private void AddEnemyEntity( string entityName)
        {           
            var enemy = createEntity(entityName);
            enemy.addComponent(new PrototypeSprite(16, 16)).setColor(Color.Purple);
            enemy.addComponent(new TiledMapMover(Map.getLayer<TiledTileLayer>("main")));
            // enemy.addComponent(new Mover());
            enemy.addComponent(new BoxCollider(-8,-8,16,16));
            enemy.addComponent<EnemyController>();
            enemyCounter++;
        }

        private void AddPlayerEntity(TiledObject spawn, string entityName)
        {
            var player = createEntity(entityName);
            player.transform.setPosition(spawn.x, spawn.y);
            player.addComponent(new PrototypeSprite(32, 32)).setColor(Color.Red);
            player.addComponent<PlayerController>();
            player.addComponent(new TiledMapMover(Map.getLayer<TiledTileLayer>("main")));
            player.addComponent(new BoxCollider(-16, -16, 32, 32));
        }

        private void AddTiledMapEntity()
        {
            var tiledEntity = createEntity("tiled-map");
            tiledEntity.addComponent(new TiledMapComponent(Map, "main"));
        }

        private void AddToNodeCollectionEntity(TiledObjectGroup tiledGroup)
        {
            var nodeEntity = findEntity("node-collections") ??  createEntity("node-collections");
            nodeEntity.addComponent(new NodeCollection(tiledGroup));
        }

    }
}
