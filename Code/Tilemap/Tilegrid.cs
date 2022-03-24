using UnityEngine;

namespace Sokoban.Grid
{
    public class Tilegrid : MonoBehaviour
    {
        public Tile[,] Grid;

        [SerializeField] private int gridHeight = 10;
        [SerializeField] private int gridWidth = 10;

        private Vector2 cellSize = Vector2.one;
        private Vector2 generationStartPos;

        [SerializeField] private Tile[] allTiles;
        [SerializeField] private TileObject[] allObjects;
        [SerializeField] private TileCover[] covers;

        [SerializeField, TextArea] private string testTileCode =  @"##########
                                                                    ###...####
                                                                    #.....####
                                                                    ###...####
                                                                    #.##..####
                                                                    #.#...####
                                                                    #......###
                                                                    #......###
                                                                    ##########
                                                                    ##########";
        [SerializeField, TextArea] private string testObjectCode = @"..........
                                                                     ..........
                                                                     .HPB......
                                                                     ....BH....
                                                                     .H..B.....
                                                                     ....H.....
                                                                     .B.H(B)BBH...
                                                                     ....H.....
                                                                     ..........
                                                                     ..........";


        private void Awake(){
            transform.localScale = new Vector2(gridWidth, gridHeight);
            Grid = new Tile[gridWidth, gridHeight];
            generationStartPos = new Vector3((cellSize.x-gridWidth)/2, (gridHeight - cellSize.y)/2);
            GenerateGridFromCode(testTileCode);
            GenerateObjectsFromCode(testObjectCode);
        }

        public void GenerateGridFromCode(string code){
            code = string.Concat(code.Split(new char[]{'\n', 't', '\v', 'r',' '}));
            for(int y = 0; y < gridHeight; y++){
                for(int x = 0; x < gridWidth; x++){
                    char currentChar = code[y* gridWidth + x];
                    int selection;
                    switch (currentChar){
                        case '.':
                            selection = 0;
                            break;
                        case 'I':
                            selection = 1;
                            break;
                        default:
                            selection = 2;
                            break;
                    }
                    Grid[x,y] = Instantiate<Tile>(allTiles[selection], generationStartPos + new Vector2(cellSize.x * x, -cellSize.y * y), Quaternion.identity);
                }
            }
        }

        public void GenerateObjectsFromCode(string code){
            int counter = 0;
            code = string.Concat(code.Split(new char[]{'\n', 't', '\v', 'r',' '}));
            for(int y = 0; y < gridHeight; y++){
                for(int x = 0; x < gridWidth; x++){
                    ParseInstantiateObject(ref counter, code, x, y);
                    counter++;
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

        private void ParseInstantiateObject(ref int counter, string code, int x, int y){
            int selection;
            bool isObject = true;
            switch (code[counter]){
                case 'P':
                    selection = 0;
                    break;
                case 'B':
                    selection = 1;
                    break;
                case 'W':
                    selection = 2;
                    break;
                case 'S':
                    isObject = false;
                    selection = 0;
                    break;
                case 'H':
                    isObject = false;
                    selection = 1;
                    if(code[++counter] == '('){
                        while(code[++counter] != ')'){
                            ParseInstantiateObject(ref counter, code, x, y);
                        }
                    }
                    break;
                default:
                    return;
            }
            if(isObject)
                Grid[x,y].AddTileObject(Instantiate<TileObject>(allObjects[selection], Grid[x,y].transform.position, Quaternion.identity));
            else
                Grid[x,y].AddCover(Instantiate<TileCover>(covers[selection], Grid[x,y].transform.position, Quaternion.identity));
        }
    }
}
