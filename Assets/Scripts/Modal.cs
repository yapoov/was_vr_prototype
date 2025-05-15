using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Button nextButton;

    public UnityEvent OnBackButtonClicked;
    public UnityEvent OnNextButtonClicked;
    void Start()
    {
        
        backButton.onClick.AddListener(OnBackButtonClicked.Invoke);
        nextButton.onClick.AddListener(OnNextButtonClicked.Invoke);
    }
}
