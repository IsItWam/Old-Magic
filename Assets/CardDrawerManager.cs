using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardDrawerManager : MonoBehaviour
{
    public GameObject cardButtonTemplate;
    public List<Card> availableCards;

    private void Start()
    {
        PopulateDrawer();
    }

    private void PopulateDrawer()
    {
        foreach (Card card in availableCards)
        {
            GameObject newCardButton = Instantiate(cardButtonTemplate, transform);
            newCardButton.SetActive(true);

            Image buttonImage = newCardButton.GetComponent<Image>();
            if (buttonImage && card.cardImage)
            {
                buttonImage.sprite = card.cardImage;
            }

            Text buttonText = newCardButton.GetComponentInChildren<Text>();
            if (buttonText)
            {
                buttonText.text = card.cardName; 
            }

            CardDragDrop dragDrop = newCardButton.AddComponent<CardDragDrop>();
            dragDrop.Initialize(card);
        }
    }
}
