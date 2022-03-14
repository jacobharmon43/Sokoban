using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace BlockPuzzle
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}
        public string LevelCode;

        private void Awake(){
            if(Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadScene(int i){
            SceneManager.LoadScene(i);
        }

        public void RunChecks(){
            foreach(IUpdate u in ObjectStore.OfTypeInList<IUpdate>()){
                u.UpdateAction();
            }
        }

        public void SetCode(InputField i){
            LevelCode = i.text;
        }
    }
}
