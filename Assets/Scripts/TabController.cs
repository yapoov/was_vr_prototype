using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TabController : MonoBehaviour
    {
        public Color selectedColor;

        public float offset = 50;
        public AnimationCurve selectedTabMotionCurve;
        public Button[] tabButtons;
        public GameObject[] tabPanels;
        public TMP_Text header;

        private void Start()
        {
            for (int i = 0; i < tabButtons.Length; i++)
            {
                int index = i; // capture i in local variable
                tabButtons[i].onClick.AddListener(() => SwitchTab(index));
            }

            SwitchTab(0);
        }

        public void SwitchTab(int index)
        {
            for (int i = 0; i < tabPanels.Length; i++)
            {
                var rectTransform = (RectTransform)tabButtons[i].transform;
                StartCoroutine(Move(rectTransform,
                    i == index
                        ? new Vector2(offset, rectTransform.anchoredPosition.y)
                        : new Vector2(0, rectTransform.anchoredPosition.y)));

                tabButtons[i].GetComponent<Image>().color = i == index ? selectedColor : Color.white;
                tabPanels[i].SetActive(i == index);

                if (i == index)
                {
                    header.SetText(tabButtons[i].name);
                }
            }
        }


        IEnumerator Move(RectTransform tf, Vector2 targetPos)
        {
            var startPos = tf.anchoredPosition;
            for (float t = 0; t < selectedTabMotionCurve.keys.Last().time; t += Time.deltaTime)
            {
                tf.anchoredPosition = Vector2.Lerp(startPos, targetPos, selectedTabMotionCurve.Evaluate(t));
                yield return null;
            }

            tf.anchoredPosition = targetPos;
        }
    }
}