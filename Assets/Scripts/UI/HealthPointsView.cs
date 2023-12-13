using TMPro;
using UnityEngine;

public class HealthPointsView : MonoBehaviour
{
    [SerializeField] private HealthPoints healthPoints;
    [SerializeField] private TMP_Text hpValueText;

    private void Update()
    {
        if (hpValueText != null)
        {
            hpValueText.text = healthPoints.HP.ToString();
        }
    }
}
