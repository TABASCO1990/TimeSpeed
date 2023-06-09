using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayGenerate : ObjectPool
{
    [SerializeField] private int _countTemplatePreSpawn;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _movingSpeed;

    private void Start()
    {        
        float spawnpoint = 0;

        foreach (var template in _templates)
        {
            Initialize(template);
        }

        for (int i = 0; i < _countTemplatePreSpawn; i++)
        {
            if(TryGetObject(out GameObject template))
            {
                SetRoad(template, new Vector3(0,0,spawnpoint));
                spawnpoint += 20;
            }         
        }
    }

    private void Update()
    {
        transform.Translate(-_pool[0].transform.forward * Time.deltaTime * _movingSpeed, Space.World);

        if (mainCamera.WorldToViewportPoint(_pool[0].transform.position).z < -20)
        {
            print("Off");
        }
    }

    private void SetRoad(GameObject road, Vector3 spawnPoint)
    {
        road.SetActive(true);
        road.transform.position = spawnPoint;
    }
}
