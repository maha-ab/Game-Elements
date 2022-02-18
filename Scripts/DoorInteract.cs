using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteract : MonoBehaviour
{
    //public GameObject door;
    public GameObject canvas;
    public Text interact;
    public SoundManager sound;
   // public bool isDoorOpen;
    bool canInteract = false;


    // Start is called before the first frame update
    void Start()
    {
        interact.text = ("Press 'E' to open/close the Door");
        canvas.SetActive(false);
       // isDoorOpen = false;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {

            canvas.SetActive(true);
            canInteract = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag== "Player" && Input.GetKeyDown(KeyCode.E))
        {
            canvas.SetActive(false);
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
            canInteract = false;
        }
    }

    void OpenDoor()
    {
        sound.DoorUnlock();
    }
}
