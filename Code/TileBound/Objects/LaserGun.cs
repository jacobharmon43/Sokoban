using UnityEngine;
using System.Collections.Generic;
using Sokoban.Grid;
using Sokoban.Dict;

namespace Sokoban
{
    public class LaserGun : TileObject
    {
        [SerializeField] private GameObject _laserPrefab;
        private Vector2Int fireDir;
        private float zRot;

        private List<GameObject> lasers = new List<GameObject>();
        private Dict<char, Vector2Int> store = new Dict<char, Vector2Int>(new char[]{'<','>','^','v'}, new Vector2Int[]{Vector2Int.left, Vector2Int.right, Vector2Int.down, Vector2Int.up});

        public void Init(char dir){
            fireDir = store[dir];
            zRot = (fireDir.x!= 0 ? fireDir.x * 90 + 90 : 0) + (fireDir.y != 0 ? fireDir.y * 90 + 180 : 0);
            transform.rotation = Quaternion.Euler(Vector3.forward * zRot);
        }

        private void Update()
        {
            Fire();
        }

        private void Fire(){

            foreach(GameObject o in lasers){
                Destroy(o);
            }
            lasers.Clear();
            List<Prism> hit = new List<Prism>();
            Vector2Int nextDir = fireDir;
            Vector2Int nextPos = _gridPosition + nextDir;
            Tile t = _tileGrid.GetTile(nextPos);
            float currentRot = zRot;
            while(t && t.isGround){
                TileObject to = t.GetObject();
                if(to){
                    if(to.GetType() == typeof(Glass)){
                        //ignore
                    }
                    else if(to.GetType() == typeof(Prism)){
                        Prism prism = ((Prism)to);
                        if(hit.Contains(prism)) return;
                        hit.Add(prism);
                        nextDir = prism.RedirectDir;
                        currentRot = prism.zRot;
                        nextPos += nextDir;
                        t = _tileGrid.GetTile(nextPos);
                        continue;
                    }
                    else if(to.GetType() == typeof(Player)){
                        GameManager.Instance.ResetLevel();
                    }
                    else if(to.GetType() == typeof(Target)){
                        Destroy(to.gameObject);
                    }
                    else{
                        break;
                    }
                }
                GameObject l = Instantiate<GameObject>(_laserPrefab, t.transform.position, Quaternion.Euler(0,0, currentRot));
                l.transform.localScale = _tileGrid.Scale;
                lasers.Add(l);

                nextPos += nextDir;
                t = _tileGrid.GetTile(nextPos);
            }
        }
    }
}
