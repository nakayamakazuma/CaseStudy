﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour
{
    public Image[] g_TimerBoard;
    public Sprite[] g_TimerNumber;

    private float g_timer = 100;
    private float loadTime = 2.0f;
    public GameObject canvas;
    public float fadeRate = 0.2f;
    private bool fadeStart = false;
    private float _bombTime;//爆弾出すカウントみたいなの

    //石川追記
    public bool bTimerPause = true;

    // Use this for initialization
    void Start()
    {
        int[] num = new int[3];
        num[0] = (int)g_timer / 100 % 10;
        num[1] = (int)g_timer / 10 % 10;
        num[2] = (int)g_timer % 10;

        _bombTime = 0;

        for (int i = 0; i < 3; i++)
        {
            g_TimerBoard[i].sprite = g_TimerNumber[num[i]];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(StartManager._b)
        {
        
            if(bTimerPause)
            {
              _bombTime += Time.deltaTime;
              if(_bombTime >= 20.0f)
              {
                  _bombTime = 0.0f;
                  BallShooter ba = GameObject.Find( "BallSet" ).GetComponent<BallShooter>();
                  ba.BombSet();
              }

              g_timer -= Time.deltaTime;

              int[] num = new int[3];



              num[0] = (int)g_timer / 100 % 10;
              num[1] = (int)g_timer / 10 % 10;
              num[2] = (int)g_timer % 10;

              for (int i = 0; i < 3; i++)
              {
                  g_TimerBoard[i].sprite = g_TimerNumber[num[i]];
              }
            }

        }
        if (g_timer <= 0)
        {
            g_timer = 0;
            //画面遷移
            loadTime -= Time.deltaTime;
            canvas.GetComponent<StartManager>().SetTimeupActive();
            if (loadTime <= 0.0f && !fadeStart)
            {
                //Application.LoadLevel("ResultScene");
                FadeManager.Instance.LoadLevel("ResultScene", fadeRate);
                fadeStart = true;
            }

        }

    }

    public float GetTime(){
        return g_timer;
    }

    public void TimerPauseChange(bool bPause)
    {
        bTimerPause = bPause;
    }

	public void PlusTime( float plusTime ){
		g_timer += plusTime;
	}
}
