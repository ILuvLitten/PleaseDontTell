using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    [SerializeField] Sprite[] heartSprites;
    [SerializeField] Image[] heartImages;

    static float staticHealth = 6;

    static HealthManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static HealthManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

        UpdateHealth(staticHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float health)
    {

        staticHealth = health;

        switch (staticHealth)
        {
            case 6:
                heartImages[0].sprite = heartSprites[2];
                heartImages[1].sprite = heartSprites[2];
                heartImages[2].sprite = heartSprites[2];
                break;
            case 5:
                heartImages[0].sprite = heartSprites[1];
                heartImages[1].sprite = heartSprites[2];
                heartImages[2].sprite = heartSprites[2];
                break;
            case 4:
                heartImages[0].sprite = heartSprites[0];
                heartImages[1].sprite = heartSprites[2];
                heartImages[2].sprite = heartSprites[2];
                break;
            case 3:
                heartImages[0].sprite = heartSprites[0];
                heartImages[1].sprite = heartSprites[1];
                heartImages[2].sprite = heartSprites[2];
                break;
            case 2:
                heartImages[0].sprite = heartSprites[0];
                heartImages[1].sprite = heartSprites[0];
                heartImages[2].sprite = heartSprites[2];
                break;
            case 1:
                heartImages[0].sprite = heartSprites[0];
                heartImages[1].sprite = heartSprites[0];
                heartImages[2].sprite = heartSprites[1];
                break;
            case 0:
                heartImages[0].sprite = heartSprites[0];
                heartImages[1].sprite = heartSprites[0];
                heartImages[2].sprite = heartSprites[0];
                break;
        }

    }

    public float GetHealth()
    {
        return staticHealth;
    }
}
