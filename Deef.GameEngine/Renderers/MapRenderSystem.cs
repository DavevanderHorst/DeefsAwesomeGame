using System.Collections.Generic;
using System.Drawing;
using Deef.GameEngine.Updaters;

namespace Deef.GameEngine.Renderers
{
    public class MapRenderSystem : IRender
    {
        private readonly World _world;
        public MapRenderSystem(World world)
        {
            _world = world;
        }


        public void Render(GameTime gameTime)
        {
            if (_world.MapIsChanged)
            {
                _world.MapIsChanged = false;
                if (_world.Has<List<MapPointDescription>>())
                {
                    var changes = _world.Get<List<MapPointDescription>>();
                    if (changes.Count > 0)
                    {
                        PrintMap(changes);
                    }
                }
            }
        }

        public void PrintMap(List<MapPointDescription> map)
        {
            foreach (var area in map)
            {
                if (area.AreaMapSymbol.Length > 2)
                {
                    int monsters = 0;
                    foreach (var letter in area.AreaMapSymbol)
                    {
                        if (letter == 'M')
                        {
                            monsters++;
                        }
                    }

                    if (monsters == 2)
                    {
                        "M".WriteWithCursorRestore(area.CursorOnMapPoint.Left, area.CursorOnMapPoint.Top,
                            Color.Crimson);
                        break;
                    }
                    else
                    {
                        "M".WriteWithCursorRestore(area.CursorOnMapPoint.Left, area.CursorOnMapPoint.Top,
                            Color.OrangeRed);
                        break;
                    }

                }
                string symbol = area.AreaMapSymbol.Substring(area.AreaMapSymbol.Length - 1, 1);
                switch (symbol)
                {
                    case "X":
                        symbol.WriteWithCursorRestore(area.CursorOnMapPoint.Left, area.CursorOnMapPoint.Top,
                            Color.LimeGreen);
                        break;
                    case "M":
                        symbol.WriteWithCursorRestore(area.CursorOnMapPoint.Left, area.CursorOnMapPoint.Top,
                            Color.Firebrick);
                        break;
                    default :
                        symbol.WriteWithCursorRestore(area.CursorOnMapPoint.Left, area.CursorOnMapPoint.Top,
                            Color.White);
                        break;
                }
            }
        }
    }
}
