using UnityEngine;

namespace BlockPuzzle
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : Pushable
    {
        private PlayerInputReader _input;
        [SerializeField] private float _delay = 0.15f;
        private float _timer = 0.0f;

        private void Awake(){
            _input = GetComponent<PlayerInputReader>();
        }

        private void Update(){
            if(_input.Reset){
                GameManager.Instance.ResetScene();
            }
            if(_timer > 0){
                _timer -= Time.deltaTime;
                return;
            }

            /* Input prodding */
            Vector2 movement = _input.Input;
            if(movement.x != 0) movement *= Vector2.right; //Prioritize X movement.
            movement = movement.normalized;
            Movement(movement);
        }

        private void Movement(Vector2 movement){
            if(movement != Vector2.zero){
                Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
                _timer = _delay;
                GameManager.Instance.RunChecks();
            }
        }

        public override void Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return;
            TileObject to = NextTileObject(nextPos);
            if(to){
                to.ContactEvent(this, input);
                if(to.blocking && to.GridPosition == nextPos){
                    return;
                }
                
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
        }
    }
}
