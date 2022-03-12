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

        private void Awake(){
            _map = GetComponent<PlayerInput>().currentActionMap;
            _movement = _map.FindAction("Movement");
        }

        public Vector2 Input => _movement.ReadValue<Vector2>();
    }
}
