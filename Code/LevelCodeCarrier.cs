using UnityEngine.UI;
using UnityEngine;

namespace BlockPuzzle
{
    public class LevelCodeCarrier : MonoBehaviour
    {
        public static LevelCodeCarrier Instance {get; private set;}

        private void Awake(){
            if(Instance == null){
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);
        }

        public string LevelCode;

        public void SetCode(string i){
            LevelCode = i;
        }
    }
}
