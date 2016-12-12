using System;
using System.Linq;
using System.Collections.Generic;

namespace CardsCliRenderer {
	public struct Coordinates {
		public int x { get; set; }

		public int y { get; set; }
	}

	public class CardsCliRenderer {
		private const int WIDTH = 7;
		private const int HEIGHT = 6;

		//list of all suits for test rendering
		private List<char> allSuits = new List<char> {
			{ 'S' },
			{ 'H' },
			{ 'C' },
			{ 'D' },
		};

		//list of all values for test rendering
		private List<string> allValues = new List<string> {
			{ "A" },
			{ "2" },
			{ "3" },
			{ "4" },
			{ "5" },
			{ "6" },
			{ "7" },
			{ "8" },
			{ "9" },
			{ "10" },
			{ "J" },
			{ "Q" },
			{ "K" },
		};

		//pretty suits
		private Dictionary <char, char> suitSymbols = new Dictionary <char, char> {
			{ 'S', '♠' }, //Spades
			{ 'H', '♡' }, //Hearths
			{ 'C', '♣' }, //Clubs
			{ 'D', '♢' }, //Diamonds
		};

		//upside down values
		private Dictionary <string, string> valueUpsideDown = new Dictionary <string, string> {
			{ "2", "Z" },
			{ "3", "E" },
			{ "4", "h" },
			{ "5", "S" },
			{ "6", "9" },
			{ "7", "L" },
			{ "8", "8" },
			{ "9", "6" },
			{ "10", "OI" },
			{ "J", "ſ" },
			{ "Q", "O" },
			{ "K", "ʞ" },
			{ "A", "V" },
		};

		//points for suits in numeric values
		private Dictionary <string, List<Coordinates>> numericFigurePoints = new Dictionary <string, List<Coordinates>> { 
			{"2", new List<Coordinates> {
					new Coordinates{ x = 3, y = 2 },
					new Coordinates{ x = 3, y = 4 },
				}
			}, {"3", new List<Coordinates> {
					new Coordinates{ x = 2, y = 2 },
					new Coordinates{ x = 4, y = 2 },
					new Coordinates{ x = 3, y = 4 },
				}
			}, {"4", new List<Coordinates> {
					new Coordinates{ x = 2, y = 2 },
					new Coordinates{ x = 4, y = 2 },
					new Coordinates{ x = 2, y = 4 },
					new Coordinates{ x = 4, y = 4 },
				}
			}, {"5", new List<Coordinates> {
					new Coordinates{ x = 2, y = 2 },
					new Coordinates{ x = 4, y = 2 },
					new Coordinates{ x = 3, y = 3 },
					new Coordinates{ x = 2, y = 4 },
					new Coordinates{ x = 4, y = 4 },
				}
			}, {"6", new List<Coordinates> {
					new Coordinates{ x = 2, y = 2 },
					new Coordinates{ x = 4, y = 2 },
					new Coordinates{ x = 2, y = 3 },
					new Coordinates{ x = 4, y = 3 },
					new Coordinates{ x = 2, y = 4 },
					new Coordinates{ x = 4, y = 4 },
				}
			}, {"7", new List<Coordinates> {
					new Coordinates{ x = 2, y = 2 },
					new Coordinates{ x = 4, y = 2 },
					new Coordinates{ x = 1, y = 3 },
					new Coordinates{ x = 3, y = 3 },
					new Coordinates{ x = 5, y = 3 },
					new Coordinates{ x = 2, y = 4 },
					new Coordinates{ x = 4, y = 4 },
				}
			}, {"8", new List<Coordinates> {
					new Coordinates{ x = 1, y = 2 },
					new Coordinates{ x = 3, y = 2 },
					new Coordinates{ x = 5, y = 2 },
					new Coordinates{ x = 2, y = 3 },
					new Coordinates{ x = 4, y = 3 },
					new Coordinates{ x = 1, y = 4 },
					new Coordinates{ x = 3, y = 4 },
					new Coordinates{ x = 5, y = 4 },
				}
			}, {"9", new List<Coordinates> {
					new Coordinates{ x = 1, y = 2 },
					new Coordinates{ x = 3, y = 2 },
					new Coordinates{ x = 5, y = 2 },
					new Coordinates{ x = 1, y = 3 },
					new Coordinates{ x = 3, y = 3 },
					new Coordinates{ x = 5, y = 3 },
					new Coordinates{ x = 1, y = 4 },
					new Coordinates{ x = 3, y = 4 },
					new Coordinates{ x = 5, y = 4 },
				}
			}, {"10", new List<Coordinates> {
					new Coordinates{ x = 1, y = 2 },
					new Coordinates{ x = 3, y = 2 },
					new Coordinates{ x = 5, y = 2 },
					new Coordinates{ x = 1, y = 3 },
					new Coordinates{ x = 2, y = 3 },
					new Coordinates{ x = 4, y = 3 },
					new Coordinates{ x = 5, y = 3 },
					new Coordinates{ x = 1, y = 4 },
					new Coordinates{ x = 3, y = 4 },
					new Coordinates{ x = 5, y = 4 },
				}
			},
		};

