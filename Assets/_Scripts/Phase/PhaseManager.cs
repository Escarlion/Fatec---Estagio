using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] GameObject phaseStart;
    [SerializeField] TextMeshProUGUI startInfos;
    [Space]
    [SerializeField] GameObject success;
    [SerializeField] TextMeshProUGUI successInfos;
    [Space]
    [SerializeField] GameObject fail;
    [SerializeField] TextMeshProUGUI failInfos;

    Timer timer;
    Counter counter;

    private void Start()
    {
        timer = GetComponent<Timer>();
        counter = GetComponent<Counter>();

        phaseStart.SetActive(true);
        success.SetActive(false);
        fail.SetActive(false);
        SetPhaseInfos();
    }

    private void SetPhaseInfos()
    {
        int itensCount = counter.GetTotalItensCount();
        float duration = timer.GetDuration();

        startInfos.text = "Quantidade de itens:" + itensCount + "\nTempo: " + duration;
    }

    public void EndPhase(bool result)
    {
        if (result)
        {
            timer.StopTimer();
            success.SetActive(true);
            string timeLeft = timer.GetTimeLeft();
            successInfos.text = "Tempo Restante: " + timeLeft;
        }
        else
        {
            fail.SetActive(true);
            int itensLeft = counter.GetTotalItensCount() - counter.GetCurrentItensCount();
            failInfos.text = "Itens restantes: " + itensLeft;
        }
    }


}
