﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    private GameObject Core;
    private GameObject BallSet;
    private GameObject BallManager;

    public bool bPause = false;

    private GameObject Timer_Board;

    // Use this for initialization
    void Start()
    {
        //タイムボードの取得
        Timer_Board = GameObject.Find("Timer_Board");

        //各オブジェクトを取得
        foreach (Transform child in transform)
        {
            if (child.name == "Core")
            {
                Core = child.gameObject;
                Debug.Log("コア格納");
            }
            else if (child.name == "BallSet")
            {
                BallSet = child.gameObject;
                Debug.Log("ボールセット格納");
            }
            else if (child.name == "BallManager")
            {
                BallManager = child.gameObject;
                Debug.Log("ボールマネージャー格納");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bPause)
        {
        }
        else
        {
        }
    }

    public void bPauseChange()
    {
        bPause = bPause ? false : true;

        Core.SetActive(!bPause);
        BallSet.SetActive(!bPause);
        BallManager.SetActive(!bPause);
        Timer_Board.GetComponent<TimerScript>().TimerPauseChange(!bPause);
    }
}
