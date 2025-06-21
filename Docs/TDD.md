================================================================================
# TDD — Conquest Tactics 210df9df710280998d1bc7cb57ba0afb
================================================================================

# TDD — Conquest Tactics

### 📐 1. Arquitectura General

- **Arquitectura**: Cliente-Servidor autoritativo
- **Motor**: Unity 3D `2022.3.62f1`
- **Red**: Cliente Predictivo + Servidor Autoritativo (Mirror Networking)
- **Componentes del sistema**:
    - Cliente (render, input, UI, visualización)
    - Servidor (validación, lógica de batalla, sincronización)
    - Backend de matchmaking (matchmaker local)
    - Persistencia en servidor local (SQLite/mock)

---

### ⚔️ 2. Sistemas Críticos (MVP)

### 2.1 Combate y Escuadras

| Sistema | Detalles |
| --- | --- |
| `UnitController` | Control local por unidad, enlace con IA y formación |
| `SquadManager` | Controla spawn, órdenes, disolución y composición de escuadra |
| `CombatController` | Raycast o hitbox, cálculo de daño y aplicación de efectos |
| `SquadCommandSystem` | Sistema de órdenes tácticas: seguir, atacar, mantener |
| `FormationController` | Asigna posición por slot relativo; reorganiza al morir una unidad |

### 2.2 IA de Tropas

- **FSM básica**:
    - `Idle`, `Follow`, `Engage`, `Attack`
- **NavMesh Agent** por unidad + lógica FSM
- **Reorganización** automática en formación

### 2.3 Control del Jugador

- Control directo del héroe en 3ra persona
- Hotkeys para órdenes de escuadra
- Interfaz radial para formaciones (mínimo funcional)

---

### 🧠 3. Sistema de Formaciones

- **Formaciones fijas por tipo de unidad**
- El jugador puede cambiar entre formaciones disponibles en su escuadra
- Las posiciones se reasignan dinámicamente en tiempo real
- No se permite personalización por el jugador

---

### 🌟 4. Talentos / Perks

- Solo **perks pasivos** en MVP
- Se aplican al cargar batalla
- Almacenados por `loadout` del héroe
- No editable en tiempo real (fuera de combate)

---

### 🧭 5. Flujo de Partida y Matchmaking

- `LoginManager` → `CharacterSelectionPanel` → `FeudoScene` → `Matchmaker` → `Preparación` → `Batalla`
- `Matchmaker` local: agrupa jugadores 3v3 y asigna bandos
- `SceneDataCarrier` transfiere el perfil del jugador y selección a la escena de preparación
- `PreparationPanel` permite seleccionar tropas (manual o por loadout) y punto de spawn

---

### 🗺️ 6. Mapa de Batalla (Feudo)

- 3 puntos de spawn por bando (atacante y defensor)
- `SupplyPointController` con interacción contextual:
    - Cambiar escuadra (de las sobrevivientes)
    - Cambiar arma del héroe
    - Curación en área si es aliado
- `CapturePointController`: puntos de bandera con conquista unilateral
- `BattleManager`: lógica de condiciones de victoria
- `BattleTimer`: cuenta regresiva de 10 min

---

### 🎯 7. Condiciones de Victoria (MVP)

- Si el **atacante** captura todas las banderas → victoria atacante
- Si el **tiempo** se agota y hay banderas sin capturar → victoria defensor

---

### 🧾 8. UI y Pantallas Clave

| Pantalla | Sistema asociado |
| --- | --- |
| Login | `LoginManager` |
| Selección de personaje | `CharacterSelectionPanel` |
| Feudo | `SceneLoader`, `Matchmaker` |
| Preparación de batalla | `PreparationPanel`, `LoadoutSystem` |
| HUD combate | `SquadCommandSystem`, `FormationSelectorUI`, `TimerUI` |
| UI de Supply Point | `SupplyPointInteractionUI` |
| Resultados post-batalla | `BattleResultsUI`, `EndBattleHandler` |

---

### 🧪 9. Persistencia (Mock para MVP)

- Perfiles de jugador: username, personajes, unidades desbloqueadas
- Progreso local (nivel, loadouts, perks pasivos)
- Guardado en estructura `PlayerProfileManager` (temporalmente local)

---

### 🛠️ 10. Herramientas internas (mínimas para MVP)

- Editor de formaciones (`FormationData` como ScriptableObject)
- Visualizador 3D de personaje (`HeroViewer3D`)
- Gestor de perfiles y loadouts (`PlayerProfileManager`)

---

### 🔧 11. Consideraciones Técnicas

- Tickrate: 30Hz para tropas, 60Hz para héroes
- Sincronización de estado cada 100ms
- Soporte para testing offline (modo sin servidor dedicado)
- Escalado futuro con backend y servidores dedicados (no incluido en MVP)


# Sistemas

[`HeroPerkSystem` (Perks y Talentos)](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/HeroPerkSystem%20(Perks%20y%20Talentos)%20217df9df710280018cb2c3c7dd14ac87.md)

[Puntos de Captura (Banderas)](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/Puntos%20de%20Captura%20(Banderas)%20217df9df7102804ca63dc8dfbae08289.md)

[`BattleManager`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/BattleManager%20217df9df710280d19354c9f007b8c1ba.md)

[`SupplyPointController`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/SupplyPointController%20217df9df71028002a9e4d5fe56f54cb5.md)

[`EndBattleHandler`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/EndBattleHandler%20217df9df7102803594d4f82abbb33f0f.md)

[ `BattleTimer`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/BattleTimer%20217df9df710280eab445c57c8395547d.md)

[`SquadManager`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/SquadManager%20217df9df710280dea474c6d6160e3e6a.md)

[`FormationController`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/FormationController%20217df9df710280228bc5f4e0c0a652d3.md)

[`CombatController` y Cálculo de Daño](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/CombatController%20y%20Ca%CC%81lculo%20de%20Dan%CC%83o%20217df9df710280aab531dbf6955d4c89.md)

[`PreparationPanel` (UI de Preparación de Batalla)](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/PreparationPanel%20(UI%20de%20Preparacio%CC%81n%20de%20Batalla)%20217df9df710280b1804ce19987300f77.md)

[`SupplyPointInteractionUI`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/SupplyPointInteractionUI%20217df9df710280e49f51d437700823c8.md)

[`BattleResultsUI`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/BattleResultsUI%20217df9df71028056added431b135a0c8.md)

[`UnitAIController` (FSM básica de tropas)](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/UnitAIController%20(FSM%20ba%CC%81sica%20de%20tropas)%20217df9df7102808d9cbccfc24b6440a9.md)

[UnitController](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/UnitController%20217df9df710280cdaebed736f82142e4.md)

[**`SquadCommandSystem`**](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/SquadCommandSystem%20217df9df710280d6b3b3f5b3242f1b62.md)

[`HeroEquipmentManager`](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/HeroEquipmentManager%20217df9df710280638009f6ce3431d9da.md)

[`HeroViewer3D` (Visualizador 3D del Héroe en UI)](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/HeroViewer3D%20(Visualizador%203D%20del%20He%CC%81roe%20en%20UI)%20217df9df710280c492a6e99790824251.md)

[LoginManager](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/LoginManager%20217df9df710280c8b9d9e1212042acc2.md)

[CharacterSelectionPanel](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/CharacterSelectionPanel%20217df9df710280bb8e85f79233217b10.md)

[SceneLoader](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/SceneLoader%20217df9df710280bcb8d4f194b5971705.md)

[Matchmaker](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/Matchmaker%20217df9df710280f3bf0df8f34b6f5ff3.md)

[**`PlayerProfileManager`**](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/PlayerProfileManager%20217df9df71028034bf61ca46d15f268d.md)

[**`SceneDataCarrier`**](TDD%20%E2%80%94%20Conquest%20Tactics%20210df9df710280998d1bc7cb57ba0afb/SceneDataCarrier%20217df9df710280f28baadeb160000018.md)

================================================================================
# BattleManager 217df9df710280d19354c9f007b8c1ba
================================================================================

# BattleManager

### 📌 1. Nombre del Sistema

**Controlador de Batalla (BattleManager)**

---

### 🎯 2. Propósito

Centralizar toda la lógica de estado de partida durante una batalla. Supervisa las condiciones de victoria, el conteo de banderas capturadas, la conexión con el temporizador, y gestiona la finalización de la partida.

---

### 🧩 3. Componentes principales

- `BattleManager.cs` (script global activo durante la batalla)
- Dependencias:
    - `CapturePointController`
    - `BattleTimer`
    - `EndBattleHandler`
- Integración con UI:
    - Temporizador (HUD)
    - Mensajes de victoria/derrota

---

### 🧱 4. Clases y estructuras

### Variables clave:

```csharp
public class BattleManager : MonoBehaviour {
    public int totalFlags = 3;
    public int capturedFlags = 0;

    public float battleDuration = 600f; // 10 minutos
    private bool battleEnded = false;

    public BattleTimer timer;
    public EndBattleHandler endHandler;

    public List<CapturePointController> allFlags;
}
```

### Métodos principales:

```csharp
public void RegisterFlagCaptured(CapturePointController point) {
    capturedFlags++;
    CheckVictoryConditions();
}

public void OnTimerExpired() {
    if (!battleEnded && capturedFlags < totalFlags) {
        TriggerVictoryForDefender();
    }
}

private void CheckVictoryConditions() {
    if (capturedFlags >= totalFlags && !battleEnded) {
        TriggerVictoryForAttacker();
    }
}

private void TriggerVictoryForAttacker() {
    battleEnded = true;
    endHandler.TriggerEndSequence(Team.Attackers);
}

private void TriggerVictoryForDefender() {
    battleEnded = true;
    endHandler.TriggerEndSequence(Team.Defenders);
}
```

---

### 🔄 5. Eventos y flujo de control

- Al iniciar la batalla:
    - `StartBattle()` → arranca el temporizador y escucha banderas.
- Cada vez que una bandera es capturada:
    - `RegisterFlagCaptured()` incrementa el contador y verifica victoria.
- Al llegar el cronómetro a cero:
    - `OnTimerExpired()` es llamado → verifica si el defensor gana.
