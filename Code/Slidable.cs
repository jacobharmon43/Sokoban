using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if(_timer > 0){
                _timer -= Time.deltaTime;
                return;
            }
            Vector3Int originalPos = _gridPosition;
            Move(slidingDir);
            if(_gridPosition == originalPos){
                state = slidingStates.Normal;
                slidingDir = Vector3Int.zero;
            }
            _timer = _delay;
        }
    }
}
