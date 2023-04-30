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
    public GameObject category;
    bool oppositeDay = false;
    public progress p;
    public Animator animator;
    public Animator bossEndAnim;
    public Animator darken;
    public Canvas endCanvas;

    void Start()
    {
        animator = GameObject.FindWithTag("Fade").GetComponent<Animator>();
        p = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();
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
        category = GameObject.FindWithTag("Category");
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

    public bool checkReadySubmit()
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
            endCanvas.sortingOrder = 999;
            BossDisplay bd = boss.GetComponent<BossDisplay>();
            int target = bd.scoreToBeat;
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
                    part1Score = categoryModifier(bossParts[i], part1Score);
                    score += part1Score;
                    print("Match found: " + part1);
                    print("Points for part: " + part1Score);
                    print("Total score: " + score);
                    continue;
                }
                else if(bossParts[i] == part2)
                {
                    part2Score = categoryModifier(bossParts[i], part2Score);
                    score += part2Score;
                    print("Match found: " + part2);
                    print("Points for part: " + part2Score);
                    print("Total score: " + score);
                    continue;
                }
                else if(bossParts[i] == part3)
                {
                    part3Score = categoryModifier(bossParts[i], part3Score);
                    print("Match found: " + part3);
                    print("Points for part: " + part3Score);
                    print("Total score: " + score);
                    score += categoryModifier(part2, part2Score);
                    continue;
                }
                else
                {
                    score += categoryModifier(bossParts[i], 0);
                    print("No match! No score!");
                }
            }
            
            print("TOTAL SCORE: " + score);
            print("SCORE TO BEAT: " + target);

            if(oppositeDay == false)
            {
                if(score < target)
                {
                    //animator.SetTrigger("FadeOut");
                    darken.SetTrigger("EndScreen");
                    bossEndAnim.SetTrigger("Loss");
                    print("YOU LOSE!");
                }
                else
                {
                    p.currentLevel++;
                    //animator.SetTrigger("FadeOut");
                    darken.SetTrigger("EndScreen");
                    bossEndAnim.SetTrigger("Win");
                    print("YOU WIN!");
                }
            }
            else
            {
                if(score == 0)
                {
                    p.currentLevel++;
                    //animator.SetTrigger("FadeOut");
                    darken.SetTrigger("EndScreen");
                    bossEndAnim.SetTrigger("Win");
                    print("YOU WIN!");
                }
                else
                {
                    //animator.SetTrigger("FadeOut");
                    darken.SetTrigger("EndScreen");
                    bossEndAnim.SetTrigger("Loss");
                    print("YOU LOSE!");
                }
            }
            oppositeDay = false;
        }
        else
        {
            print("Not all cards have been assigned!");
        }
    }

    public void fadeOutLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    int categoryModifier(string part, int partPoints)
    {
        int c = category.GetComponent<CategoryDisplay>().category_class.conditionType;
        switch(c) 
        {
        // MLG Gamer Mode
        case 0:
        if(part == "CPU/GPU" || part == "Mouse" || part == "Keyboard" || part == "Speaker")
        {
            if(partPoints >= 3)
            {
                print("Condition met for: " + part + "! Points go from: " + partPoints + " to " + (partPoints + 1));
                return partPoints + 1;
            }
            else
            {
                print("Condition failed for: " + part + "! Points go from: " + partPoints + " to " + (partPoints - 1));
                return partPoints - 1;
            }
        }
        break;

        // MLG Gamer Mode
        case 1:
        if(part == "Monitor" || part == "Mouse" || part == "Keyboard" || part == "Case")
        {
            if(partPoints >= 3)
            {
                print("Condition met for: " + part + "! Points go from: " + partPoints + " to " + (partPoints + 1));
                return partPoints + 1;
            }
            else
            {
                print("Condition failed for: " + part + "! Points go from: " + partPoints + " to " + (partPoints - 1));
                return partPoints - 1;
            }
        }
        break;
        // Function Over Form
        case 2:
        if(part == "CPU/GPU" || part == "Power Supply" || part == "Cooler" || part == "Speaker")
        {
            if(partPoints >= 3)
            {
                print("Condition met for: " + part + "! Points go from: " + partPoints + " to " + (partPoints + 1));
                return partPoints + 1;
            }
            else
            {
                print("Condition failed for: " + part + "! Points go from: " + partPoints + " to " + (partPoints - 1));
                return partPoints - 1;
            }
        }
        break;

        // PC Master Race
        case 3:
        if(part == "CPU/GPU" || part == "Case" || part == "Cooler" || part == "Power Supply")
        {
            if(partPoints >= 3)
            {
                print("Condition met for: " + part + "! Points go from: " + partPoints + " to " + (partPoints + 1));
                return partPoints + 1;
            }
            else
            {
                print("Condition failed for: " + part + "! Points go from: " + partPoints + " to " + (partPoints - 1));
                return partPoints - 1;
            }
        }
        break;

        // Desert Island Gaming
        case 4:
        if(part == "Cooler" || part == "Case" || part == "Monitor" || part == "Mouse")
        {
            if(partPoints >= 3)
            {
                print("Condition met for: " + part + "! Points go from: " + partPoints + " to " + (partPoints + 1));
                return partPoints + 1;
            }
            else
            {
                print("Condition failed for: " + part + "! Points go from: " + partPoints + " to " + (partPoints - 1));
                return partPoints - 1;
            }
        }
        break;

        // Urban Gaming
        case 5:
        if(part == "CPU/GPU" || part == "Cooler" || part == "Keyboard" || part == "Speaker")
        {
            if(partPoints >= 3)
            {
                print("Condition met for: " + part + "! Points go from: " + partPoints + " to " + (partPoints + 1));
                return partPoints + 1;
            }
            else
            {
                print("Condition failed for: " + part + "! Points go from: " + partPoints + " to " + (partPoints - 1));
                return partPoints - 1;
            }
        }
        break;

        //  Opposite Day
        case 6:
            oppositeDay = true;
        break;

        //  Binary System Update
        case 7:
            if(partPoints >= 3)
            {
                return 5;
            }
            else if(partPoints <= 2)
            {
                return 0;
            }
        break;

        // Factory Settings
        default:
            return partPoints;
        }
        return partPoints;
    }
}
