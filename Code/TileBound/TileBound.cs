using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class TileBound : MonoBehaviour
    {
        public Vector2Int GridPosition = Vector2Int.one;
        protected Tilegrid _tiles;

        protected virtual void Awake(){
            _tiles = GameObject.FindObjectOfType<Tilegrid>();
        }

        protected virtual void Start(){
            AlignTileToGrid();
        }
        
        private void AlignTileToGrid(){
            if(!_tiles)
                throw new System.Exception($"{transform.name} cannot find tilegrid");
            GridPosition = _tiles.WorldToGrid(transform.position);
            Tile t = _tiles.GetTile(GridPosition);
            if(t) transform.position = t.transform.position;
            else throw new System.Exception($"Tile not found on desired position {GridPosition}");
        }
    }
}
