using UnityEngine;

namespace BlockPuzzle
{
    public class Key : Pushable
    {
        public override bool Move(Vector3Int input)
        {
            bool moved = base.Move(input);
            if(!moved){
                TileBound t = NextTileObject(GridPosition + input);
                if(t && t.GetComponent<Door>()){
                    t.GetComponent<Door>().Unlock();
                    Destroy(gameObject);
                    return true;
                }
            }
            return moved;
        }
    }
}
