using UnityEngine;

namespace BlockPuzzle
{
    public class Key : Pushable
    {
        public override bool Move(Vector3Int input)
        {
            bool moved = base.Move(input);
            if(!moved){
                Physical p = NextPhysicalTileObject(GridPosition + input);
                if(p && p.GetComponent<Door>()){
                    p.GetComponent<Door>().Unlock();
                    Destroy(gameObject);
                    return true;
                }
            }
            return moved;
        }
    }
}
