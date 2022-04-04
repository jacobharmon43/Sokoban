using UnityEngine.UI;
using UnityEngine;

namespace Sokoban
{
    public class SidePanel : MonoBehaviour
    {
        private Text _title;
        private Text _objectives;

        // Start is called before the first frame update
        private void Awake()
        {
            _title = transform.Find("Title").GetComponent<Text>();
            _objectives = transform.Find("Objectives").GetComponent<Text>();
        }

        public void Update(){
            _title.text = Levels.All[Levels.LevelIndex].Title;
            _objectives.text = Levels.All[Levels.LevelIndex].Objective;
        }
    }
}
