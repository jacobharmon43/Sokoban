using UnityEngine;
using Sokoban.Dict;

namespace Sokoban
{
    public class Prism : Dynamic
    {
        public Vector2Int RedirectDir;
        public float zRot;
        private Dict<char, Vector2Int> store = new Dict<char, Vector2Int>(new char[]{'<','>','^','v'}, new Vector2Int[]{Vector2Int.left, Vector2Int.right, Vector2Int.down, Vector2Int.up});
        
        public void Init(char dir){
            Debug.Log(dir);
            RedirectDir = store[dir];
            zRot = (RedirectDir.x!= 0 ? RedirectDir.x * 90 + 90 : 0) + (RedirectDir.y != 0 ? RedirectDir.y * 90 : 0);
            transform.rotation = Quaternion.Euler(Vector3.forward * zRot);
        }

    }
}
