using UnityEngine;

public class BlackJackDeck : DeckOfCards
{
    void Awake()
    {
        if (!IsValidDeck())
        {
            deck = new ShuffleBag<Card>();

            AddCardsToDeck();
        }
    }

    protected override bool IsValidDeck()
    {
        if (base.IsValidDeck() &&  deck.Cursor > 20)
        {
            return true;
        }
        else
        {
            return false;
        }

        // return deck.Cursor > 20;
    }

    protected override void AddCardsToDeck()
    {
        for (int i = 0; i < 4; i++)
        {
            base.AddCardsToDeck();
        }
    }
}