- Si se alcanza una condición de victoria:
    - `battleEnded = true`, se bloquea todo el input, y se lanza `EndBattleHandler`.

---

### 🔗 6. Dependencias

- `CapturePointController`: envía eventos de captura.
- `BattleTimer`: envía evento al expirar.
- `EndBattleHandler`: gestiona transición visual y de escena.
- UI HUD (cronómetro) – puede consultar `battleDuration`.

---

### ⚙️ 7. Notas de implementación

- Solo puede haber un `BattleManager` activo en escena.
- El sistema es **autoridad final de fin de partida**, no las banderas ni el timer por separado.
- A futuro puede extenderse para modos de juego con múltiples condiciones (control de zonas, puntos, etc.).
- Idealmente debería integrarse con un `MatchSession` si se extiende a red.

================================================================================
# BattleResultsUI 217df9df71028056added431b135a0c8
================================================================================

# BattleResultsUI

### 📌 1. Nombre del Sistema

**Pantalla de Resultados de Batalla (`BattleResultsUI`)**

---

### 🎯 2. Propósito

Mostrar al jugador un resumen detallado de su rendimiento una vez finaliza la batalla. Incluye el resultado (victoria o derrota), unidades utilizadas, estadísticas de combate individuales, experiencia obtenida y un botón para continuar de regreso al mapa de Feudo.

---

### 🧩 3. Componentes principales

- `BattleResultsUI.cs`: script que gestiona el despliegue del panel.
- `UnitResultCard`: componente reutilizable para mostrar datos por escuadra.
- `VictoryBanner`: indica si el jugador ganó o perdió.
- `ContinueButton`: regresa al mapa de Feudo.

---

### 🧱 4. Clases y estructuras

### `BattleResultsUI.cs`

```csharp
public class BattleResultsUI : MonoBehaviour {
    public GameObject resultPanel;
    public Text resultText;
    public Transform unitCardContainer;
    public GameObject unitResultCardPrefab;
    public Button continueButton;

    public void Show(BattleResultData resultData) {
        resultPanel.SetActive(true);
        resultText.text = resultData.victory ? "VICTORIA" : "DERROTA";

        foreach (var unit in resultData.unitsUsed) {
            var card = Instantiate(unitResultCardPrefab, unitCardContainer);
            card.GetComponent<UnitResultCard>().Initialize(unit);
        }

        continueButton.onClick.AddListener(ReturnToFeudo);
    }

    private void ReturnToFeudo() {
        SceneLoader.LoadFeudoScene();
    }
}
```

---

### `BattleResultData`

```csharp
public class BattleResultData {
    public bool victory;
    public List<UnitCombatStats> unitsUsed;
    public int heroExperienceGained;
}
```

### `UnitCombatStats`

```csharp
public class UnitCombatStats {
    public string unitName;
    public int kills;
    public int damageDealt;
    public int remainingTroops;
    public int experienceEarned;
}
```

---

### 🔄 5. Eventos y flujo de control

1. `BattleManager` o `EndBattleHandler` detecta el fin de la batalla.
2. Se genera un objeto `BattleResultData`.
3. Se llama a `BattleResultsUI.Show(data)`.
4. La UI:
    - Indica victoria/derrota.
    - Despliega cards con información de cada unidad.
    - Muestra la experiencia ganada.
5. El jugador presiona “Continuar”.
6. Se carga la escena del mapa de Feudo.

---

### 🔗 6. Dependencias

- `EndBattleHandler`: invoca `Show()` al finalizar el combate.
- `PlayerProfile`: puede actualizar el progreso con lo mostrado.
- `SceneLoader`: para retornar a la ciudad/feudo.

---

### ⚙️ 7. Notas de implementación

- El sistema debe manejar correctamente batallas incompletas (ej: jugador cae antes de terminar).
- Las estadísticas se deben resetear tras mostrar la pantalla.
- El botón de continuar puede tener delay mínimo para evitar skip accidental.
- Compatible con control por teclado o mando.

================================================================================
# BattleTimer 217df9df710280eab445c57c8395547d
================================================================================

# BattleTimer

### 📌 1. Nombre del Sistema

**Temporizador de batalla (`BattleTimer`)**

---

### 🎯 2. Propósito

Llevar el control del tiempo límite durante una batalla. Cuando el contador llega a cero, si el atacante no ha cumplido su condición de victoria, se declara automáticamente la victoria del defensor. También actualiza la interfaz con el tiempo restante.

---

### 🧩 3. Componentes principales

- `BattleTimer.cs`: script que ejecuta la lógica de cuenta regresiva.
- `UIBattleTimer`: componente de UI que muestra el cronómetro al jugador.
- `BattleManager`: recibe evento cuando el tiempo expira.

---

### 🧱 4. Clases y estructuras

### `BattleTimer.cs`

```csharp
public class BattleTimer : MonoBehaviour {
    public float battleDuration = 600f; // 10 minutos
    private float timeRemaining;
    private bool isRunning = false;

    public Action OnTimerExpired;

    void Start() {
        timeRemaining = battleDuration;
    }

    void Update() {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;
        UIBattleTimer.UpdateDisplay(timeRemaining);

        if (timeRemaining <= 0) {
            isRunning = false;
            OnTimerExpired?.Invoke();
        }
    }

    public void StartTimer() => isRunning = true;
}
```

---

### 🔄 5. Eventos y flujo de control

1. Al comenzar la batalla, `BattleManager` llama a `StartTimer()`.
2. El cronómetro comienza a descender desde `battleDuration`.
3. En cada frame:
    - Se reduce `timeRemaining`.
    - Se actualiza la UI con el valor actual.
4. Si el tiempo llega a cero:
    - Se ejecuta `OnTimerExpired()`.
    - `BattleManager` verifica si el defensor ha ganado.

---

### 🔗 6. Dependencias

- `BattleManager`: recibe el evento cuando expira el tiempo.
- `UIBattleTimer`: muestra el cronómetro al jugador.
- (Opcional) sistema de audio o efectos visuales al llegar a 0.

---

### ⚙️ 7. Notas de implementación

- La lógica del timer debe detenerse si `BattleManager.battleEnded == true`.
- El tiempo puede configurarse dinámicamente desde el `BattleManager`.
- La UI debe soportar mostrar el tiempo en `MM:SS` con claridad.
- Puede integrarse en el HUD general de batalla o como componente flotante.

================================================================================
# CharacterSelectionPanel 217df9df710280bb8e85f79233217b10
================================================================================

# CharacterSelectionPanel

### 📌 1. Nombre del Sistema

**Selección y Creación de Personaje (`CharacterSelectionPanel`)**

---

### 🎯 2. Propósito

Permitir al jugador ver los personajes que ha creado, seleccionar uno para ingresar al mundo del juego (Feudo), o crear un nuevo personaje si tiene espacios disponibles. Este sistema centraliza la lógica de selección activa, preview visual y persistencia.

---

### 🧩 3. Componentes principales

- `CharacterSelectionPanel.cs`: script controlador de la UI y lógica.
- `CharacterCardUI`: elemento que representa un personaje jugable.
- `CreateCharacterUI`: subinterfaz para definir nuevo personaje (nombre, apariencia).
- `HeroViewer3D`: visualiza al personaje seleccionado en 3D con su equipo.
- `PlayerProfile`: mantiene los personajes del usuario.
- `SceneLoader`: transición a Feudo tras la selección.

---

### 🧱 4. Clases y estructuras

### `CharacterSelectionPanel.cs`

```csharp
public class CharacterSelectionPanel : MonoBehaviour {
    public Transform characterCardContainer;
    public GameObject characterCardPrefab;
    public HeroViewer3D viewer;
    public Button enterButton;
    private CharacterData selectedCharacter;

    void Start() {
        LoadCharacters();
        enterButton.interactable = false;
        enterButton.onClick.AddListener(EnterWorld);
    }

    void LoadCharacters() {
        foreach (var character in PlayerProfile.Characters) {
            var card = Instantiate(characterCardPrefab, characterCardContainer);
            card.GetComponent<CharacterCardUI>().Initialize(character, OnCharacterSelected);
        }
    }

    void OnCharacterSelected(CharacterData data) {
        selectedCharacter = data;
        viewer.LoadHeroModel(data);
        enterButton.interactable = true;
    }

    void EnterWorld() {
        PlayerProfile.SetActiveCharacter(selectedCharacter);
        SceneLoader.LoadFeudoScene();
    }
}
```

---

### 🔄 Flujo de control

1. **Se carga la escena de selección** tras login.
2. El sistema genera una lista de `CharacterCardUI`, uno por personaje.
3. Al seleccionar uno:
    - Se actualiza el modelo 3D (`HeroViewer3D`) con su equipamiento y apariencia.
    - Se habilita el botón "Entrar".
4. Al presionar “Entrar”:
    - Se guarda el personaje activo en el perfil.
    - Se carga la escena del mapa de Feudo.

---

### 🔗 Dependencias

- `PlayerProfile`: contiene todos los personajes del usuario.
- `HeroViewer3D`: muestra el modelo con su equipo actual.
- `SceneLoader`: para transición a la ciudad del MVP.
- `CreateCharacterUI`: puede abrirse para crear uno nuevo.

---

### ⚙️ Notas de implementación

- Si no hay personajes creados, se debe mostrar directamente la creación.
- Puede limitarse a 3 personajes por usuario en el MVP.
- Cada `CharacterData` puede incluir:
    - Nombre
    - Nivel
    - Equipamiento actual
    - Clase (opcional)
- Al crear uno nuevo, se instancia `CharacterData` con valores base y se persiste.

================================================================================
# CombatController y Cálculo de Daño 217df9df710280aab531dbf6955d4c89
================================================================================

# CombatController y Cálculo de Daño

### 📌 1. Nombre del Sistema

**Sistema de Combate – Impacto y Resolución de Daño**

---

### 🎯 2. Propósito

Gestionar la detección de ataques físicos (cuerpo a cuerpo o a distancia), verificar colisión contra entidades vulnerables, y calcular el daño basado en atributos ofensivos y defensivos, tipos de daño, penetraciones y bonificaciones situacionales. Permite modularidad entre unidades, héroes y tipos de ataques.

---

### 🧩 3. Componentes principales

