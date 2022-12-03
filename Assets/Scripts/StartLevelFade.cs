using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelFade : MonoBehaviour
{
    [SerializeField] GameObject fadePanel;

   public void FadeIn()
    {
        fadePanel.SetActive(false);
    }
}
