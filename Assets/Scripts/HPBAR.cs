using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBAR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3((-1080 + 1080 * (Player.hp / 100)), 0, transform.position.z);
    }
}
