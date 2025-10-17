# 🌌 Galaxy Shooter

**Galaxy Shooter** is a 2D vertical scrolling shooter game built in **Unity** with **C#**, focusing on modular game systems, object pooling, responsive controls, shader-based VFX, and event-driven interactions. It features multiple power-ups, audio feedback systems, and an extensible architecture built for scalability.

---

## 🎮 Gameplay Summary

- Navigate a player spaceship in a scrolling space environment.
- Shoot enemies, collect power-ups, avoid collisions.
- Features include enemy wave spawning, randomized power-up drops, and damage-based health reduction.
- The game ends when the player’s lives are depleted.

---

## 🧠 Technical Breakdown

### 🎯 Player Mechanics

- **Player.cs** implements:
  - 2D movement clamped within screen bounds using viewport conversion.
  - Dual and triple shot mechanics using coroutine-based cooldowns.
  - Temporary shield mechanic with visual indicators and layered collision logic.
- **Camera shake** and **flash VFX** are used to improve impact feedback.

### 🔫 Shooting & Weapon Power-ups

- **Three distinct power-ups**:
  - **Triple Shot**: Temporarily spawns a 3-way projectile spread.
  - **Speed Boost**: Multiplies player movement speed for a duration.
  - **Shield**: Adds a temporary shield that absorbs one hit.
- All power-ups are time-bound using `IEnumerator`-based coroutines.
- Projectiles use **object pooling** via prefab instantiation and manual reuse.

### 🤖 Enemy Behavior

- Enemies spawn at randomized x-positions and move downward with constant velocity.
- Respawn on screen exit to simulate endless waves.
- Basic AI with reactive collision:
  - On projectile hit → explosion, score increment.
  - On player collision → damage or shield depletion.

### 💡 Object Pooling & Performance

- Projectiles and power-ups avoid `Instantiate()` where possible.
- Use of manual pooling logic to reduce heap allocations and garbage collection spikes during gameplay.

### 🎨 Visuals & Shaders

- Basic **ShaderLab**/HLSL scripts power:
  - Pulsing shield effect (alpha modulation).
  - Engine exhaust glow and trail.
  - Simple sprite color overlays for hit indication.

### 🔊 Audio System

- AudioManager implemented as a singleton pattern.
- Centralized SFX management using `AudioSource.PlayOneShot`.
- Background music loops and individual sound triggers:
  - Laser fire, power-up pickup, explosion, shield break, etc.
- Volume control and mixer exposed for future UI sliders.

### 🧪 UI & Game Flow

- `GameManager.cs` orchestrates game state:
  - Score updates via event delegation.
  - Player death → game over UI activation.
  - High-score tracking planned via `PlayerPrefs` or cloud integration.
- Use of `Canvas` groups for fade in/out transitions.

---

## 🧰 Tools & Technologies

| Tech | Purpose |
|------|---------|
| Unity (2021.x) | Game engine |
| C# | Game logic, coroutines |
| ShaderLab / HLSL | Custom shader effects |
| TextMeshPro | UI rendering |
| Git & GitHub | Version control |
| Audacity / SFX packs | Audio processing |

---

## 🔍 Key Scripts

| Script | Function |
|--------|----------|
| `Player.cs` | Movement, shooting, damage, power-up logic |
| `Enemy.cs` | Movement, collision, destruction |
| `Laser.cs` | Bullet behavior |
| `PowerUp.cs` | Drop type handling and trigger logic |
| `SpawnManager.cs` | Wave generation with coroutine loops |
| `GameManager.cs` | Game state, UI transitions |
| `AudioManager.cs` | Centralized sound playback |

---

## 🧠 Learning Outcomes

- Implemented **game loop architecture** using `MonoBehaviour` lifecycle and coroutines.
- Learned **shader scripting** for performance-friendly visual effects.
- Built **modular, event-driven systems** for gameplay extensibility.
- Applied **object pooling** and performance profiling in Unity.
- Structured gameplay into **maintainable, scalable components** for future feature integration.

---

## 🚀 Future Enhancements

- Boss AI with health phases and patterns.
- Mobile version with adaptive UI and touch controls.
- WebGL build with pause/save system.
- Online leaderboard using Firebase or PlayFab.

---

## 🎮 Demo & Media

> Coming soon: WebGL playable link and demo GIFs.

---

## 📜 License

MIT — For educational and showcase purposes.

---

## 🙌 Acknowledgements

Thanks to Unity tutorials, Brackeys, and the open-source game dev community.
