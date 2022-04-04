using UnityEngine;
using Sokoban.Dict;

namespace Sokoban.Grid
{
    public class TileGrid : MonoBehaviour
    {
        private Tile[,] _grid;
        private Vector2Int _gridSize = new Vector2Int(14,14);
        private Vector2Int _cellSize;
        private Vector2Int _generationStartPos;

        [SerializeField] private Dict<char, Tile> _tilePrefabs;
        [SerializeField] private Dict<char, TileCover> _coverPrefabs;
        [SerializeField] private Dict<char, TileObject> _objectPrefabs;

        private void Start(){
            _grid = new Tile[_gridSize.x, _gridSize.y];
            Vector2Int center = new Vector2Int((int)transform.position.x, (int)transform.position.y);
            Vector2Int area = new Vector2Int((int)transform.localScale.x, (int)transform.localScale.y);
            _cellSize = new Vector2Int(area.x / _gridSize.x, area.y / _gridSize.y);
            _generationStartPos = center - area/2;
            InitializeGrid(Levels.All[GameManager.Instance.LevelIndex].LevelCode);
        }

        public Tile GetTile(Vector2Int pos){
            if(pos.x < 0 || pos.x >= _gridSize.x || pos.y < 0 || pos.y >= _gridSize.y) return null;
            return _grid[pos.x, pos.y];
        }

        public Vector2Int WorldToGrid(Vector2 pos){
            Vector2 topLeft = new Vector2(-_gridSize.x/2, _gridSize.y/2);
            Vector2 dist = new Vector2(Mathf.Abs(pos.x - topLeft.x), Mathf.Abs(pos.y - topLeft.y));
            return new Vector2Int(Mathf.FloorToInt(dist.x), Mathf.FloorToInt(dist.y));
        }

        public void MoveTile(TileObject obj, Vector2Int from, Vector2Int to){
            obj.transform.position = GetTile(to).transform.position;
            GetTile(from).SetObject(null);
            GetTile(to).SetObject(obj);
        } 

        public void InitializeGrid(string levelCode){
            levelCode = string.Concat(levelCode.Split(new char[]{'\n', '\t', '\v', '\r', ' '}));
            int counter = 0;
            for(int y = 0; y < _gridSize.y; y++){
                for(int x = 0; x < _gridSize.x; x++){
                    Vector2Int rPos =  _generationStartPos + _cellSize * new Vector2Int(x,y);
                    if(counter < levelCode.Length - 1)
                        counter = ParseTile(levelCode, counter, x, y, rPos, _cellSize);
                    else
                        _grid[x,y] = Instantiate<Wall>((Wall)_tilePrefabs['#']);
                }
            }
        }

        private int ParseTile(string levelCode, int counter, int x, int y, Vector2Int renderPos, Vector2Int scale){
            _grid[x,y] = Instantiate<Tile>(_tilePrefabs[levelCode[counter]]);
            counter++;
            if(levelCode[counter] == '('){
                counter = ParseCover(levelCode, ++counter, x, y, renderPos, scale);
                counter++;
            }
            return counter;
        }

        private int ParseCover(string levelCode, int counter, int x, int y, Vector2Int renderPos, Vector2Int scale){
            _grid[x,y].SetCover(Instantiate<TileCover>(_coverPrefabs[levelCode[counter]]));
            counter++;
            if(levelCode[counter] == '('){
                counter = ParseObject(levelCode, ++counter, x, y, renderPos, scale);
                counter++;
            }
            return counter;
        }

        private int ParseObject(string levelCode, int counter, int x, int y, Vector2Int renderPos, Vector2Int scale){
            _grid[x,y].SetObject(Instantiate<TileObject>(_objectPrefabs[levelCode[counter]]));
            return ++counter;
        }
  
    }
}

