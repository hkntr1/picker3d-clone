using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameScreen : MonoBehaviour
{
    [SerializeField] GameObject dynamicjoystick;
    public Slider forceController;
    public TextMeshProUGUI moneyText;
    private void Start()
    {
        forceController.minValue = PickerMovement.instance.firstSpeed*1.5f;
        forceController.maxValue = PickerMovement.instance.firstSpeed * 2f;
        moneyText.text = SceneManager.instance.money.ToString();
    }
    public void Ramp()
    {
        forceController.gameObject.SetActive(true);
        dynamicjoystick.SetActive(false);
        forceController.value = 0;
        
    }
    public void StartScreen()
    {
        forceController.gameObject.SetActive(false);
        dynamicjoystick.SetActive(true);
    }
    private void Update()
    {
        if (StateManager.instance.eState == GameState.Ramp)
        {
            PickerMovement.instance.speed = forceController.value;
            if (Input.GetMouseButtonDown(0))
            {
                forceController.value += 0.2f;
            }
            else forceController.value -= 0.01f; 
        }
    }
    public void UpdateMoney(int addQuantity = 0)
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + addQuantity);
        SceneManager.instance.money += addQuantity;
        moneyText.text=SceneManager.instance.money.ToString();
    }
}
