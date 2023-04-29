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
    public List<string> parts = new List<string> {"CPU/GPU", "Case", "Power Supply", "Cooler", "Mouse", "Monitor", "Speaker", "Keyboard"};

    public Transform[] cardslots;
    public bool[] availableCardSlots;

    public bool[] buttonsAvailable = new bool[3];

    public TextMeshProUGUI deckSizeText;
    public TextMeshProUGUI discardPileText;
    public BossClass[] bosses = new BossClass[4];
    public GameObject currentBoss;
    public progress prog;
    public int level;
    bool moveCardSlots = true;
    int cardSlotIndex = 0;
    float delay = 0;

    void Start()
    {
        prog = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();
        level = prog.currentLevel;
        buttonsAvailable = prog.buttonStates;
        currentBoss = GameObject.FindGameObjectWithTag("Boss");

        currentBoss.GetComponent<BossDisplay>().boss = bosses[level];
        
        ShuffleDeck();
        for(int i = 0; i < 8; i++)
        {
            DrawCard();
        }
    }

    void Update()
    {
        if(smallDelay() == true)
        {
            if (moveCardSlots == true)
            {
                hand[cardSlotIndex].transform.position += new Vector3(0, 20f, 0) * Time.deltaTime;
                if (hand[cardSlotIndex].transform.position.y >= -3.5)
                {
                    if (cardSlotIndex < cardslots.Length - 1)
                    {
                        cardSlotIndex++;
                    }
                    else
                    {
                        moveCardSlots = false;
                    }
                }
            }
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
        if(buttonsAvailable[0])
        {
            foreach (Card card in hand)
            {
                deck.Add(card);
                card.transform.position = new Vector3(-21.3400002f, -7.67999983f, 0);
            }
            hand.Clear();
            ShuffleDeck();
            for (int i = 0; i < 8; i++)
            {
                availableCardSlots[i] = true;
                DrawCard();
            }
            cardSlotIndex = 0;
            moveCardSlots = true;
            prog.buttonStates[0] = false;
        }
    }
    public void p_rerollChallenge()
    {
        if(buttonsAvailable[1])
        {
            CategoryDisplay c = GameObject.FindWithTag("Category").GetComponent<CategoryDisplay>();
            CategoryClass new_c = categories[Random.Range(0, categories.Count)];
            while (c.category_class == new_c)
            {
                new_c = categories[Random.Range(0, categories.Count)];
                print(new_c);
            }

            c.category_class = new_c;
            c.updateCategory();
            prog.buttonStates[1] = false;
        }
    }
    public void p_rerollParts()
    {
        if (buttonsAvailable[2])
        {
            BossDisplay b = GameObject.FindWithTag("Boss").GetComponent<BossDisplay>();
            int index = Random.Range(0, parts.Count);
            b.part1.text = parts[index];
            parts.RemoveAt(index);
            index = Random.Range(0, parts.Count);
            b.part2.text = parts[index];
            parts.RemoveAt(index);
            index = Random.Range(0, parts.Count);
            b.part3.text = parts[index];
            parts.RemoveAt(index);
            index = Random.Range(0, parts.Count);
            b.part4.text = parts[index];
            parts.RemoveAt(index);

            parts = new List<string> { "CPU/GPU", "Case", "Power Supply", "Cooler", "Mouse", "Monitor", "Speaker", "Keyboard" };
            prog.buttonStates[2] = false;
        }
    }

    bool smallDelay()
    {
        delay += Time.deltaTime;
        if(delay >= 2.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
