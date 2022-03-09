using UnityEngine;

namespace BlockPuzzle
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

            Movement(movement);
            if(_input.Action){
                PlayerAction();
            }
            RotatePlayer(movement, rotation);
        }

        private void Movement(Vector2 movement){
            if(movement != Vector2.zero){
                Move(new Vector3Int((int)movement.x, (int)movement.y, 0));
                _timer = _delay;
                GameManager.Instance.RunChecks();
            }
        }

        private void PlayerAction(){
            Debug.DrawRay(transform.position, direction, Color.red, 2);
        }

        private void RotatePlayer(Vector2 movement, Vector2 rotational){
           
            if(movement != Vector2.zero)
            {
                SetRotation(movement);
            } 
            else if(rotational != Vector2.zero){
                SetRotation(rotational);
            }
        }

        private void SetRotation(Vector2 read){
            Quaternion curr = transform.rotation;
            transform.rotation = Quaternion.Euler(curr.x, curr.y, read.x * 90 + read.y * 180);
            direction = read;
        }
    }
}