- `CombatController.cs`: controla ataques, cálculos y eventos de daño.
- `HitboxComponent` / `RaycastDetector`: define zonas de colisión.
- `DamageCalculator.cs`: módulo estático que realiza el cálculo matemático.
- `HealthComponent.cs`: recibe y aplica el daño final.
- `PhysicalDamageType`, `ArmorType`, `PenetrationStats`: definiciones y factores.

---

### 🧱 4. Clases y estructuras

### `PhysicalDamageType` (enum)

```csharp
public enum PhysicalDamageType {
    Slashing,
    Piercing,
    Blunt
}

```

### `CombatStats`

```csharp
csharp
CopiarEditar
public class CombatStats {
    public float baseDamage;
    public PhysicalDamageType damageType;
    public float armorPenetration; // porcentaje
}

```

### `DefenseStats`

```csharp
public class DefenseStats {
    public float armorSlashing;
    public float armorPiercing;
    public float armorBlunt;
}
```

### `DamageCalculator.cs`

```csharp
public static class DamageCalculator {
    public static int Calculate(CombatStats attacker, DefenseStats defender) {
        float armor = GetRelevantArmor(defender, attacker.damageType);
        float reducedArmor = armor * (1f - attacker.armorPenetration);
        float finalDamage = attacker.baseDamage - reducedArmor;
        return Mathf.Max(1, Mathf.RoundToInt(finalDamage)); // Nunca 0
    }

    private static float GetRelevantArmor(DefenseStats def, PhysicalDamageType type) {
        return type switch {
            PhysicalDamageType.Slashing => def.armorSlashing,
            PhysicalDamageType.Piercing => def.armorPiercing,
            PhysicalDamageType.Blunt => def.armorBlunt,
            _ => 0f
        };
    }
}
```

---

### 🔄 5. Eventos y flujo de control

1. **El jugador o unidad lanza un ataque.**
    - El `CombatController` emite un `raycast` o activa un `hitbox` según animación.
2. **Si el objetivo es impactado:**
    - Se accede a su `DefenseStats`.
    - Se aplica la lógica de `DamageCalculator`.
    - Se llama a `HealthComponent.ApplyDamage(finalDamage)`.
3. **Se muestran efectos secundarios:**
    - Animaciones de impacto
    - VFX o sonido
    - Daño flotante (opcional)

---

### 🔗 6. Dependencias

- `UnitController` / `HeroController`: invocan ataques.
- `AnimationEventBridge`: dispara hitbox en momento correcto.
- `HealthComponent`: recibe daño y verifica muerte.
- `EffectManager`: para feedback visual del golpe.

---

### ⚙️ 7. Notas de implementación

- El sistema admite tipos de daño y defensas diferenciadas por unidad.
- La penetración se expresa como **reducción del valor defensivo**.
- Todo cálculo final se clampa a 1 mínimo para garantizar retroalimentación.
- Puede extenderse para aplicar:
    - Efectos de estado
    - Críticos
    - Daño en área
- La detección física puede hacerse por:
    - `Raycast` (preciso, ideal para melee)
    - `OverlapBox` o `Hitbox` con trigger

================================================================================
# EndBattleHandler 217df9df7102803594d4f82abbb33f0f
================================================================================

# EndBattleHandler

### 📌 1. Nombre del Sistema

**Finalización de la batalla y transición a resultados (`EndBattleHandler`)**

---

### 🎯 2. Propósito

Gestionar de forma segura y controlada el fin de una batalla. Se encarga de congelar el estado de juego, bloquear el input, detener sistemas activos (IA, HUD, cronómetro) y cargar la interfaz de resumen de resultados con los datos del combate.

---

### 🧩 3. Componentes principales

- `EndBattleHandler.cs`: controlador central del cierre de partida.
- `BattleResultsUI`: interfaz de resultados con estadísticas del jugador y botón de continuar.
- `BattleManager.cs`: sistema que llama a este componente al detectar una condición de victoria.
- `MatchSession` o `PlayerProfile`: persistencia temporal del resultado.

---

### 🧱 4. Clases y estructuras

### `EndBattleHandler.cs`

```csharp
public class EndBattleHandler : MonoBehaviour {
    public BattleResultsUI resultsUI;

    public void TriggerEndSequence(Team winner) {
        FreezeGameState();
        ShowResults(winner);
    }

    private void FreezeGameState() {
        Time.timeScale = 0;
        DisablePlayerInput();
        DisableAI();
        HideHUD();
    }

    private void ShowResults(Team winner) {
        var data = CollectBattleData(winner);
        resultsUI.Show(data);
    }
}
```

---

### 🔄 5. Eventos y flujo de control

1. `BattleManager` detecta que se cumple una condición de victoria.
2. Llama a `EndBattleHandler.TriggerEndSequence(Team winner)`.
3. Se ejecuta:
    - Bloqueo de todos los controles (jugador + IA).
    - Detención de cronómetro, HUD, órdenes.
    - Recolección de datos de combate.
    - Activación del `BattleResultsUI` con los datos procesados.
4. Jugador ve la pantalla de resultados y puede continuar.

---

### 🔗 6. Dependencias

- `BattleManager`: única clase que debe invocar este handler.
- `UIController`: para ocultar elementos del HUD.
- `SquadManager`, `InputManager`, `AIController`: desactivados al finalizar.
- `BattleResultsUI`: componente que muestra el resumen.

---

### ⚙️ 7. Notas de implementación

- El `FreezeGameState()` debe garantizar que **todo input local y remoto esté bloqueado**.
- Las IA de tropas deben dejar de responder (congelar FSM).
- Se recomienda incluir un sistema de transición visual (`FadeIn` o corte).
- El sistema debe evitar llamadas duplicadas si se cumplen condiciones múltiples a la vez.
- Datos recolectados incluyen:
    - Unidades usadas y su desempeño (kills, daño).
    - Exp ganada por héroe y cada escuadra.
    - Resultado (victoria o derrota).

================================================================================
# FormationController 217df9df710280228bc5f4e0c0a652d3
================================================================================

# FormationController

### 📌 1. Nombre del Sistema

**Sistema de Formaciones (`FormationController`)**

---

### 🎯 2. Propósito

Controlar la disposición táctica de las unidades dentro de una escuadra, basándose en una formación predefinida por tipo de unidad. Asegura que las posiciones sean fijas, ordenadas y adaptables ante pérdidas de miembros para mantener integridad visual y funcional. Permite el cambio de formación en tiempo real si la unidad lo permite.

---

### 🧩 3. Componentes principales

- `FormationController.cs`: gestiona las posiciones relativas y actualizaciones dinámicas.
- `FormationData (ScriptableObject)`: estructura de datos que define la geometría de una formación.
- `UnitController`: cada miembro consulta su slot asignado.
- `SquadManager`: comunica cambios o inicializa formaciones desde `SquadLoadout`.

---

### 🧱 4. Clases y estructuras

### `FormationData` (ScriptableObject)

```csharp
[CreateAssetMenu(fileName = "NewFormation", menuName = "Formations/FormationData")]
public class FormationData : ScriptableObject {
    public string formationName;
    public List<Vector3> relativePositions; // Slot por índice
}
```

### `FormationController.cs`

```csharp
public class FormationController : MonoBehaviour {
    public FormationData currentFormation;
    public Transform leaderTransform;
    private List<UnitController> units;

    public void ApplyFormation(FormationData newFormation) {
        currentFormation = newFormation;
        ReassignPositions();
    }

    public void ReassignPositions() {
        for (int i = 0; i < units.Count; i++) {
            if (i >= currentFormation.relativePositions.Count) continue;

            Vector3 offset = currentFormation.relativePositions[i];
            Vector3 worldTarget = leaderTransform.position + leaderTransform.rotation * offset;

            units[i].assignedFormationPosition = worldTarget;
            units[i].SetFormationMode(true); // Cambia a estado de movimiento en formación
        }
    }

    public void OnUnitDeath(UnitController unit) {
        units.Remove(unit);
        ReassignPositions(); // Reajusta slots
    }
}
```

---

### 🔄 5. Eventos y flujo de control

- **Al spawnear una escuadra**:
    - Se asigna la `FormationData` correspondiente según tipo de unidad.
    - Cada unidad es movida a su slot en el mundo.
- **Al cambiar formación (por UI o hotkey)**:
    - `ApplyFormation()` es llamada y redistribuye posiciones.
- **Al morir una unidad**:
    - Se actualiza la lista interna.
    - Las demás se reorganizan para mantener simetría.

---

### 🔗 6. Dependencias

- `UnitController`: cada unidad recibe su posición destino desde aquí.
- `SquadManager`: comunica cambios solicitados por jugador o sistema.
- `PlayerInput` / `FormacionSelectorUI`: interfaz para cambiar formación.
- `leaderTransform`: se pasa explícitamente desde el `SquadManager` (es el héroe del jugador).

---

### ⚙️ 7. Notas de implementación

- **Las formaciones no son personalizables por el jugador**.
    - Son definidas por el tipo de unidad (en data).
- Las posiciones son **fijas** y **reordenadas** si alguien muere.
- Los cambios de formación deben ser instantáneos o con breve animación (dependiendo del nivel de polish).
- Idealmente, usar `NavMeshAgent.SetDestination()` o `Warp` si ya están alineadas.

================================================================================
# HeroEquipmentManager 217df9df710280638009f6ce3431d9da
================================================================================

# HeroEquipmentManager

### 

### 📌 1. Nombre del Sistema

**Gestión de Equipamiento del Héroe (`HeroEquipmentManager`) – Versión con Slots Detallados**

---

### 🎯 2. Propósito

Permitir al jugador ver y modificar el equipamiento de su héroe en cuatro piezas de armadura distintas, además del arma. Cada pieza aporta efectos visuales únicos y bonificaciones estadísticas específicas. El sistema asegura la correcta aplicación de cada pieza tanto visual como funcionalmente.

---

### 🧩 3. Componentes principales

- `HeroEquipmentManager.cs`: controlador general del sistema.
- `EquipmentSlot` (enum): define 5 tipos (arma + 4 piezas de armadura).
- `EquipmentData` (ScriptableObject): contiene el ítem y sus efectos.
- `HeroVisualUpdater`: actualiza el modelo 3D del héroe.
- `HeroStats`: aplica las bonificaciones del equipo.
- `EquipmentSelectorUI`: interfaz para cambiar piezas.

