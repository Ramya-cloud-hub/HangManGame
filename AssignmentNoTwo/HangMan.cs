using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AssignmentNoTwo
{
    public class HangMan
    {
      static StringBuilder sb = new StringBuilder();
      static StringBuilder sb2 = new StringBuilder();
       public string st;
        static void Main(string[] args)
        {
            HangMan obj = new HangMan();
            Print p = new Print();
            p.PrintScreen();
            int op = 0;
            do
            {
                 op = UserInputNumber();
            
                switch (op)
                {
                    case 1:
                        obj.GuessByWord();
                        break;
                    case 2:
                       obj.GuessByChar();
                        break;
                    default:
                        Console.WriteLine("Press 3 to exit from the game");
                        break;
                }
            } while (op != 3);
        }// End of main method

        //Impimentaion of random string generater function
        public static string RandomStringGenerator()
        {
            string[] listwords = new string[10];
            listwords[0] = "america";
            listwords[1] = "goat";
            listwords[2] = "computer";
            listwords[3] = "river";
            listwords[4] = "yellow";
            listwords[5] = "summer";
            listwords[6] = "jasmine";
            listwords[7] = "prince";
            listwords[8] = "orange";
            listwords[9] = "mango";
            Random randomGen = new Random();
            int randomNumber = randomGen.Next(0, 9);
            string randomString = listwords[randomNumber];
            return randomString;
        }

        //IImpimentation of guess by word function
        public  void GuessByWord()
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
                Console.WriteLine("You Lost the Game\n");
            else
                Console.WriteLine("You Won the Game\n");
        }

        //Impimentation Get by charecter function
     public  void GuessByChar()
        {
            int guessCount = 0;
            int currectGuessCountThree = 0;
            char playerGuess;
            string st = "";
            bool istrue = false;
            bool isSameChar = true;
             

            string randomString = RandomStringGenerator();
            Console.WriteLine(randomString);
            char[] randomChar = randomString.ToCharArray();
            for (int i = 0; i < randomChar.Length; i++)
                randomChar[i] = '_';

            while (guessCount < 10 && !istrue)
            {
                 playerGuess = UserInputChar();//User input char function
                 isSameChar = CheckRepeatChar(playerGuess); //Funtion calling to check user entered same char twice
                if (isSameChar)
                { 
                    guessCount ++;
                    
                    for (int j = 0; j < randomString.Length; j++)
                    {
                        if (playerGuess.Equals(randomString[j]))
                        {
                            randomChar[j] = playerGuess;
                            currectGuessCountThree++;
                        }
                    }

                    PrintFunction(randomChar, randomString, playerGuess);
                    CheckValue(playerGuess, randomString);
                    st = new string(randomChar);
                    if (currectGuessCountThree >=3 )
                    {
                        GuessTheRemainingWord(guessCount, randomString);
                        break;

                    }
             
                }
                else
                    Console.WriteLine("You are not allowed to guess same Character twice");   
            } // End of while loop
          
        }
        //Implimentaion of user input selection function
        public static int UserInputNumber()
        {
            int number = 0;
            bool wasNotNumber = true;
            do
            {
                try
                {
                    Console.WriteLine("Welcome to Hangman!!!!!!!!!!");
                    Console.WriteLine("Enter 1 to Play a Game, Guess by Word");
                    Console.WriteLine("Enter 2 to play a Game, Guess by character");
                    Console.WriteLine("Enter 3 to Exit from the Game!");
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

        //Implimentaion of user input char value
         public char UserInputChar()
        {   
            bool isValidKey = true;  
            char ch = ' ';
            do
            {
                try
                {
                    Console.WriteLine("Enter Your Guess character");
                    ch = char.Parse(Console.ReadLine());               
                }
                catch (FormatException)
                {
                    Console.WriteLine("must enter correct format");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("was unable to read your number");
                }
            } while (!isValidKey);
            return ch;
        }

        //Impimentation of capturing wrong input charecter entered by player function
        public void CheckValue(char playerGuessChar, string randomString)
        {
            StringBuilder sb1 = new StringBuilder();
            if (randomString.Contains(playerGuessChar))
                sb1.Append(playerGuessChar);
            else
            {
                sb.Append(playerGuessChar);                       
            }
            Console.WriteLine("");
            Console.WriteLine("Wrong Guesses: " +sb);           
        }

        //Implimentation of print guessing values.
        public void PrintFunction(char[] randomChar, string randomString, char playerGuess)
        {
            for (int k = 0; k < randomString.Length; k++) 
                Console.Write("\t " + randomChar[k]);
            
            Console.WriteLine("");
            Console.WriteLine("Your Guess: " + playerGuess);
        }

        //Implimentation of if the player guesses the same letter twice, the program will not consume a guess.
      public  bool CheckRepeatChar(char guessChar)
        {
            char[] userInputCharList;
            bool isPresent = true;
         
            sb2.Append(guessChar);
            st = sb2.ToString();
            userInputCharList = st.ToCharArray();
            int length = userInputCharList.Length;         
            
            //loop to find repeated char 
           for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    //If any duplicate found
                    if (userInputCharList[i] == userInputCharList[j])
                    {
                        isPresent =false;
                        st =  st.Remove(st.Length-1, 1);
                        sb2.Clear();
                        sb2.Append(st);
                    }
                             
                }

            }  
            return isPresent;
        }
      public void  GuessTheRemainingWord(int guessCount , string randomString)
        {
            string userGuessString = "";
            int guessLimit = 10;
            bool outOfGuesses = false;
            while (userGuessString != randomString && !outOfGuesses)
            {
                if (guessCount < guessLimit)
                {
                    Console.WriteLine("Now guess the whole word: ");
                    userGuessString = Console.ReadLine();
                    guessCount++;
                }
                else
                {
                    outOfGuesses = true;
                }
            }
            if (outOfGuesses)
                Console.WriteLine("You Lost the Game\n");
            else
                Console.WriteLine("You Won the Game\n");
        }

    }
}

