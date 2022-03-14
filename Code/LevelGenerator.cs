using UnityEngine;

namespace BlockPuzzle
{
    public class LevelGenerator : MonoBehaviour
    {
        private void Start(){
            Debug.Log(GameManager.Instance.LevelCode);
            SceneGenerator.GenerateLevelFromCode(GameManager.Instance.LevelCode);
            Flag[] flags = ObjectStore.OfTypeInList<Flag>().ToArray();
            foreach(Flag f in flags){
                f.contactEvent.AddListener(delegate {GameManager.Instance.LoadScene(0);});
            }
        }
    }
}
