using UnityEngine;
using Sokoban.Dict;

namespace Sokoban
{
    public class LaserGun : TileObject
    {
        private Vector2Int fireDir;
        private float zRot;

        private Dict<char, Vector2Int> store = new Dict<char, Vector2Int>(new char[]{'<','>','^','v'}, new Vector2Int[]{Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down});

        public void Init(char dir){
            fireDir = store[dir];
            zRot = (fireDir.x!= 0 ? fireDir.x * 90 + 90 : 0) + (fireDir.y != 0 ? fireDir.y * 90 + 180 : 0);
            transform.rotation = Quaternion.Euler(Vector3.forward * zRot);
        }
    }
}
