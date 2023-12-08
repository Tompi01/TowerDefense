using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager main;

    public Transform StartPoint;
    public Dictionary<Transform, Transform[]> path;

    [SerializeField]
    public NewDict newDict;
    
    private void Awake()
    {
        path = newDict.dico();
        main = this;
    }


}

[Serializable]
public class NewDict
{
    [SerializeField]
    newDictItem[] item;

    public Dictionary<Transform, Transform[]> dico()
    {
        Dictionary<Transform, Transform[]> newDict = new Dictionary<Transform, Transform[]>();

        foreach (var items in item)
        {
            newDict.Add(items.startPoint, items.path);
        }

        return newDict;
    }
}

[Serializable]
public class newDictItem
{
    [SerializeField]
    public Transform startPoint;
    [SerializeField]
    public Transform[] path;

    
}