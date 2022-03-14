using UnityEngine.UI;
using UnityEngine;

namespace BlockPuzzle
{
    public class SecondaryCharButton : MonoBehaviour
    {
        private void Awake(){
            GetComponent<Button>().onClick.AddListener(() => UpChar());
        }

        private void UpChar(){
            char c =  GetComponentInChildren<Text>().text[0];
            c++;
            GetComponentInChildren<Text>().text = $"{c}";
        }
    }
}
