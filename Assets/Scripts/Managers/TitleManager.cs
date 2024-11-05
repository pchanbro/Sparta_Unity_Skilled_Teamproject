using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject titlePopup;
    private void Awake()
    {
        titlePopup.SetActive(true);
    }
}
