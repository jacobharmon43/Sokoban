using UnityEngine;

namespace BlockPuzzle
{
    public class LevelGenerator : MonoBehaviour
    {
        public string code;

        private void Awake(){
            code = GameManager.Instance.LevelCode;
        }

        private void Start(){
            SceneGenerator.GenerateLevelFromCode(code);
        }
    }
}
