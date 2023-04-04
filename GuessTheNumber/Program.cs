using System.Security;

Random r = new Random();
int numberToBeGuessed = r.Next(1, 100);
Console.WriteLine("You have to guess a number between 1 and 100!(inclusive)");
Console.WriteLine("You have 5 attempts. Good Luck!");
int attemptsLeft = 5;
bool playerWin = false;
while (attemptsLeft > 0)
{
    attemptsLeft--;
    int currentGuess = int.Parse(Console.ReadLine());
    if (currentGuess < 1 || currentGuess>100)
        while(currentGuess < 1 || currentGuess > 100)
        {
            Console.WriteLine("Please enter a number between 1 and 100 (inclusive)!");
           currentGuess = int.Parse(Console.ReadLine());
        }    
    if (currentGuess == numberToBeGuessed)
    {
        if(attemptsLeft == 4)
        Console.WriteLine($"Congrats you won on your first guess !!!");
        if(attemptsLeft == 3)
        Console.WriteLine($"Congrats you won on your second guess !!!");
        if (attemptsLeft == 2)
            Console.WriteLine($"Congrats you won on your third guess!!!");
        if (attemptsLeft == 1)
            Console.WriteLine($"Congrats you won on your forth guess!!!");
        if (attemptsLeft == 0)
            Console.WriteLine($"Congrats you won on your last guess!!!");
        playerWin = true;
        break;
    }
    if(currentGuess > numberToBeGuessed && attemptsLeft!=0)
    {
        Console.WriteLine($"The number is lower than {currentGuess}.");
        if(attemptsLeft > 1)
            Console.WriteLine($"{attemptsLeft} attempts left.");
        else
            Console.WriteLine("Last chance.");
    }
    if (currentGuess < numberToBeGuessed)
    {
        Console.WriteLine($"The number is higher than {currentGuess}.");
        if (attemptsLeft > 1)
            Console.WriteLine($"{attemptsLeft} attempts left.");
        else
            Console.WriteLine("Last chance.");
    }
}
if (!playerWin)
{
    Console.WriteLine("You don't have more attempts.");
    Console.WriteLine($"The number was {numberToBeGuessed}.");
    Console.WriteLine("Better luck next time!");
}
//Start by guessing 50. Either you're right, in which case you're done, or you're wrong;
//if you're wrong, then you know that the number is either in [1,49] or [51,100], so that there are only 49 or 50 possibilities left.
//Now, assuming that you aren't already done, you have a collection of 49 or 50 possibilities left; guess the middle one. 
//That is, if you are on [1,49], guess (25; if you're on [51,100], then guess(75. If you got it right: great.
//If not, then you find out whether it should be higher or lower; in particular,
//if you previously knew it was in [1,49], then you either now know it is in [1,24] or you now know it is in [26,49].
//If you previously knew it was in [51,100], then either you know that it is in [51,74] or that it is in [76,100].
//In any case, you have either already guess right, or you have narrowed down the possibilities to one of [1,24], [26,49], [51,74], or[76, 100].
//In any one of these cases, there are at most 25 possibilities left, and it must be one of them.
//Continue in this way: cut your current interval of possibilities in half by a guess,
//so that you are either right or you can discard roughly half of the possibilities based on the announcement of "higher" or "lower".
//By continuing this process,
//in the third step you narrow it down to at most 12 possibilities;
//in the fourth, to at most 6 possibilities.
//On your last guess u have 16% chance to guess right 



