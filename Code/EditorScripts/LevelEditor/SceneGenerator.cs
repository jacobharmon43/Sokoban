using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace BlockPuzzle
{
    public static class SceneGenerator
    {
        [SerializeField] private static TileBase groundTile;
        [SerializeField] private static GameObject P;
        [SerializeField] private static GameObject F;
        [SerializeField] private static GameObject D;
        [SerializeField] private static GameObject K;
        [SerializeField] private static GameObject S;
        [SerializeField] private static GameObject B;

        public static void GenerateLevelFromCode(string levelLayout){
            Tilemap ground = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            int counter = 0;
            Debug.Log("Start");
            for(int y = 4; y >= -5; y--){
                for(int x = -11; x <= 10; x++){
                    Vector3Int pos = new Vector3Int(x,y,0);
                    if(ground.HasTile(pos)){
                        ground.SetTile(pos, null);
                    }
                    if(levelLayout[counter] != '1'){
                        ground.SetTile(pos, groundTile);
                        switch (levelLayout[counter]){
                            case 'P':
                                GenerateObject(P, ground.CellToWorld(pos));
                                break;
                            case 'F':
                                GenerateObject(F, ground.CellToWorld(pos));
                                break;
                            case 'D':
                                GenerateObject(D, ground.CellToWorld(pos));
                                break;
                            case 'K':
                                GenerateObject(K, ground.CellToWorld(pos));
                                break;
                            case 'S':
                                GenerateObject(S, ground.CellToWorld(pos));
                                break;
                            case 'B':
                                GenerateObject(B, ground.CellToWorld(pos));
                                break;
                            default:
                                break;
                        }
                    }
                    counter++;
                }
                AlignTileBoundToGrid.Align();
            }
        }

        private static void GenerateObject(GameObject obj, Vector3 pos){
            MonoBehaviour.Instantiate<GameObject>(obj, pos, Quaternion.identity);
        }
    }
}
