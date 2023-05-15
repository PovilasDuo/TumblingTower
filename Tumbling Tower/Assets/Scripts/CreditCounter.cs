using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditCounter : MonoBehaviour
{
    private TextMeshProUGUI  txt;
    // Start is called before the first frame update

    private void Start()
    {
        txt = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text=SaveManager.instance.Credits+"c";
    }
}
