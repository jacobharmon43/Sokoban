using UnityEngine;
using Sokoban.Dict;

namespace Sokoban.Grid
{
    public class TileGrid : MonoBehaviour
    {
        private Tile[,] _grid;
        private Vector2Int _gridSize = new Vector2Int(14,14);
        private Vector2 _cellSize;
        private Vector2 _generationStartPos;

        [SerializeField] private Dict<char, Tile> _tilePrefabs;
        [SerializeField] private Dict<char, TileCover> _coverPrefabs;
        [SerializeField] private Dict<char, TileObject> _objectPrefabs;

        private void Awake(){
            _grid = new Tile[_gridSize.x, _gridSize.y];
            Vector2 center = new Vector2(transform.position.x, transform.position.y);
            Vector2 area = new Vector2(transform.localScale.x, transform.localScale.y);
            _cellSize = new Vector2(area.x / _gridSize.x, area.y / _gridSize.y);
            _generationStartPos = center + Vector2.right * (-area.x/2 + _cellSize.x/2) + Vector2.up * (area.y/2 - _cellSize.y/2) ;
        }

        public Tile GetTile(Vector2Int pos){
            if(pos.x < 0 || pos.x >= _gridSize.x || pos.y < 0 || pos.y >= _gridSize.y) return null;
            return _grid[pos.x, pos.y];
        }

        public Vector2 Scale => _cellSize;
        public Tile[,] GetTiles() => _grid;

        public Vector2Int WorldToGrid(Vector2 pos){
            Vector2 topLeft = new Vector2(-_gridSize.x/2, _gridSize.y/2);
            Vector2 dist = new Vector2(Mathf.Abs(pos.x - topLeft.x), Mathf.Abs(pos.y - topLeft.y));
            return new Vector2Int(Mathf.FloorToInt(dist.x), Mathf.FloorToInt(dist.y));
        }

        public void MoveTile(TileObject obj, Vector2Int from, Vector2Int to){
            GetTile(from).SetObject(null);
            GetTile(to).SetObject(obj);
        } 

        public void InitializeGrid(string levelCode){
            levelCode = string.Concat(levelCode.Split(new char[]{'\n', '\t', '\v', '\r', ' '}));
            int counter = 0;
            for(int y = 0; y < _gridSize.y; y++){
                for(int x = 0; x < _gridSize.x; x++){
                    Vector3 rPos =  (Vector2)_generationStartPos + (Vector2)_cellSize * new Vector2(x,-y);
                    if(counter < levelCode.Length - 1)
                        counter = ParseTile(levelCode, counter, x, y, rPos);
                    else{
                        Tile t = Instantiate<Tile>(_tilePrefabs['#'], rPos, Quaternion.identity);
                        _grid[x,y] = t;
                        t.transform.localScale = new Vector2(_cellSize.x, _cellSize.y);
                    }
                }
            }
        }

        private int ParseTile(string levelCode, int counter, int x, int y, Vector3 renderPos){
            Debug.Log(levelCode[counter]);
            Tile t = Instantiate<Tile>(_tilePrefabs[levelCode[counter]], renderPos, Quaternion.identity);
            _grid[x,y] = t;
            t.transform.localScale = new Vector2(_cellSize.x, _cellSize.y);
            if(levelCode[++counter] == '('){
                counter = ParseCover(levelCode, ++counter, x, y, renderPos);
            }
            return counter;
        }

        private int ParseCover(string levelCode, int counter, int x, int y, Vector3 renderPos){
            Debug.Log(levelCode[counter]);
            if(_coverPrefabs[levelCode[counter]]){
                TileCover tc = Instantiate<TileCover>(_coverPrefabs[levelCode[counter]], renderPos, Quaternion.identity);
                _grid[x,y].SetCover(tc);
                tc.SetGrid(this);
                tc.SetGridPos(new Vector2Int(x,y));
                tc.transform.localScale = new Vector2(_cellSize.x, _cellSize.y);
                counter++;
                if(levelCode[counter] == '('){
                    counter = ParseObject(levelCode, ++counter, x, y, renderPos);
                }
            }
            else{
                counter = ParseObject(levelCode, counter, x, y, renderPos);
            }
            return ++counter;
        }

        private int ParseObject(string levelCode, int counter, int x, int y, Vector3 renderPos){
            Debug.Log(levelCode[counter]);
            TileObject to = Instantiate<TileObject>(_objectPrefabs[levelCode[counter]], renderPos, Quaternion.identity);
            if(to.GetType() == typeof(Player)){
                GameManager.Instance.Player = (Player)to;
            }
            else if(to.GetType() == typeof(LaserGun)){
                ((LaserGun)to).Init(levelCode[++counter]);
                Debug.Log(levelCode[counter]);
            }
            else if(to.GetType() == typeof(Prism)){
                ((Prism)to).Init(levelCode[++counter]);
            }
            _grid[x,y].SetObject(to);
            to.SetGrid(this);
            to.SetGridPos(new Vector2Int(x,y));
            to.transform.localScale = Scale;
            return ++counter;
        }
  
    }
}