---

### 🧱 4. Clases y estructuras (actualizadas)

### `enum EquipmentSlot`

```csharp
public enum EquipmentSlot {
    Weapon,
    Helm,
    Chest,
    Gloves,
    Boots
}
```

### `EquipmentData` (ScriptableObject)

```csharp
[CreateAssetMenu(fileName = "NewEquipment", menuName = "Equipment/Item")]
public class EquipmentData : ScriptableObject {
    public string itemName;
    public EquipmentSlot slot;
    public GameObject meshPrefab;

    // Bonificaciones aplicables
    public float bonusDamage;
    public float bonusArmor;
    public float bonusHealth;
    public float bonusMobility;
}
```

### `HeroEquipmentManager.cs` (actualizado)

```csharp
public class HeroEquipmentManager : MonoBehaviour {
    private Dictionary<EquipmentSlot, EquipmentData> equippedItems = new();

    public HeroStats stats;
    public HeroVisualUpdater visual;

    public void EquipItem(EquipmentData item) {
        equippedItems[item.slot] = item;
        ApplyStats();
        visual.UpdateMesh(item.slot, item.meshPrefab);
    }

    private void ApplyStats() {
        stats.ResetToBase();

        foreach (var item in equippedItems.Values) {
            stats.baseDamage     += item.bonusDamage;
            stats.baseArmor      += item.bonusArmor;
            stats.baseHealth     += item.bonusHealth;
            stats.mobilityFactor += item.bonusMobility;
        }
    }

    public EquipmentData GetEquippedItem(EquipmentSlot slot) {
        return equippedItems.ContainsKey(slot) ? equippedItems[slot] : null;
    }
}
```

---

### 🔄 Flujo de control

1. **En la interfaz de estadísticas o preparación**:
    - El jugador selecciona una pieza de equipo específica (Helm, Chest, etc.).
2. **Al equiparla**:
    - `EquipItem()` actualiza el diccionario de slots.
    - Se recalculan los atributos del héroe (`HeroStats`).
    - El modelo visual es actualizado (`HeroVisualUpdater`).
3. **Visualización en tiempo real**:
    - Cada pieza tiene su propio `meshPrefab` y se actualiza por separado.

---

### 🔗 Dependencias

- `HeroVisualUpdater`: renderiza cada pieza visualmente en el modelo del héroe.
- `HeroStats`: contiene los valores base y los modificadores.
- `PlayerProfile`: conoce los ítems desbloqueados y el loadout actual.
- `EquipmentSelectorUI`: permite al jugador navegar los ítems por slot.

---

### ⚙️ Notas de implementación

- Cada slot tiene **una sola pieza válida** equipada al mismo tiempo.
- `HeroStats` debe estar preparado para tener bonificaciones **acumulativas**.
- En la visualización:
    - El casco puede ocultar el cabello si corresponde.
    - Las botas y guantes deben respetar proporciones del modelo base.
- Se puede validar que ciertas combinaciones estén restringidas por clase o rareza.

================================================================================
# HeroPerkSystem (Perks y Talentos) 217df9df710280018cb2c3c7dd14ac87
================================================================================

# HeroPerkSystem (Perks y Talentos)

### 📌 1. Nombre del Sistema

**Sistema de Perks y Talentos del Héroe (`HeroPerkSystem`)**

---

### 🎯 2. Propósito

Gestionar las habilidades pasivas (perks) y talentos activos del héroe. Este sistema permite modificar atributos base, activar efectos contextuales, y adaptarse al estilo de juego del usuario. En el MVP, se aplican exclusivamente **perks pasivos** que alteran valores de combate, liderazgo u otras variables numéricas.

---

### 🧩 3. Componentes principales

- `HeroPerkSystem.cs`: gestiona perks aplicados, lectura de data y aplicación en tiempo real.
- `PerkData` (ScriptableObject): define efectos, condiciones y valores.
- `HeroStats`: sistema que recibe las modificaciones numéricas.
- `PerkSelectorUI` (fuera del MVP): UI para seleccionar perks en el futuro.

---

### 🧱 4. Clases y estructuras

### `PerkData.cs` (ScriptableObject)

```csharp
[CreateAssetMenu(fileName = "NewPerk", menuName = "Perks/PerkData")]
public class PerkData : ScriptableObject {
    public string perkName;
    public string description;
    public PerkEffect effectType;
    public float effectValue;
}
```

### `enum PerkEffect`

```csharp
public enum PerkEffect {
    BonusLeadership,
    BonusHealth,
    BonusArmorPiercing,
    BonusSquadDamage
}
```

### `HeroPerkSystem.cs`

```csharp
public class HeroPerkSystem : MonoBehaviour {
    public List<PerkData> equippedPerks;

    public void ApplyPerks(HeroStats stats) {
        foreach (var perk in equippedPerks) {
            switch (perk.effectType) {
                case PerkEffect.BonusLeadership:
                    stats.leadership += perk.effectValue;
                    break;
                case PerkEffect.BonusHealth:
                    stats.baseHealth += perk.effectValue;
                    break;
                case PerkEffect.BonusArmorPiercing:
                    stats.armorPenetration += perk.effectValue;
                    break;
                case PerkEffect.BonusSquadDamage:
                    stats.squadDamageBonus += perk.effectValue;
                    break;
            }
        }
    }
}
```

---

### 🔄 5. Eventos y flujo de control

1. **Al iniciar batalla:**
    - Se aplica `ApplyPerks()` al cargar los stats del héroe.
2. **Durante el combate:**
    - No hay interacción directa (pasivos).
3. **Fin de batalla:**
    - Los perks siguen activos para efectos de estadísticas y experiencia.

---

### 🔗 6. Dependencias

- `HeroStats`: clase que contiene los valores numéricos que pueden ser modificados.
- `PlayerProfile`: define qué perks están desbloqueados y cuáles están equipados.
- `BattleSetupManager`: puede aplicar los efectos antes del spawn.

---

### ⚙️ 7. Notas de implementación

- En el MVP solo se incluyen perks **pasivos** y aplicados automáticamente.
- Cada perk puede afectar directamente al héroe o su escuadra.
- El sistema es extensible para talentos activos en versiones posteriores.
- Los perks deben mostrarse en la **UI de stats del héroe** si se desea visualizarlos.

================================================================================
# HeroViewer3D (Visualizador 3D del Héroe en UI) 217df9df710280c492a6e99790824251
================================================================================

# HeroViewer3D (Visualizador 3D del Héroe en UI)

### 📌 1. Nombre del Sistema

**Visualizador del Héroe en UI (`HeroViewer3D`)**

---

### 🎯 2. Propósito

Mostrar una representación 3D en tiempo real del héroe con su equipamiento actual aplicado. Este sistema permite al jugador **ver su personaje rotar, cambiar de equipo y observar visualmente cada cambio** desde interfaces como la pantalla de stats, selección de personaje o preparación de batalla.

---

### 🧩 3. Componentes principales

- `HeroViewer3D.cs`: controlador principal del visualizador.
- `CameraRenderToTexture`: cámara dedicada a capturar el modelo.
- `HeroDummyModel`: instancia del héroe sin lógica jugable, usada solo para renderizar.
- `RenderTexture`: textura que se muestra en un `RawImage` de la UI.
- `HeroEquipmentManager` + `HeroVisualUpdater`: se usan para aplicar visualmente los ítems.
- `RotationHandler`: permite al jugador rotar el modelo manualmente con el mouse o stick.

---

### 🧱 4. Clases y estructura

### `HeroViewer3D.cs`

```csharp
public class HeroViewer3D : MonoBehaviour {
    public GameObject heroPrefab;
    public Transform viewerSpawnPoint;
    public Camera viewerCamera;
    public RenderTexture outputTexture;
    public HeroEquipmentManager equipmentManager;

    private GameObject currentInstance;

    public void LoadHeroModel(PlayerProfile profile) {
        if (currentInstance != null)
            Destroy(currentInstance);

        currentInstance = Instantiate(heroPrefab, viewerSpawnPoint.position, Quaternion.identity, viewerSpawnPoint);
        equipmentManager = currentInstance.GetComponent<HeroEquipmentManager>();

        foreach (var slot in profile.GetEquippedSlots()) {
            var item = profile.GetEquippedItem(slot);
            equipmentManager.EquipItem(item);
        }
    }
}

```

---

### 🔄 Flujo de control

1. **Entra a una UI con modelo del héroe**:
    - `HeroViewer3D` instancia el prefab visual del héroe.
    - Se posiciona sobre un punto invisible (`viewerSpawnPoint`) con rotación fija.
2. **Se aplican los ítems equipados**:
    - `HeroEquipmentManager` + `HeroVisualUpdater` instancian los meshes.
3. **La cámara (`viewerCamera`)**:
    - Renderiza el modelo a una `RenderTexture`.
    - Esta textura se muestra en un `RawImage` dentro de la interfaz.
4. **El jugador puede rotar el modelo** (opcional):
    - Arrastrando con el mouse.
    - Con stick derecho si usa control.

---

### 🔗 Dependencias

- `HeroEquipmentManager` y `HeroVisualUpdater`: aplican equipamiento.
- `PlayerProfile`: para obtener los ítems activos.
- `UIController` o `StatsPanel`: que contiene el `RawImage` donde se muestra.

---

### ⚙️ Notas de implementación

- El modelo 3D del héroe debe ser una versión simplificada (sin lógica de juego).
- Las luces, cámara y fondo deben ser personalizados para la presentación (idealmente neutral).
- Se debe evitar ejecutar animaciones de combate o IA.
- Puede integrar una animación idle, o ciclo de presentación para más polish.
- Se recomienda permitir zoom o rotación con límites suaves.

================================================================================
# LoginManager 217df9df710280c8b9d9e1212042acc2
================================================================================

# LoginManager

### 📌 1. Nombre del Sistema

**Gestión de Autenticación de Usuario (`LoginManager`)**

---

### 🎯 2. Propósito

