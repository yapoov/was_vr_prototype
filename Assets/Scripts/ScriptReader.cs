using System;
using UnityEngine;
using UnityEngine.UI;

public class ScriptReader : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentTransform;
    public float scrollSpeed = 30f;
    public bool isScrolling = true;


    private void Update()
    {
        if (!isScrolling) return;
        float contentHeight = scrollRect.content.sizeDelta.y;
        float contentShift = scrollSpeed* Time.deltaTime;
        scrollRect.verticalNormalizedPosition -= contentShift / contentHeight;
    }


    public void SetScrolling(bool val) => isScrolling = val;
    public void Pause() => isScrolling = false;
    public void Resume() => isScrolling = true;
    public void Toggle() => isScrolling = !isScrolling;
}