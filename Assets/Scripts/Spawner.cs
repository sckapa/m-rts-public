using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPlane;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        StartCoroutine(SpawnPlayerEnumerator());
    }

    private void SpawnPlayer()
    {
        float x = Random.Range(spawnPlane.transform.position.x - spawnPlane.transform.localScale.x * 5, spawnPlane.transform.position.x + spawnPlane.transform.localScale.x * 5);
        float z = Random.Range(spawnPlane.transform.position.z - spawnPlane.transform.localScale.z * 5, spawnPlane.transform.position.z + spawnPlane.transform.localScale.z * 5);
        Instantiate(player, new Vector3(x, spawnPlane.transform.position.y, z), Quaternion.identity);
    }

    private IEnumerator SpawnPlayerEnumerator()
    {
        while (true)
        {
            SpawnPlayer();
            yield return new WaitForSeconds(2);
        }
    }
}
