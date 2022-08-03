using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class SpawnerController : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] SplineFollower sf;
    [SerializeField] rotateAround wing;
    [SerializeField] Transform spawnTarget;
    [SerializeField] BoxCollider collider;
    public void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }
    public IEnumerator SpawnCoroutine()
    {
        collider.enabled = false;
        sf.followSpeed = 5;
        wing.speed = 5;
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < pool.amountToPool; i++)
        {
            GameObject ball = pool.GetPooledObject();
            ball.SetActive(true);
            ball.transform.position = spawnTarget.position;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
