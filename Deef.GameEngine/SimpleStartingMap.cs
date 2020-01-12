using System;
using System.Collections.Generic;
using System.Text;

namespace Deef.GameEngine
{
    public class SimpleStartingMap
    {
        public static List<MapPointDescription> CreateMap(int width, int heigth)
        {
            List<MapPointDescription> map = new List<MapPointDescription>();
            for (int i = 0; i < heigth; i++)//hoogte
            {
                int widthOnScreen = width * 2;
                for (int j = 0; j < widthOnScreen; j+=2)//breedte
                {
                    int mapIndex = widthOnScreen * i + j;
                    if (i == 0 || j == 0 || mapIndex > ((heigth -1)*widthOnScreen)-1|| (mapIndex+2)%(widthOnScreen)==0)
                    {
                        map.Add(new MapPointDescription("#", "Impenetrable terrain!",
                            new MapPoint(j, i)));
                    }
                    else
                    {
                        map.Add(new MapPointDescription(".", "komt nog", 
                            new MapPoint(j, i)));
                    }
                }
            }
            return map;
        }
    }

    public class MapPointDescription
    {
        public MapPoint CursorOnMapPoint { get; }
        public string AreaMapSymbol { get; set; }
        public string Description { get; set; }
        
        public MapPointDescription(string areaMapSymbol, string description, MapPoint mapPoint)
        {
            AreaMapSymbol = areaMapSymbol;
            Description = description;
            CursorOnMapPoint = mapPoint;
        }
    }

    public class MapPoint
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public MapPoint(int left, int top)
        {
            Left = left;
            Top = top;
        }
    }

    public class MapWithDetails
    {
        public List<MapPointDescription> MapPointDescriptionsList { get; set; }
        public int MapWidth { get; set; }
        public int MapHeigth { get; set; }
        public MapWithDetails(int width, int heigth)
        {
            MapWidth = width;
            MapHeigth = heigth;
            MapPointDescriptionsList = SimpleStartingMap.CreateMap(width, heigth);
        }
    }
}
