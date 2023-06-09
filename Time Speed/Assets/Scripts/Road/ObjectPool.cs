using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    protected List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);
        _pool.Add(spawned);
    }

    protected bool TryGetObject(out GameObject result)
    {
        var randomSelection = _pool.Where(i => i.activeSelf == false);
        result = randomSelection.ElementAtOrDefault(new System.Random().Next() % randomSelection.Count());

        return result != null;
    }
}
