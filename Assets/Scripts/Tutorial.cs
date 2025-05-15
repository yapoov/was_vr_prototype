using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    [SerializeField] private AnimationCurve scaleCurve;
    [SerializeField] private GameObject[] modalSequence;

    private void Start()
    {
        foreach (var g in modalSequence)
        {
            g.SetActive(false);
        }

        modalSequence[0].SetActive(true);

        for (int i = 0; i < modalSequence.Length; i++)
        {
            var modal = modalSequence[i];
            int nextIndex = i + 1;
            int prevIndex = Mathf.Min(i - 1,0);
            modal.GetComponent<Modal>().OnBackButtonClicked.AddListener(()=>{
                modal.gameObject.SetActive(false);
                ShowModal(modalSequence[prevIndex]);
            });
            modal.GetComponent<Modal>().OnNextButtonClicked.AddListener(()=>{
                if(nextIndex >= modalSequence.Length) return;
                modal.gameObject.SetActive(false);
                ShowModal(modalSequence[nextIndex]);
            });
        }
    }

    private void ShowModal(GameObject target)
    {
        target.SetActive(true);
        StartCoroutine(ScaleAnimate(target.transform));
    }

    private IEnumerator ScaleAnimate(Transform tf)
    {
        Vector3 startScale = tf.localScale;
        for (float t = 0; t < scaleCurve.keys.Last().time; t += Time.deltaTime)
        {
            tf.localScale = startScale * scaleCurve.Evaluate(t);
            yield return null;
        }
        tf.localScale = startScale;
    }
}