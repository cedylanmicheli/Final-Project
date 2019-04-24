using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {

        GameObject theController = GameObject.Find("GameController");
        GameController gameScript = theController.GetComponent<GameController>();


        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed * gameScript.speed;

    }
}