using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class Dynamic : TileObject{
        public virtual bool Move(Vector2Int direction){
            Tile t = _tileGrid.GetTile(_gridPosition + direction);
            if(t && !t.GetObject()){
                _tileGrid.MoveTile(this, _gridPosition, _gridPosition + direction);
                _gridPosition += direction;
                return true;
            }   
            return false;
        }
    }
}
