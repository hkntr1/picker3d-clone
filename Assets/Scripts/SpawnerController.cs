using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class SpawnerController : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] SplineFollower sf;
    [SerializeField] rotateAround wing;
    [SerializeField] List<Transform> spawnTargets;
    [SerializeField] Transform spawnTarget;
    [SerializeField] BoxCollider collider;
    Mesh mesh;
    public espawmerType ModifierType;
    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    public void BallBomb()
    {
        for (int i = 0; i < pool.amountToPool; i++)
        {
            GameObject ball = pool.GetPooledObject();
            ball.SetActive(true);
            ball.transform.position = spawnTargets[i].position;
        }
       

        transform.gameObject.SetActive(false);
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }
    public IEnumerator SpawnCoroutine()
    {
        collider.enabled = false;
        sf.followSpeed = PickerMovement.instance.speed*2;
        wing.speed = 5;
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < pool.amountToPool; i++)
        {
            GameObject ball = pool.GetPooledObject();
            ball.SetActive(true);
            ball.transform.position = spawnTarget.position;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
public enum espawmerType
{
    HELICOPTER,
    BALLBOMB,
}
