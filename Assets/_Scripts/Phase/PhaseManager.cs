using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] Phases phase;
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

        //Desativa ambas interfaces por segurança
        success.SetActive(false);
        fail.SetActive(false);

        SetPhaseInfos();
    }

    //Mostra as informações da fase na tela de inicio
    private void SetPhaseInfos()
    {
        int itensCount = counter.GetTotalItensCount();
        float duration = timer.GetDuration();

        startInfos.text = "Quantidade de itens:" + itensCount + "\nTempo: " + duration;
    }

    //Ao coletar todos os itens ou o tempo acabar, retorna a tela de sucesso/falha
    public void EndPhase(bool success)
    {
        if (success)
        {
            timer.StopTimer();
            this.success.SetActive(true);
            string timeLeft = timer.GetTimeLeft();
            successInfos.text = "Tempo Restante: " + timeLeft;
            SavePhaseInfo();
        }
        else
        {
            fail.SetActive(true);
            int itensLeft = counter.GetTotalItensCount() - counter.GetCurrentItensCount();
            failInfos.text = "Itens restantes: " + itensLeft;
        }
    }

    //Detecta qual a fase atual e salva no PlayerPref
    private void SavePhaseInfo()
    {
        switch (phase)
        {
            case Phases.Phase1:
                if(PlayerPrefs.GetInt("PhasesCompleted") < 1) PlayerPrefs.SetInt("PhasesCompleted", 1);
                break;
            case Phases.Phase2:
                if (PlayerPrefs.GetInt("PhasesCompleted") < 2) PlayerPrefs.SetInt("PhasesCompleted", 2);
                break;
            case Phases.Phase3:
                if (PlayerPrefs.GetInt("PhasesCompleted") < 3) PlayerPrefs.SetInt("PhasesCompleted", 3);
                break;
        }
    }


}

enum Phases{
    Phase1,
    Phase2,
    Phase3
}
