using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{

    private float spawnTimer;

    public static ShurikenSpawner instance;
    public List<GameObject> shurikens = new List<GameObject>();
    public GameObject shurikenPrefab;
    public float spawnRate;
    public int spawnAmount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        spawnTimer = spawnRate;
    }

    void Update()
    {
        if(spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnRate;
            SpawnShuriken();
        }
    }

    private void SpawnShuriken()
    {
        Vector2 randInsideCircle = Random.insideUnitCircle * 15f;
        Vector3 randPos = transform.position;
        randPos.x += randInsideCircle.x;
        randPos.z += randInsideCircle.y;
        randPos.y = 1f;
        GameObject shuriken = Instantiate(shurikenPrefab, randPos, Quaternion.identity);
        shurikens.Add(shuriken);
        shuriken.transform.parent = transform;
    }
}
