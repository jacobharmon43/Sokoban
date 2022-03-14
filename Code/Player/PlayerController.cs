using UnityEngine;

namespace BlockPuzzle
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : Pushable
    {
        private PlayerInputReader _input;

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

        public override bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            Physical p = NextTileObject(nextPos);
            if(p && p.active){
                Pushable push = p.GetComponent<Pushable>();
                if(push && !push.Move(input))
                    return false;  
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
            return true;
        }
    }
}
