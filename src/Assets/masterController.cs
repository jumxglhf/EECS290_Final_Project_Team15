using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        var dogC = player.GetComponent<dogController>();
        if (dogC.energyRemained <= 50)
        {
            transform.position = new Vector3(transform.position.x + 1 * speed, transform.position.y, transform.position.z);
        }
        if (dogC.energyRemained > 50 && transform.position.x > -12)
        {
            transform.position = new Vector3(transform.position.x - 1 * speed, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= -player.transform.position.x)
        {
            Application.Quit();
        }
    }
}
