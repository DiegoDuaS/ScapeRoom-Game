# MazeOut: Escape Room Game

> **Un juego de aventura y acertijos físicos desarrollado en Unity.**

![Unity](https://img.shields.io/badge/Unity-2022.3%2B-black?style=flat&logo=unity)
![Language](https://img.shields.io/badge/Language-C%23-blue?style=flat&logo=csharp)
![Status](https://img.shields.io/badge/Status-Development-green)

**MazeOut** es un juego en tercera persona donde el jugador debe resolver acertijos de lógica y física para avanzar a través de diferentes salas. 

---

## 📺 Demostración

Mira un gameplay:

<p align="center">
  <a href="https://youtu.be/IIkuU5bcB3w">
    <img src="https://img.youtube.com/vi/IIkuU5bcB3w/0.jpg" alt="MazeOut Gameplay" width="600">
  </a>
</p>

---

## 🕹️ Mecánicas y Características Principales

### 1. Sistema de Interacción (Pickup System)
El jugador interactúa con el entorno mediante un sistema basado en **Raycasting**:
* **Detección Visual:** Los objetos cambian de color al ser detectados por el rayo central de la cámara.
* **Manipulación Dinámica:** Al agarrar un objeto, se ajusta su escala, se desactiva su gravedad y se emparenta a la mano del jugador.

### 2. Arquitectura de Sistemas (Managers)
* **AudioManager (Singleton):** Sistema persistente que no se destruye entre escenas. Utiliza canales separados para efectos de sonido (`PlayOneShot`) y música de ambiente con soporte para detener y cambiar clips.
* **ScenesManager:** Controlador centralizado para la navegación entre el menú principal y la escena de juego, asegurando que el flujo de tiempo se restablezca correctamente.
* **LevelManager:** Actúa como el cerebro de la escena, gestionando el conteo de coleccionables, la apertura de puertas y los estados de victoria o pausa.

### 3. Gestión de Pantallas y UI
* **Menú de Pausa:** Implementado mediante el `LevelManager`, permite congelar el tiempo (`Time.timeScale = 0`), liberar el cursor del mouse y ocultar el puntero de juego.
* **Pantallas de Estado:** El juego gestiona dinámicamente pantallas de "You Win", menús de pausa y notificaciones de Checkpoint.
* **Audio de Menú:** Uso de scripts dedicados para disparar música ambiental específica al cargar menús o escenas iniciales.

### 4. Puzzles y Seguridad
* **Botones Físicos:** Detectan objetos con el tag `Sphere` para activar eventos y reproducir sonidos a través del AudioManager.
* **Sistema de Respawn:** Si un objeto clave o el jugador caen al vacío, son devueltos automáticamente a sus posiciones iniciales o al último checkpoint.

---

## 🛠️ Detalle Técnico (Scripts Principales)

| Script | Descripción Técnica |
| :--- | :--- |
| `AudioManager.cs` | Gestiona múltiples `AudioSource` para SFX y Ambience usando un patrón Singleton persistente. |
| `ScenesManager.cs` | Orquestador de cambio de escenas y reseteo de la escala de tiempo (`Time.timeScale`). |
| `LevelManager.cs` | Controla el flujo del nivel, el estado de pausa, coleccionables y la lógica de victoria. |
| `PickupSystem.cs` | Maneja el agarre de objetos mediante Raycasts y manipulación de jerarquías de Transform. |
| `Button.cs` | Detecta colisiones mediante `OnTriggerEnter` y activa la recolección de monedas. |

---

## ⌨️ Controles

| Acción | Input (Teclado/Mouse) |
| :--- | :--- |
| **Movimiento** | `W`, `A`, `S`, `D` |
| **Interactuar / Agarrar** | `Clic Izquierdo` |
| **Pausar / Menú** | `P` |
| **Saltar** | `Barra Espaciadora` |

---

## Instalación y Uso

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/DiegoDuaS/ScapeRoom-Game.git](https://github.com/DiegoDuaS/ScapeRoom-Game.git)
    ```
2.  **Abrir en Unity:**
    * Abre **Unity Hub**.
    * Haz clic en "Add" y selecciona la carpeta clonada.
    * Versión recomendada: **Unity 2022.3 LTS** o superior.
3.  **Configuración:**
    * Asegúrate de añadir las escenas MainMenu y MainGame en las configuraciones de construcción (Build Settings) para que el ScenesManager funcione correctamente.
3.  **Jugar:**
    * Abre la escena `MainMenu` en la carpeta `Assets/Scenes`.
    * Dale al botón **Play**.

---

## Créditos

* **Desarrollador:** Diego Duarte
* **Assets:**
  - https://assetstore.unity.com/packages/3d/props/wooden-boxes-257121
  - https://assetstore.unity.com/packages/3d/props/poly-halloween-pack-236625
  - https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/prototype-stylized-skeleton-350102
  - https://assetstore.unity.com/packages/vfx/particles/fire-explosions/free-fire-vfx-urp-266226
  - https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-updates-in-new-charactercontroller-pa-196526

---
