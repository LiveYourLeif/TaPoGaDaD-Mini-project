using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class RoundManager : MonoBehaviour
{
    public Button submitButton;
    public GameObject[] cards;
    public string[] bossParts;
    public GameObject boss;

    void Start()
    {
        GameObject[] cardSlots;
        cardSlots = GameObject.FindGameObjectsWithTag("PlayCardSlot");
        foreach (GameObject slot in cardSlots)
        {
            print("Card slots: " + slot.name);
        }

        cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cards)
        {
            print("Card slots: " + card.name);
        }
    }

    void Update()
    {
        if(checkReadySubmit() == true)
        {
            var colors = submitButton.GetComponent<Button>().colors;
            colors.normalColor = Color.red;
            submitButton.GetComponent<Button>().colors = colors;
        }
        else
        {
            var colors = submitButton.GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            submitButton.GetComponent<Button>().colors = colors;
        }
    }

    bool checkReadySubmit()
    {
        GameObject[] cardSlots;
        cardSlots = GameObject.FindGameObjectsWithTag("PlayCardSlot");
        foreach (GameObject slot in cardSlots)
        {
            if(slot.GetComponent<playedCardSlot>().isFilled == false)
            {
                return false;
            }
        }
        return true;
    }

    GameObject[] rearrangedCards()
    {
        GameObject[] newCardList = new GameObject[4];
        foreach(GameObject card in cards)
        {
            for(int i = 1; i < 5; i++)
            {
                if(card.GetComponent<DragAndDrop>().assignedSlot == i)
                {
                    newCardList[i - 1] = card;
                }
            }
        }
        foreach(GameObject newCard in newCardList)
        {
            print(newCard.name);
        }
        return newCardList;
    }

    // Calculates the score for the round 
    public void calcScore()
    {
        if(checkReadySubmit() == true)
        {
            BossDisplay bd = boss.GetComponent<BossDisplay>();
            int target = int.Parse(bd.scoreToBeat.text);
            int score = 0;
            GameObject[] cards = rearrangedCards();
            string[] bossParts = {bd.part1.text, bd.part2.text, bd.part3.text, bd.part4.text};

            for(int i = 0; i < 4; i++)
            {
                string part1 = cards[i].GetComponent<cardDisplay>().card_class.computerPart1;
                string part2 = cards[i].GetComponent<cardDisplay>().card_class.computerPart2;
                string part3 = cards[i].GetComponent<cardDisplay>().card_class.computerPart3;
                int part1Score = cards[i].GetComponent<cardDisplay>().card_class.computerPartPoint1;
                int part2Score = cards[i].GetComponent<cardDisplay>().card_class.computerPartPoint2;
                int part3Score = cards[i].GetComponent<cardDisplay>().card_class.computerPartPoint3;

                if(bossParts[i] == part1)
                {
                    score += part1Score;
                    print("Match found: " + part1);
                    print("Points for part: " + part1Score);
                    print("Total score: " + score);
                    continue;
                }
                else if(bossParts[i] == part2)
                {
                    score += part2Score;
                    print("Match found: " + part2);
                    print("Points for part: " + part2Score);
                    print("Total score: " + score);
                    continue;
                }
                else if(bossParts[i] == part3)
                {
                    score += part3Score;
                    print("Match found: " + part3);
                    print("Points for part: " + part3Score);
                    print("Total score: " + score);
                    continue;
                }
                else
                {
                    print("No match! No score!");
                }
            }
            
            print("TOTAL SCORE: " + score);
            print("SCORE TO BEAT: " + target);
            if(score < target)
            {
                print("YOU LOSE!");
            }
            else
            {
                print("YOU WIN!");
            }
        }
        else
        {
            print("Not all cards have been assigned!");
        }
    }
}
