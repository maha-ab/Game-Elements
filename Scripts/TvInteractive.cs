using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TvInteractive : MonoBehaviour
{
    public GameObject tvScreen;
    public GameObject tvLight;
    public GameObject canvas;
    public Text interact;
    public SoundManager sound;
    public bool isTvOpen;

    public bool canInteract = false;

    public Renderer screen;

    // Start is called before the first frame update
    void Start()
    {
        interact.text = ("Press 'E' to open/close the Tv");
        canvas.SetActive(false);
        isTvOpen = false;
        screen = tvScreen.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {

            if (Input.GetKeyDown(KeyCode.E) && isTvOpen == false)
            {

                canvas.SetActive(false);
                OpenTv();
                isTvOpen = true;

            }
            else if (Input.GetKeyDown(KeyCode.E) && isTvOpen == true)
            {

                canvas.SetActive(false);
                CloseTv();
                isTvOpen = false;
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

    void OpenTv()
    {
        tvLight.SetActive(true);
        screen.material.color = Color.white;
        screen.material.SetColor("_EmissionColor", Color.white);
        sound.TvOpen();
    }

    void CloseTv()
    {
        tvLight.SetActive(false);
       screen.material.color = Color.black+Color.gray;
        screen.material.SetColor("_EmissionColor",new Color(0.1882f, 0.1882f, 0.1882f));
        sound.TvClose();

    }
}

