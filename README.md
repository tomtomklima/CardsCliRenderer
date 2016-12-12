# CardsCliRenderer
Library in c# rendering standard poker cards in command interface

## Installation
Just copy class CardsCliRenderer into your project

## Usage
Usage is simple - create class and call render function with string[] or List<string> of desired cards: 
```
CardsCliRenderer renderer = new CardsCliRenderer();

//print jack of diamonds, two of hearths, ten of clubs and ace of spades
string[] arrayOfCards = {"DJ", "H2", "C10", "SA"}; 
//or List<string> arrayOfCards = new List<string> {"DJ", "H2", "C10", "SA"};

renderer.Render (arrayOfCards);
```
You can test this class by calling the TestRender function with number of cards: 
```
//print 5 random cards
renderer.TestRender(5);
```
And you can also render just the card backs like this:
```
//print 7 card backs
renderer.CardBacksRender(7);
```