using UnityEngine;

namespace BlockPuzzle.Player
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : TileBound
    {
        private PlayerInputReader _input;

        private void Awake(){
            _input = GetComponent<PlayerInputReader>();
        }

        private void Update(){
            if(_timer > 0){
                _timer -= Time.deltaTime;
                return;
            }
            Vector2 movement = _input.Input;
            Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
            _timer = _delay;
            if(_input.Kick){
                Kick();
            }
        }

        private void Kick(){
            Collider2D[] col = Physics2D.OverlapBoxAll(transform.position, transform.localScale * 2, 0, _pushableLayer);
            foreach(Collider2D c in col){
                Slidable s = c.GetComponent<Slidable>();
                s.Kick(GridPosition - s.GridPosition);
            }
        }
    }
}
