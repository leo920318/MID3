using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2choice : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
    }

    public void click()
    {
        Player.double_shot = true;
        Time.timeScale = 1;
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);
    }
}

