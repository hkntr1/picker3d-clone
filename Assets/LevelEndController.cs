using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelEndController : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI text;
    public int point;
    private void Start()
    {
        text.text = point.ToString();
    }
}