Gestionar el proceso de ingreso al juego mediante nombre de usuario y contraseña. Este sistema valida credenciales, conecta con el backend (si aplica) y permite al jugador acceder a su perfil, personajes creados y progreso. Es el **punto de entrada inicial** al ecosistema del juego.

---

### 🧩 3. Componentes principales

- `LoginManager.cs`: controlador principal del flujo de autenticación.
- `LoginUI`: interfaz con campos para usuario y contraseña.
- `BackendService` (mock o real): verifica las credenciales.
- `PlayerProfileManager`: instancia el perfil local tras validación.

---

### 🧱 4. Clases y estructuras

### `LoginManager.cs`

```csharp
public class LoginManager : MonoBehaviour {
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Text errorMessage;

    void Start() {
        loginButton.onClick.AddListener(AttemptLogin);
    }

    void AttemptLogin() {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
            errorMessage.text = "Campos incompletos.";
            return;
        }

        StartCoroutine(ValidateCredentials(username, password));
    }

    IEnumerator ValidateCredentials(string user, string pass) {
        yield return BackendService.Authenticate(user, pass, OnLoginSuccess, OnLoginFail);
    }

    void OnLoginSuccess(PlayerData data) {
        PlayerProfileManager.Initialize(data);
        SceneLoader.LoadCharacterSelection();
    }

    void OnLoginFail(string reason) {
        errorMessage.text = $"Error de login: {reason}";
    }
}

```

---

### 🔄 Flujo de control

1. **El jugador abre el juego.**
2. Se muestra `LoginUI` con campos de entrada.
3. El jugador introduce usuario y contraseña.
4. Al presionar “Iniciar sesión”:
    - Se validan los campos.
    - Se hace la llamada al backend o al sistema simulado.
5. Si la validación es correcta:
    - Se crea un `PlayerProfile` local.
    - Se carga la escena de selección de personaje.
6. Si falla:
    - Se muestra mensaje de error.

---

### 🔗 Dependencias

- `BackendService`: real o local (mock) para validación de usuarios.
- `PlayerProfileManager`: instancia y gestiona el perfil del jugador.
- `SceneLoader`: transición a `CharacterSelectionScene`.

---

### ⚙️ Notas de implementación

- En el MVP, puede usarse un backend simulado con datos en local.
- Se puede implementar un botón “Entrar como Invitado”.
- Las contraseñas deben estar ocultas por defecto.
- Debe manejar conexión fallida, errores de red o formatos inválidos.

================================================================================
# Matchmaker 217df9df710280f3bf0df8f34b6f5ff3
================================================================================

# Matchmaker

### 📌 1. Nombre del Sistema

**Emparejamiento y Formación de Lobbies (`Matchmaker`)**

---

### 🎯 2. Propósito

Recoger solicitudes de jugadores que desean entrar en batalla, agruparlos en lobbies automáticos según la configuración del modo (3v3, 5v5, etc.), asignarlos a bandos (atacante o defensor), y cargar la escena de preparación de batalla correspondiente. Es el núcleo del flujo multijugador competitivo dentro del MVP.

---

### 🧩 3. Componentes principales

- `Matchmaker.cs`: controlador principal del sistema de emparejamiento.
- `MatchQueue`: cola donde se almacenan los jugadores en espera.
- `LobbyData`: estructura temporal con los jugadores agrupados.
- `BattlePreparationData`: datos que se enviarán a la escena siguiente (equipo, loadout, etc.).
- `SceneLoader`: llamado una vez se completa un lobby.

---

### 🧱 4. Clases y estructuras

### `Matchmaker.cs`

```csharp
public class Matchmaker : MonoBehaviour {
    public int playersPerTeam = 3;
    private List<PlayerProfile> queue = new();

    public void EnqueuePlayer(PlayerProfile player) {
        queue.Add(player);
        TryCreateLobby();
    }

    void TryCreateLobby() {
        int totalPlayers = playersPerTeam * 2;

        if (queue.Count >= totalPlayers) {
            var selectedPlayers = queue.Take(totalPlayers).ToList();
            queue.RemoveRange(0, totalPlayers);

            var lobby = new LobbyData(selectedPlayers);
            StartBattle(lobby);
        }
    }

    void StartBattle(LobbyData lobby) {
        SceneDataCarrier.CurrentLobby = lobby;
        SceneLoader.LoadBattleScene("BattleMap_Feudo");
    }
}

```

### `LobbyData.cs`

```csharp
public class LobbyData {
    public List<PlayerProfile> attackers;
    public List<PlayerProfile> defenders;

    public LobbyData(List<PlayerProfile> players) {
        players = players.OrderBy(p => UnityEngine.Random.value).ToList();
        attackers = players.Take(players.Count / 2).ToList();
        defenders = players.Skip(players.Count / 2).ToList();
    }
}

```

---

### 🔄 Flujo de control

1. El jugador presiona el botón “Entrar en batalla” desde el Feudo.
2. Se invoca `Matchmaker.EnqueuePlayer(profile)`.
3. Cuando hay suficientes jugadores:
    - Se crea un nuevo `LobbyData`.
    - Se divide aleatoriamente en atacante vs defensor.
4. Se llama a `SceneLoader.LoadBattleScene("BattleMap_Feudo")`.
5. Cada jugador entra en la escena de preparación con su rol asignado.

---

### 🔗 Dependencias

- `PlayerProfile`: para extraer las unidades y el loadout del jugador.
- `SceneDataCarrier`: transfiere datos del lobby entre escenas.
- `SceneLoader`: inicia la carga del mapa de batalla.

---

### ⚙️ Notas de implementación

- En el MVP se puede usar un simulador local o modo LAN, sin backend real.
- En futuras versiones, esto se integrará con un sistema de red (`Mirror`, `Netcode`, etc.).
- Puede expandirse para soportar matchmaking por nivel, región o preferencias.

================================================================================
# PlayerProfileManager 217df9df71028034bf61ca46d15f268d
================================================================================

# PlayerProfileManager

### 📌 1. Nombre del Sistema

**Gestor del Perfil del Jugador (`PlayerProfileManager`)**

---

### 🎯 2. Propósito

Administrar el perfil activo del jugador dentro de una sesión de juego. Este sistema es responsable de **cargar, almacenar y exponer los datos persistentes** de usuario: personajes creados, perks desbloqueados, escuadras disponibles, loadouts, etc. Sirve como capa de acceso entre el backend/localstorage y los sistemas en tiempo real.

---

### 🧩 3. Componentes principales

- `PlayerProfileManager.cs`: clase singleton que gestiona el perfil actual.
- `PlayerData`: clase contenedora con la información del jugador.
- `CharacterData`: datos de cada personaje creado.
- `SaveSystem` o `BackendService`: fuente de persistencia (según el entorno).

---

### 🧱 4. Clases y estructuras

### `PlayerProfileManager.cs`

```csharp
public static class PlayerProfileManager {
    public static PlayerData CurrentProfile { get; private set; }

    public static void Initialize(PlayerData data) {
        CurrentProfile = data;
    }

    public static CharacterData GetActiveCharacter() => CurrentProfile.activeCharacter;

    public static void SetActiveCharacter(CharacterData character) {
        CurrentProfile.activeCharacter = character;
    }

    public static List<TroopData> GetAvailableSquads() => CurrentProfile.selectedLoadout;
}
```

### `PlayerData.cs`

```csharp
public class PlayerData {
    public string username;
    public List<CharacterData> characters;
    public CharacterData activeCharacter;
    public List<TroopData> unlockedTroops;
    public List<TroopData> selectedLoadout;
}
```

---

### 🔄 Flujo de control

- Al iniciar sesión (`LoginManager`), se recibe un `PlayerData`.
- `Initialize()` carga ese perfil como activo.
- Otros sistemas (como el visor 3D, preparación de batalla, escuadras, etc.) acceden a los datos mediante getters.

---

### 🔗 Dependencias

- `LoginManager`: inicializa el perfil tras autenticación.
- `CharacterSelectionPanel`: cambia el personaje activo.
- `PreparationPanel`, `HeroEquipmentManager`, `PerkSystem`, etc.: leen datos desde aquí.

---

### ⚙️ Notas

- No contiene lógica de persistencia en sí (delegada a `SaveSystem` o `BackendService`).
- Se asume que los datos son cargados y seguros al momento de uso.
- Debe vaciarse al cerrar sesión o salir del juego.

================================================================================
# PreparationPanel (UI de Preparación de Batalla) 217df9df710280b1804ce19987300f77
================================================================================

# PreparationPanel (UI de Preparación de Batalla)

### 📌 1. Nombre del Sistema

**Interfaz de Preparación de Batalla (`PreparationPanel`)**

---

### 🎯 2. Propósito

Permitir al jugador configurar sus tropas, punto de aparición y equipamiento antes del inicio de una batalla. Esta interfaz se muestra durante la fase de preparación (previa al combate), y representa un punto crítico para validar liderazgo, aplicar un loadout, y establecer el contexto inicial del combate.

---

### 🧩 3. Componentes principales

- `PreparationPanel.cs`: controlador general del panel de UI.
- `SquadSelectorUI`: muestra y valida las escuadras disponibles del jugador.
- `LoadoutButtonPanel`: permite seleccionar un loadout predefinido.
- `SpawnPointSelector`: muestra un minimapa interactivo para elegir punto de despliegue.
- `WeaponSelector`: muestra el arma actual del héroe y permite cambiarla.
- `ReadyButton`: envía confirmación y bloquea cambios.

---

### 🧱 4. Clases y estructuras

### `PreparationPanel.cs`

```csharp
public class PreparationPanel : MonoBehaviour {
    public SquadSelectorUI squadSelector;
    public LoadoutButtonPanel loadoutPanel;
    public WeaponSelector weaponSelector;
    public SpawnPointSelector spawnSelector;
    public Button readyButton;

    private bool confirmed = false;

    void Start() {
        LoadPlayerOptions();
        readyButton.onClick.AddListener(ConfirmLoadout);
    }

    void ConfirmLoadout() {
        if (!confirmed && squadSelector.IsValidSelection()) {
            confirmed = true;
            LockSelections();
            PreparationManager.MarkPlayerReady();
        }
    }

    void LockSelections() {
        squadSelector.SetInteractable(false);
        weaponSelector.SetLocked(true);
        spawnSelector.DisableInput();
    }
}
```

