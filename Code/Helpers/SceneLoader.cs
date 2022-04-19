using UnityEngine.SceneManagement;
using UnityEngine;

namespace Sokoban
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string name){
            SceneManager.LoadScene(name);
        }
    }
}
