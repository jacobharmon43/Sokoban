using UnityEngine.InputSystem;
using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : TileObject{

        private InputActionMap _map;
        private InputAction _up;
        private InputAction _left;
        private InputAction _down;
        private InputAction _right;
        private InputAction _reset;
        private InputAction _pause;

        protected override void Awake(){
            _map = GetComponent<PlayerInput>().currentActionMap;
            _up = _map.FindAction("Up");
            _left = _map.FindAction("Left");
            _down = _map.FindAction("Down");
            _right = _map.FindAction("Right");
            _reset = _map.FindAction("Reset");
            _pause = _map.FindAction("Pause");

            _right.started += ctx => Move(Vector2Int.right);
            _left.started += ctx => Move(Vector2Int.left);
            _up.started += ctx => Move(Vector2Int.down);
            _down.started += ctx => Move(Vector2Int.up);
            //_reset.started += ctx => GameManager.Instance.ReloadScene();
            //_pause.started += ctx => GameManager.Instance.ReloadScene();
        }

        public void Move(Vector2Int direction){
            Vector2Int nextPos = _gridPosition + direction;
            Tile t = _tileGrid.GetTile(nextPos);
            if(t && t.isGround){
                TileObject to = t.GetObject();
                if(to){
                    Dynamic d = (Dynamic) to;
                    if(!d || !d.Move(direction)) return;
                }
                _tileGrid.MoveTile(this, _gridPosition, nextPos);
                _gridPosition += direction;
                transform.position = t.transform.position;
            }
        }
    }
}
