using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dotText;

    private void Start()
    {
        StartCoroutine(DotAnimation());
    }

    IEnumerator DotAnimation()
    {
        while (true)
        {
            dotText.text = "";
            for (int i = 1; i <= 6; i++)
            {
                dotText.text += ".";
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}
