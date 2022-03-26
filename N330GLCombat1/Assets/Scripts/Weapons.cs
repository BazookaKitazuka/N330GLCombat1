using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    public float timeout = 5f;
    // Start is called before the first frame update
    public List<GameObject> prefabsToSpawn;
    private bool spawn = true;
     
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWeapons());
    }

    IEnumerator SpawnWeapons()
    {
        while (true)
        {
            float randomTime = Random.Range(5f, 10f);
            float randomPosition = Random.Range(1f, 10f);
            int randomPrefab = Random.Range(0, prefabsToSpawn.Count);

            yield return new WaitForSeconds(randomTime);
            if (spawn == true)
            {
                Instantiate(prefabsToSpawn[randomPrefab], new Vector2(randomPosition, 10f), Quaternion.identity);
            }
            else
            {
                int noSpawn = Random.RandomRange(0, 2);
                    if(noSpawn == 0)
                {
                    Instantiate(prefabsToSpawn[randomPrefab], new Vector2(randomPosition, 10f), Quaternion.identity);
                }
            }
        }
       
    }

}
