using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItem : MonoBehaviour
{
    [Tooltip("Não adiciona pontos, apenas muda o sprite")]
    [SerializeField] private bool hidden;
    [Tooltip("Adiciona pontos")]
    [SerializeField] private bool collectable;

    [Space]
    [Tooltip("Disapear: O objeto desaparece ao ser coletado e é destruido.\nChangeSprite: O objeto apenas muda de sprite ao ser coletado, permanecendo na cena.")]
    [SerializeField] ItemInteractionType type;
    [Space]

    [SerializeField] AnimationClip disapearAnimation;
    [SerializeField] Sprite unhideSprite, collectedSprite;

    public void OnClick()
    {
        if (hidden) Unhide();
        else if (collectable) Collect();

        AudioController.current.PlaySfx(AudioController.current.itemSfx);
    }

    private void Unhide()
    {
        Debug.Log("Objeto foi revelado");
        GetComponent<Image>().sprite = unhideSprite;
        hidden = false;
    }

    private void Collect()
    {
        Debug.Log("Objeto coletado");

        GetComponentInParent<Counter>().IncreaseItemCount();

        switch (type)
        {
            case ItemInteractionType.ChangeSprite:
                if(collectedSprite != null) GetComponent<Image>().sprite = collectedSprite;
                break;
            case ItemInteractionType.Disapear:
                RunDisapearAnimation();
                Destroy(gameObject, 1f);
                break;
        }
        collectable = false;
    }

    private void RunDisapearAnimation()
    {
        GetComponent<Animator>().Play(disapearAnimation.name);
    }
}

public enum ItemInteractionType
{
    Disapear,
    ChangeSprite,
}
