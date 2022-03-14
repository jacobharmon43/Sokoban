using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace BlockPuzzle
{
    public class LevelGenButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        public int state = 0;
        char[] possibleChars = {'1','0','P','B','D','K','S','G','F'};
        [SerializeField] Image img;
        [SerializeField] Button secondary;
        [SerializeField] Sprite[] images;

        public void SwitchState(int swap){
            state += swap;
            img.color = Color.white;
            secondary.gameObject.SetActive(false);
            if(state >= possibleChars.Length){
                state = 0;
            }
            if(state < 0){
                state = possibleChars.Length - 1;
            }
            switch (possibleChars[state]){
                case '1':
                    img.color = Color.black;
                    break;
                case '0':
                    break;
                case 'P':
                    break;
                case 'B':
                    break;
                case 'D':
                    break;
                case 'K':
                    break;
                case 'S':
                    secondary.gameObject.SetActive(true);
                    break;
                case 'G':
                    secondary.gameObject.SetActive(true);
                    break;
                case 'F':
                    break;
                default:
                    break;
            }
            img.sprite = images[state];
            GetComponentInChildren<Text>().text = $"{possibleChars[state]}";
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if(Mouse.current.leftButton.isPressed){
                state = 0;
                SwitchState(1);
            }
            else if(Mouse.current.rightButton.isPressed){
                state = 1;
                SwitchState(-1);
            }
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left){
                SwitchState(1);
            }
            else if(eventData.button == PointerEventData.InputButton.Right){
                SwitchState(-1);
            }
        }
    }
}