---

### 🔄 5. Eventos y flujo de control

1. **El jugador entra en la fase de preparación.**
    - El `PreparationPanel` se activa automáticamente.
2. **Flujos simultáneos:**
    - Elige escuadras disponibles (o usa un loadout).
    - Elige arma equipada.
    - Elige punto de spawn en el minimapa (solo los de su bando).
3. **Presiona “Listo” (Ready):**
    - Se valida el liderazgo total.
    - Se bloquean las selecciones.
    - El sistema marca al jugador como listo.
    - Si todos los jugadores están listos o el tiempo expira → se inicia la partida.

---

### 🔗 6. Dependencias

- `PlayerProfile`: para acceder a escuadras desbloqueadas, liderazgo, armas disponibles.
- `BattleSetupManager`: recibe la selección y la transfiere a la escena de combate.
- `MatchLobby`: lleva el conteo de jugadores listos.

---

### ⚙️ 7. Notas de implementación

- El panel debe manejar feedback visual en tiempo real:
    - Liderazgo restante.
    - Escuadras no válidas (grises o con íconos de advertencia).
    - Puntos de spawn bloqueados.
- Si el jugador no confirma a tiempo, el sistema debe aplicar la selección parcial automáticamente.
- Este panel también se reutiliza (parcialmente) desde los `SupplyPoints`, pero con restricciones.

================================================================================
# Puntos de Captura (Banderas) 217df9df7102804ca63dc8dfbae08289
================================================================================

# Puntos de Captura (Banderas)

### 📌 1. Nombre del Sistema

---

**Sistema de Puntos de Captura – Banderas de Feudo**

---

### 🎯 2. Propósito

Controlar la lógica de captura de objetivos estáticos en el mapa, utilizados exclusivamente en el modo “Batalla de Feudo”. Determinan el progreso del equipo atacante hacia la victoria.

---

### 🧩 3. Componentes principales

- **CapturePoint_Bandera (Prefab)**: Objeto físico colocado en el mapa.
- **CapturePointController.cs**: Script que gestiona lógica de detección y captura.
- **BattleManager.cs**: Sistema central que recibe eventos de captura y verifica condiciones de victoria.

---

### 🧱 4. Clases y estructuras

### `enum CaptureState`

```csharp
public enum CaptureState {
    Defended,
    InProgress,
    Captured
}
```

### `CapturePointController.cs`

```csharp
public class CapturePointController : MonoBehaviour {
    public Team currentOwner;
    public CaptureState state;
    public float captureTimeRequired = 5f;
    private float currentCaptureProgress = 0f;

    private List<Player> attackersInside = new List<Player>();
    private bool canBeRecaptured = false; // Siempre false en banderas
}
```

---

### 🔄 5. Eventos y flujo de control

- `OnTriggerEnter(Collider other)`
    - Si es un **héroe atacante** y `state == Defended` → comienza captura.
- `UpdateCaptureProgress()`
    - Incrementa `currentCaptureProgress`.
    - Al completarse: cambia `state` a `Captured`, actualiza visual, desactiva triggers.
- Llama a:
    
    ```csharp
    BattleManager.RegisterFlagCaptured(this);
    ```
    

---

### 🔗 6. Dependencias

- `Team` (definido en sistema de jugador).
- `BattleManager.cs`
- `UI_CaptureBar.cs` (opcional, para visual de progreso).

---

### ⚙️ 7. Notas de implementación

- Los defensores **no pueden reconquistar** una bandera una vez ha sido capturada.
- Cada bandera debe estar registrada al inicio de la partida con el `BattleManager`.
- No se requiere sincronización de red en MVP, pero la lógica es autoritativa.

================================================================================
# SceneDataCarrier 217df9df710280f28baadeb160000018
================================================================================

# SceneDataCarrier

### 📌 1. Nombre del Sistema

**Transportador de Datos entre Escenas (`SceneDataCarrier`)**

---

### 🎯 2. Propósito

Transportar datos temporales (no persistentes) entre escenas que no comparten ejecución directa, como entre la selección de personaje y la ciudad del Feudo, o entre el Matchmaker y la escena de batalla. Su función principal es mantener información accesible **sin reconsultar backend ni duplicar lógica**.

---

### 🧩 3. Componentes principales

- `SceneDataCarrier.cs`: clase estática o singleton para almacenar datos temporales.
- `LobbyData`: estructura que contiene los jugadores y bandos antes de batalla.
- `BattlePreparationData`: incluye la selección de unidades, arma, punto de spawn, etc.

---

### 🧱 4. Clases y estructura

### `SceneDataCarrier.cs`

```csharp
public static class SceneDataCarrier {
    public static LobbyData CurrentLobby;
    public static BattlePreparationData CurrentPreparation;

    public static void Clear() {
        CurrentLobby = null;
        CurrentPreparation = null;
    }
}
```

### `LobbyData.cs`

```csharp
public class LobbyData {
    public List<PlayerProfile> attackers;
    public List<PlayerProfile> defenders;
}

```

### `BattlePreparationData.cs`

```csharp
public class BattlePreparationData {
    public CharacterData hero;
    public List<UnitData> selectedSquads;
    public EquipmentData selectedWeapon;
    public int selectedSpawnPointId;
}
```

---

### 🔄 Flujo de control

1. El jugador entra en la cola de batalla → el `Matchmaker` construye un `LobbyData` y lo guarda en `SceneDataCarrier.CurrentLobby`.
2. Cuando se carga la escena de preparación, esta lee `CurrentLobby` para asignar el bando.
3. Al confirmar su selección en la UI de preparación, se genera un `BattlePreparationData`.
4. Esa estructura se guarda en `CurrentPreparation` antes de cargar el mapa de batalla.
5. Al entrar al mapa de batalla, el sistema de spawn y combate lee `CurrentPreparation` para instanciar todo lo necesario.

---

### 🔗 Dependencias

- `Matchmaker` → asigna `LobbyData`.
- `PreparationPanel` → escribe `BattlePreparationData`.
- `BattleManager`, `SquadManager`, `HeroSpawner` → leen los datos cargados.

---

### ⚙️ Notas de implementación

- Esta clase no debe contener lógica, solo datos en RAM.
- Puede vaciarse con `Clear()` al terminar una batalla o volver al feudo.
- No es persistente: los datos se pierden si el juego se cierra o falla antes de transicionar.
- Puede migrar a un `DontDestroyOnLoad` GameObject si se desea versión no estática.

================================================================================
# SceneLoader 217df9df710280bcb8d4f194b5971705
================================================================================

# SceneLoader

### 📌 1. Nombre del Sistema

**Gestión de Transición de Escenas (`SceneLoader`)**

---

### 🎯 2. Propósito

Controlar de forma centralizada y segura el cambio entre escenas del juego: login, selección de personaje, feudo y mapas de batalla. Se encarga también de mostrar una pantalla de carga, evitar errores durante la transición y transferir datos necesarios entre escenas (como el personaje activo, unidades seleccionadas o contexto de batalla).

---

### 🧩 3. Componentes principales

- `SceneLoader.cs`: clase estática o singleton que realiza las transiciones.
- `LoadingScreenUI`: interfaz que se muestra mientras se carga la nueva escena.
- `SceneDataCarrier`: clase que retiene datos necesarios entre escenas (ej: selección de unidades).
- `UnityEngine.SceneManagement.SceneManager`: API base para cargar escenas.

---

### 🧱 4. Clases y estructuras

### `SceneLoader.cs`

```csharp
public static class SceneLoader {
    private static string nextSceneName;

    public static void LoadScene(string sceneName) {
        nextSceneName = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    public static void LoadLoginScene()         => LoadScene("LoginScene");
    public static void LoadCharacterSelection() => LoadScene("CharacterSelection");
    public static void LoadFeudoScene()         => LoadScene("FeudoCity");
    public static void LoadBattleScene(string mapName) => LoadScene(mapName);

    public static string GetNextScene() => nextSceneName;
}
```

### `LoadingScreenController.cs`

```csharp
public class LoadingScreenController : MonoBehaviour {
    void Start() {
        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext() {
        string targetScene = SceneLoader.GetNextScene();
        yield return new WaitForSeconds(1f); // opcional: delay visual
        yield return SceneManager.LoadSceneAsync(targetScene);
    }
}
```

---

### 🔄 Flujo de control

1. **Se invoca `SceneLoader.LoadX()`** desde cualquier parte del juego.
2. Se carga primero una escena intermedia (`LoadingScreen`) con su propia UI.
3. La escena `LoadingScreen` carga automáticamente la `nextSceneName` en segundo plano.
4. La nueva escena aparece lista, con los datos requeridos ya transferidos.

---

### 🔗 Dependencias

- `SceneManager`: para cargar escenas de Unity.
- `LoadingScreenUI`: muestra progreso o animaciones.
- `SceneDataCarrier`: para mantener datos de sesión entre escenas (ej: escuadras elegidas).
- `PlayerProfile`: mantiene el héroe activo seleccionado.

---

### ⚙️ Notas de implementación

- El uso de una pantalla de carga intermedia previene congelamientos visuales.
- `SceneDataCarrier` puede ser una clase estática o `DontDestroyOnLoad`.
- Se puede integrar animación o barra de carga en la UI.
- En el MVP, los nombres de escenas pueden estar hardcodeados o definidos por constantes.

================================================================================
# SquadCommandSystem 217df9df710280d6b3b3f5b3242f1b62
================================================================================

# SquadCommandSystem

### 📌 1. Nombre del Sistema

**Sistema de Órdenes Básicas a Escuadra (`SquadCommandSystem`)**

---

### 🎯 2. Propósito

Permitir que el jugador emita órdenes tácticas simples a su escuadra activa, como seguir, mantener posición o atacar un objetivo puntual. Estas órdenes afectan el comportamiento de la IA individual de cada unidad (vía `UnitAIController`) y permiten una capa mínima de control sin microgestión completa.

---

### 🧩 3. Componentes principales