		//figures is picture of person on 4x5 canvas + figure of suit in size of [3 3 2]
		//strings is here because visibility of images directly in code
		private Dictionary<string, string[]> figuresImages = new Dictionary<string, string[]> { {"J", new string[] {
					"  w",
					" {)",
					" %%",
					" % ",
					"%%%",
				}
				
			}, {"Q", new string[] {
					"  W",
					" {(",
					" %%",
					"%%%",
					"%%%",
				}

			}, {"K", new string[] {
					" WW",
					" {)",
					" %%",
					"%%%",
					"%%%",
				}

			},
		};

		private Dictionary<char, string[]> smallSuitsImages = new Dictionary<char, string[]> { {'S', new string[] {
					" ʌ ",
					"(:)",
					" |",
				}
			}, {'H', new string[] {
					"(v)",
					" v ",
					"  ",
				}
			}, {'C', new string[] {
					" o ",
					"o o",
					" |",
				}
			}, { 'D', new string[] {
					" /\\",
					" \\/",
					"  ",
				}
			},
		};
			
		//aces is pictures on 5x4 canvas
		private Dictionary<char, string[]> acesImages = new Dictionary<char, string[]> { {'S', new string[] {
					"  ʌ  ",
					" /:\\ ",
					"(_:_)",
					"  |  ",
				}
			}, {'H', new string[] {
					" _ _ ",
					"( v )",
					" \\ / ",
					"  v  ",
				}
			}, {'C', new string[] {
					"  _  ",
					" ( ) ",
					"(_x_)",
					"  |  ",
				}
			}, { 'D', new string[] {
					"  ʌ  ",
					" / \\ ",
					" \\ / ",
					"  v  ",
				}
			},
		};

		private string[] cardBackImage = new string[] {
			" _____ ",
			"|\\\\V//|",
			"|\\\\V//|",
			"|>>X<<|",
			"|//A\\\\|",
			"|//A\\\\|",
		};

		public void CardBacksRender (int numberOfCards) {
			char[,] preparedCardsLine = new char[numberOfCards * (WIDTH + 1), HEIGHT];

			for (int row = 0; row < HEIGHT; row++) {
				for (int block = 0; block < numberOfCards; block++) {
					//add space before each card block and desired block
					preparedCardsLine [(block * (WIDTH + 1)), row] = ' ';
					for (int column = 0; column < WIDTH; column++) {
						preparedCardsLine [1 + column + (WIDTH + 1) * (block), row] = cardBackImage [row] [column];
					}
				}
			}

			RenderIntoCli (preparedCardsLine);
		}

		public void TestRender (int numberOfCards) {
			if (numberOfCards < 0) {
				throw new Exception ("Number of testing cards should be not negative number");
			}

			string[] testCards = new string[numberOfCards];

			Random rnd = new Random ();

			for (int count = 0; count < numberOfCards; count++) {
				int randomSuit = rnd.Next (allSuits.Count);
				int randomValue = rnd.Next (allValues.Count);
				testCards [count] = allSuits [randomSuit] + allValues [randomValue];
			}

			Render (testCards);
		}

