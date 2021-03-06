# EwanCotter_Project_1 - Creative redesign of SMART brain training program

The included C# code was created for the Unity game engine as part of a final year group project for Psychology and Computing. 
<br />
<br />The goal of the project was to creatively redesign an existing brain training program as to make it more engaging for the users. 
<br />Included is part of the final prototype(out of three), where each prototype was reviewed and reported on with test users. 
<br />The old program was found to be too repetitive, not visually stimulating and generally boring to interact with,
while the final prototype reported a significant improvement in these areas. 

-------------
**My role**<br />
I was a developer for this project, working directly with the design and development of each prototype. 
<br />Developers of the program would be responsible for implementing ideas and feedback from our testers, which would be gathered by the UX researchers of the group(who were responsible for user research)
<br />I was also tasked with creating all the digital art that would be created for this project and played a large role the ideation of the project.
Each team member would also be responsible for their own academic research, which would influence some design decisions throughout and some considerations made in the final report.


--------------
**Research**
<br />Extensive research was performed prior and during the project, citing upwards of 30+ academic papers in the final report. 
<br />The areas of research included many different academic disciplines including Psychology, Human Computer Interaction and Human centred computing
also including writings from professionals in the areas of game design and development. 
<br />
<br />As part of this project, evaluations were performed on the original brain training program and at each prototyping phase. 
<br />Evaluations were gathered in the form of surveys and interviews with a total of 30 participants. 
<br />Each prototype evaluation directly contributed to the next design phase as is consistent with most development models.

-------------
**Development**
<br />In order to make the brain training program more engaging the team and I decided to convert the program into a role playing game,
in which the user would fight waves of enemies by selecting the correct attack to counter the enemies' attack, losing health if incorrect.
<br />The questions would be constructed in a way similar to the original program, converting the more mundane questions
![image](https://user-images.githubusercontent.com/76906306/128596719-51d0f395-3a5f-4741-859a-925f152b886d.png)
<br />Into dynamic enemy interactions<br />
![image](https://user-images.githubusercontent.com/76906306/128596736-204ed305-f3d4-4394-b04e-28cd3d06328d.png)
<br />The prototype design software used in this project was Picolo(prototype 1) and the Unity game engine(prototype 2, 3). 
<br />Original art was also created using the graphic design software Krita, art work for 16 counter attacks, 8 backgrounds and 36 enemy variants were created for the final two prototypes<br/>
![image](https://user-images.githubusercontent.com/76906306/128596865-724beef9-e1e2-46d0-94c7-590709dfba48.png)
 <br/>while Prototype 1 had very basic artwork.<br/>![image](https://user-images.githubusercontent.com/76906306/128596928-7630e808-6dee-432d-92d4-ea265baaf396.png)
 <br />
<br />**Prototype 1** was developed in order to convey the basic idea of the game to our testers, it had virtually no animations and was essentially
an online substitute for what would have been a paper prototype before COVID. 
<br />**Prototype 2 and 3** were created as more high fidelity prototype versions of P1, incorporating the preferred aspects from our user evaluations.
P2 had limited animation and no sound while P3 added sound and animations for multiple aspects of gameplay including enemy death and player damage.<br />
<br />
The Unity game engine is very powerful and does not require as much conventional programming as some other game creation packages that were considered. 
Before the project both developers had limited experience with C#, Unity and digital Art creation but became quite adept towards the end of the process. 

---------
**Content**<br />
The game consists of a brief tutorial and three enemy stages; the cave, the forest and the castle. Each stage represents the introduction of major game mechanics, thus increasing the difficulty as the player progresses. <br />
The player is presented with a series of scenarios where an enemy is attacking and there is a 'correct' counter move, however, environmental such as weather or light level conditions change what the actual correct answer would be. <br />
After answering the player moves on to the next enemy, taking damage for a wrong answer or killing the enemy otherwise<br />
During these interactions the player must use and develop relational reasoning skills to progress without dying. Relational reasoning being the basis for the original brain training program. 

<br /><br />
Each section(cave, forest, castle) came in the form of separate scenes in Unity, which meant only one is loaded at once. 
<br />Enemy interactions were in the form of a stack of panels, which contained the content such as enemy sprites, question text and answer sprites. which could be 'activated' and 'deactivated' when needed.<br />
Essentially, the player moved through this stack of interactions with one panel activated at once and deactivate when completed.<br />
To detect the player input, an invisible panel was placed on top of the stack with mouse-click listeners.<br />
This removing the need to program listeners for each indiviual enemy interaction and instead generate an array with the button index(0,1 or 2) of each correct answer, then checking if the player selected this button. 



