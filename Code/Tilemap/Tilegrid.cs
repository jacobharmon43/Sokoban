using UnityEngine;
using System.Collections.Generic;
using Sokoban.Dict;
using static Sokoban.Dict.DictHelp;

namespace Sokoban.Grid
{
    public class Tilegrid : MonoBehaviour
    {
        public Tile[,] Grid;

        [SerializeField] private int gridHeight = 10;
        [SerializeField] private int gridWidth = 10;

        private Vector2 cellSize = Vector2.one;
        private Vector2 generationStartPos;

        [SerializeField] private Dict<char, Tile>[] allTiles;
        [SerializeField] private Dict<char, TileObject>[] allObjects;
        [SerializeField] private Dict<char, TileCover>[] allCovers;

        public string testTileCode;
        public string testObjectCode;

        private Dictionary<char, List<Switch>> _switches = new Dictionary<char, List<Switch>>();
        private Dictionary<char, List<Switchable>> _switchables = new Dictionary<char, List<Switchable>>();


        private void Start(){
            transform.localScale = new Vector2(gridWidth, gridHeight);
            Grid = new Tile[gridWidth, gridHeight];
            generationStartPos = new Vector3((cellSize.x-gridWidth)/2, (gridHeight - cellSize.y)/2);
            GenerateGridFromCode(GameManager.Instance.current.TileCode);
            GenerateObjectsFromCode(GameManager.Instance.current.ObjectCode);
            foreach(var g in _switchables){
                foreach(Switchable s in g.Value){
                    s.Switches = _switches[g.Key].ToArray();
                }
                
            }
        }

        public void GenerateGridFromCode(string code){
            code = string.Concat(code.Split(new char[]{'\n', 't', '\v', 'r',' ', (char)13}));
            for(int y = 0; y < gridHeight; y++){
                for(int x = 0; x < gridWidth; x++){
                    char currentChar = code[y* gridWidth + x];
                    Grid[x,y] = Instantiate<Tile>(DictSearch<char, Tile>(allTiles, currentChar), generationStartPos + new Vector2(cellSize.x * x, -cellSize.y * y), Quaternion.identity);
                }
            }
        }

        public void GenerateObjectsFromCode(string code){
            int counter = 0;
            code = string.Concat(code.Split(new char[]{'\n', 't', '\v', 'r',' ', (char)13}));
            for(int y = 0; y < gridHeight; y++){
                for(int x = 0; x < gridWidth; x++){
                    counter = ParseInstantiateObject(counter, code, x, y);
                }
            }
        }

        public Tile GetTile(Vector2Int pos){
            if(pos.x < 0 || pos.x >= gridWidth || pos.y < 0 || pos.y >= gridHeight) return null;
            return Grid[pos.x, pos.y];
        }

        public Vector2Int WorldToGrid(Vector2 pos){
            Vector2 topLeft = new Vector2(-gridWidth/2, gridHeight/2);
            Vector2 dist = new Vector2(Mathf.Abs(pos.x - topLeft.x), Mathf.Abs(pos.y - topLeft.y));
            return new Vector2Int(Mathf.FloorToInt(dist.x), Mathf.FloorToInt(dist.y));
        }

        private int ParseInstantiateObject(int counter, string code, int x, int y){
            TileObject t = DictSearch<char, TileObject>(allObjects, code[counter]);
            TileCover c = DictSearch<char, TileCover>(allCovers, code[counter]);
            if(t)
                Grid[x,y].AddTileObject(Instantiate<TileObject>(t, Grid[x,y].transform.position, Quaternion.identity));
            else if(c)
                Grid[x,y].AddCover(Instantiate<TileCover>(c, Grid[x,y].transform.position, Quaternion.identity));

            //Special cases:
            //Highlight tile case, because you can spawn objects already on a highlight tile.
            if(code[counter] == 'H'){
                if(counter < code.Length && code[counter + 1] == '('){
                    counter+=2;
                    while(code[counter] != ')'){
                        counter = ParseInstantiateObject(counter, code, x, y);
                    }
                }
            }
            else if(code[counter] == 'G'){
                counter++;
                if(_switchables.ContainsKey(code[counter]))
                    _switchables[code[counter]].Add(Grid[x,y].Cover.GetComponent<Switchable>());
                else
                    _switchables.Add(code[counter], new List<Switchable>{Grid[x,y].Object.GetComponent<Switchable>()});
            }
            else if(code[counter] == 'S'){
                counter++;
                if(_switches.ContainsKey(code[counter]))
                    _switches[code[counter]].Add(Grid[x,y].Cover.GetComponent<Switch>());
                else
                    _switches.Add(code[counter], new List<Switch>{Grid[x,y].Cover.GetComponent<Switch>()});
                if(counter < code.Length && code[counter + 1] == '('){
                    counter+=2;
                    while(code[counter] != ')'){
                        counter = ParseInstantiateObject(counter, code, x, y);
                    }
                }
            }
            else if(code[counter] == 'L'){
                if(counter < code.Length && code[counter + 1] == '('){
                    counter+=2;
                    Grid[x,y].Object.GetComponent<Gun>().dirChar = code[counter];
                    if(code[counter+1] != ')'){
                        counter++;
                        if(_switchables.ContainsKey(code[counter]))
                            _switchables[code[counter]].Add(Grid[x,y].Object.GetComponent<Switchable>());
                        else
                            _switchables.Add(code[counter], new List<Switchable>{Grid[x,y].Object.GetComponent<Switchable>()});
                    }
                    counter++;
                }
            }
            counter++;
            
            return counter;
        }
    }
}

