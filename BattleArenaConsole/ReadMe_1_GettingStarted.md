
### BATTLE ARENA CODE TUTORIAL ###

Welcome to the BattleArena Code Tutorial.


# GETTING STARTED:

This tutotial attempts to help step you through the basics of creating a simple application while adding fundamental OOP (Object Oriented Programming) concepts. We'll be using C# for the language.

We'll initially begin with a command line console application then build that base up and tease out a web and windows based version as well as web services and a mobile interface later.

But to get started, we want to keep it somewhat simple. Fwiw, this isn't necessarily going to replace more formal study but is intended to be a hands-on study companion.

I hope it helps.



# TRY THE APPLICATION:

While you can look through the code via github and even play around by replacing ".com" with ".dev" (https://github.dev/mdbarton/BattleArenaConsole), you'll need Visual Studio to run it, etc.

Download the free version of Visual Studio:
https://visualstudio.microsoft.com/vs/community/

Load the project from gitHub [more] and click "Debug" on the menu bar then "Start Debugging".

We'll explore Visual Studio more as the project exapnds but for now, you can add "breakpoints" by clicking on the far left grey area just past the lines numbers. When debugging the code will pause wherever you place a breakpoint.

[more]


# LOOK AT THE CODE:

First, understand, this is not "correct" code, we will improve it through these projects but it's better not to think that there is always one "correct" way to do something, rarely is that the case.

There is however objectively "wrong" code, including here. Hopefully we'll be able to show why it's "wrong" and how to improve as we move into the next projects.

Here's the basic flow, add breakpoints and "step-through" it (click the play button once paused) to watch for yourself.
 - upon start, code in the Program class will be executed, so line 8 instantiating "var g = new Game();" creates a new Game class (line 14)
 - the Game class has two "Private" fields for "Player" and "Opponent" both of the Combtant datatype
 - once the class is instantiated, the constructor (line 18) runs creating both Compatants and calling the "Arm" method with different Weapons
 - then the next line "g.Start()" invokes the "Start" method in game (line 31)
   * it's valuable to understand "g" is the specific instance of the Game class, we could have mulitple instances but methods, etc. only run on the specfic instance
 - The Start method waits for user to enter some text, we'll add more later but type "attack" and the attack method will be called for player (you)
 - The game will keep checkin input until the user types "quit"

Please note, this UI (User Interface) is quite amateurish. We'll build it out some but it's not ideal - here though, we're trying to focus less on the presentation and more on what happens inside.


# DATATYPES:

Data "Types" describe what "kind" of data something is. Data can be broken down into text types (Char or String), numbers (Int, Float) or more complex types.

Strings (ie "hello") and Int (ie 5) are some of the most common. "Classes" and "Objects" are also datatypes, as are the types you define by writing a Class.

[examples in projects]


# OBJECTS / CLASSES:

Understanding the different terminology can be tough so for now, we'll just try to make some sense of creating objects and using them.

In OOP, "classes" are used to "compartmentalize" our code. Most often, we'll be defining objects that we then intend to use to do stuff.

An "object" could be many things, a "book", "car", etc. It will generally have some datapoints of a defined datatype (usually called properties or fields) and business logic that allows it to do stuff.

For example, in our "Objects" folder, we have a "Combatant" with defined "properties" for Strength & Dexterity (Int16, aka short), Hitpoints (Int32 aka int) and a "weapon" with a custom datatype of "Weapon" which we've also defined.

We then have two methods, "Arm" to allow the combatant to arm a weapon and "Attack" to attack an opponent.

We also have the object's "constructor" which executes when an onject is first instantiated.



# PRIVATE / PUBLIC:

Properties and methods (and much else we'll get to) have "accessibility" settings like "Public" and "Private" (there are more).

You'll notice the "weapon" field in combatant is set to Private, that means a class that instantiates it (ie )


## STUFF TO TRY ##
- step through the Combatant class, Arm and Attack, change accessibilities and datatypes, see what breaks
[more]