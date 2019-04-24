using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    public Text winText;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    double scroll;



    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

      
       

    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (winText.text.Equals("") == false)
        {
            if (scroll > -15)
            {
                scrollSpeed -= Time.deltaTime;

            }
             var main = ps.main;
             main.simulationSpeed = 10f;
            var main1 = ps1.main;
            main1.simulationSpeed = 10f;
        }
    }
}