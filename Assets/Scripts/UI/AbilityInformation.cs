using TMPro;
using UnityEngine;

public class AbilityInformation : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;

    private void Start()
    {
        if(Text != null)
            ShowText();
    }

    private void ShowText()
    {
        Text.text = $"E - �������\nQ - ���������";
    }
}
