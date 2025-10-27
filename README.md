# DIG4778C_Lab4

## **Shooter Prototype**

This is a simple shooter prototype where the player controls a spaceship and the goal is to shoot meteors. The player only has one life, and after shooting 5 meteors, a giant meteor which takes 5 shots spawns.

The Player.cs and Shooting.cs scripts use Unity's new input system to detect and implement the user's input for movement and shooting.

The meteors are repeatedly spawned through the GameManager.cs script and are constantly orbiting around and facing the player. They are destroyed when hit by a laser.

The Cinemachine is used to create a camera that tracks the spaceship and has a screen shake when the player destroys a meteor.
