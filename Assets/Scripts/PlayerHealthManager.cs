using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class PlayerHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int startHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            gameObject.SetActive(false);
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void hurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
