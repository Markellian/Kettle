using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class Kettle : MonoBehaviour, IPointerClickHandler
{
    bool _switchOn;
    float _speed = 0.1f;
    AudioSource _switchSound;
    AudioSource _boilSound;

    [SerializeField]
    public Image themperatureBar;
    public GameObject switchModel;
    public GameObject steam;


    void Awake()
    {
        _switchSound = switchModel.GetComponent<AudioSource>();
        _boilSound = GetComponent<AudioSource>();
        steam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_switchOn)
        {
           if (themperatureBar.fillAmount < 1)
           {
                themperatureBar.fillAmount += Time.deltaTime * _speed;
                float fillAmount = themperatureBar.fillAmount;
                themperatureBar.color = new Color(fillAmount, 0, 1 - fillAmount);
           }
           if (themperatureBar.fillAmount == 1)
            {
                Debug.Log("Kettle is off");
                _switchOn = false;
                switchModel.transform.Rotate(10, 0, 0);
                _switchSound.Play();
            }
        }
        else
        {
            if (themperatureBar.fillAmount >= 0.1)
            {
                themperatureBar.fillAmount -= Time.deltaTime * _speed / 1.5f;
                float fillAmount = themperatureBar.fillAmount;
                themperatureBar.color = new Color(fillAmount, 0, 1 - fillAmount);
            }
        }

        if (themperatureBar.fillAmount >= 0.8)
        {            
            steam.SetActive(true);
            if (!_boilSound.isPlaying) _boilSound.Play();
        }
        else
        {
            steam.SetActive(false);
            if (_boilSound.isPlaying) _boilSound.Stop();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        if (_switchOn)
        {
            Debug.Log("Kettle is off");
            _switchOn = false;
            switchModel.transform.Rotate(10, 0, 0);
        }
        else
        {
            Debug.Log("Kettle is on");
            _switchOn = true;
            switchModel.transform.Rotate(-10, 0, 0);
        }
        _switchSound.Play();
    }
}