		public void Render(List<string> userInput) {
			Render (userInput.ToArray ());
		}

		public void Render (string[] userInput) {
			List<char[,]> cards = new List<char[,]> ();

			//parse and sanitize data from user
			foreach (string userInputCard in userInput) {
				char suit = Char.ToUpper (userInputCard [0]);
				string value = userInputCard.Substring (1).ToUpper ();

				cards.Add (OneCardImage (suit, value));
			}

			char[,] preparedCardsLine = new char[cards.Count * (WIDTH + 1), HEIGHT];
			//for a line of cards ready for render

			//TODO optimalize
			for (int row = 0; row < HEIGHT; row++) {
				for (int countCards = 0; countCards < cards.Count; countCards++) {
					//add column of spaces before each card
					preparedCardsLine [((countCards) * (WIDTH + 1)), row] = ' ';

					for (int column = 0; column < WIDTH; column++) {
						preparedCardsLine [1 + column + countCards * (WIDTH + 1), row] = cards [countCards] [column, row];
					}
				}
			}

			RenderIntoCli (preparedCardsLine);
		}

		private char[,] OneCardImage (char suit, string value) {
			//start with space characters
			char[,] card = new char[WIDTH, HEIGHT];
			for (int y = 0; y < HEIGHT; y++) {
				for (int x = 0; x < WIDTH; x++) {
					card [x, y] = ' ';
				}
			}

			//top and bottom edge, than left and right
			for (int i = 1; i < WIDTH - 1; i++) {
				card [i, 0] = '_';
				card [i, HEIGHT - 1] = '_';
			}
			for (int i = 1; i < HEIGHT; i++) {
				card [0, i] = '|';
				card [WIDTH - 1, i] = '|';
			}

			//image inside
			int output; //unwanted, but must-to-have variable
			if (int.TryParse (value, out output)) {
				List<Coordinates> valueFigure = numericFigurePoints [value];
				foreach (Coordinates point in valueFigure) {
					card [point.x, point.y] = suitSymbols [suit];
				}

			} else if (value == "A") {
				string[] aceImage = acesImages [suit];
				for (int y = 0; y < aceImage.Length; y++) {
					for (int x = 0; x < aceImage [y].Length; x++) {
						card [x + 1, y + 1] = aceImage [y] [x];
					}
				}

			} else if (new [] { "J", "Q", "K" }.Contains (value)) {
				string[] figureImage = figuresImages [value];
				//image render for [3 3 2] jagged array
				for (int y = 0; y < figureImage.Length; y++) {
					for (int x = 0; x < figureImage [y].Length; x++) {
						card [x + 3, y + 1] = figureImage [y] [x];
					}
				}

				string[] smallSuitImage = smallSuitsImages [suit];
				//image render for [3 3 2] jagged array
				for (int y = 0; y < smallSuitImage.Length; y++) {
					for (int x = 0; x < smallSuitImage [y].Length; x++) {
						card [x + 1, y + 2] = smallSuitImage [y] [x];
					}
				}

			} else {
				throw new DataMisalignedException ("Second character must be either number from 2 to 10 or one of the characters J, Q, K or A");
			}

			//render value and upside-down value
			for (int i = 0; i < value.Length; i++) {
				card [WIDTH - 1 - value.Length + i, HEIGHT - 1] = valueUpsideDown [value] [i];
			}
			for (int i = 0; i < value.Length; i++) {
				card [1 + i, 1] = value [i];
			}

			return card;
		}

		private void RenderIntoCli (char[,] output) {
			//output one card into console
			for (int row = 0; row < output.GetLength (1); row++) {
				for (int column = 0; column < output.GetLength (0); column++) {
					Console.Write (output [column, row]);
				}
				Console.WriteLine ();
			}
		}
	}
}