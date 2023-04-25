using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<CategoryClass> categories = new List<CategoryClass>();

    public Transform[] cardslots;
    public bool[] availableCardSlots;

    public TextMeshProUGUI deckSizeText;
    public TextMeshProUGUI discardPileText;

    void Start()
    {
        ShuffleDeck();
        for(int i = 0; i < 4; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;
                    randCard.transform.position = cardslots[i].position;
                    randCard.hasBeenPlayed = false;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    hand.Add(randCard);
                    UpdateCardText();
                    return;
                } 
            }
        }
    }

    public void AddDiscardPileToDeck()
    {
        if(discardPile.Count >= 1)
        {
            foreach(Card card in discardPile)
            {
                deck.Add(card);
            }
            discardPile.Clear();
        }
        UpdateCardText();
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++) {
        Card temp = deck[i];
        int randomIndex = Random.Range(i, deck.Count);
        deck[i] = deck[randomIndex];
        deck[randomIndex] = temp;
     }
    }

    public void UpdateCardText()
    {
        deckSizeText.text = deck.Count.ToString();
        discardPileText.text = discardPile.Count.ToString();
    }

    public void p_rerollHand()
    {
        foreach(Card card in hand)
            {
                deck.Add(card);
                card.transform.position = new Vector3(-21.3400002f,-7.67999983f,0);
            }
        hand.Clear();
        ShuffleDeck();
        for(int i = 0; i < 4; i++)
        {
            availableCardSlots[i] = true;
            DrawCard();
        }

    }
    public void p_rerollChallenge()
    {
        CategoryDisplay c = GameObject.FindWithTag("Category").GetComponent<CategoryDisplay>();
        CategoryClass new_c = categories[Random.Range(0, categories.Count)];
        while(c.category_class == new_c)
        {
            new_c = categories[Random.Range(0, categories.Count)];
            print(new_c);
        }

        c.category_class = new_c;
        c.updateCategory();
    }
    public void p_rerollParts()
    {
        
    }

}
