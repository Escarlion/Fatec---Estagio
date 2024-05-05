using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private int totalItens;
    private int currentItens;
    [SerializeField] private Text counterText;

    private void Start()
    {
        CountTotalItens();
        counterText.text = currentItens + "/" + totalItens;
    }

    private void CountTotalItens()
    {
        GameObject[] itens = GameObject.FindGameObjectsWithTag("Collectible");
        totalItens = itens.Length;

    }

    public void IncreaseItemCount()
    {
        currentItens++;
        counterText.text = currentItens + "/" + totalItens;

        if (currentItens == totalItens) GetComponent<PhaseManager>().EndPhase(true); //chama a tela de vitoria
    }

    public int GetTotalItensCount()
    {
        return totalItens;
    }

    public int GetCurrentItensCount()
    {
        return currentItens;
    }

}
