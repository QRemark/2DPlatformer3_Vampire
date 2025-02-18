using TMPro;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;

    private void Start()
    {
        if(Text != null)
            ShowText();
    }

    private void ShowText()
    {
        Text.text = $"E - выстрел\nQ - вампиризм";
    }
}
