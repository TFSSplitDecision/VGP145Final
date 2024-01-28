using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExistanceTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutineLoop());
        //Destroy(gameObject,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator coroutineLoop() {
        int i = 0;
        while (true) {
            Debug.Log("Loop! " + i++);
            yield return new WaitForEndOfFrame();
        }
    }
}
