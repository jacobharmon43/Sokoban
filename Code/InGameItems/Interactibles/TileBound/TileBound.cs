using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        public Vector3Int GridPosition;
        protected Tilemap _groundTiles;

        protected virtual void Awake(){
            _groundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            Vector2 pos = transform.position;
            Vector3Int gridPosition = _groundTiles.WorldToCell(new Vector2(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y)));
            if(!ValidTile(gridPosition))
                throw new System.TypeLoadException($"{transform.name} starting position not on a tile.");
            GridPosition = gridPosition;
            transform.position = SetPos(gridPosition);
        }

        protected bool ValidTile(Vector3Int tile) => _groundTiles.HasTile(tile);

        protected Vector3 SetPos(Vector3Int tile) => _groundTiles.CellToWorld(tile);

        protected TileObject ObjectOnTile(Vector3Int tile){
            foreach(TileObject to in (ObjectStore.OfTypeInList<TileObject>())){
                if(to == this) continue;
                if(to.GridPosition == tile && to.blocking) return to;
            }
            return null;
        }

        protected TileMaterial MaterialOfTile(Vector3Int tile){
            foreach(TileMaterial tm in (ObjectStore.OfTypeInList<TileMaterial>())){
                if(tm == this) continue;
                if(tm.GridPosition == tile) return tm;
            }
            return null;
        }

        private void OnEnable(){
            if(!ObjectStore.AllTiles.Contains(this))
                ObjectStore.AllTiles.Add(this);
        }

        private void OnDisable(){
            if(ObjectStore.AllTiles.Contains(this))
                ObjectStore.AllTiles.Remove(this);
        }

        private void OnDestroy(){
            if(ObjectStore.AllTiles.Contains(this))
                ObjectStore.AllTiles.Remove(this);
        }
    }
}
