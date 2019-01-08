using System;
using System.Collections.Generic;

namespace DeckOfCards {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class Deck {
        Random rand = new Random();
        string[] suits = {"Hearts", "Spades", "Diamonds", "Clubs"};
        string[] stringVals = {"Ace", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

        public List<Card> cards = new List<Card> ();
        public Deck () {
            for (var i = 0; i < 4; i++) {
                for (var j = 1; j <= 13; j++) {
                    cards.Add(new Card(stringVals[j],suits[i]));
                }
            }
        }
        public void Shuffle () {
            for(var idx = 0; idx <= cards.Count; idx++){
                var temp = cards[idx];
                int r = rand.Next(idx, cards.Count);
                cards[idx] = cards[r];
                cards[r] = temp;
            }
        }
        public Card Deal () {
            Card topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }
        public void Reset () {
            cards = new List<Card>();
            for (var i = 0; i < 4; i++) {
                for (var j = 1; j <= 13; j++) {
                    cards.Add(new Card(stringVals[j],suits[i]));
                }
            }
        }
    }

    public class Card {
        public Card(string Val, string Suit){
            this.suit = Suit;
            this.stringVal = Val;
        }
        public string stringVal { get; set; }
        public string suit { get; set; }
        public int val { get; set; }
    }

    public class Player {
        public string name{get;set;}
        public List<Card> hand{get;set;}
        public Card Draw(Deck deck){
            Card card = deck.cards[0];
            hand.Add(card);
            deck.cards.RemoveAt(0);
            return card;
        }
        public Card Discard(int idx){
            if(this.hand[idx] != null){
                Card disCard = this.hand[idx];
                this.hand.RemoveAt(idx);
                return disCard;
            }
            else{
                return null;
            }
        }
    }

}