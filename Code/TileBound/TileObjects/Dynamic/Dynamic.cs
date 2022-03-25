using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class Dynamic : TileObject
    {
        public virtual bool Move(Vector2Int input){
            Tile t = _tiles.GetTile(GridPosition + input);
            if(t && t.ground && (t.Object && !t.Object.blocking)){
                SetToPos(input, t, _tiles);
                return true;
            }
            return false;
        }

        protected void SetToPos(Vector2Int input, Tile t, Tilegrid tiles){
            transform.position = t.transform.position;
            _tiles.GetTile(GridPosition).RemoveTileObject(this);
            GridPosition += input;
            _tiles.GetTile(GridPosition).AddTileObject(this);
        }
    }
}
