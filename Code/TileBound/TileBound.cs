using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class TileBound : MonoBehaviour
    {
        protected Vector2Int _gridPosition;
        protected TileGrid _tileGrid;
        protected virtual void Awake(){
        }
        protected virtual void Start(){
        }
        public Vector2Int GridPosition => _gridPosition;
        public void SetGrid(TileGrid grid) => _tileGrid = grid;
        public void SetGridPos(Vector2Int set) => _gridPosition = set;
    }
}
