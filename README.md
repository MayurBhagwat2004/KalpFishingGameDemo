# KalpFishingGameDemo
**Author:** Mayur Sunil Bhagwat

Hello Kalp Team!

Thank you for the opportunity to take this assessment. I had a lot of fun building this out.

Below is a breakdown of my architectural decisions, how to navigate the project, and the assets I used. I focused heavily on writing scalable, clean code over spending time on visual polish, keeping the delivery speed in mind.

## Project Setup and Navigation
* **Unity Version:** 2022.3.62f2
* **Render Pipeline:** 3D URP
* **Scenes:** 1.`MainMenu`
2.`FishingLevel`
* **Build:** A compiled windows `.exe` is located in the `/Build/` folder at the root of this repository.

## Architecture & Design Decisions
### 1. Finite State Machine (FSM) for Fishing Logic
Rather than stuffing all the casting, waiting, and reeling logic into a single `Update()` loop filled with boolean checks, I built an Object-Oriented State Machine.
* **`FishingStateBase.cs`**: An abstract blueprint enforcing `EnterState`, `UpdateState`, and `ExitState` methods.
* **The States**: Logic is strictly isolated into `IdleState`, `CastingState`, `WaitingState`, and `ReelingState`. 

### 2. Data-Driven Design with ScriptableObjects
Adding new fish to the game shouldn't require a programmer to touch C# scripts. 
* I created a `FishData.cs` ScriptableObject template.
* The three assessment fish (*Coastal Catfish, Majili Snapper, Golden Mackerel*) exist purely as asset files in the `Assets/ScriptableObjects/` folder.

### 3. Event-Driven UI & Decoupling
To satisfy the Single Responsibility Principle, managers do not directly reference each other.
* The Main Menu uses a static `MenuEvents` action class. The UI buttons fire events, and the `SceneLoader` and `AppManager` listen for them. 
* The `SceneLoader` safely handles `SceneManager.LoadSceneAsync`, normalizing the `0.9f` progress quirk to ensure the loading bar smoothly reflects actual loading times.
* The `FishingManager` only calculates the math for the minigame; it passes the raw numbers to the `UIManager` to handle the visual representation of the tension and progress bars.

**Playable Windows Build:** [Download .exe from Google Drive] (https://drive.google.com/file/d/1qhes_ZlnNPm-yvsOuwQwAuk-_863oMS_/view?usp=sharing)