using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    public Text TextScore;
    public Text TextHP;
    public static float Score = 0;
    public Transform TeleportSpot1;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    private bool choice = false;
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = "Score:" + Score;
        TextHP.text = "HP:" + Player.hp;
      
        if (Score >= 500)
        {
            SceneManager.LoadScene("END");
        }
    }
}
