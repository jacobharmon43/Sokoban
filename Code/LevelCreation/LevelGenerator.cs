using UnityEngine;

namespace BlockPuzzle
{
    public class LevelGenerator : MonoBehaviour
    {
        private void Start(){
            SceneGenerator.GenerateLevelFromCode(LevelCodeCarrier.Instance.LevelCode);
        }
    }
}
