using UnityEngine;

namespace BlockPuzzle{
    public class Slidable : TileBound
    {
        private enum slidingStates {Normal, Sliding};
        private slidingStates state = slidingStates.Normal;
        private Vector3Int slidingDir;
        
        public void Kick(Vector3Int direction){
            state = slidingStates.Sliding;
            slidingDir = -direction;
        }

        private void Update(){
            if(state == slidingStates.Sliding){
                if(!MoveNoPush(slidingDir)) state = slidingStates.Normal;
            }
            _timer = _delay;
        }
    }
}
