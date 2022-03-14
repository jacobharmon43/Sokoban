using UnityEngine.UI;
using UnityEngine;

namespace BlockPuzzle
{
    public class CodeGen : MonoBehaviour
    {
        public InputField displayText;
        public GameObject ButtonHolder;

        private void Awake(){
            GetComponent<Button>().onClick.AddListener(() => GenerateCode());
        }

        private void GenerateCode(){
            string s = "";
            foreach(Button b in ButtonHolder.GetComponentsInChildren<Button>()){
                s += b.GetComponentInChildren<Text>().text;
                if(s == "S" || s =="G"){
                    s += b.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text;
                }
            }
            displayText.text = s;
        }
    }
}
