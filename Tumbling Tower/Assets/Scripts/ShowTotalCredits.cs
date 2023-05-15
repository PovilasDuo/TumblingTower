using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTotalCredits : MonoBehaviour
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
        txt.text="Total credits earned: "+SaveManager.instance.TotalCredits;
    }
}
