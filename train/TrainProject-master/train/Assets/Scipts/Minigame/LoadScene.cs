using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {

	public GameObject gateway; //Objekt mit OnTrigger und Collider, wenn Spieler sich hineinbewegt und L drückt wechselt die Szene 
    public string loadScene;

	void Start ()
    {
        gateway.SetActive(false);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            gateway.SetActive(true);
            if (gateway.activeInHierarchy == true && Input.GetKeyDown(KeyCode.L))
            {
                //Application.LoadLevel(loadScene);
                Starting();
            }
        }
    }
    void Starting()
    {
        SceneManager.LoadScene("Minigame");
    }

}
