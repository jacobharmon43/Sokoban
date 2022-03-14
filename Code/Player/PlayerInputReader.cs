using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlockPuzzle
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputReader : MonoBehaviour
    {
        private InputActionMap _map;
        private InputAction _movement;
        private InputAction _reset;

        private void Awake(){
            _map = GetComponent<PlayerInput>().currentActionMap;
            _movement = _map.FindAction("Movement");
            _reset = _map.FindAction("Reset");
        }

        public Vector2 Input => _movement.ReadValue<Vector2>();
        public bool Reset => _reset.ReadValue<float>() == 1;
    }
}
