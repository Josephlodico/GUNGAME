# 🔫 GUNGAME
<img width="1857" height="781" alt="GunGamePic" src="https://github.com/user-attachments/assets/cd94b661-de6e-4e84-b720-e809881e560d" />

A text-based console adventure game built in C# where you fight monsters, solve puzzles, and escape through a series of challenging rooms.

> Made by Joseph & Anthony | April 2024

---

## 🎮 About the Game

You wake up in a mysterious room. A gun lies in front of you. What do you do?

GUNGAME is a turn-based console RPG where you must clear **5 unique rooms** — each with its own challenge — before the locked final door will open and let you escape.

---

## 🚪 The Rooms

| Room | Challenge |
|------|-----------|
| 🔴 Red Room | Fight 3 enemies in a row: a Goblin, a Blob, and a Goomba |
| ⚫ Black Room | Type a code correctly within **15 seconds** |
| 🟢 Green Room | Answer True/False trivia questions correctly |
| 🩷 Pink Room | Spot the difference between two ASCII images |
| 🔵 Blue Room | Duel your shadow clone in a fight to the death |
| 🔒 Locked Room | Opens only once all 5 rooms are completed |
| 🟡 Gold Room | Access your inventory and pick up a medkit |

---

## ⚔️ Gameplay Features

- **Turn-based combat** with randomized damage values
- **Bullet management** — run out and it's game over
- **HP tracking** across all rooms
- **Medkit** healing item usable during the Blue Room boss fight
- **Save system** that records your progress
- **Room completion tracking** — you can't replay a finished room

---

## 🛠️ Built With

- **C#** / **.NET Framework 4.8**
- Visual Studio 2022

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/NarrativeProject.git
   ```
2. Open `NarrativeProject.sln` in Visual Studio
3. Build and run the project (`F5` or `Ctrl+F5`)

> Requires .NET Framework 4.8

---

## 📁 Project Structure

```
NarrativeProject/
├── Program.cs          # Main game loop and room logic
├── Game.cs             # Room management and transitions
├── Room.cs             # Abstract base class for rooms
├── Rooms/
│   ├── redroom.cs
│   ├── blackroom.cs
│   ├── greenroom.cs
│   ├── pinkroom.cs
│   └── blueroom.cs
└── Properties/
    └── AssemblyInfo.cs
```

---

## 💡 Tips

- Always pick up the **medkit** from the Gold Room before entering the Blue Room
- In the Red Room, choosing **not** to attack still lets the enemy hit you — fight back!
- The Black Room timer starts the moment the code is displayed, so read fast

---

*This project was created as part of a school assignment using Git and GitHub for version control.*
