using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Creator : MonoBehaviour
{
    public GameObject Enemy_A;
    private float GameLevel = 11;
    void Start()
    {
        StartCoroutine(Level1_1());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameLevel == 12 && ScoreControl.Score >= 400)
        {
            Instantiate(Enemy_A, new Vector3(194, 2, -18), transform.rotation);
            Instantiate(Enemy_A, new Vector3(194, 2, -26), transform.rotation);
            Instantiate(Enemy_A, new Vector3(194, 2, -34), transform.rotation);
            Instantiate(Enemy_A, new Vector3(211, 2, -23), transform.rotation);
            Instantiate(Enemy_A, new Vector3(211, 2, -29), transform.rotation);
            GameLevel += 1;
        }
    }
    IEnumerator Level1_1()
    {
        Instantiate(Enemy_A, new Vector3(-1.43f, 1.5f, 5.08f), transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(Enemy_A, new Vector3(-8.86f, 1.5f, -3.31f), transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(Enemy_A, new Vector3(9.08f, 1.5f, -3.62f), transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(Enemy_A, new Vector3(2.42f, 1.5f, 4.63f), transform.rotation);
        GameLevel += 1;
    }
}