- `SquadCommandSystem.cs`: controlador de órdenes emitidas por el jugador.
- `SquadManager`: referencia a la escuadra activa del jugador.
- `UnitAIController`: cada unidad reacciona a la orden recibida.
- `CommandType` enum: define los tipos de órdenes básicas.
- `InputManager` o UI táctica: origen del comando (hotkey o botón).

---

### 🧱 4. Clases y estructura

### `CommandType` (enum)

```csharp
public enum CommandType {
    FollowMe,
    HoldPosition,
    AttackTarget
}
```

### `SquadCommandSystem.cs`

```csharp
public class SquadCommandSystem : MonoBehaviour {
    public SquadManager squadManager;

    public void IssueCommand(CommandType command, Transform target = null) {
        foreach (var unit in squadManager.GetActiveUnits()) {
            var ai = unit.GetComponent<UnitAIController>();

            switch (command) {
                case CommandType.FollowMe:
                    unit.SetFormationMode(true);
                    break;
                case CommandType.HoldPosition:
                    unit.SetFormationMode(false);
                    ai.SetToHoldPosition();
                    break;
                case CommandType.AttackTarget:
                    if (target != null) ai.SetTarget(target);
                    break;
            }
        }
    }
}

```

---

### 🔄 Flujo de control

1. El jugador pulsa una tecla o botón de comando.
2. Se llama a `IssueCommand()` con el tipo de orden.
3. Cada unidad de la escuadra interpreta la orden:
    - `FollowMe` → retoman formación.
    - `HoldPosition` → se detienen.
    - `AttackTarget` → corren hacia el objetivo asignado.

---

### 🔗 Dependencias

- `InputManager` / UI → llama a `IssueCommand`.
- `SquadManager` → da acceso a unidades activas.
- `UnitAIController` → reacciona a los comandos.
- `FormationController` → relevante si se reactiva la formación.

---

### ⚙️ Notas de implementación

- El sistema debe asegurar que **solo la escuadra activa del jugador** reciba las órdenes.
- El jugador no puede emitir órdenes a escuadras que no estén activas o hayan muerto.
- Puede integrarse con un pequeño HUD táctico visual con íconos o teclas.
- En versiones futuras se puede ampliar con órdenes como:
    - `Flanquear`, `Formación defensiva`, `Replegar`, etc.

================================================================================
# SquadManager 217df9df710280dea474c6d6160e3e6a
================================================================================

# SquadManager

### 📌 1. Nombre del Sistema

**Gestión de Escuadras (`SquadManager`)**

---

### 🎯 2. Propósito

Administrar el ciclo de vida, estado y comportamiento de las escuadras bajo control del jugador. Incluye su activación, reemplazo dinámico desde puntos de suministro, integración con formaciones, y sincronización con el héroe líder. Asegura que **solo una escuadra esté activa por jugador** y centraliza la interacción con el sistema de órdenes básicas y formaciones.

---

### 🧩 3. Componentes principales

- `SquadManager.cs`: clase responsable de controlar una escuadra activa por jugador.
- `SquadLoadout`: `List<TroopData>` que almacena las plantillas disponibles.
- `UnitController`: script de cada unidad miembro dentro de una escuadra.
- `FormationController`: posicionamiento y lógica de organización táctica.
- `SquadSpawner`: encargado de instanciar escuadras desde prefabs + loadout.
- `SquadChangeUI`: interfaz que permite cambiar escuadra desde un Supply Point.

---

### 🧱 4. Clases y estructuras

### `SquadLoadout`

```csharp
[System.Serializable]
public class SquadLoadout {
    public List<TroopData> troops;
    // isCombatViable se calcula vía SquadStatsTracker
}
```

### `SquadManager.cs`

```csharp
public class SquadManager : MonoBehaviour {
    public List<TroopData> loadout; // Plantillas en memoria
    public SquadInstance activeInstance;

    public bool SwitchToSquad(TroopData troop) {
        if (activeInstance != null && activeInstance.template == troop)
            return false;

        if (SquadStatsTracker.Instance.GetRemainingTroopPercentage(troop) <= 0.1f)
            return false; // Demasiado diezmada

        if (activeInstance != null)
            Destroy(activeInstance.gameObject);

        activeInstance = SquadInstance.Spawn(troop);
        return true;
    }
}
```

---

### 🔄 5. Eventos y flujo de control

1. **Al entrar a batalla o Supply Point**:
    - Se instancia la escuadra activa con `SwitchToSquad(troop)`.
2. **Cambio de escuadra**:
    - `SwitchToSquad()` elimina la actual y crea la nueva si supera la validación.
    - La nueva escuadra aparece en la zona de spawn o supply.
3. **Durante el combate**:
    - El `FormationController` alinea las unidades automáticamente.
    - Las órdenes del jugador se interpretan y distribuyen (Follow, Attack, Hold).
    - El héroe siempre tiene una referencia a su escuadra activa.

---

### 🔗 6. Dependencias

- `FormationController`: calcula posiciones relativas de la formación táctica.
- `PlayerProfile`: contiene escuadras disponibles del jugador.
- `SupplyPointController`: llama a `SquadManager` para realizar el cambio.
- `BattleManager`: puede acceder al estado de la escuadra activa.
- `UnitController`: control directo de cada individuo de la escuadra.

---

### ⚙️ 7. Notas de implementación

- La escuadra debe estar organizada jerárquicamente bajo un `SquadRoot`.
- Cada unidad debe tener:
    - `UnitController`
    - `HealthComponent`
    - `NavMeshAgent`
- Las unidades deben autoajustarse a formaciones incluso tras pérdidas (reorganización dinámica).
- Cada jugador tiene **una y solo una escuadra activa**. Este sistema **lo garantiza.**
- `SquadLoadout` se utiliza como entrada tanto desde UI de preparación como desde Supply.
- Las tropas con ≤10% de supervivientes son marcadas como no reutilizables.

================================================================================
# SupplyPointController 217df9df71028002a9e4d5fe56f54cb5
================================================================================

# SupplyPointController

### 📌 1. Nombre del Sistema

**Sistema de Puntos de Suministro (Supply Points)**

---

### 🎯 2. Propósito

Proveer zonas tácticas en el mapa donde los jugadores del bando correspondiente puedan **curarse, cambiar de arma y reemplazar su escuadra activa**. También sirven como puntos de control conquistables. Son clave para la sostenibilidad en combate y la estrategia de midgame.

---

### 🧩 3. Componentes principales

- `SupplyPoint.prefab`: estructura visual en el mapa (carreta, tótem, etc.).
- `SupplyPointController.cs`: lógica de interacción, captura y efectos.
- `SupplyPointInteractionUI`: interfaz mostrada al interactuar con el objeto central del supply.
- `HealingZone.cs`: script separado para curación en área (puede ser parte del mismo prefab).
- `SquadManager`, `HeroEquipmentManager`: sistemas que reciben la interacción de reemplazo o cambio de arma.

---

### 🧱 4. Clases y estructuras

### `enum SupplyState`

```csharp
public enum SupplyState {
    Neutral,
    ControlledByAlly,
    ControlledByEnemy
}
```

### `SupplyPointController.cs`

```csharp
public class SupplyPointController : MonoBehaviour {
    public SupplyState currentState;
    public Team controllingTeam;
    public float captureDuration = 6f;

    private float captureProgress;
    private bool canBeCaptured = true;

    public Collider triggerZone;
    public GameObject interactionObject; // carreta central
    public SupplyPointInteractionUI interactionUI;

    public void OpenInteraction(PlayerProfile profile) {
        var squads = profile.GetAvailableSquads();
        interactionUI.Show(squads, SquadManager.Instance);
    }
}
```

---

### 🔄 5. Eventos y flujo de control

- **Captura de Supply Point:**
    - Si un jugador enemigo entra en el área y permanece por `captureDuration`, el control cambia a su bando.
    - Puede ser recapturado múltiples veces.
- **Interacción:**
    - Si el jugador está en el bando correcto y presiona `F` sobre el objeto central (`interactionObject`), se abre la `SupplyPointInteractionUI`.
- **Cambios posibles desde la UI:**
    - Cambiar de escuadra. La lista muestra todas las del loadout y se deshabilitan las con ≤10% de unidades vivas o la actualmente activa.
    - Cambiar arma (entre armas desbloqueadas y compatibles).
    - Curación pasiva del héroe y la escuadra mientras permanezcan en el área.

---

### 🔗 6. Dependencias

- `PlayerProfile`: para validar escuadras y armas disponibles.
- `SquadManager`: para instanciar la nueva escuadra y eliminar la anterior.
- `HeroEquipmentManager`: para aplicar nuevo arma al modelo y al sistema de combate.
- `HealingZone.cs`: aplica curación periódica si el jugador permanece dentro.

---

### ⚙️ 7. Notas de implementación

- Curación se aplica como `tick` cada cierto intervalo de tiempo (`ApplyHealing()`).
- Si el Supply está en estado enemigo o neutral, no se puede interactuar.
- El cambio de escuadra o arma no es inmediato si hay condiciones que bloquean la acción (ej: muerte de héroe).
- Puede haber más de un `SupplyPoint` en el mapa.

================================================================================
# SupplyPointInteractionUI 217df9df710280e49f51d437700823c8
================================================================================

# SupplyPointInteractionUI

### 📌 1. Nombre del Sistema

**Interfaz de Interacción con Punto de Suministro (`SupplyPointInteractionUI`)**

---

### 🎯 2. Propósito

Permitir al jugador, mientras se encuentra en el área de un `SupplyPoint` controlado, interactuar con una interfaz para cambiar de escuadra y/o de arma. Este sistema reutiliza gran parte de la UI de preparación de batalla, pero en contexto activo y bajo nuevas restricciones (una escuadra activa, validación de salud, etc.).

---

### 🧩 3. Componentes principales

- `SupplyPointInteractionUI.cs`: controlador del panel.
- `SquadSelectorUI`: lista de escuadras válidas para cambiar.
- `WeaponSelector`: selector de armas del héroe.
- `ConfirmChangeButton`: aplica los cambios y cierra la interfaz.
- `SupplyPointController`: instancia esta UI cuando el jugador interactúa con el objeto central del supply.

---

### 🧱 4. Clases y estructuras

### `SupplyPointInteractionUI.cs`

