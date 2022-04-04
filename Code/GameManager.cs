using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sokoban.Grid;

namespace Sokoban
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}

        public Player Player;
        public TileGrid Grid;
        public GameObject pauseMenu;
        public GameObject levelCompleteMenu;
        public SidePanel panel;

        public bool paused = false;

        private void Awake(){
            if(Instance == null){
                Instance = this;
            }
            else
                Destroy(this);
        }

        private void Start(){
            Grid.InitializeGrid(Levels.All[Levels.LevelIndex].LevelCode);
        }

        private void Update(){
            if(CheckWin()){
                CompleteLevel();
            }
        }

        public void ResetLevel(){
            panel.Update();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void NextLevel(){
            if(++Levels.LevelIndex >= Levels.All.Length){
                MainMenu();
            }
            else{
                ResetLevel();
            }
        }

        public void FlipPause(){
            paused = !paused;
            pauseMenu.SetActive(paused);
        }

        public void CompleteLevel(){
            paused = true;
            levelCompleteMenu.SetActive(true);
        }

        public void MainMenu(){
            SceneManager.LoadScene("Main Menu");
        }

        private bool CheckWin(){
            Tile[,] tiles = Grid.GetTiles();
            bool flagExists = false;
            bool allBoxesSorted = true;
            bool allTargetsDestroyed = true;
            bool onFlag = false;

            foreach(Tile t in tiles){
                TileCover tc = t.GetCover();
                TileObject to = t.GetObject();
                if(to && to.GetType() == typeof(Target))
                    allTargetsDestroyed = false;
                if(tc){
                    System.Type type = tc.GetType();
                    if(type == typeof(Highlight)){
                        allBoxesSorted &= ((Highlight)t.GetCover()).BoxOn;
                    }
                    else if(type == typeof(Flag)){
                        flagExists = true;
                        onFlag |= ((Flag)tc).PlayerOn;
                    }
                }
            }
            return (allTargetsDestroyed && allBoxesSorted) && (flagExists == onFlag);

        }
    }
}
