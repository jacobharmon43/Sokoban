using UnityEngine;

namespace BlockPuzzle
{
    public abstract class TileObject : TileBound
    {
        public bool blocking = true;
        public virtual void ContactEvent(TileBound caller, Vector3Int contactDirection){}

        protected override void Awake(){
            base.Awake();
            TileObject to = ObjectOnTile(GridPosition);
            if(to && to != this && to.blocking && this.blocking){
                throw new System.Exception("Stacked objects error, only one blocking TileObject per tile");
            }
        }
    }
}
