using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace BlockPuzzle
{
    public class SceneGenerator : EditorWindow
    {
        string levelLayout;
        Tilemap ground;
        [SerializeField] private TileBase groundTile;
        [SerializeField] private GameObject P;
        [SerializeField] private GameObject F;
        [SerializeField] private GameObject D;
        [SerializeField] private GameObject K;
        [SerializeField] private GameObject S;
        [SerializeField] private GameObject B;
        Texture tex;

        [MenuItem("Window/LevelGenerator")]
        static void Init(){
            SceneGenerator window = (SceneGenerator)EditorWindow.GetWindow(typeof(SceneGenerator));
        }

        private void OnGUI(){
            GUILayout.Label("GroundCode", EditorStyles.boldLabel);
            levelLayout = EditorGUILayout.TextField("LevelString", levelLayout);
            if(GUILayout.Button(tex)){
                GenerateLevelFromCode();
            }
        }

        private void GenerateLevelFromCode(){
            ground = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
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

        private void GenerateObject(GameObject obj, Vector3 pos){
            Instantiate<GameObject>(obj, pos, Quaternion.identity);
        }
    }
}
