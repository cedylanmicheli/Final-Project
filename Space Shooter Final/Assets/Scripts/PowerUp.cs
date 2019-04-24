using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public float reducefirerate;

    private GameController gameController;




    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }


        GameObject thePlayer = GameObject.Find("Player");
        PlayerController playerScript = thePlayer.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }


        if (explosion != null)
        {
            GameObject thePlayer = GameObject.Find("Player");
            PlayerController playerScript = thePlayer.GetComponent<PlayerController>();
            if(playerScript.fireRate > .19)
                playerScript.fireRate += reducefirerate;
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}