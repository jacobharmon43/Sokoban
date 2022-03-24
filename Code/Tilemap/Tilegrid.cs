using UnityEngine;

namespace Sokoban.Grid
{
    public class Tilegrid : MonoBehaviour
    {
        public Tile[,] Grid;

        [SerializeField] private int gridHeight;
        [SerializeField] private int gridWidth;

        private Vector2 cellSize = Vector2.one;
        private Vector2 generationStartPos;

        [SerializeField] private Tile[] allTiles;
        [SerializeField, TextArea] private string testCode;

        private void Awake(){
            transform.localScale = new Vector2(gridWidth, gridHeight);
            Grid = new Tile[gridWidth, gridHeight];
            generationStartPos = new Vector3((cellSize.x-gridWidth)/2, (gridHeight - cellSize.y)/2);
        }

        private void Start(){
            GenerateGridFromCode(testCode);
        }

        public void GenerateGridFromCode(string code){
            code = string.Concat(code.Split(new char[]{'\n', 't', '\v', 'r',' '}));
            for(int y = 0; y < gridHeight; y++){
                for(int x = 0; x < gridWidth; x++){
                    Debug.Log(y* gridWidth + x);
                    char currentChar = code[y* gridWidth + x];
                    int selection;
                    switch (currentChar){
                        case '.':
                            selection = 0;
                            break;
                        case '#':
                            selection = 2;
                            break;
                        case 'I':
                            selection = 1;
                            break;
                        default:
                            selection = 2;
                            break;
                    }
                    Grid[x,y] = Instantiate<Tile>(allTiles[selection], generationStartPos + new Vector2(cellSize.x * x, -cellSize.y * y), Quaternion.identity);
                    Grid[x,y].transform.localScale = cellSize;
                }
            }
        }

        public Tile GetTile(Vector3Int pos){
            return Grid[pos.x, pos.y];
        }
    }
}
