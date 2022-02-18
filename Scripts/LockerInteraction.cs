using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerInteraction : MonoBehaviour
{
    public GameObject door;
    public GameObject canvas;
    public Text interact;
    public SoundManager sound;
    public bool isDoorOpen;
    bool canInteract = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
        interact.text = ("Press 'E' to open/close the Door");
        canvas.SetActive(false);
        isDoorOpen = false;
    }

    private void Update()
    {
        if (canInteract)
        {

            if (Input.GetKeyDown(KeyCode.E) && isDoorOpen == false)
            {
                
                canvas.SetActive(false);
                OpenDoor();
                isDoorOpen = true;

            }
            else if (Input.GetKeyDown(KeyCode.E) && isDoorOpen == true)
            {
               
                canvas.SetActive(false);
                CloseDoor();
                isDoorOpen = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            canvas.SetActive(true);
            canInteract = true;

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
         var rotationVector = transform.rotation.eulerAngles;
         rotationVector.y = 0;
         door.transform.rotation = Quaternion.Euler(rotationVector);
        
         sound.LockerDoorOpen();
    }

    void CloseDoor()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 153;
        door.transform.rotation = Quaternion.Euler(rotationVector);
        sound.LockerDoorClose();

    }
}

