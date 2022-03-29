using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
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
            float randomTime = Random.Range(15f, 25f);
            float randomPosition = Random.Range(-8f, 10f);
            int randomPrefab = Random.Range(0, prefabsToSpawn.Count);

            yield return new WaitForSeconds(randomTime);
            if (spawn == true)
            {
                Instantiate(prefabsToSpawn[randomPrefab], new Vector2(randomPosition, 10f), Quaternion.identity);
            }
            else
            {
                int noSpawn = Random.Range(0, 2);
                    if(noSpawn == 0)
                {
                    Instantiate(prefabsToSpawn[randomPrefab], new Vector2(randomPosition, 10f), Quaternion.identity);
                }
            }
        }
       
    }

}
