using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static float Score = 0;
    public static float Live = 200;
    public static float Money = 300;

    public TMP_Text score;
    public TMP_Text live;
    public TMP_Text money;
    public TMP_Text tWave;

    public static LevelManager main;

    public Transform StartPoint;
    public Dictionary<Transform, Transform[]> path;

    [SerializeField]
    public NewDict newDict;

    [SerializeField]
    public Canvas __GameOver;

    private void Start()
    {
        Score = 0;
        Live = 200;
        Money = 300;
    }

    private void Awake()
    {
        path = newDict.dico();
        main = this;
    }

    private void Update()
    {
        score.text = "Score : " + Score.ToString("n0");
        live.text = "Vie : " + Live.ToString("n0");
        money.text = "Money : " + Money.ToString("n0");
        tWave.text = "Vague : " + EnemySpawner.main.currentWave;

        if(Live <= 0)
        {
            __GameOver.enabled = true;
        }


        Score += 1 * Time.deltaTime;
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