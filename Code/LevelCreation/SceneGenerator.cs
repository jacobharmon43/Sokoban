using UnityEngine;
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
        
        public TileBase GroundTile;
        public GameObject Player; //
        public GameObject Flag; //
        public GameObject Door; //
        public GameObject Key; //
        public GameObject Switch; //
        public GameObject Box; //
        public GameObject Gate; //
        public GameObject Spike;
        public GameObject Ice;
        public GameObject Gun;

        private static Dictionary<char, Switch> switches;
        private static Dictionary<char, GameObject> switchables;

        public static void GenerateLevelFromFullCode(string code){
            switches= new Dictionary<char, Switch>();
            switchables = new Dictionary<char, GameObject>();
            string[] x = code.Split('X');
            GenerateFloorFromCode(x[0]);
            GenerateLevelFromCode(x[1]);
            AlignTileBoundToGrid.Align();
            AlignTileBoundToGrid.TieSwitchesToSwitchables(switches, switchables);
        }

        public static void GenerateLevelFromCode(string levelLayout){
            Tilemap ground = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            int counter = 0;
            for(int y = 4; y >= -5; y--){
                for(int x = -11; x <= 10; x++){
                    Vector3Int pos = new Vector3Int(x,y,0);
                    while(levelLayout[counter] == ' ' || levelLayout[counter] == '\n' || levelLayout[counter] == '\t' || levelLayout[counter] == '\v' || levelLayout[counter] == '\r'){
                        counter++;
                    }
                    if(levelLayout[counter] == 'P'){
                        GenerateObject(s_player, pos);
                    }
                    else if(levelLayout[counter] == 'D'){
                        GenerateObject(s_door, pos);
                    }
                    else if(levelLayout[counter] == 'K'){
                        GenerateObject(s_key, pos);
                    }
                    else if(levelLayout[counter] == 'B'){
                        GenerateObject(s_box, pos);
                    }
                    else if(levelLayout[counter] == 'G'){
                        counter++;
                        switchables.Add(levelLayout[counter], GenerateObject(s_gate, pos));
                    }
                    else if(levelLayout[counter] == 'L')
                    {
                        counter++;
                        switchables.Add(levelLayout[counter], GenerateObject(s_gun, pos));
                    }
                    else if(levelLayout[counter] == 'E')
                    {
                        counter++;
                         GenerateObject(s_spike, pos);
                    }
                    counter++;
                }
            }
        }

        private static void GenerateFloorFromCode(string floorLayout){
            Tilemap ground = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            int counter = 0;
            for(int y = 4; y >= -5; y--){
                for(int x = -11; x <= 10; x++){
                    Vector3Int pos = new Vector3Int(x,y,0);
                    while(floorLayout[counter] == ' ' || floorLayout[counter] == '\n' || floorLayout[counter] == '\t' || floorLayout[counter] == '\v' || floorLayout[counter] == '\r'){
                        counter++;
                    }
                    if(ground.HasTile(pos)){
                        ground.SetTile(pos, null);
                    }
                    if(floorLayout[counter] != '1'){
                        ground.SetTile(pos, s_floor);
                        if(floorLayout[counter] == 'I'){
                            GenerateObject(s_ice, ground.CellToWorld(pos));
                        }
                        else if(floorLayout[counter] == 'S'){
                            counter++;
                            char p = floorLayout[counter];
                            switches.Add(p,GenerateObject(s_switch, ground.CellToWorld(pos)).GetComponent<Switch>());
                        }
                        else if(floorLayout[counter] == 'F'){
                            GenerateObject(s_flag, ground.CellToWorld(pos));
                        }
                    }
                    counter++;
                }
            }
        }

        private static GameObject GenerateObject(GameObject obj, Vector3 pos){
            return MonoBehaviour.Instantiate<GameObject>(obj, pos, Quaternion.identity);
        }

        private static GameObject s_ice => SceneGenerator.Instance.Ice;
        private static GameObject s_switch => SceneGenerator.Instance.Switch;
        private static GameObject s_flag => SceneGenerator.Instance.Flag;
        private static GameObject s_gun => SceneGenerator.Instance.Gun;
        private static GameObject s_box => SceneGenerator.Instance.Box;
        private static GameObject s_player => SceneGenerator.Instance.Player;
        private static GameObject s_door => SceneGenerator.Instance.Door;
        private static GameObject s_key => SceneGenerator.Instance.Key;
        private static GameObject s_gate => SceneGenerator.Instance.Gate;
        private static GameObject s_spike => SceneGenerator.Instance.Spike;
        private static TileBase s_floor => SceneGenerator.Instance.GroundTile;

    }
}
