using UnityEngine;
using System.Collections;

namespace BlockPuzzle
{
    public class CameraScalar : MonoBehaviour 
        {
        const float NORMAL_ASPECT = 16/10f;
        const float CAMERA_SIZE = 7;
        private Camera cam;

        private void Awake(){
            cam = GetComponent<Camera>();
        }

        void Start () 
        {
            float aspectRatio = Screen.width / ((float)Screen.height);
            cam.orthographicSize = aspectRatio * CAMERA_SIZE / NORMAL_ASPECT;
        }
    }
}
