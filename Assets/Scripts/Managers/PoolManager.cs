using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager
{
    private GameObject _prefab;
    private Transform _startPosition;
    private List<GameObject> _objects;

    public PoolManager(GameObject prefab, int countObjectForPool, Transform startPosition)
    {
        _startPosition = startPosition;
        _prefab = prefab;
        _objects = new List<GameObject>();
        for (int i = 0; i < countObjectForPool; i++)
        {
            Create();
        }
    }
    public void UpdatePoolPosition(Transform currentPosition)
    {
        _startPosition.position = currentPosition.position;
    }
    public GameObject GetObject()
    {
        GameObject obj = _objects.FirstOrDefault(x => !x.activeSelf);
        if (obj == null) obj = Create();
        obj.transform.position = _startPosition.position;
        obj.SetActive(true);
        return obj;
    }
    public void Release(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
            obj.gameObject.transform.position = _startPosition.position;
        }
    }

    private GameObject Create()
    {
        GameObject obj = MonoBehaviour.Instantiate(_prefab, _startPosition.position, _startPosition.rotation);
        obj.SetActive(false);
        _objects.Add(obj);
        return obj;
    }
}
