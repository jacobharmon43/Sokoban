using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class LoadEditorFromCode : MonoBehaviour
    {
        [SerializeField] private InputField i;
        [SerializeField] private GameObject buttonHolder;
        private List<char> possibleChars = new List<char>{'1','0','P','B','D','K','S','G','F'};

        private void Start(){
            GetComponent<Button>().onClick.AddListener(() => GenerateLevelEditor());
        }

        private void GenerateLevelEditor(){
            string code = i.text;
            int counter = 0;
            foreach(LevelGenButton b in buttonHolder.GetComponentsInChildren<LevelGenButton>()){
                b.state = possibleChars.IndexOf(code[counter]);
                b.SwitchState(0);
                if(code[counter] == 'S' || code[counter] == 'G'){
                    counter++;
                    b.GetComponentInChildren<SecondaryCharButton>().GetComponentInChildren<Text>().text = code[counter].ToString();
                }
                counter++;
            }
        }
    }
}
