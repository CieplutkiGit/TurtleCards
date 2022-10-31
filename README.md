# ♠️TurtleCards🐢
A simple Clash Royale alike game!
#
**Features:**
- Unlimited cards options! You can create as many as you want and need!
- Unlimited units options! You can create as many units as you want! From simple warriors, archers to dragons or buildings!
- Board created from boxes! You can set your own pattern or change material of each box or many more!
- GameReady! Put your sprites for cards and 3D models for units and you are ready to go! 
- No need to worry about camera! Camera automaticaly fit into board size so fell free to change size of board!
- Mobile ready! Works without any problem on Android and iOS! Or you can play on PC using mouse! Propably works fine on VR as well!
# Some guidelines
**Creating new Cards**

To create new card simple right click and select card option from create menu
![image](https://user-images.githubusercontent.com/68950131/199023961-c7e86756-c4fa-48b6-b994-4f7fb6f44d96.png)

Then just simply fill out name ID splashArt(sprite of the card that ll be used in game!) and Unit
![image](https://user-images.githubusercontent.com/68950131/199025184-30af6b84-a81c-4f74-b870-a2b20d4e806c.png)

**When you have your card ready create Unit same as you did with card just pick >Unit instead of card option**

![image](https://user-images.githubusercontent.com/68950131/199025614-6bc43e33-67ca-49c7-9169-78e3aaf7defc.png)

**Fill out unit variables, enemy and player base transforms are prefabs of those gameobject, to add them simply pick them from prefabs folder,
note that when you move those object on scene you need to save them so position of those object will be updated othervise units gonna go
in to place where base was previous!** (you can also add to BaseUnit.cs simple line of code in start function that will find those object it's up to you!)

**When you check isBuilding, object not gonna move even when you set speed above 0!**

**And at the end add prefab that contain 3D model, Canvas with image for health bar, and ```UnitBase.cs```**

**Thats it your new card was created! Now add this card to ```CardsManager.cs``` in hierarchy Managers>CardsManager and simply drag and drop Card
to Cards array**

**Read note under to know how to use your cards in game and how to save and load deck!**

#
**Note!**
Game does not contain lobby menu or any other scene so for example if you want to save your deck its simply stored in PlayerPrefs example usage:
```C#
PlayerPrefs.SetString("Cards", "1|1|3|2|0|1|3|2");
```
Where number stands for card ID and "|" is used to separate ID's example real time deck saving:
```C#
CardScriptableObject[] playerCards;
string newDeck; 
  for(int i = 0; playerCards.Lenght; i++)
    {
      newDeck += playerCards[i].cardID + "|";
    }
PlayerPrefs.SetString("Cards", newDeck);
```
And then simple load deck:
```C#
string[] cardsID = PlayerPrefs.GetString("Cards").Split("|");

        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCards[i] = cards[int.Parse(cardsID[i])];
        }
```
You can also save it in json file or any other way you want! Up to you!
You can send that string to server to save player deck in cloud or in case you want to create online version of it!

**Note!** Defalut deck have 8 cards and 4 cards on screen, you can change those setting in ``` CardsManager.cs slots[]``` by changing 
number of slots (how many cards player have on screen to pick from) and in ``` CardsManager.cs playerCards[]``` (how many cards in total player have - full deck)

<img align="left" src="https://user-images.githubusercontent.com/68950131/199029366-e7601dfc-f5db-4579-982f-6772c1c22aec.png">

**Map is made of cubes, in ```MapManager.cs``` you can change size and colors of map, if you want to use textures instead of colors, just simply replace
line of code:**
```C#
tileRenderer.material.color = Color.yellow;
```
**To:**
```C#
tileRenderer.material = yourCoolMaterialWithTextureAttahedToIt;
```
**So now instead of yellow blocks you will have blocks with your material, the same you can do to green blocks, you can change order how they spawning and any other stuff 
that you want its just simple loop with modulo that spawning them!**



If you want to spawn every block alone with time bettwen next one just put it in coroutine!

<img align="right" src="https://user-images.githubusercontent.com/68950131/199035673-89176133-e455-4148-a8e9-0bbd481bc98f.png" width="125" height="175">

All block should have colliders! Camera is scaling to bounds of encapsulated colliders of all of them!

**If you want to create space on middle of map just simple put if in loop example like this: if(j != z/2){spawn cubes}; 
this will skip middle row and it ll look like this**


<pre>



</pre>

#
Enemy AI is quite stupid as it only spawn random card in specific area but you can change AI cards spawn area and spawn time in ```SimpleEnemyBot.cs```
But enemy units work same as yours so be prepared for battle!

# Thats all for now! Will update read me when I add new stuff to this project C:

