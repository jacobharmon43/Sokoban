using UnityEngine;
using UnityEngine.InputSystem;
using Sokoban.Grid;

namespace Sokoban{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : Dynamic{
        private InputActionMap _map;
        private InputAction _up;
        private InputAction _left;
        private InputAction _down;
        private InputAction _right;

        // Start is called before the first frame update
        private void Awake(){
            _map = GetComponent<PlayerInput>().currentActionMap;
            _up = _map.FindAction("Up");
            _left = _map.FindAction("Left");
            _down = _map.FindAction("Down");
            _right = _map.FindAction("Right");

            _right.started += ctx => Move(Vector2Int.right);
            _left.started += ctx => Move(Vector2Int.left);
            _up.started += ctx => Move(Vector2Int.down);
            _down.started += ctx => Move(Vector2Int.up);
        }

        public override bool Move(Vector2Int input)
        {
            Tile t = _tiles.GetTile(GridPosition + input);
            TileObject to = t.Object;
            Dynamic d = to ? to.GetComponent<Dynamic>() : null;
            if(t && t.ground && (!to || (d && d.Move(input)))){
                SetToPos(input, t, _tiles);
                GameManager.Instance.MoveCount++;
                return true;
            }
            return false;
        }
    }
}
