using System.Collections.Generic;
using System.IO;
using System.Text;
using Colorful;
using Deef.GameEngine.Renderers;
using Deef.GameEngine.Updaters;
using Console = Colorful.Console;


namespace Deef.GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.OutputEncoding = Encoding.Unicode;
            MapWithDetails map = new MapWithDetails(20,10);
            List<MapPointDescription> mapChanges = new List<MapPointDescription>();
            //System.Console.WriteLine("\u2665");
            //System.Console.WriteLine("\uF496");

            //System.Console.Write('\u003A');
            //System.Console.WriteLine('\u0029');//

            //System.Console.Write('\u263A');
            //System.Console.Write('♥');
            //System.Console.Write('♡');
            //System.Console.WriteLine('\u263B');
            //System.Console.Read();

            Console.SetWindowSize(120, 35);
            Console.CursorVisible = false;
            var world = new World();
            world.Set(map);
            world.Set(mapChanges);

            var health = new HealthComponent(world)
            {
                Health = new RegenAttribute
                {
                    Current = 50, Max = 100, Name = "Health", RegenRatePerSecond = 1
                }
            };
            var mana = new ManaComponent(world)
            {
                Mana = new RegenAttribute
                {
                    Current = 30,Max = 60, Name = "Mana", RegenRatePerSecond = 0.2
                }
            };

            var fpsCounter = new FramesPerSecondCounter(world);
            var fpsWriter = new FpsRenderer(world);
            var inputSystem = new ConsoleInputSystem(world);
            Queue<string> playerMessages = new Queue<string>();
            world.Set(playerMessages);
            //var playerRenderSystem = new PlayerRenderSystem(world);
            var playerMovement = new PlayerMovementSystem(world);

            //var monsterRenderSystem = new MonsterRenderSystem(world);

            //Initialize Player position
            var initialPlayerPosition = new MovementHelper(map, 'X', world, false);
            initialPlayerPosition.MoveTo(45);
            world.Set(initialPlayerPosition);

            //initializ monster/s
            Monster monster1 = new Monster(world, 55, map, 'M');
            Monster monster2 = new Monster(world, 56, map, 'M');
            Monster monster3 = new Monster(world, 57, map, 'M');
            List<Monster> monsters= new List<Monster>();
            monsters.Add(monster1);
            monsters.Add(monster2);
            monsters.Add(monster3);
            world.Set(monsters);
            MonstersUpdater monstersUpdater = new MonstersUpdater(world);
            MapRenderSystem mapRenderer = new MapRenderSystem(world);
            mapRenderer.PrintMap(map.MapPointDescriptionsList);
            PlayerMessageRenderSystem messageRenderSystem = new PlayerMessageRenderSystem(world);

            var updateSystems = new IUpdate[] {inputSystem, fpsCounter, playerMovement, monstersUpdater , health, mana}; //Order is important!
            var renderSystems = new IRender[] {mapRenderer, messageRenderSystem, health, mana, fpsWriter, fpsCounter };
            
            GameEngine gameEngine = new GameEngine(updateSystems, renderSystems);
            
            gameEngine.Start();
        }
    }
}
