using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDecoy : MonoBehaviour
{
    public GameObject[] myObjects;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex1 = Random.Range(0, myObjects.Length);
        int randomIndex2 = Random.Range(0, myObjects.Length);
        int randomIndex3 = Random.Range(0, myObjects.Length);
        int randomIndex4 = Random.Range(0, myObjects.Length);
        Vector3 randomSpawnPosition1 = new Vector3(Random.Range(-10, 11), 3, Random.Range(1, 11));
        Vector3 randomSpawnPosition2 = new Vector3(Random.Range(-10, 11), 3, Random.Range(1, 11));
        Vector3 randomSpawnPosition3 = new Vector3(Random.Range(-10, 11), 3, Random.Range(1, 11));
        Vector3 randomSpawnPosition4 = new Vector3(Random.Range(-10, 11), 3, Random.Range(1, 11));


        Instantiate(myObjects[randomIndex1], randomSpawnPosition1, Quaternion.identity);
        Instantiate(myObjects[randomIndex2], randomSpawnPosition2, Quaternion.identity);
        Instantiate(myObjects[randomIndex3], randomSpawnPosition3, Quaternion.identity);
        Instantiate(myObjects[randomIndex4], randomSpawnPosition4, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
