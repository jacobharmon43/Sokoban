using UnityEngine;

namespace BlockPuzzle
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : Pushable
    {
        private PlayerInputReader _input;

        private float _delay = 0.15f;
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
            if(_input.Left)
                Movement(new Vector2(-1,0));
            if(_input.Right)
                Movement(new Vector2(1,0));
            if(_input.Up)
                Movement(new Vector2(0,1));
            if(_input.Down)
                Movement(new Vector2(0,-1));
        }

        private void Movement(Vector2 movement){
            if(movement != Vector2.zero){
                GameManager.Instance.RunChecks();
                Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
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
