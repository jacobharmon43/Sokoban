using UnityEngine;

namespace BlockPuzzle
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : Pushable
    {
        private PlayerInputReader _input;

        private float _delay = 0.12f;
        private float _timer = 0;

        protected override void Awake(){
            base.Awake();
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
            _timer = _delay;
            Vector2 movement = _input.Input;
            Movement(movement);
        }

        private void Movement(Vector2 movement){
            if(movement.x != 0) movement *= Vector2.right; //Prioritize X movement.
            movement = movement.normalized;
            if(movement != Vector2.zero){
                Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
                GameManager.Instance.RunChecks();
            }
        }

        public override bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileObject to = ObjectOnTile(nextPos);
            if(to){
                to.ContactEvent(this, input);
                if(!to.blocking || !(to.GridPosition == nextPos))
                    DoTheMove(nextPos, input);
            }
            else
                DoTheMove(nextPos, input);
            return false;
        }

        private void DoTheMove(Vector3Int nextPos, Vector3Int input){
            TileMaterial tm = MaterialOfTile(nextPos);
            if(tm){
                tm.OnTopEvent(this, input);
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
        }
    }
}
