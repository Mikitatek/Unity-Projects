using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{

    public GameObject[] myObjects;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3( Random.Range(-40, 40), Random.Range(10, 40), Random.Range(-40, 40));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
