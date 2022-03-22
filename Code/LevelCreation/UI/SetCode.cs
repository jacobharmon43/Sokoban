using UnityEngine.UI;
using UnityEngine;

namespace BlockPuzzle
{
    public class SetCode : MonoBehaviour
    {
        public InputField i;

        private void Start(){
            GetComponent<Button>().onClick.AddListener(() => LevelCodeCarrier.Instance.SetCode(i.text));
            GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.LoadScene(1));
        }
    }
}
