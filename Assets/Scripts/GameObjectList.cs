using System.Collections.Generic;
using UnityEngine;

public static class GameObjectList
{
    private static List<GameObject> _gameObjectList = new List<GameObject>();

    public static void Add(GameObject gameObject)
    {
        _gameObjectList.Add(gameObject);
    }

    public static void Remove(GameObject gameObject)
    {
        _gameObjectList.Remove(gameObject);
    }

    public static List<GameObject> GetObjects(string tag)
    {
        List<GameObject> objects = new List<GameObject>();
        foreach(GameObject gameObject in _gameObjectList)
        {
            if (gameObject.tag == tag)
                objects.Add(gameObject);
        }
        return objects;
    }

    public static List<GameObject> GetObjects()
    {
        return _gameObjectList;
    }
}
