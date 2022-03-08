using UnityEngine;

namespace BlockPuzzle.Player
{
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerController : Pushable
    {
        private PlayerInputReader _input;
        private Vector2 direction;

        private void Awake(){
            _input = GetComponent<PlayerInputReader>();
        }

        private void Update(){
            if(_timer > 0){
                _timer -= Time.deltaTime;
                return;
            }

            /* Input prodding */

            Vector2 movement = _input.Input;
            Vector2 rotation = _input.Rotation;
            if(movement.x != 0) movement *= Vector2.right; //Prioritize X movement.
            movement = movement.normalized;

            Move(movement);
            if(_input.Action){
                PlayerAction();
            }
            RotatePlayer(movement, rotation);
        }

        private void Move(Vector2 movement){
            if(movement != Vector2.zero){
                Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
                _timer = _delay;

            }
        }

        private void PlayerAction(){
            Debug.DrawRay(transform.position, direction, Color.red, 2);
        }

        private void RotatePlayer(Vector2 movement, Vector2 rotational){
            Quaternion curr = transform.rotation;
            if(movement != Vector2.zero)
            {
                float angle = 0;
                if(movement.x != 0)
                    angle = movement.x > 0 ? 0 : 180;
                else if(movement.y != 0)
                    angle = movement.y > 0 ? 90 : 270;
                transform.rotation = Quaternion.Euler(curr.x, curr.y, angle);
                direction = movement;
            } 
            else if(rotational != Vector2.zero){
                float angle = 0;
                if(rotational.x != 0)
                    angle = rotational.x > 0 ? 0 : 180;
                else if(rotational.y != 0)
                    angle = rotational.y > 0 ? 90 : 270;
                transform.rotation = Quaternion.Euler(curr.x, curr.y, angle);
                direction = rotational;
            }
        }
    }
}
