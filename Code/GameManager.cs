using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}
        public List<Action> TurnActions = new List<Action>();
        public bool invoking = false;

        private float _delay = 0.15f;
        private float _timer = 0;

        private void Awake(){
            if(Instance == null){
                Instance = this;
            }
            else
                Destroy(gameObject);
        }

        private void Start(){
            RunChecks();
        }

        public void LoadScene(int i){
            SceneManager.LoadScene(i);
        }

        public void RunChecks(){
            foreach(IUpdate u in ObjectStore.OfTypeInList<IUpdate>()){
                if(u.GetType() == typeof(Gun)) continue;
                u.UpdateAction();
            }
            foreach(Gun g in ObjectStore.OfTypeInList<Gun>()){
                g.GetComponent<IUpdate>().UpdateAction();
            }
        }

        public IEnumerator RunActions(){
            invoking = true;
            foreach(Action a in TurnActions){
                a?.Invoke();
                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();
            }
            TurnActions.Clear();
            yield return new WaitForSeconds(0.1f);
            invoking = false;
            RunChecks();
            
        }

        public void ResetScene(){
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
