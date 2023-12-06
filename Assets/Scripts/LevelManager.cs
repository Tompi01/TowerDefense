using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{

    public static LevelManager main;

    public static float Score = 0;
    public static float Live = 100;
    public static float Money = 700;

    public Transform StartPoint;
    public Transform[] path;

    [SerializeField]
    public TMP_Text Scores;
    public TMP_Text Lives;
    public TMP_Text Moneys;
    private void Awake()
    {
        main = this;
    }
    private void Start() 
    {
    Score = 0;
    }

    private void Update ()
    {
        Score += 1 * Time.deltaTime;
        Scores.text = "Score : " + Score.ToString("n0");
        Lives.text = Live.ToString("n0");
        Moneys.text =  Money.ToString("n0");

    }

}
