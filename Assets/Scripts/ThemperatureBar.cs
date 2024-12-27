using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemperatureBar : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI degreesText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float fillAmount = gameObject.GetComponent<Image>().fillAmount;
        degreesText.text = Math.Round(fillAmount * 100) + "C";
        float x = -580.0f + fillAmount * 1160;
        degreesText.transform.localPosition = new Vector3(x, degreesText.transform.localPosition.y, degreesText.transform.localPosition.z);
        degreesText.color = new Color(fillAmount, 0, 1 - fillAmount);
    }
}
