using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    [Header("Appearance")]

    public CostumizerSlot headgearSlot;
    public CostumizerSlot shieldSlot;

    public Color[] colors;

    [Header("Buttons")]

    public Button headgearLeftButton;
    public Button headgearRightButton;
    public Button shieldLeftButton;
    public Button shieldRightButton;

    [Header("Body part")]

    public SpriteRenderer body;
    public SpriteRenderer leg_l;
    public SpriteRenderer leg_r;

    [Header("Misc")]

    public Button colorButtonPrefab;
    public Transform colorButtonParent;

    private int headgearID = 0;
    private int shieldID = 0;

    private void Start()
    {
        headgearSlot.spriteRenderer.sprite = headgearSlot.sprites[headgearID];
        shieldSlot.spriteRenderer.sprite = shieldSlot.sprites[shieldID];

        GenerateColorButtons();

        headgearLeftButton.onClick.AddListener(() => ChangeGear(ref headgearID, -1, headgearSlot));
        headgearRightButton.onClick.AddListener(() => ChangeGear(ref headgearID, 1, headgearSlot));
        shieldLeftButton.onClick.AddListener(() => ChangeGear(ref shieldID, -1, shieldSlot));
        shieldRightButton.onClick.AddListener(() => ChangeGear(ref shieldID, 1, shieldSlot));
    }

    private void GenerateColorButtons()
    {
        foreach (Color color in colors)
        {
            Button newButton = Instantiate(colorButtonPrefab, colorButtonParent);
            newButton.GetComponent<Image>().color = color;
            // Add OnColorButtonClicked to each button.
            newButton.onClick.AddListener(() => OnColorButtonClicked(color));
        }
    }

    // dir is -1 for left and +1 for right
    private void ChangeGear(ref int id, int dir, CostumizerSlot costumizerSlot)
    {
        id += dir;
        if (id < 0)
        {
            id = costumizerSlot.sprites.Length - 1;
        }
        else if (id > costumizerSlot.sprites.Length - 1)
        {
            id = 0;
        }
        costumizerSlot.spriteRenderer.sprite = costumizerSlot.sprites[id];
    }

    private void OnColorButtonClicked(Color newColor)
    {
        // Color newColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
        body.color = newColor;
        leg_l.color = newColor;
        leg_r.color = newColor;
        print("Body color: " + newColor);
    }
}

[System.Serializable]
public class CostumizerSlot
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
}


