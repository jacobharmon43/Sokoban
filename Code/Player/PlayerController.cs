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
            if(movement != Vector2.zero){
                Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
                _timer = _delay;
            }
            if(_input.Action){
                PlayerAction();
            }
        }

        private void PlayerAction(){

        }

        public void Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return;
            TileBound t = NextTileObject(nextPos);
            if(t){
                Pushable p = t.GetComponent<Pushable>();
                if(!p) return;
                else if(!p.Move(input)) return;
            }
            Vector3 goTo = GoTo(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
        }
    }
}
