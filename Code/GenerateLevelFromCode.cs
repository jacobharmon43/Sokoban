using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class GenerateLevelFromCode
    {
        public static GenerateLevelFromCode Instance {get; private set;}
        [SerializeField] private GameObject _floor;
        [SerializeField] private GameObject _ice;
        [SerializeField] private GameObject _switch;
        [SerializeField] private GameObject _flag;

        private static Dictionary<char, GameObject> Storage = new Dictionary<char, GameObject>(){
            {'1', null},
            {'.', null},
            {'0', GenerateLevelFromCode.Instance._floor},
            {'I', GenerateLevelFromCode.Instance._ice},
            {'S', GenerateLevelFromCode.Instance._switch},
            {'F', GenerateLevelFromCode.Instance._flag}
        };

        public static void GenerateLevel(string floorCode, string objectCode){
            Tilemap ground = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            int floorCount = 0;
            int objectCount = 0;
            for(int y = 4; y >= -5; y--){
                for(int x = -11; x <= 10; x++){
                    Vector3Int position = new Vector3Int(x,y,0);
                    Vector3 pos = ground.CellToWorld(position);
                    if(ground.HasTile(position)){
                        ground.SetTile(position, null);
                    }
                    floorCount = floorCodeParser(floorCount, floorCode, pos);
                    objectCount = itemCodeParser(objectCount, objectCode, pos);
                }
            }
        }

        private static int floorCodeParser(int count, string floorCode, Vector3 pos){
            GameObject spawned = GenParse(ref count, floorCode, pos);
            switch (floorCode[count]){
                case 'S':
                    //Set up switch to be wired
                    break;
            }
            return count;
        }

        private static int itemCodeParser(int count, string itemCode, Vector3 pos){
            GameObject spawned = GenParse(ref count, itemCode, pos);
            switch (itemCode[count]){
                case 'L':
                    count++;
                    spawned.GetComponent<Gun>().rotationChar = itemCode[count];
                    break;
            }
            return count;
        }

        private static GameObject GenParse(ref int count, string code, Vector3 pos){
            while(code[count] == ' ' || code[count] == '\n' || code[count] == '\t' || code[count] == '\v' || code[count] == '\r'){
                count++;
            }
            return GenerateObject(Storage[code[count]], pos);
        }

        private static GameObject GenerateObject(GameObject g, Vector3 pos){
            return MonoBehaviour.Instantiate<GameObject>(g, pos, Quaternion.identity);
        }
    }
}
