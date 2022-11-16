
### BATTLE ARENA CODE TUTORIAL v2 ###

Now we'll dig a little deeper into how the code is organized and how to improve it.

Again, try test playing the application in debug mode. Set breakpoints to see how the code "flows".


# LOOK AT THE CODE:

Ok, we've still got lots of udly code but here's some areas of improvement


Here's the basic flow, add breakpoints and "step-through" it (click the play button once paused) to watch for yourself.
 - upon start, code in the Program class will be executed, so line 8 instantiating "var g = new Game();" creates a new Game class (line 14)
 - the Game class has two "Private" fields for "Player" and "Opponent" both of the Combtant datatype
   * it's valuable to understand "g" is the specific instance of the Game class, we could have mulitple instances but methods, etc. only run on the specfic instance
 - The Start method waits for user to enter some text, we'll add more later but type "attack" and the attack method will be called for player (you)




# INHERITANCE
- Inheritance is the idea that we can describe an object that does basic stuff then inherit from it to refine aspects
- "Weapon" is our parent class to describe all weapons available. "Sword" and "Axe" both inherit from it while adding new code
- The same happens with Combatant now leading to Paladin and Fighter.
- Code from the parent will exist in the inherited class, as long as it's not overridden.


# POLYMORPHISM
- Polymorphism allows us to alter ...

