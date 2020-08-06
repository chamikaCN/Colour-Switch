using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearer : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, cam.position.y - 20f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.transform.parent.gameObject);
        return;
    }
}
