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
                Vector3Int originalPos = GridPosition;
                Move(slidingDir);
                if(GridPosition == originalPos){
                    state = slidingStates.Normal;
                    slidingDir = Vector3Int.zero;
                }
            }
            _timer = _delay;
        }
    }
}
