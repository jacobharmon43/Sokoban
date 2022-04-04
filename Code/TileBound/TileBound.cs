using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class TileBound : MonoBehaviour
    {
        protected Vector2Int _gridPosition;
        protected TileGrid _tileGrid;

        protected virtual void Awake(){
            _tileGrid = GameObject.FindObjectOfType<TileGrid>();
        }

        protected virtual void Start(){
            AlignTileToGrid();
        }

        public Vector2Int GridPosition => _gridPosition;
        
        private void AlignTileToGrid(){
            if(!_tileGrid)
                throw new System.Exception($"{transform.name} cannot find tilegrid");
            _gridPosition = _tileGrid.WorldToGrid(transform.position);
            Tile t = _tileGrid.GetTile(_gridPosition);
            if(t) transform.position = t.transform.position;
            else throw new System.Exception($"Tile not found on desired position {_gridPosition}");
        }
    }
}
