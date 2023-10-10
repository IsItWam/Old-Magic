using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    public CardType cardType;
    public int manaCost;
    public int materialCost;
    public int bluudCost;
    public int health;
    public int damage;
    public string description;
    public Sprite cardImage; 

    public enum CardType
    {
        Creature,
        Spell,
        Structure
    }

    void Start()
    {
    }

    void Update()
    {
    }

  
    public void InitializeCard(string name, CardType type, int mcost, int mtcost, int hp, int dmg, string desc, int blud, Sprite image)
    {
        cardName = name;
        cardType = type;
        manaCost = mcost;
        materialCost = mtcost;
        bluudCost = blud;
        health = hp;
        damage = dmg;
        description = desc;
        cardImage = image;

    }

    private void OnMouseDown()
    {
    }

    private void OnMouseDrag()
    {
    }

    public void Heal(Card targetCard, int healAmount)
    {
        targetCard.health += healAmount;
    }

 
}