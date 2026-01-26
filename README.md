# MazeOut: Escape Room Game

> **Un juego de aventura y acertijos físicos desarrollado en Unity.**

![Unity](https://img.shields.io/badge/Unity-2022.3%2B-black?style=flat&logo=unity)
![Language](https://img.shields.io/badge/Language-C%23-blue?style=flat&logo=csharp)
![Status](https://img.shields.io/badge/Status-Development-green)

**MazeOut** es un juego en tercera persona donde el jugador debe resolver acertijos de lógica y física para avanzar a través de diferentes salas. 

---

##  Demostración

Mira un gameplay:

<p align="center">
  <a href="https://youtu.be/FT3sdVFLXjE">
    <img src="https://img.youtube.com/vi/FT3sdVFLXjE/0.jpg" alt="MazeOut Gameplay" width="600">
  </a>
</p>

---

## Mecánicas y Características Principales

Este proyecto implementa varias mecánicas complejas desarrolladas desde cero en C#:

### 1. Sistema de Interacción (Pickup System)
El jugador puede interactuar con el entorno usando un sistema basado en **Raycasting**:
* **Detección Visual:** Los objetos interactuables cambian de color cuando el jugador los mira.
* **Manipulación de Objetos:** Capacidad de agarrar, transportar y soltar objetos.
* **Ajuste Dinámico:** Al agarrar un objeto, este ajusta su escala, desactiva sus físicas y se emparenta al jugador. Al soltarlo, recupera su tamaño, posición y físicas (inercia).

### 2. Puzzles Físicos y Lógicos
* **Botones de Presión:** Interruptores de suelo que detectan objetos específicos y reaccionan con animaciones de escalado y eventos.
* **Empuje de Objetos:** Implementación de fuerza física en el controlador del personaje para poder empujar esferas pesadas, calculando vectores de dirección y masa.
* **Materiales Físicos:** Uso de `Physic Materials` para crear superficies con rebote y fricción personalizada.

### 3. Gestión del Nivel (Game Architecture)
* **Level Manager Centralizado:** Un script maestro que controla el estado del juego.
* **Sistema de Eventos:** Las puertas no "preguntan" si pueden abrirse; el Manager les envía la señal, optimizando el rendimiento.
* **Checkpoint & Respawn:** * Sistema de **SpawnPoints** y **DeathZones**.
    * Si un objeto clave cae al vacío, un script de seguridad (`ObjectRespawn`) lo devuelve a su posición original automáticamente.

### 4. UI y Feedback
* Sistema de recolección de monedas con condiciones de victoria.
* Pantalla de **"You Win"** animada con Sprites 2D integrados en el Canvas al completar los objetivos.

---

## 🛠️ Detalle Técnico (Scripts)

Breve descripción de la lógica implementada en los scripts principales:

| Script | Descripción Técnica |
| :--- | :--- |
| `PickupSystem.cs` | Maneja Raycasts, `ViewportPointToRay`, Layers y manipulación de padres/hijos (`SetParent`). Integra el **New Input System**. |
| `LevelManager.cs` | Actúa como el cerebro de la escena. Gestiona contadores y referencias a objetos dinámicos (Puertas). |
| `Button.cs` | Detecta colisiones `OnTriggerEnter` filtrando por Tags específicos y modifica `Transform.localScale` para simular presión. |
| `PushRigidBody.cs` | Utiliza `OnControllerColliderHit` para aplicar fuerza (`linearVelocity`) a objetos físicos al caminar contra ellos. |
| `ObjectRespawn.cs` | Guarda `initialPosition` en el `Start` y resetea el objeto si toca un trigger de zona muerta. |

---

## Controles

| Acción | Input (Teclado/Mouse) |
| :--- | :--- |
| **Movimiento** | `W`, `A`, `S`, `D` |
| **Cámara** | Mouse |
| **Interactuar / Agarrar** | `Clic Izquierdo` |
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
3.  **Jugar:**
    * Abre la escena `Level1` (o el nombre de tu escena) en la carpeta `Assets/Scenes`.
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
