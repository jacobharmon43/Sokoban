using UnityEngine;
using States;
using static PlayerMovementStates;

namespace BlockPuzzle.Player
{
    [RequireComponent(typeof(PlayerInputReader))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputReader _input;
        private Rigidbody2D _rb;

        private StateMachine _ps;

        private void Awake(){
            _input = GetComponent<PlayerInputReader>();
            _rb = GetComponent<Rigidbody2D>();

            _ps = new StateMachineBuilder()
                .WithState(IDLE)
                .WithTransition(RUNNING, () => _input.Input != Vector2.zero)
                
                .WithState(RUNNING)
                .WithOnRun(() => Move(_input.Input))
                .WithTransition(IDLE, () => _input.Input == Vector2.zero)

                .WithState(KICKING)
                .WithOnEnter(() => Kick())
                .WithTransitionFromAnyState(() => _input.Kick)
                .WithTransition(IDLE, () => true)

                .Build();
        }

        private void Update(){
            _ps.RunStateMachine();
        }

        private void Kick(){
            Debug.Log("Kick");
        }

        private void Move(Vector2 movement){
            transform.position += (Vector3)movement * 6 * Time.deltaTime;
        }
    }
}
