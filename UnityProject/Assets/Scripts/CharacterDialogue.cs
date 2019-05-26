using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterDialogue : MonoBehaviour
{
    public GameObject bubble;
    public float textDisplayDuration;
    private bool canSpeak = true;
    
    public TMP_Text text;
    public string[] sentences;
    int sentenceID = 0;

    private void Awake()
    {
        bubble.SetActive(false);
        text.text = sentences[sentenceID];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canSpeak)
        {
            canSpeak = false;

            //pick new sentence
            int r = Random.Range(0, sentences.Length);
            while (r == sentenceID)
            {
                r = Random.Range(0, sentences.Length);
            }
            sentenceID = r;
            text.text = sentences[sentenceID];

            StartCoroutine("DisplayBubble");
        }
        else if (Input.GetMouseButtonDown(1) && !canSpeak)
        {
            Debug.Log("Nope! Spammen von rechter Maus ist folgenlos. :D");
        }
    }

    private IEnumerator DisplayBubble()
    {
        bubble.SetActive(true);
        
        yield return new WaitForSeconds(textDisplayDuration);
        
        bubble.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        canSpeak = true;        
    }

}
