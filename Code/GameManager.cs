using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sokoban
{
    public class GameManager : MonoBehaviour
    {
        private Highlight[] _desiredSquares;

        private void Start(){
            _desiredSquares = GameObject.FindObjectsOfType<Highlight>();
        }

        private void Update(){
            bool won = true;
            foreach(Highlight h in _desiredSquares){
                won &= h.BoxOn;
            }
            if(won)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
