using UnityEngine;
using UnityEngine.UI;

public class HealthPointsBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] public HealthPoints healthPoints;

    private void Update()
    {
        bar.fillAmount = 1.0f * healthPoints.HP / healthPoints.maxHP;
    }
}
