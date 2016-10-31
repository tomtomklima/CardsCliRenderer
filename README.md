# CardsCliRenderer
Library in c# rendering standard poker cards in command interface

## Installation
Just copy class CardsCliRenderer into your project

## Usage
Usage is simple - create class and call render function with array of desired cards in strings
```
CardsCliRenderer renderer = new CardsCliRenderer();

//print jack of diamonds, two of hearths, ten of clubs and ace of spades
string[] arrayOfCards = {"DJ", "H2", "C10", "SA"};
renderer.Render (arrayOfCards);
```
You can test this class by call TestRender function with number of cards
```
//print 5 random cards
renderer.TestRender(5);
```
