using UnityEngine;

namespace BlockPuzzle
{
    public abstract class TileMaterial : TileBound{
        public abstract void OnTopEvent(TileBound caller, Vector3Int entranceDirection);

        protected override void Awake(){
            base.Awake();
            TileMaterial tm = MaterialOfTile(GridPosition);
            if(tm && tm != this){
                throw new System.Exception("Stacked materials error, only one material per tile");
            }
        }
    }
}
