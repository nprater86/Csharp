Card kingOfSpades = new Card("King","Spades");
Deck myDeck = new Deck();
Player nathan = new Player("Nathan");
myDeck.Shuffle();
nathan.Draw(myDeck);
nathan.Draw(myDeck);
nathan.Draw(myDeck);
nathan.ShowHand();
nathan.Discard(1);
nathan.ShowHand();



public class Card {

    public string Name;
    public string Suit;
    public int Val;

    //constructor
    public Card(string name, string suit){
        Name = name;
        Suit = suit;
        switch(name) {
            case "Ace":
                Val = 1;
                break;
            case "2":
                Val = 2;
                break;
            case "3":
                Val = 3;
                break;
            case "4":
                Val = 4;
                break;
            case "5":
                Val = 5;
                break;
            case "6":
                Val = 6;
                break;
            case "7":
                Val = 7;
                break;
            case "8":
                Val = 8;
                break;
            case "9":
                Val = 9;
                break;
            case "10":
                Val = 10;
                break;
            case "Jack":
                Val = 11;
                break;
            case "Queen":
                Val = 12;
                break;
            case "King":
                Val = 13;
                break;
            default:
                Console.WriteLine("Something went wrong...");
                break;
        }
    }

    //print method
    public void Print() {
        Console.WriteLine($"Name: {Name} of {Suit} | Value: {Val}");
    }
}

public class Deck {
    public List<Card> Cards;
    private List<string> cardTypes;
    private List<string> suits;

    //Constructor
    public Deck() {
        Cards = new List<Card>();
        cardTypes = new List<string> {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
        suits = new List<string> {"Clubs","Spades","Hearts","Diamonds"};

        foreach (string suit in suits){
            foreach (string cardType in cardTypes){
                Cards.Add(new Card(cardType, suit));
            }
        }
    }

    //Methods
    //Deal
    public Card Deal(){
        Card topCard = Cards[0];
        Cards.RemoveAt(0);
        return topCard;
    }
    //Reset
    public void Reset(){
        Cards = new List<Card>();

        foreach (string suit in suits){
            foreach (string cardType in cardTypes){
                Cards.Add(new Card(cardType, suit));
            }
        }
    }
    //Shuffle
    public void Shuffle(){
        //create empty list for the shuffled cards
        List<Card> shuffledCards = new List<Card>();
        //initiate a rand for use later
        Random rand = new Random();
        //create a counter for our while loop
        int count = Cards.Count;
        while (count > 0){
            int randomIndex = rand.Next(Cards.Count-1);
            shuffledCards.Add(Cards[randomIndex]);
            Cards.Remove(Cards[randomIndex]);
            count--;
        }
        Cards = shuffledCards;
    }
}

public class Player {
    public string Name;
    public List<Card> Hand;
    //Constructor
    public Player(string name){
        Name = name;
        Hand = new List<Card>();
    }
    //Methods
    //Draw
    public void Draw(Deck deck){
        Hand.Add(deck.Deal());
    }
    //Discard
    public Card Discard(int index){
        if(index >= 0 && index < Hand.Count-1){
            Card discard = Hand[index];
            Hand.RemoveAt(index);
            return discard;
        } else {
            return null;
        }
    }
    //Show Hand
    public void ShowHand(){
        foreach(Card card in Hand){
            card.Print();
        }
    }
}