using UnityEngine;

namespace BlockPuzzle
{
    public class Key : Slidable
    {
        public override bool Move(Vector3Int input)
        {
            Vector3Int nextPos = GridPosition + input;
            if(!ValidTile(nextPos)) return false;
            
            Slidable[] allSlides = GameObject.FindObjectsOfType<Slidable>();
            foreach(Slidable s in allSlides){
                if(s.GridPosition == nextPos){
                    if(s.GetType() == typeof(Door)){
                        s.GetComponent<Door>().Unlock();
                        Destroy(gameObject);
                    }
                    else if(!s.Move(input)) return false;
                }
            }

            Vector3 goTo = GoTo(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }
    }
}
