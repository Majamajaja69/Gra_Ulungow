using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zdjecie : MonoBehaviour
{
    public GameObject DialogPanel;
    public Text DialogText;
    public string[] dialogue;
    private int index;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(DialogPanel.activeInHierarchy) 
            {
                zeroText();


            }
            else
            {
                DialogPanel.SetActive(true);
                //StartCoroutine(Typing());
            }
        }
        if (DialogText.text== dialogue[index])
        {
            contButton.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        playerIsClose = true;


        }

    }
    public void zeroText()
    {
        DialogText.text = "";
        index = 0;
        DialogPanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray() )
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        contButton.SetActive(false);
    if(index<dialogue.Length-1)
        {
            index ++;
            DialogText.text= "";
            StartCoroutine(Typing());

        }
        else
       {
            zeroText();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();

        }
    }
}
