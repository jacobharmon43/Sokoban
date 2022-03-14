using UnityEngine.Tilemaps;
using UnityEngine;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class AlignTileBoundToGrid
    {
        public static void Align(){
            Tilemap _groundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            TileBound[] allTiles = GameObject.FindObjectsOfType<TileBound>();
            foreach(TileBound t in allTiles){
                Vector2 pos = t.transform.position;
                Vector3Int gridPosition = _groundTiles.WorldToCell(new Vector2(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y)));
                if(!_groundTiles.HasTile(gridPosition))
                    throw new System.Exception($"Tilebound object: {t.transform.name} starting location is off the grid");
                t.transform.position = _groundTiles.CellToWorld(gridPosition);
                t.GridPosition = gridPosition;
                t.GroundTiles = _groundTiles;
            }
        }

        public static void TieSwitchesToSwitchables(Dictionary<char, Switch> d, Dictionary<char, GameObject> f){
            foreach(var s in d){
                s.Value.toSwitch = f[s.Key].GetComponent<ISwitchable>();
            }
        }
    }
}
