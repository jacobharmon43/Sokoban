using UnityEngine;

namespace Sokoban
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}

        private void Awake(){
            if(Instance == null){
                Instance = this;
            }
            else
                Destroy(this);
        }

        public int LevelIndex = 0;
    }
}
