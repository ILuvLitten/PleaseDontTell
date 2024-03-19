using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{

    Image heart0;
    Image heart1;
    Image heart2;

    [SerializeField] PlayerController player;

    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {

        heart0 = transform.GetChild(0).gameObject.GetComponent<Image>();
        heart1 = transform.GetChild(1).gameObject.GetComponent<Image>();
        heart2 = transform.GetChild(2).gameObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (player.playerHealth)
        {
            case 6:
                heart0.sprite = fullHeart;
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                break;
            case 5:
                heart0.sprite = halfHeart;
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                break;
            case 4:
                heart0.sprite = emptyHeart;
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                break;
            case 3:
                heart0.sprite = emptyHeart;
                heart1.sprite = halfHeart;
                heart2.sprite = fullHeart;
                break;
            case 2:
                heart0.sprite = emptyHeart;
                heart1.sprite = emptyHeart;
                heart2.sprite = fullHeart;
                break;
            case 1:
                heart0.sprite = emptyHeart;
                heart1.sprite = emptyHeart;
                heart2.sprite = halfHeart;
                break;
            case 0:
                heart0.sprite = emptyHeart;
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                break;
        }
    }
}
