using UnityEngine;
using UnityEngine.InputSystem;

namespace BlockPuzzle.Player{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputReader : MonoBehaviour
    {
        private InputActionMap _map;
        private InputAction _movement;
        private InputAction _kick;
        private InputAction _rotation;

        private void Awake(){
            _map = GetComponent<PlayerInput>().currentActionMap;
            _movement = _map.FindAction("Movement");
            _kick = _map.FindAction("Kick");
            _rotation = _map.FindAction("Rotation");
        }

        public Vector2 Input => _movement.ReadValue<Vector2>();
        public Vector2 Rotation => _rotation.ReadValue<Vector2>();
        public bool Kick => _kick.ReadValue<float>() != 0;
    }
}
