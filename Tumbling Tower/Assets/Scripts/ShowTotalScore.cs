using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTotalScore : MonoBehaviour
{
    private TextMeshProUGUI  txt;
    // Start is called before the first frame update

    private void Awake()
    {
        txt = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text="Total score: "+SaveManager.instance.LifetimeScore;
    }


    public void ClearStats()
    {
        SaveManager.instance.LifetimeScore = 0;
        SaveManager.instance.TotalLivesLost = 0;
        SaveManager.instance.TotalCredits = 0;
        for(int i=0;i<SaveManager.instance.UnlockedSkins.Length;i++)
        {
            SaveManager.instance.UnlockedSkins[i]=false;
        }
        SaveManager.instance.Save();
    }
}
