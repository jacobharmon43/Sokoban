using UnityEngine;

namespace BlockPuzzle.Player
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : TileBound
    {
        private LayerMask _pushableLayer;
        private PlayerInputReader _input;
        private void Awake(){
            _input = GetComponent<PlayerInputReader>();
            _pushableLayer = LayerMask.GetMask("Pushable");
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
                Debug.Log(c.transform.name);
                Slidable s = c.GetComponent<Slidable>();
                s.Kick(_gridPosition - s._gridPosition);
            }
        }

        public override void Move(Vector3Int input)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(input.x, input.y), 1, _pushableLayer);
            if(hit){
                Slidable s = hit.transform.GetComponent<Slidable>();
                s.Move(input);
            }
            base.Move(input);
        }
    }
}
