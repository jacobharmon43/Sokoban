using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class Dynamic : TileObject
    {
        public virtual bool Move(Vector2Int input){
            Tile t = _tiles.GetTile(GridPosition + input);
            TileCover c = t.Cover;
            if(c)
                c.StepOnEvent();
            if(t && t.ground && t.Object == null){
                SetToPos(input, t, _tiles);
                return true;
            }
            return false;
        }

        protected void SetToPos(Vector2Int input, Tile t, Tilegrid tiles){
            transform.position = t.transform.position;
            _tiles.GetTile(GridPosition).Object = null;
            GridPosition += input;
            _tiles.GetTile(GridPosition).Object = this;
        }
    }
}
