using UnityEngine.UI;
using UnityEngine;

namespace BlockPuzzle
{
    public class SecondaryCharButton : MonoBehaviour
    {
        public char[] list = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
        public int loc = 0;

        private void Awake(){
            GetComponent<Button>().onClick.AddListener(() => UpChar());
        }

        private void UpChar(){
            loc++;
            if(loc >= list.Length){
                loc = 0;
            }
            GetComponentInChildren<Text>().text = $"{list[loc]}";
        }
    }
}
