using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEditor;

namespace BlockPuzzle
{
    public class AlignTIleBoundToGrid
    {

        [MenuItem("Tools/Align TileBound Objects to Grid")]
        private static void Align(){
            Tilemap _groundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            foreach(TileBound t in GameObject.FindObjectsOfType<TileBound>()){
                Vector2 pos = t.transform.position;
                Vector3Int gridPosition = _groundTiles.WorldToCell(new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y)));
                if(!_groundTiles.HasTile(gridPosition))
                    throw new System.Exception($"Tilebound object: {t.transform.name} starting location is off the grid");
                t.transform.position = _groundTiles.CellToWorld(gridPosition);
                t.GridPosition = gridPosition;
                t.GroundTiles = _groundTiles;
            }
        }
    }
}
