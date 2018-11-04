# Snakes and Ladders Kata

## Approach

I decided to keep logics simple and contained within Dice and Player objects.

* Dice: provides a random number on each roll using System.Random
* Player: responsible for moving and verifying its position (token).
* Game: is a simple simulation of how a game could be constructed and played using the Player object.

## To consider

### Testing randomness of dice numbers

I implemented a simple test to verify the number that dice generates are in fact different by rolling dice 100 times and checking the result. In this particular case this test is light and does not require much resources to run.
 
The randomness of numbers however is not verified in my solution, if required this could be achieved by verifying the average percentage of times a number is generated (i.e. between 10% and 20% for each number).
