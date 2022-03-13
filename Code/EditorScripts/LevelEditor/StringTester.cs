using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockPuzzle
{
    public class StringTester : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
            string testString = string.Join("","1111111111111111111111",
                                        "100000S000000000000001",
                                        "1001000001000000010001",
                                        "100000000000000D000001",
                                        "1000000000110000000001",
                                        "100P000000110000000001",
                                        "100000000000000K000001",
                                        "1000010000000000100001",
                                        "10000000000000000000F1",
                                        "1111111111111111111111");
            Debug.Log(testString);

            string fullString = string.Join("0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000",
                                            "0000000000000000000000");
            Debug.Log(fullString);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
