using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace BlockPuzzle
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}

        private void Awake(){
            if(Instance == null){
                Instance = this;
            }
            else
                Destroy(gameObject);
        }

        public void LoadScene(int i){
            SceneManager.LoadScene(i);
        }

        public void RunChecks(){
            foreach(Gun g in ObjectStore.OfTypeInList<Gun>()){
                g.GetComponent<IUpdate>().UpdateAction();
            }
            foreach(IUpdate u in ObjectStore.OfTypeInList<IUpdate>()){
                if(u.GetType() == typeof(Gun)) continue;
                u.UpdateAction();
            }
        }

        public void ResetScene(){
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
