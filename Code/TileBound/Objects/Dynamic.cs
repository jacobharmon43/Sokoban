using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class Dynamic : TileObject{
        public virtual bool Move(Vector2Int direction){
            Tile t = _tileGrid.GetTile(_gridPosition + direction);
            if(t && t.isGround && !t.GetObject()){
                _tileGrid.MoveTile(this, _gridPosition, _gridPosition + direction);
                _gridPosition += direction;
                transform.position = t.transform.position;
                return true;
            }   
            return false;
        }
    }
}
