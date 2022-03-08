using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        public Tilemap GroundTiles;
        protected LayerMask _pushableLayer;
        protected float _delay = 0.15f;
        protected float _timer = 0.0f;
        public Vector3Int GridPosition;

        private void Start(){
            if(!GroundTiles) GroundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            _pushableLayer = LayerMask.GetMask("Pushable");
            GridPosition = GroundTiles.WorldToCell(transform.position);
            if(!GroundTiles.HasTile(GridPosition))
                throw new System.Exception($"Tilebound object: {transform.name} starting location is off the grid");
            transform.position = GroundTiles.CellToWorld(GridPosition);
        }

        protected TileBound NextTileObject(Vector3Int tile){
            TileBound[] allTiles = GameObject.FindObjectsOfType<TileBound>();
            foreach(TileBound t in allTiles){
                if(t.GridPosition == tile) return t;
            }
            return null;
        }
        protected bool ValidTile(Vector3Int tile) => GroundTiles.HasTile(tile);
        protected Vector3 GoTo(Vector3Int tile) => GroundTiles.CellToWorld(tile);
    }
}
