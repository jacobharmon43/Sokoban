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
        private Dict<char, Vector2Int> store = new Dict<char, Vector2Int>(new char[]{'<','>','^','v'}, new Vector2Int[]{Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down});

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
            Vector2Int nextPos = _gridPosition + fireDir;
            Tile t = _tileGrid.GetTile(nextPos);
            float currentRot = zRot;
            int protCount = 0;
            while(t && t.isGround && protCount < 20){
                protCount++;
                TileObject to = t.GetObject();
                if(to){
                    if(to.GetType() == typeof(Glass)){
                        //ignore
                    }
                    else if(to.GetType() == typeof(Prism)){
                        //Do turn
                    }
                    else if(to.GetType() == typeof(Player)){
                        GameManager.Instance.ResetLevel();
                    }
                    else if(to.GetType() == typeof(Target)){
                        Destroy(to);
                    }
                    else{
                        break;
                    }
                }
                GameObject l = Instantiate<GameObject>(_laserPrefab, t.transform.position, Quaternion.Euler(0,0, currentRot));
                l.transform.localScale = _tileGrid.Scale;
                lasers.Add(l);

                nextPos += fireDir;
                t = _tileGrid.GetTile(nextPos);
            }
        }
    }
}
