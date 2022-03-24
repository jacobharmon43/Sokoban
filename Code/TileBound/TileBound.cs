using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class TileBound : MonoBehaviour
    {
        public Vector2Int GridPosition = Vector2Int.one;
        protected Tilegrid _tiles;

        protected virtual void Start(){
            AlignTileToGrid();
        }
        
        private void AlignTileToGrid(){
            _tiles = GameObject.FindObjectOfType<Tilegrid>();
            GridPosition = _tiles.WorldToGrid(transform.position);
            Tile t = _tiles.GetTile(GridPosition);
            if(t) transform.position = t.transform.position;
            else throw new System.Exception($"Tile not found on desired position {GridPosition}");
        }
    }
}
