using UnityEngine;
using UnityEngine.SceneManagement;
using static Sokoban.Levels;

namespace Sokoban
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}
        private Highlight[] _desiredSquares;
        public Level current;
        public int MoveCount;
        private int index = 0;

        private void Awake(){
            if(Instance == null){
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(this);
            current = levels[0];
        }

        private void Update(){
            bool won = true;
            foreach(Highlight h in GameObject.FindObjectsOfType<Highlight>()){
                won &= h.BoxOn;
            }
            if(won){
                MoveCount = 0;
                if(index < levels.Length - 1)
                    current = levels[++index];
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
                
        }
    }
}
