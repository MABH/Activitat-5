using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject[] rigidBody;
    public Text buttonText,reloj;
    public GameObject startButton;
    public static int timeRemaining = 3;
    bool itsGo = false;
    public static bool wayPointMeta, wayPointMiddle;
    string texto;

    // Use this for initialization
    void Start()
    {
        wayPointMeta = false;
        wayPointMiddle = false;
        texto = "";
        rigidBody[0].GetComponent<Rigidbody>().isKinematic = true;
        rigidBody[1].GetComponent<Rigidbody>().isKinematic = true;
        rigidBody[2].GetComponent<Rigidbody>().isKinematic = true;
        rigidBody[3].GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPointMeta && !wayPointMiddle)
        {
            texto = "Has hecho trampas";
            timeRemaining = -10;
            reloj.text = texto;
        }
        else if (wayPointMeta && wayPointMiddle)
        {
            texto = "Has llegado a la meta¡¡";
            timeRemaining = -10;
            reloj.text = texto;
        }
       
    }

        public void StartGame()
    {
        startButton.GetComponent<Button>().enabled = false;
        StartCoroutine(Temporizador(buttonText));
        Time.timeScale = 1;
    }

    IEnumerator Temporizador(Text textToShow)
    {
        while (timeRemaining>=0)
        {
            yield return new WaitForSeconds(1);
            textToShow.text = texto+timeRemaining.ToString();
            timeRemaining--;
        }
        if(!itsGo)
            Go();
        if (timeRemaining <= 0 && !wayPointMeta)
        {
            textToShow.text = "Has perdido";
        }
    }

    void Go()
    {
        texto = "Time: ";
        itsGo = true;
        rigidBody[0].GetComponent<Rigidbody>().isKinematic = false;
        rigidBody[1].GetComponent<Rigidbody>().isKinematic = false;
        rigidBody[2].GetComponent<Rigidbody>().isKinematic = false;
        rigidBody[3].GetComponent<Rigidbody>().isKinematic = false;
        startButton.SetActive(false);
        timeRemaining = 60;
        StartCoroutine(Temporizador(reloj));
    }
}
