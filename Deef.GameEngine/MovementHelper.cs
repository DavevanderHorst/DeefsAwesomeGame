using System.Collections.Generic;
using System.Linq;
using Deef.GameEngine.Updaters;

namespace Deef.GameEngine
{
    public class MovementHelper
    {
        private readonly World _world;
        private readonly MapWithDetails _map;
        private readonly char _mapSymbol;
        private readonly bool _isMonster;
        public MovementHelper(MapWithDetails map, char mapSymbol, World world, bool isMonster = true)
        {
            _map = map;
            _mapSymbol = mapSymbol;
            _world = world;
            _isMonster = isMonster;
        }

        int PlaceOnMap { get; set; }
        
        public bool Changed { get; set; }
        int OldPlaceOnMap { get; set; }

        public void MoveDown()
        {
            if (CanMoveInDirection(_map.MapWidth))
            {
                MoveTo(_map.MapWidth);
            }else if (_isMonster)
            {
                MoveTo(-_map.MapWidth);
            }
            else
            {
                Message(_world.WrongDirectionCount);
                _world.WrongDirectionCount++;
            }
        }

        public void MoveUp()
        {
            if (CanMoveInDirection(-_map.MapWidth))
            {
                MoveTo(-_map.MapWidth);
            }else if (_isMonster)
            {
                MoveTo(_map.MapWidth);
            }
            else
            {
                Message(_world.WrongDirectionCount);
                _world.WrongDirectionCount++;
            }
        }

        public void MoveLeft()
        {
            if (CanMoveInDirection(-1))
            {
                MoveTo(-1);
            }else if (_isMonster)
            {
                MoveTo(1);
            }
            else
            {
                Message(_world.WrongDirectionCount);
                _world.WrongDirectionCount++;
            }
        }

        public void MoveRight()
        {
            if (CanMoveInDirection(1))
            {
                MoveTo(1);
            }else if (_isMonster)
            {
                MoveTo(-1);
            }
            else
            {
                Message(_world.WrongDirectionCount);
                _world.WrongDirectionCount++;
            }
        }

        public void MoveTo(int newPlaceOnMap)
        {
            var mapChanges = _world.Get<List<MapPointDescription>>();
            int indexOfSymbol = _map.MapPointDescriptionsList[PlaceOnMap].AreaMapSymbol.IndexOf(_mapSymbol);
            if (indexOfSymbol >= 0)
            {
                _map.MapPointDescriptionsList[PlaceOnMap].AreaMapSymbol = 
                    _map.MapPointDescriptionsList[PlaceOnMap].AreaMapSymbol.Remove(indexOfSymbol, 1);
                mapChanges.Add(_map.MapPointDescriptionsList[PlaceOnMap]);
            }

            if (!_isMonster)
            {
                ConsoleExtensions.RemoveExtraText(_world.WrongDirectionCount);
                _world.WrongDirectionCount = 0;
            }
            Changed = true;
            _world.MapIsChanged = true;
            OldPlaceOnMap = PlaceOnMap;
            PlaceOnMap += newPlaceOnMap;
            _map.MapPointDescriptionsList[PlaceOnMap].AreaMapSymbol += _mapSymbol;
            mapChanges.Add(_map.MapPointDescriptionsList[PlaceOnMap]);
        }
        public bool CanMoveInDirection(int movement)
        {
            int tryMove = PlaceOnMap + movement;
            if (_map.MapPointDescriptionsList[tryMove].Description == "Impenetrable terrain!")
            {
                return false;
            }
            
            return true;
        }
        private void Message(int wrongDirectionCount) //for if your move is not possible
        {
            _world.HasMessage = true;
            var messageQueue = _world.Get<Queue<string>>();
            if (wrongDirectionCount == 0)
            {
                messageQueue.Enqueue("That direction is not possible");
            }
            else if (wrongDirectionCount == 1)
            {
                messageQueue.Enqueue("I said : That direction is not POSSIBLE!!!");
            }
            else if (wrongDirectionCount == 2)
            {
                messageQueue.Enqueue("OH MY GOD!!!!!!");
            }
            else
            {
                messageQueue.Enqueue("You must be the dumbest little fuck on earth......");
            }
        }
    }
}