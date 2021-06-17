using System;
using System.Text;


namespace AssignmentNoTwo
{
    class HangMan
    {
      static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                 op = UserInputNumber();
            
                switch (op)
                {
                    case 1:
                        GuessByWord();
                        break;
                    case 2:
                        GuessByChar();
                        break;
                    default:
                        Console.WriteLine("Press 3 to exit from the game");
                        break;
                }
            } while (op != 3);
        }// End of main method

        //Impimentaion of random string generater function
        static string RandomStringGenerator()
        {
            string[] listwords = new string[10];
            listwords[0] = "sheep";
            listwords[1] = "goat";
            listwords[2] = "computer";
            listwords[3] = "america";
            listwords[4] = "watermelon";
            listwords[5] = "icecream";
            listwords[6] = "jasmine";
            listwords[7] = "pineapple";
            listwords[8] = "orange";
            listwords[9] = "mango";
            Random randomGen = new Random();
            int randomNumber = randomGen.Next(0, 9);
            string randomString = listwords[randomNumber];
            return randomString;
        }

        //IImpimentation of guess by word function
        static void GuessByWord()
        {
            string userGuessString = "";
            string randomString = RandomStringGenerator();    
            int guessCount = 0;
            int guessLimit = 10;
            bool outOfGuesses = false;
            while (userGuessString != randomString && !outOfGuesses)
            {
                if (guessCount < guessLimit)
                {  
                  Console.WriteLine("Enter Your Guess string: ");  
                    userGuessString = Console.ReadLine();
                    guessCount++;
                }
                else
                {
                    outOfGuesses = true;
                }
            }
            if (outOfGuesses)
                Console.WriteLine("You Loose");
            else
                Console.WriteLine("You Won the Game");
        }

        //Impimentation Get by charecter function
        static void GuessByChar()
        {
            int guessCount = 0;
            char playerGuess;
            string st = "";
            bool istrue = false;

            string randomString = RandomStringGenerator();
            char[] randomChar = randomString.ToCharArray();
            Console.WriteLine("Enter Your Guess Charecter");
            for (int i = 0; i < randomChar.Length; i++)
                randomChar[i] = '_';

            while (guessCount < 10 && !istrue)
            {
                string str = Console.ReadLine();

                if (!char.TryParse(str, out playerGuess))
                   Console.WriteLine("Please Enter valid Charecter");

                    guessCount++;

                    for (int j = 0; j < randomString.Length; j++)
                    {
                        if (playerGuess == randomString[j])
                            randomChar[j] = playerGuess;
                    }
                
                    PrintFunction(randomChar, randomString, playerGuess);
                    CheckValue(playerGuess, randomString);
                    st = new string(randomChar);

                    if (st.Equals(randomString))
                    {
                        istrue = true;
                        Console.WriteLine("You Won the Game");
                    }
                
            } // End of while loop
            if (!st.Equals(randomString))
                Console.WriteLine("You Lost  the Game");
        }

        //Implimentaion of user input selection function
        static int UserInputNumber()
        {
            int number = 0;
            bool wasNotNumber = true;
            do
            {
                try
                {
                    Console.WriteLine("Welcome to Hangman!!!!!!!!!!");
                    Console.WriteLine("Enter 1 to Play a Game, Guess by Word");
                    Console.WriteLine("Enter 2 to play a Game, Guess by Charecter");
                    number = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("must enter somthing");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("was unable to read your number");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number was too big");
                }
            } while (!wasNotNumber);
            
            return number;
        }

        //Impimentation of capturing wrong input charecter entered by player function
        static void CheckValue(char playerGuessChar, string randomString)
        {
            StringBuilder sb1 = new StringBuilder();
            if (randomString.Contains(playerGuessChar))
                sb1.Append(playerGuessChar);
            else
            {
                sb.Append(playerGuessChar);                       
            }         
            Console.WriteLine("Missing: " + sb);           
        }  

        //Implimentation of print guessing values
        static void PrintFunction(char[] randomChar, string randomString, char playerGuess)
        {
            for (int k = 0; k < randomString.Length; k++)
                Console.Write("\t " + randomChar[k]);

            Console.WriteLine("");
            Console.WriteLine("Guess: " + playerGuess);
        }
    }
}