```csharp
public class SupplyPointInteractionUI : MonoBehaviour {
    public SquadSelectorUI squadSelector;
    public Button confirmButton;
    private SquadManager squadManager;

    public void Show(List<TroopData> troops, SquadManager manager) {
        squadManager = manager;
        squadSelector.Populate(troops, troop =>
            SquadStatsTracker.Instance.GetRemainingTroopPercentage(troop) > 0.1f);
        confirmButton.onClick.AddListener(ApplyChanges);
    }

    void ApplyChanges() {
        var selected = squadSelector.GetSelectedTroop();
        if (selected != null)
            squadManager.SwitchToSquad(selected);
        gameObject.SetActive(false);
    }
}
```

---

### 🔄 5. Eventos y flujo de control

1. El jugador entra en el área del SupplyPoint (estado: `ControladoPorAliado`).
2. Interactúa con el objeto central (`F`).
3. Se muestra la UI:
    - Lista de todas las tropas del loadout indicando su porcentaje vivo.
    - Las inviables (≤10% o la activa) se muestran deshabilitadas con tooltip.
    - Armas equipables disponibles.
4. El jugador hace una o ambas selecciones.
5. Al confirmar:
    - Se llama a `SwitchToSquad()` para cambiar la escuadra.
    - Se actualiza el arma equipada del héroe.
6. La interfaz se cierra automáticamente.

---

### 🔗 6. Dependencias

- `SupplyPointController`: verifica si puede mostrarse la UI.
- `SquadManager`: para cambiar la escuadra activa.
- `HeroEquipmentManager`: para aplicar el arma nueva.
- `PlayerProfile`: consulta las opciones válidas.

---

### ⚙️ 7. Notas de implementación

- Las escuadras ya utilizadas o con ≤10% efectivos deben mostrarse como **bloqueadas o deshabilitadas**.
- Las escuadras deben reaparecer dentro del área del Supply Point.
- No se pueden tener dos escuadras activas.
- El arma del héroe debe actualizarse en tiempo real (visual + lógica de combate).
- El `ConfirmChangeButton` debe estar desactivado si ninguna opción válida ha sido seleccionada.
- Mostrar tooltip "Demasiado diezmada para ser desplegada" en opciones deshabilitadas.

================================================================================
# SquadStatsTracker
================================================================================

# SquadStatsTracker

### 📌 1. Nombre del Sistema

**Seguimiento de estadísticas de escuadra (`SquadStatsTracker`)**

---

### 🎯 2. Propósito

Registrar las bajas de cada `SquadInstance` y exponer porcentajes de tropas restantes para la lógica de UI y reemplazo.

---

### 🧱 3. Clases y estructuras

### `SquadStatsTracker.cs`

```csharp
public class SquadStatsTracker : MonoBehaviour {
    public int GetAliveCount(TroopData troop);
    public int GetTotalCount(TroopData troop);
    public float GetRemainingTroopPercentage(TroopData troop);
}
```

Este método `GetRemainingTroopPercentage()` se utiliza para filtrar tropas viables.

================================================================================
# UnitAIController (FSM básica de tropas) 217df9df7102808d9cbccfc24b6440a9
================================================================================

# UnitAIController (FSM básica de tropas)

### 

### 📌 1. Nombre del Sistema

**IA de Tropas (`UnitAIController`) – FSM con integración de formación**

---

### 🎯 2. Propósito

Controlar el comportamiento autónomo de cada unidad dentro de una escuadra, permitiendo una transición fluida entre el modo formación, el seguimiento al líder y el combate activo contra enemigos. Opera como una **máquina de estados finita (FSM)** que evalúa constantemente el entorno y las órdenes.

---

### 🧩 3. Componentes principales

- `UnitAIController.cs`: script principal de la IA por unidad.
- `NavMeshAgent`: locomoción de la unidad.
- `UnitController`: contiene la posición de formación y estado táctico.
- `UnitSensor`: detecta enemigos cercanos.
- `FormationController`: define los `slots` de posicionamiento.
- `SquadCommander` (futuro): sistema para aplicar órdenes tácticas.
- `FSMDebugger` (opcional): muestra sobre la unidad el estado actual de la FSM.

---

### 🧱 4. Clases y estructuras

### `enum UnitState`

```csharp
public enum UnitState {
    Idle,
    MovingToFormation,
    AttackingEnemy,
    HoldingPosition
}
```

### `UnitAIController.cs`

```csharp
[RequireComponent(typeof(NavMeshAgent))]
public class UnitAIController : MonoBehaviour {
    public UnitState currentState = UnitState.Idle;
    private UnitController unit;
    private NavMeshAgent agent;
    private UnitSensor sensor;

    void Start() {
        unit = GetComponent<UnitController>();
        agent = GetComponent<NavMeshAgent>();
        sensor = GetComponent<UnitSensor>();
    }

    void Update() {
        switch (currentState) {
            case UnitState.MovingToFormation:
                agent.SetDestination(unit.assignedFormationPosition);
                break;
            case UnitState.AttackingEnemy:
                var target = sensor.GetNearestEnemy();
                if (target != null)
                    agent.SetDestination(target.position);
                break;
            case UnitState.HoldingPosition:
                agent.isStopped = true;
                break;
        }

        EvaluateTransitions();
    }

    void EvaluateTransitions() {
        if (sensor.HasEnemiesInRange()) {
            currentState = UnitState.AttackingEnemy;
        }
        else if (unit.IsInFormationMode()) {
            currentState = UnitState.MovingToFormation;
        }
        else {
            currentState = UnitState.Idle;
        }
    }
}
```

---

### 🔄 Flujo de control

1. **Estado por defecto**: `MovingToFormation`
    - La unidad se dirige a su `assignedFormationPosition` definido por el `FormationController`.
2. **Estado de combate**: `AttackingEnemy`
    - Al detectar enemigos, cambia automáticamente al modo ofensivo.
3. **Retorno a formación**:
    - Si no hay enemigos, vuelve a `MovingToFormation`.
4. **Modo pasivo**: `HoldingPosition`
    - Se activa por órdenes externas (ej: “mantener posición”).

---

### 🔗 Dependencias

- `UnitController`:
    - `assignedFormationPosition` – objetivo en formación.
    - `IsInFormationMode()` – determina si debe seguir en posición estructurada.
- `NavMeshAgent`:
    - Movimiento de la unidad.
- `UnitSensor`:
    - Detección de enemigos para transición a combate.
- `FormationController`:
    - Asigna posiciones iniciales al entrar en formación.

---

### ⚙️ Notas de implementación

- La IA siempre prioriza enemigos cercanos sobre formación.
- El estado `HoldingPosition` se usará con comandos directos del jugador (órdenes básicas).
- En modo combate, el `NavMeshAgent` sigue directamente al objetivo.
- Si el sistema se expande, podrían añadirse nuevos estados como:
    - `Fleeing`, `SupportingAlly`, `ReturningToFormationAfterCombat`.

================================================================================
# UnitController 217df9df710280cdaebed736f82142e4
================================================================================

# UnitController

### 📌 1. Nombre del Sistema

**Controlador de Unidad (`UnitController`)**

---

### 🎯 2. Propósito

Gestionar los datos, comportamientos y estado individual de una unidad dentro de una escuadra. Funciona como un contenedor central para su posición táctica, salud, animaciones, referencia al equipo, y conexión con la IA. Recibe instrucciones del sistema de formación y combate, y expone propiedades que usan otros módulos como el AI, HUD o lógica de daño.

---

### 🧩 3. Componentes principales

- `UnitController.cs`: clase base por unidad.
- `NavMeshAgent`: para movimiento individual.
- `HealthComponent`: gestión de vida y muerte.
- `UnitAIController`: lógica de comportamiento autónomo.
- `SquadManager` / `FormationController`: asignan posición táctica.
- `Team` enum o clase: determina el bando y pertenencia.

---

### 🧱 4. Clases y estructura

### `UnitController.cs`

```csharp
public class UnitController : MonoBehaviour {
    // Asignado por FormationController
    public Vector3 assignedFormationPosition { get; set; }

    // Control de modo
    private bool formationMode = false;

    // Estado básico
    public bool isAlive = true;
    public Team unitTeam;
    public int unitIndexInSquad;

    // Referencias
    public NavMeshAgent agent;
    public HealthComponent health;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<HealthComponent>();
    }

    public void SetFormationMode(bool active) {
        formationMode = active;
    }

    public bool IsInFormationMode() {
        return formationMode;
    }

    public void MarkAsDead() {
        isAlive = false;
        agent.isStopped = true;
        // Se puede desactivar colisión, animación, etc.
    }
}
```

---

### 🔄 Flujo de control

1. **Inicio o Spawn:**
    - `FormationController` le asigna `assignedFormationPosition`.
    - Entra en `formationMode`.
2. **Durante el combate:**
    - El `UnitAIController` consulta esta clase para:
        - Saber si debe seguir en formación.
        - Saber hacia dónde moverse.
3. **Al morir:**
    - Se llama a `MarkAsDead()`, se detiene el movimiento y puede lanzar eventos.
4. **Si se reorganiza la escuadra:**
    - `FormationController` reasigna nuevas posiciones.

---

### 🔗 Dependencias

- `FormationController`: asigna posición táctica.
- `UnitAIController`: lee modo y destino asignado.
- `HealthComponent`: verifica estado de vida.
- `NavMeshAgent`: ejecuta el movimiento.

---

### ⚙️ Notas de implementación

- La propiedad `assignedFormationPosition` es **el objetivo al que debe moverse la unidad cuando está en formación**.
- `unitIndexInSquad` puede usarse para organización y depuración.
- Puede ser extendido con:
    - Animaciones (`Animator`)
    - Daño recibido (`HitReaction`)
    - Tipo de unidad / rol
- Las unidades se identifican por `unitTeam` para evitar fuego amigo o confusión de IA.

================================================================================
# Estructuras Base de Escuadras
================================================================================

- **`TroopData` (ScriptableObject):** plantilla con atributos de una tropa.
- **`SquadInstance` (en escena):** instancia activa de `TroopData` que gestiona a sus unidades.
- **`SquadStatusTracker`** (alias de `SquadStatsTracker`): mantiene el porcentaje vivo y marca escuadras como no reutilizables.
