using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShinySwordScript : MonoBehaviour
{
    public TMP_Text pickUpText;
    private bool pickUpAllowed;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetMouseButtonDown(1))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
        Character.Instance.weaponEquipped = true;
        Character.Instance.currentWeapon = "Red Sword";
        Character.Instance.damageOutput = 50;
    }
}
