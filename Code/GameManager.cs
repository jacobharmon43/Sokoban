using UnityEngine;
using Sokoban.Grid;

namespace Sokoban
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}
        public TileGrid Grid;

        private void Awake(){
            if(Instance == null){
                Instance = this;
            }
            else
                Destroy(this);
        }

        public int LevelIndex = 0;

        public void ResetLevel(){
            Grid.InitializeGrid(Levels.All[LevelIndex].LevelCode);
        }

        public void NextLevel(){
            if(++LevelIndex >= Levels.All.Length){
                //GoToMainMenu
            }
            else{
                Grid.InitializeGrid(Levels.All[LevelIndex].LevelCode);
            }
        }
    }
}
