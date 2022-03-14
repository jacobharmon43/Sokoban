using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class SceneGenerator : MonoBehaviour
    {
        public static SceneGenerator Instance {get; private set;}

        private void Awake(){
            Instance = this;
        }
        
        public TileBase groundTile;
        public GameObject P;
        public GameObject F;
        public GameObject D;
        public GameObject K;
        public GameObject S;
        public GameObject B;
        public GameObject G;

        public static void GenerateLevelFromCode(string levelLayout){
            Tilemap ground = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            int counter = 0;
            Dictionary<char, Switch> switches = new Dictionary<char, Switch>();
            Dictionary<char, GameObject> switchables = new Dictionary<char, GameObject>();
            for(int y = 4; y >= -5; y--){
                for(int x = -11; x <= 10; x++){
                    Vector3Int pos = new Vector3Int(x,y,0);
                    while(levelLayout[counter] == ' ' || levelLayout[counter] == '\n' || levelLayout[counter] == '\t' || levelLayout[counter] == '\v' || levelLayout[counter] == '\r'){
                        counter++;
                    }
                    if(ground.HasTile(pos)){
                        ground.SetTile(pos, null);
                    }
                    if(levelLayout[counter] != '1'){
                        ground.SetTile(pos, SceneGenerator.Instance.groundTile);
                        switch (levelLayout[counter]){
                            case 'P':
                                GenerateObject(SceneGenerator.Instance.P, ground.CellToWorld(pos));
                                break;
                            case 'F':
                                GenerateObject(SceneGenerator.Instance.F, ground.CellToWorld(pos));
                                break;
                            case 'D':
                                GenerateObject(SceneGenerator.Instance.D, ground.CellToWorld(pos));
                                break;
                            case 'K':
                                GenerateObject(SceneGenerator.Instance.K, ground.CellToWorld(pos));
                                break;
                            case 'S':
                                counter++;
                                char p = levelLayout[counter];
                                switches.Add(p,GenerateObject(SceneGenerator.Instance.S, ground.CellToWorld(pos)).GetComponent<Switch>());
                                break;
                            case 'B':
                                GenerateObject(SceneGenerator.Instance.B, ground.CellToWorld(pos));
                                break;
                            case 'G':
                                counter++;
                                char q = levelLayout[counter];
                                switchables.Add(q,GenerateObject(SceneGenerator.Instance.G, ground.CellToWorld(pos)));
                                break;
                            default:
                                break;
                        }
                    }
                    counter++;
                }
            }
            AlignTileBoundToGrid.Align();
            AlignTileBoundToGrid.TieSwitchesToSwitchables(switches, switchables);
        }

        public static GameObject GenerateObject(GameObject obj, Vector3 pos){
            return MonoBehaviour.Instantiate<GameObject>(obj, pos, Quaternion.identity);
        }
    }
}
