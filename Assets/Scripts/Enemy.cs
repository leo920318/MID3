using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float hp = 200f;
    private GameObject focusEnemy;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(KeepShooting());
    }

    void Update()
    {
        // 找到最近的一個目標 Enemy 的物件
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Player");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            // 計算距離
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }
        float h = 0;
        float v = 0;

        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);
        if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            // 沒有移動輸入，並且有鎖定的敵人，漸漸面向敵人
            if (focusEnemy)
            {
                var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.atk;
            if (hp <= 0)
            {
                ScoreControl.Score += 100;
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }
    IEnumerator KeepShooting()
    {
        while (true)
        {
            // 射擊
            yield return new WaitForSeconds(3f);
            Fire();
            // 暫停 0.5 秒
            yield return new WaitForSeconds(3f);
        }
    }
}
