using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int SkinNumber;
    public Button BuyButton;
    public Button EquipButton;
    public void BuySkin()
    {
            SaveManager.instance.Credits = SaveManager.instance.Credits - 50;
            SaveManager.instance.UnlockedSkins[SkinNumber]=true;
            SaveManager.instance.Save();
            UpdateUI();
    }

    void Start()
    {
        UpdateUI();
    }
    void UpdateUI()
    {
        if(SaveManager.instance.UnlockedSkins[SkinNumber])
        {
            EquipButton.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(false);
        }
        else
        {
            EquipButton.gameObject.SetActive(false);
            BuyButton.gameObject.SetActive(true);
        }
        BuyButton.interactable=(SaveManager.instance.Credits >= 50);
    }
}
