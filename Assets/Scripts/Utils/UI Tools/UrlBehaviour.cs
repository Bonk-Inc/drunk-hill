using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlBehaviour : MonoBehaviour
{
    public void OpenUrl(string link) {
        Application.OpenURL(link);
    }
}
