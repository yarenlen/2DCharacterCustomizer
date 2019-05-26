using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Lena
public class CharacterCustomizer : MonoBehaviour
{

    public SpriteRenderer headgear;
    public SpriteRenderer shield;
    public SpriteRenderer body;
    public SpriteRenderer leg_l;
    public SpriteRenderer leg_r;

    int headgearID = 0;
    int shieldID = 0;

    [Header("Appearance")]
    public Sprite[] headgearOptions;
    public Sprite[] shieldOptions;


    // Start is called before the first frame update
    void Start()
    {
        ChangeHeadgear(headgearID);
        ChangeShield(shieldID);
    }

    void ChangeHeadgear(int index)
    {
        print("Headgear: " + index);
        for (int i = 0; i < headgearOptions.Length; i++)
        {
            if (i == index)
            {
                headgear.sprite = headgearOptions[i];
            }
        }
    }

    void ChangeShield(int index)
    {
        print("Shield: " + index);
        for (int i = 0; i < shieldOptions.Length; i++)
        {
            if (i == index)
            {
                shield.sprite = shieldOptions[i];
            }
        }
    }

    //buttonID: 0 = left Button, 1 = right Button
    public void OnHeadgearArrowClicked(int buttonID)
    {
        //left Button
        if (buttonID == 0)
        {
            headgearID--;
            if (headgearID < 0)
            {
                headgearID = headgearOptions.Length - 1;
            }
        }
        //right Button
        else if (buttonID == 1)
        {
            headgearID++;
            if (headgearID > headgearOptions.Length - 1)
            {
                headgearID = 0;
            }
        }
        //swap sprite
        ChangeHeadgear(headgearID);

    }

    //buttonID: 0 = left Button, 1 = right Button
    public void OnShieldArrowClicked(int buttonID)
    {
        //left Button
        if (buttonID == 0)
        {
            shieldID--;
            if (shieldID < 0)
            {
                shieldID = shieldOptions.Length - 1;
            }
        }
        //right Button
        else if (buttonID == 1)
        {
            shieldID++;
            if (shieldID > shieldOptions.Length - 1)
            {
                shieldID = 0;
            }
        }
        //swap sprite
        ChangeShield(shieldID);
    }


    public void OnColorButtonClicked()
    {
        Color newColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
        body.color = newColor;
        leg_l.color = newColor;
        leg_r.color = newColor;
        print("Body color: " + newColor);
    }
}


