using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace BlockPuzzle
{
    public class LevelGenButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        int state = 0;
        char[] possibleChars = {'1','0','P','B','D','K','S','G','F'};
        [SerializeField] Image img;
        [SerializeField] Button secondary;
        [SerializeField] Sprite[] images;

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left){
                SwitchState(1);
            }
            else if(eventData.button == PointerEventData.InputButton.Right){
                SwitchState(-1);
            }
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

        private void SwitchState(int swap){
            state += swap;
            if(state >= possibleChars.Length){
                state = 0;
            }
            if(state < 0){
                state = possibleChars.Length - 1;
            }
            switch (possibleChars[state]){
                case '1':
                    img.color = Color.black;
                    secondary.gameObject.SetActive(false);
                    break;
                case '0':
                    img.color = Color.white;
                    secondary.gameObject.SetActive(false);
                    break;
                case 'P':
                    break;
                case 'B':
                    break;
                case 'D':
                    break;
                case 'K':
                    secondary.gameObject.SetActive(false);
                    break;
                case 'S':
                    secondary.gameObject.SetActive(true);
                    break;
                case 'G':
                    secondary.gameObject.SetActive(true);
                    break;
                case 'F':
                    img.color = Color.white;
                    secondary.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            img.sprite = images[state];
            GetComponentInChildren<Text>().text = $"{possibleChars[state]}";
        }
    }
}
