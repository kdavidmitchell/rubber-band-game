<h1 align="center">
  :video_game: The Rubber Band Game :video_game:
</h1>

Code base for adaptive difficulty AI demo built with Unity. Created in _partial
fulfillment_ of ECS289G Fall 2020 course requirements.

## Contributors ##

1. [Aakash Prabhu](https://github.com/aakash1104)
1. [Aaron Ong](https://github.com/aabong)
1. [Arunpreet Sandhu](https://github.com/ASandhuZero)
1. [Kyle Mitchell](https://github.com/kdavidmitchell)

## About ##

<p align="center">
    <img src="images/main_menu.png" alt="Main Menu render"
    height="75%" width="75%">
</p>

This project is a basic game demo that highlights a genetic algorithm being used
to guide generation of content based on the skill of the player. This game takes
the shape of a 2D arena game where the difficulty of each enemy is dynamically
adjusted through procedural content generation according to the state of the
player character or token, which we use as a proxy for player skill.

In regards to expressive intelligence, if we accept the premise that intelligent
game design incorporates elements of fun to keep the player engaged and in a
state of flow, then it follows that dynamic difficulty adjustment is a form of
expressive intelligence. Much like an educator that helps struggling or bored
students out of a duty of care, we feel that game designers and developers
should also introduce systems that “care” about meeting the player where they
are before dropping them into situations that outpace or fail to keep pace with
their skill.

At the heart of this project is the goal to reduce the amount of
frustration or boredom that arises when a player finds a game too difficult or
too easy, or more simply, when it stops being fun.

## Motivation ##

We were fascinated by the concept of
[Dynamic Game Difficulty Balancing](https://en.wikipedia.org/wiki/Dynamic_game_difficulty_balancing)
and wanted to try it out implementing our own novel version of it for a simple
game. The game difficulty balancing is decided by our natively implemented
[genetic algorithm](https://en.wikipedia.org/wiki/Genetic_algorithm)

## Installation ##

You can get a copy of this project up and running in the following ways,
depending on how you wish to use it:

### Game Only ###

If you only wish to play the final game, please download/clone this repository
and find the executable file in the Build folder at the root of this repository.
There will be executables for Windows and MacOS.

### Build Project from Source ###

1. If you wish to build this project from source, it is recommended you have
[Unity 2019.4.12f1](https://unity3d.com/unity/whats-new/2019.4.12) installed on
your machine.

1. Clone this repository:
```shell
git clone https://github.com/kdavidmitchell/rubber-band-game.git
```
After cloning/downloading this repository, open a new project in
Unity with this repository's folder as the project folder.
