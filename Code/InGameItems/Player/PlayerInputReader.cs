using UnityEngine;
using UnityEngine.InputSystem;

namespace BlockPuzzle
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputReader : MonoBehaviour
    {
        private InputActionMap _map;
        private InputAction _Up;
        private InputAction _Down;
        private InputAction _Left;
        private InputAction _Right;
        private InputAction _reset;

        private void Awake(){
            _map = GetComponent<PlayerInput>().currentActionMap;
            _Up = _map.FindAction("Up");
            _Down = _map.FindAction("Down");
            _Left = _map.FindAction("Left");
            _Right = _map.FindAction("Right");
            _reset = _map.FindAction("Reset");
        }

        public bool Up => _Up.triggered;
        public bool Down => _Down.triggered;
        public bool Left => _Left.triggered;
        public bool Right => _Right.triggered;
        public bool Reset => _reset.ReadValue<float>() == 1;
    }
}
