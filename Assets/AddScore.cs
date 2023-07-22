using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using GraphTool;

public class AddScore : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().IncreaseScore();
        GraphTool.GraphRenderer1.FindObjectOfType<GraphRenderer1>().FetchNewData();
    }
}
