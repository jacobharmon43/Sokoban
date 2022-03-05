using UnityEngine;

namespace BlockPuzzle.Player
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : TileBound
    {
        private PlayerInputReader _input;

        private float _delay = 0.1f;
        private float _timer = 0.0f;

        [SerializeField] private LayerMask _pushableLayer;
    

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
        }

        public override void Move(Vector3Int input)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(input.x, input.y), 1, _pushableLayer);
            if(hit){
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Slidable>().Move(input);
            }
            base.Move(input);
        }
    }
}
