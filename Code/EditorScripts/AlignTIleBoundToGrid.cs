using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class AlignTileBoundToGrid
    {
        [MenuItem("Tools/Align TileBound Objects to Grid")]
        public static void Align(){
            Tilemap _groundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            TileBound[] allTiles = GameObject.FindObjectsOfType<TileBound>();
            foreach(TileBound t in allTiles){
                Vector2 pos = t.transform.position;
                Vector3Int gridPosition = _groundTiles.WorldToCell(new Vector2(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y)));
                if(!_groundTiles.HasTile(gridPosition))
                    throw new System.Exception($"Tilebound object: {t.transform.name} starting location is off the grid");
                t.transform.position = _groundTiles.CellToWorld(gridPosition);
                SerializedObject obj = new SerializedObject(t);
                obj.FindProperty("GridPosition").vector3IntValue = gridPosition;
                obj.FindProperty("GroundTiles").objectReferenceValue = _groundTiles;
                obj.ApplyModifiedProperties();
            }
        }

        public static void TieSwitchesToSwitchables(Dictionary<char, Switch> d, Dictionary<char, GameObject> f){
            foreach(var s in d){
                SerializedObject obj = new SerializedObject(s.Value);
                obj.FindProperty("toSwitch").objectReferenceValue = f[s.Key];
                obj.ApplyModifiedProperties();
            }
        }
    }
}
