# Activar fase previa de preparación (3 minutos) 216df9df710280448e18da3cf76d68ff

# Activar fase previa de preparación (3 minutos)

Descripción: Temporizador e interfaz que habilita la elección de punto de spawn y bloqueo de acción.
Prioridad: Media
Etiquetas: Flujo, Preparación
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md)
Bloqueando: Spawn automático de héroe + unidad en punto seleccionado (Spawn%20automa%CC%81tico%20de%20he%CC%81roe%20+%20unidad%20en%20punto%20sele%20216df9df710280cdbaf9cd4f5fb657fc.md)
Fase: Preparación de Combate
orden: 28

### 🧭 **Tarea:** Activar fase previa de preparación (3 minutos)

**Descripción técnica detallada:**

Al iniciar una batalla, antes de que el combate comience, se debe activar una fase de preparación de duración fija (ej. 180 segundos). Durante esta fase, el jugador puede configurar su participación: elegir punto de aparición, escuadra, loadout y confirmar su disposición. El sistema debe controlar el temporizador, bloquear acciones de combate, y monitorear si todos los jugadores están listos antes del límite de tiempo. Esta fase es crítica para establecer el despliegue táctico inicial de cada bando.

---

### 🎮 **Funcionalidades requeridas:**

- Activar el temporizador global de preparación (ej. 180 segundos).
- Mostrar el tiempo restante en la UI de preparación.
- Permitir al jugador:
    - Seleccionar punto de spawn.
    - Seleccionar unidades sin pasar el liderazgo.
    - Elegir un loadout predefinido (opcional).
    - Presionar “Continuar” si está listo.
- Bloquear cualquier acción de combate.
- Transicionar automáticamente a combate al finalizar el tiempo o si todos confirman.

---

### ⚙️ **Requisitos técnicos**

- Script `PreparationPhaseManager.cs`:
    - Controla el tiempo (`float timer = 180f`)
    - Llama a `StartCombatPhase()` si:
        - `timer <= 0`
        - o todos los jugadores han confirmado
- Emisión de evento `OnPreparationStart()` para mostrar UI.
- Temporizador visual (`TimerUI`) sincronizado con lógica del tiempo.
- Lógica de monitoreo de “readiness” para cada jugador.
- Si multijugador:
    - Servidor debe sincronizar inicio y fin de esta fase con todos los clientes.

---

### 🧪 **Criterios de aceptación**

- Al iniciar la batalla, la fase de preparación comienza automáticamente con tiempo visible.
- El jugador tiene acceso completo a las selecciones permitidas.
- El HUD de combate no está disponible.
- Al finalizar el tiempo o al confirmar todos los jugadores, la transición a combate ocurre correctamente.
- No se puede mover ni atacar durante esta fase.

# Agregar botón “Continuar” con transición al Feud 216df9df710280848bb4f699b895d5bb

# Agregar botón “Continuar” con transición al Feudo

Descripción: Permitir salir de la pantalla de resultados y volver al Feudo con el personaje activo.
Prioridad: Alta
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Agregar botón “Continuar” con transición al Feudo

**Descripción técnica detallada:**

Botón de acción que cierra el resumen de batalla y realiza la transición segura al Mapa de Feudo, manteniendo el personaje y equipo activo.

---

### 🎮 Funcionalidades requeridas:

- Botón visible y destacado
- Al hacer clic, cambia de escena

---

### ⚙️ Requisitos técnicos:

- Función `GoToFeudo()` en `BattleSummaryController`
- Uso de `SceneManager.LoadScene("Feudo")`
- Desactivación de inputs múltiples

---

### 🧪 Criterios de aceptación:

- El botón funciona y lleva al jugador al Feudo sin errores
- No hay retrasos ni bugs al presionar
- El jugador vuelve con el mismo héroe activo

# Agregar puntos de referencia (spawn, zonas) 214df9df7102815ba355e0a0f32687cd

# Agregar puntos de referencia (spawn, zonas)

Descripción: Colocar ubicaciones clave en el terreno para probar la colocación de héroes, unidades y objetivos tácticos.
Prioridad: Media
Etiquetas: Gameplay
Etapa: Por hacer
Sistema Principal: Formaciones, Terreno y Navegación
Bloqueado por: Crear terreno de prueba (250x250m) (Crear%20terreno%20de%20prueba%20(250x250m)%20214df9df7102819d85d8daf06673b3ec.md)
Fase: Preparación de Combate
orden: 34

### 🧭 **Tarea:** Agregar puntos de referencia (spawn, zonas)

**Descripción técnica detallada:**

Establecer una serie de puntos visibles y reutilizables en la escena de prueba para representar ubicaciones importantes como zonas de aparición (`spawn points`), áreas de control o puntos de interés táctico. Estos puntos son esenciales para validar el posicionamiento de tropas, probar sistemas de despliegue, órdenes iniciales, y rutas de navegación controladas.

---

### 🎮 **Funcionalidades requeridas:**

- Crear al menos tres tipos de puntos:
    - `HeroSpawnPoint` – para el héroe del jugador.
    - `SquadSpawnPoint` – para escuadras aliadas o enemigas.
    - `ControlZone` – área de control para futuras pruebas de modos de juego.
- Cada punto debe ser un `GameObject` con un visual mínimo (ej: gizmo, ícono, marcador de color).
- Posicionamiento en áreas representativas:
    - Zona central libre.
    - Bordes del mapa (lados opuestos para simular enemigos).
    - Áreas con obstáculos cercanos para validación de movimiento.

---

### ⚙️ **Requisitos técnicos**

- Scripts opcionales:
    - `SpawnPointType` enum o tag para diferenciarlos.
    - `ZoneMarker` script para efectos visuales si se requiere identificación.
- Prefabs en `/Prefabs/Gameplay/Markers/`.
- Uso de `Gizmos` para mostrar íconos en editor (por color y nombre).
- Alineación correcta con el terreno (`Y=0` o normalizada).
- Organización jerárquica: agrupar bajo `MarkersRoot` en la escena.

---

### 🧪 **Criterios de aceptación**

- Los puntos son visibles en editor y fácilmente reconocibles.
- Los objetos pueden ser instanciados desde código sobre estos puntos.
- La IA o escuadras pueden navegar desde/hacia estos puntos sin errores.
- Están colocados con intencionalidad para futuras pruebas de combate, flanqueo o control de zonas.
- Pueden ser activados/desactivados sin romper referencias en otros sistemas.

# Animaciones sincronizadas por tipo de formación 217df9df710280449482c875e2fa3adf

# Animaciones sincronizadas por tipo de formación

Descripción: Adaptar la postura y animación de los miembros de escuadra según la formación activa.
Prioridad: Alta
Etiquetas: Animación, Combate, Formaciones, Gestión de Escuadra
Etapa: Backlog
Sistema Principal: Gestión de Escuadra
Fase: Batalla
ítem principal: Implementar cambio de formación (hotkey o menú) (Implementar%20cambio%20de%20formacio%CC%81n%20(hotkey%20o%20menu%CC%81)%20214df9df71028191b074cb0500d6b1b1.md)

### 🧭 **Tarea:** Animaciones sincronizadas por tipo de formación

**Descripción técnica detallada:**

Cada formación táctica impone una intención estratégica: defensiva, ofensiva, flanqueo, avance en cuña, etc. Las unidades dentro de la escuadra deben reflejar esa intención mediante animaciones sincronizadas y apropiadas para la formación en uso. Esto incluye la postura de movimiento, transición suave entre formaciones, y animaciones de espera o avance. Este sistema mejora la claridad visual y el nivel de inmersión táctica del combate.

---

### 🎮 **Funcionalidades requeridas:**

- Detectar cambio de formación activa en tiempo real.
- Modificar el `AnimatorController` o `AnimationState` de las unidades de la escuadra según:
    - Tipo de formación: línea, cuña, columna, escudo, etc.
    - Estado actual: idle, avanzando, en combate.
- Sincronizar la animación entre unidades de forma que no haya descoordinación perceptible.
- Permitir transiciones limpias cuando se cambia de formación (crossfade de animaciones).
- Usar animaciones más compactas, tensas o defensivas en formaciones cerradas.

---

### ⚙️ Requisitos técnicos

- Prefab de unidad debe tener:
    - `Animator` con parámetros como `formationType`, `isMoving`, `isInCombat`.
- Sistema de formación (`FormationController.cs`) debe emitir evento al cambiar:
    
    ```csharp
    OnFormationChanged(FormationType newType)
    ```
    
- Script `UnitAnimatorSync.cs`:
    - Suscrito a `OnFormationChanged`
    - Llama `Animator.CrossFade()` a animaciones específicas.
- Uso de `AnimatorOverrideController` para mapear clips por formación.
- Integración opcional con blend trees de locomoción (idle/walk/run).

---

### 🧪 **Criterios de aceptación**

- Todas las unidades en la escuadra cambian de animación cuando se cambia la formación.
- No hay desincronización ni parpadeos visuales al hacer el cambio.
- La nueva animación es apropiada para el tipo de formación seleccionada.
- El sistema responde bien tanto en desplazamiento como en modo espera.
- Las animaciones pueden escalar con nuevas formaciones en el futuro.

# Animar entrada progresiva de elementos (opcional) 216df9df71028020947be633a3ffd14a

# Animar entrada progresiva de elementos (opcional)

Descripción: Animar la aparición escalonada de secciones para mayor impacto visual.
Prioridad: Baja
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Animar entrada progresiva de elementos (opcional)

**Descripción técnica detallada:**

Usar animaciones de aparición, fade o escala para que las secciones de la interfaz entren con efecto (ej. fade-in por bloque).

---

### 🎮 Funcionalidades requeridas:

- Delay o animación por grupo de elementos
- Control desde script con secuencia opcional

---

### ⚙️ Requisitos técnicos:

- Uso de `DOTween`, `Animator` o corutinas
- Script `SummaryAnimator.cs`

---

### 🧪 Criterios de aceptación:

- La entrada visual es suave y ordenada
- Puede activarse o desactivarse sin afectar funcionalidad

# Aplicación de atributos a miembros de la escuadra 217df9df71028025b4a2cbb6947c9ae5

# Aplicación de atributos a miembros de la escuadra

Descripción: Asignar estadísticas base y modificadas a cada unidad instanciada durante el combate.
Prioridad: Alta
Etiquetas: Gestión de Escuadra, Unidades
Etapa: Backlog
Sistema Principal: Gestión de Escuadra
Fase: Mecánicas de Combate
ítem principal: Spawn automático de héroe + unidad en punto seleccionado (Spawn%20automa%CC%81tico%20de%20he%CC%81roe%20+%20unidad%20en%20punto%20sele%20216df9df710280cdbaf9cd4f5fb657fc.md)

### 🧭 **Tarea:** Aplicación de atributos a miembros de la escuadra

**Descripción técnica detallada:**

Al momento de instanciar las unidades que conforman una escuadra, cada miembro debe recibir sus atributos base correspondientes al tipo de unidad (`UnitID`) y aplicar sobre ellos cualquier modificación relevante (nivel, talentos, buffs pasivos, efectos de feudo, etc.). Esto asegura que el comportamiento en combate, como daño, salud, velocidad, y defensa, refleje correctamente las características de esa unidad dentro del perfil del jugador.

Los atributos deben almacenarse en una estructura central accesible por los sistemas de combate, animación y lógica de IA.

---

### 🎮 **Funcionalidades requeridas:**

- Al crear cada unidad:
    - Consultar su `UnitData` base desde catálogo (`UnitDatabase` o similar).
    - Aplicar modificadores (si los hay) provenientes de:
        - Nivel de la unidad
        - Efectos pasivos globales
        - Bonificaciones activas del jugador
- Guardar los atributos finales en una clase tipo `UnitStats`.
- Asegurar que estos atributos estén disponibles para:
    - Cálculo de daño recibido
    - Movimiento (velocidad)
    - Determinación de IA (agresividad, rango, prioridad)
- Los valores deben ser leídos y no modificables durante el combate, a menos que un efecto explícito lo permita.

---

### ⚙️ Requisitos técnicos

- Clase `UnitStats`:
    - Atributos típicos: `health`, `armor`, `attackPower`, `attackType`, `movementSpeed`, `defenseType`, `penetration`, etc.
- Método `UnitStatsFactory.GenerateFrom(UnitID id, int nivel, Modificadores extras)`
- La clase `Unit.cs` o `UnitController.cs` debe contener un campo:
    
    ```csharp
    csharp
    CopiarEditar
    public UnitStats Stats { get; private set; }
    
    ```
    
- Posible fuente de atributos base:
    - `UnitDatabase.GetBaseStats(UnitID)`
- Posible fuente de modificadores:
    - `PlayerProfile.UnitProgressions[UnitID]`
    - `PerkSystem.GetGlobalModifiers()`

---

### 🧪 **Criterios de aceptación**

- Cada unidad instanciada en combate tiene una copia local de sus `UnitStats`.
- Los atributos reflejan correctamente el tipo de unidad y sus progresiones.
- Los sistemas de combate leen estos valores al calcular daño y efectos.
- No se generan errores ni se producen valores nulos o inválidos.
- Cambios en el progreso del jugador afectan a los stats reales usados en batalla.

# Aplicar perks pasivos al héroe 214df9df710281b89828d83fd1e73bc1

# Aplicar perks pasivos al héroe

Descripción: Activar y aplicar los efectos estadísticos de perks pasivos sobre los atributos del héroe en tiempo real.
Prioridad: Media
Etiquetas: Gameplay
Etapa: Backlog
Sistema Principal: Perks y Talentos
Bloqueado por: Sistema de Perks y Talentos (Sistema%20de%20Perks%20y%20Talentos%20214df9df710281ce965ffbc441d224d1.md)
Fase: Mecánicas de Combate
orden: 52

### 🧭 **Tarea:** Aplicar perks pasivos al héroe

**Descripción técnica detallada:**

Desarrollar la lógica responsable de aplicar los efectos de perks pasivos sobre el héroe una vez que han sido desbloqueados o seleccionados. Estos efectos deben modificar dinámicamente los atributos base y derivados del personaje (como daño, defensa, liderazgo, moral), permitiendo personalización y progresión. El sistema debe funcionar tanto en runtime como al cargar el perfil del héroe.

---

### 🎮 **Funcionalidades requeridas:**

- Leer perks pasivos desbloqueados del perfil del héroe (`HeroProfile` o `PerkManager`).
- Aplicar automáticamente los modificadores definidos en cada perk:
    - Atributos base: Fuerza, Destreza, Vitalidad, Armadura.
    - Atributos derivados: Vida, Daño por tipo, Liderazgo, Moral.
- Acumulación de efectos si hay más de un perk que modifica la misma estadística.
- Soporte para modificadores planos y porcentuales.
- Debe reflejarse inmediatamente en el HUD (si está visible) y en combate.
- Integración con la visualización de stats en UI del héroe.

---

### ⚙️ **Requisitos técnicos**

- Perks definidos con estructura `StatModifier`, incluyendo:
    
    ```csharp
    public enum StatType { Strength, Dexterity, Vitality, Armor, Leadership, Health, DamageCut, DamagePierce, DamageBlunt, Morale }
    public class StatModifier {
        public StatType stat;
        public float value;
        public bool isPercent;
    }
    ```
    
- Sistema `HeroStatSystem` debe tener método para registrar e interpretar múltiples modificadores.
- Aplicación al cargar perfil, y también al momento de desbloquear un nuevo perk en tiempo real.
- Listener visual para notificar cambios si la UI está abierta (`HeroStatsUIController`).

---

### 🧪 **Criterios de aceptación**

- Todos los perks pasivos desbloqueados modifican correctamente los atributos del héroe.
- Los valores se acumulan si hay perks que afectan el mismo stat.
- Las estadísticas actualizadas se reflejan en la interfaz del jugador.
- Cambios se aplican también al reaparecer o cambiar de escena.
- No hay errores al aplicar perks inválidos o al cargar datos incompletos.

# Asignación de equipamiento visual y funcional a m 217df9df7102800aa21efa5031e82157

# Asignación de equipamiento visual y funcional a miembros

Descripción: Mostrar correctamente el equipamiento y aplicar sus efectos al instanciar cada unidad.
Prioridad: Alta
Etiquetas: Gestión de Escuadra, Prefab, Visualización
Etapa: Backlog
Sistema Principal: Gestión de Escuadra
Fase: Preparación de Combate
ítem principal: Spawn automático de héroe + unidad en punto seleccionado (Spawn%20automa%CC%81tico%20de%20he%CC%81roe%20+%20unidad%20en%20punto%20sele%20216df9df710280cdbaf9cd4f5fb657fc.md)

### 🧭 **Tarea:** Asignación de equipamiento visual y funcional a miembros

**Descripción técnica detallada:**

Las unidades de la escuadra deben representar visualmente el tipo de arma y armadura que usan, así como aplicar las características funcionales asociadas a dicho equipamiento. Este proceso se realiza justo después de instanciar la unidad y aplicar sus atributos. El sistema debe combinar datos del tipo de unidad, su equipamiento por defecto o personalizado, y reflejarlos tanto en la apariencia del modelo como en sus estadísticas de combate.

---

### 🎮 **Funcionalidades requeridas:**

- Asignar equipamiento **visual**:
    - Armas visibles en la mano (espada, lanza, arco).
    - Armaduras en torso y casco si aplica.
    - Colores, emblemas o partes cosméticas del ejército del jugador.
- Asignar equipamiento **funcional**:
    - Modificar daño, tipo de ataque, velocidad o defensa según el equipo asignado.
    - Equipos definidos por defecto en el catálogo de unidad, o por personalización del jugador (si está habilitada).
- Sincronización:
    - El modelo 3D debe coincidir con las estadísticas que influyen en combate.

---

### ⚙️ Requisitos técnicos

- Sistema de equipamiento:
    - `EquipmentSet` que contiene: `WeaponID`, `ArmorID`, `VisualSetID`.
- Script `UnitEquipmentApplier.cs`:
    - Método: `ApplyTo(Unit unit, EquipmentSet equip)`
        - Cambia mesh de arma, texturas o piezas.
        - Ajusta `UnitStats` con modificadores derivados del equipo.
- Base de datos de equipamiento:
    - `EquipmentDatabase.GetVisual(WeaponID)`
    - `EquipmentDatabase.GetModifiers(WeaponID, ArmorID)`
- Integración con:
    - `UnitFactory` → después de instanciar y antes de activar la unidad.

---

### 🧪 **Criterios de aceptación**

- Las unidades aparecen en el mapa con el equipamiento visible adecuado.
- Los modificadores del equipo afectan las estadísticas como el daño y la defensa.
- No hay errores visuales (por ejemplo, armas flotando o invisibles).
- Las unidades del mismo tipo pueden tener equipamiento visual diferente si se define así.
- La lógica es consistente con la del héroe jugador y puede escalar en el futuro.

# Asociar control de banderas al progreso del equipo 217df9df71028056be0fdc16951ea340

# Asociar control de banderas al progreso del equipo atacante

Descripción: Vincular la cantidad de banderas capturadas por el atacante con su condición de victoria en la batalla de feudo.
Prioridad: Alta
Etiquetas: Batalla, Condiciones de victoria, Mapa de batalla
Etapa: Backlog
Sistema Principal: Batalla
Fase: Batalla
orden: 58

### 🧭 **Tarea:** Asociar control de banderas al progreso del equipo atacante

**Descripción técnica detallada:**

Cada bandera del defensor representa un objetivo táctico que el atacante debe conquistar. El sistema de control central de la batalla debe estar al tanto de cuántas banderas han sido capturadas por los atacantes. Una vez que las **tres banderas han sido conquistadas**, se debe registrar inmediatamente que el equipo atacante ha ganado la batalla.

Este sistema se encargará de llevar el conteo de las capturas, validar el progreso y, eventualmente, **disparar la condición de victoria** para el atacante sin necesidad de esperar a que se acabe el cronómetro.

---

### 🎮 **Funcionalidades requeridas:**

- Sistema global de control de batalla (`BattleManager.cs`) escucha eventos de captura de bandera.
- Cada `CapturePoint_Bandera` notifica a `BattleManager` cuando cambia a estado “CapturadaPorAtacante”.
- `BattleManager` lleva un contador de banderas capturadas:
    
    ```csharp
    int capturedFlagsByAttackers;
    const int flagsToWin = 3;
    ```
    
- Si `capturedFlagsByAttackers == 3`:
    - Se dispara la condición de victoria para el atacante.
    - Se bloquean todas las acciones y se transiciona al fin de partida.

---

### ⚙️ **Requisitos técnicos**

- Script `BattleManager.cs`:
    - `RegisterFlagCaptured()` método llamado desde `CapturePointController`.
    - Contador interno actualizado cada vez que una bandera es capturada.
    - Método `CheckForVictory()` que se ejecuta tras cada cambio.
- Lógica de evento:
    
    ```csharp
    public void OnFlagCaptured(CapturePoint_Bandera flag) {
        capturedFlagsByAttackers++;
        if (capturedFlagsByAttackers >= flagsToWin)
            TriggerVictoryForAttackers();
    }
    ```
    
- Integración con `EndBattleHandler.cs` (ver tarea futura).

---

### 🧪 **Criterios de aceptación**

- Al capturar una bandera, el evento se registra correctamente en el sistema global.
- El contador de banderas capturadas por atacantes se actualiza en tiempo real.
- Cuando las tres banderas son capturadas:
    - Se dispara el fin de partida con victoria atacante.
    - No hay necesidad de esperar a que termine el tiempo.
- El sistema ignora intentos de recaptura por parte del defensor.

---

# Barracón y Loadouts 214df9df710281d5aa5ed3bbdbf30723

# Barracón y Loadouts

Descripción: Crear sistema básico para visualizar y seleccionar tropas disponibles, y guardar configuraciones como “loadouts” de combate.
Prioridad: Alta
Etiquetas: Barracón
Etapa: Backlog
Sistema Principal: Barracón
Fase: Configurar Personaje y Unidades
orden: 23

### 🧭 **Tarea:** Barracón y Loadouts

**Descripción técnica detallada:**

Desarrollar la primera versión funcional del sistema de **barracón**, donde el jugador puede gestionar las **tropas** disponibles (plantillas de escuadra o *Troops*), ver sus estadísticas y crear combinaciones para usarlas en combate como **loadouts**. Cada *Troop* representa una escuadra homogénea completa que consume un valor fijo de liderazgo. El sistema no requiere lógica de progresión ni restricciones por rareza para el MVP, pero sí debe contemplar su extensión futura. El enfoque está en funcionalidad mínima, claridad visual y persistencia básica.

---

### 🎮 **Funcionalidades requeridas:**

- Visualización de **tropas** disponibles para el jugador (plantillas `Troop`):
     - Nombre, tipo, rareza, nivel, liderazgo por escuadra, moral, ícono.
- Interface para crear un loadout:
     - Seleccionar **tropas completas** según el liderazgo disponible del héroe.
     - Máximo de 1 *Troop* (una escuadra) para el MVP, con posibilidad de escalar.
- Guardar y cargar configuraciones de tropas (`Loadout 1`, `Loadout 2`, etc.).
- Vista previa básica (ícono o modelo simple).
- Confirmación para asignar el loadout actual como el activo antes de entrar en partida.

---

### ⚙️ **Requisitos técnicos**

- Panel de UI llamado `BarracksPanel` dentro de `/UI/Barracks/`.
- Script de gestión: `BarracksManager.cs`.
- Clase `TroopData` para contener la plantilla de cada tropa disponible.
- Estructura de `Loadout` que contenga una lista de `TroopData` y un ID de configuración.
- Datos serializados en PlayerPrefs o ScriptableObject para persistencia local (para MVP).
- Integración con sistema de liderazgo para validar el coste total del loadout.

---

### 🧪 **Criterios de aceptación**

- El jugador puede ver todas sus unidades disponibles (inicialmente fijas).
- Puede armar un loadout válido respetando el límite de liderazgo.
- El loadout activo se guarda correctamente y se puede recuperar entre sesiones.
- La selección se refleja correctamente al iniciar una partida.
- El sistema está listo para recibir mejoras visuales o restricciones por progresión en fases futuras.

# Bloquear reconquista de banderas por el defensor 217df9df71028004aa21ccd3bf684c1d

# Bloquear reconquista de banderas por el defensor

Descripción: Evitar que el equipo defensor vuelva a capturar una bandera que ha sido tomada por el atacante.
Prioridad: Alta
Etiquetas: Batalla, Feudo, Mapa de batalla
Etapa: Backlog
Sistema Principal: Batalla
Fase: Batalla
orden: 57

### 🧭 **Tarea:** Bloquear reconquista de banderas por el defensor

**Descripción técnica detallada:**

Una vez que una bandera ha sido conquistada por el equipo atacante, esta debe quedar permanentemente en su poder durante el resto de la batalla. Aunque el defensor vuelva a ingresar al área de captura, **no debe poder revertir el control** ni interrumpir el estado actual. Esta lógica refuerza la presión estratégica y crea un avance permanente en favor del atacante, como parte del diseño de la Batalla de Feudo.

Visualmente, el estado de la bandera debe dejar en claro que ya ha sido tomada y no se puede interactuar con ella de nuevo.

---

### 🎮 **Funcionalidades requeridas:**

- Al capturar una bandera, su estado cambia a `CapturadaPorAtacante`.
- En ese estado:
    - Se desactiva la detección de unidades dentro del área de captura.
    - O, si se mantiene activa, ignora completamente a héroes defensores.
- Visualmente, debe cambiar a un modo “conquistada permanente”:
    - Color del equipo atacante (ej. azul o rojo).
    - Desactivación del marcador de progreso.
- Si un defensor entra a esa zona:
    - No ocurre ningún evento.
    - No se reinicia captura.
    - No aparece ningún indicador de progreso.

---

### ⚙️ **Requisitos técnicos**

- En `CapturePointController.cs`:
    - Añadir validación al trigger:
        
        ```csharp
        csharp
        CopiarEditar
        if (state == CapturadaPorAtacante)
            return; // ignorar entrada
        
        ```
        
    - Alternativamente, desactivar por completo el `Collider` si no se requiere visual activa.
- En `UpdateCaptureProgress()`:
    - Ignorar defensores en todo momento.
    - Si bandera ya está capturada, no continuar ejecución del tick.
- Visual:
    - Cambiar bandera o material a “bloqueada”.
    - Ocultar barra de captura.

---

### 🧪 **Criterios de aceptación**

- Una vez una bandera ha sido conquistada, el defensor no puede volver a capturarla.
- El sistema ignora cualquier intento de interacción del bando defensor.
- Visualmente se entiende que el punto está “cerrado”.
- No hay errores de reinicio ni duplicación de eventos.
- El comportamiento se mantiene consistente durante toda la partida.

# Botón “Continuar” para salir de resumen 216df9df71028011baede51b9659f4ad

# Botón “Continuar” para salir de resumen

Descripción: Al presionar, regresar automáticamente al Mapa de Feudo.
Prioridad: Alta
Etiquetas: Resultados, Retorno, UI
Etapa: Planeación
Sistema Principal: Mapas
Fase: Post Combate
orden: 62

### 🧭 **Tarea:** Botón “Continuar” para salir de resumen

**Descripción técnica detallada:**

Al finalizar una batalla, el jugador accede a una pantalla de resumen con estadísticas y resultados del combate. Esta interfaz debe incluir un botón “Continuar” visible y destacado, que permita cerrar el resumen y avanzar automáticamente al Mapa de Feudo. Este botón es el único punto de salida del resumen en el MVP y su interacción debe ser clara, inmediata y segura.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar botón “Continuar” en la interfaz de resultados de batalla.
- Detectar clic o activación de input sobre el botón.
- Llamar al sistema de transición para iniciar la carga del Mapa de Feudo.
- Desactivar o bloquear otras entradas durante la transición.
- (Opcional) reproducir un sonido o animación al presionar el botón.

---

### ⚙️ **Requisitos técnicos**

- Prefab `SummaryScreenUI` debe incluir un botón:
    - `continueButton.onClick.AddListener(HandleContinue);`
- Función `HandleContinue()` debe:
    - Guardar datos del resultado (si aplica).
    - Llamar a `GameFlowManager.GoToFeudo();` o equivalente.
    - Mostrar pantalla de carga si es necesario (`LoadingPanel.Show()`).
- El botón debe tener una prioridad visual en la jerarquía de la UI.
- Deshabilitar inputs del jugador mientras se realiza la transición.

---

### 🧪 **Criterios de aceptación**

- El botón se muestra correctamente en todos los tamaños de pantalla y resoluciones.
- Al hacer clic, la transición se realiza sin errores ni congelamientos.
- El jugador no puede activar el botón múltiples veces ni romper la lógica.
- La transición finaliza con el jugador activo en el Mapa de Feudo.
- No hay pérdida de progreso ni comportamiento inesperado.

# Botón “Continuar” y bloqueo de selección 216df9df71028188b713c698e38880a1

# Botón “Continuar” y bloqueo de selección

Descripción: Una vez confirmado, el jugador no puede cambiar opciones.
Prioridad: Media
Etiquetas: Batalla, UI
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md)
Bloqueando: Transición automática si no se presiona continuar a tiempo (Transicio%CC%81n%20automa%CC%81tica%20si%20no%20se%20presiona%20continua%20216df9df71028137ae7fe7b8775365e8.md)
Fase: Preparación de Combate
Subítem: Generar y almacenar escuadra seleccionada como SquadLoadout (Generar%20y%20almacenar%20escuadra%20seleccionada%20como%20Squ%20217df9df710280458480e1c6cb9c52df.md)
orden: 32

### 🧭 **Tarea:** Botón “Continuar” y bloqueo de selección

**Descripción técnica detallada:**

Durante la fase de preparación de batalla, el jugador realiza varias selecciones (tropas, punto de respawn, loadout). Una vez que presiona el botón “Continuar”, debe bloquearse su capacidad de modificar estas selecciones. El botón también notifica al sistema que el jugador está listo. Este mecanismo asegura sincronización con el resto del lobby hasta que todos confirmen o se acabe el tiempo.

---

### 🎮 **Funcionalidades requeridas:**

- Botón visible y habilitado solo si hay una configuración válida:
    - Al menos una unidad seleccionada.
    - Punto de respawn asignado.
- Al hacer clic en “Continuar”:
    - Se deshabilita el botón para evitar clics múltiples.
    - Se bloquea la edición de unidades, punto de spawn y loadout.
    - Se muestra un mensaje “Esperando a otros jugadores…”
    - Se emite un evento `OnPlayerReady()`.
- El sistema debe quedar a la espera de los demás jugadores o del timeout global.

---

### ⚙️ **Requisitos técnicos**

- Script `PreparationUIManager.cs` con:
    - Método `ValidateSelection()` → habilita/deshabilita botón.
    - Método `ConfirmSelection()` → guarda selección y bloquea inputs.
- UI bloqueada mediante:
    - Desactivación de paneles de selección.
    - `interactable = false` en botones y sliders.
- Almacenamiento local de configuración en `PlayerPreparationData`.
- Comunicación con `BattleLobbyManager` para sincronización de readiness.

---

### 🧪 **Criterios de aceptación**

- El jugador solo puede presionar “Continuar” con una selección válida.
- Tras confirmarlo, no puede modificar ninguna opción.
- El sistema muestra retroalimentación de que está esperando.
- La configuración se guarda correctamente.
- El botón no puede ser presionado múltiples veces.
- El jugador transiciona correctamente al inicio del combate una vez que todos están listos o el tiempo se agota.

# Botón “Entrar” para confirmar personaje seleccion 216df9df71028101adcaefbc3da79d52

# Botón “Entrar” para confirmar personaje seleccionado

Descripción: Permite continuar solo cuando hay un personaje válido seleccionado.
Prioridad: Media
Etiquetas: Personajes, UI
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Bloqueado por: Implementar pantalla de login (usuario y contraseña) (Implementar%20pantalla%20de%20login%20(usuario%20y%20contrasen%20216df9df710281ee9993f49d1070f145.md)
Fase: Login y Selección de Personaje
orden: 13

### 🧭 **Tarea:** Botón “Entrar” para confirmar personaje seleccionado

**Descripción técnica detallada:**

Una vez que el jugador ha elegido un personaje en la pantalla de selección, debe poder confirmar su elección mediante un botón claramente identificado como “Entrar”. Este botón debe permanecer desactivado mientras no haya selección válida, y al ser presionado, debe guardar el personaje como activo, cerrar la interfaz de selección y activar la transición hacia la pantalla de carga del Mapa de Feudo. Este botón es la única vía válida para avanzar al mundo de juego desde la selección de personajes.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar el botón “Entrar” en la interfaz de selección de personajes.
- Estado del botón:
    - Deshabilitado si no hay personaje seleccionado.
    - Habilitado al seleccionar un personaje válido.
- Al presionar:
    - Guardar personaje seleccionado en perfil activo (`ActiveHero`).
    - Llamar a la transición hacia la pantalla de carga del Feudo.
    - Deshabilitar el resto de la UI para evitar múltiples inputs.
    - Reproducir feedback visual (animación o sonido de confirmación).

---

### ⚙️ **Requisitos técnicos**

- Script `CharacterSelectionUI.cs`:
    - Propiedad: `selectedCharacter`
    - Método: `OnEnterPressed()`
        - `PlayerProfile.SetActiveHero(selectedCharacter)`
        - Llamar `FeudoLoader.LoadFeudo()`
- Validación:
    - Comprobar que el personaje no esté dañado, incompleto o bloqueado.
    - El botón debe estar desactivado (`interactable = false`) si no hay selección.
- Debe bloquear inputs adicionales hasta que la carga se inicie.

---

### 🧪 **Criterios de aceptación**

- El botón solo se activa con una selección válida.
- Al presionar, se inicia el flujo correcto de carga sin errores.
- El personaje elegido se guarda correctamente como el activo.
- No se permite spam de clics ni selección de personajes durante la transición.
- El botón tiene buen feedback visual y está alineado correctamente en la interfaz.

# Calcular daño y aplicar efectos 215df9df710280598a3ad31ea94d5b6e

# Calcular daño y aplicar efectos

Descripción: Procesar el daño al objetivo usando atributos ofensivos y defensivos por tipo, y disparar los efectos secundarios como reducción de vida, animaciones o muerte.
Prioridad: Alta
Etiquetas: Sistema de Combate, Técnica
Etapa: Por hacer
Sistema Principal: Control del Héroe
Fase: Mecánicas de Combate
ítem principal: Sistema de Combate (Sistema%20de%20Combate%20214df9df71028168a6bfd00b49d24c34.md)

### 🧭 **Tarea:** Calcular daño y aplicar efectos

**Descripción técnica detallada:**

Una vez detectado un impacto, este sistema se encarga de calcular el daño neto que recibirá el objetivo, aplicando fórmulas que consideren el tipo de daño infligido, la defensa correspondiente del objetivo, y la penetración específica del ataque. Además de modificar los puntos de vida, debe notificar efectos visuales, sonidos, y disparar eventos de muerte cuando corresponda.

---

### 🎮 **Funcionalidades requeridas:**

- Soporte para daño multi-componente (porcentajes de daño cortante, perforante y contundente).
- Consulta de defensa por tipo en el objetivo.
- Aplicación de penetración según el arma/habilidad del atacante.
- Suma del daño total tras aplicar mitigación.
- Modificación del `HealthComponent` del objetivo.
- Notificación de muerte si la vida alcanza 0 o menos.
- Disparo de evento `OnDamageReceived()` y `OnKilled()` si aplica.
- Opcional: generación de número flotante de daño o animación de impacto.

---

### ⚙️ **Requisitos técnicos**

- `HealthComponent` debe contener:
    - Vida máxima y actual.
    - Defensas por tipo (`defCortante`, `defPerforante`, `defContundente`).
- `DamageData` debe incluir:
    - Valor base de daño.
    - Distribución de daño por tipo (ej. `{cortante: 70, perforante: 30}`).
    - Penetraciones por tipo.
- Cálculo por componente de daño:
    
    ```
    dañoPorTipo = (dañoBase * porcentajeTipo) * (1 - defensaTipo/100) * (1 + penetraciónTipo/100)
    ```
    
- El daño total es la suma de todos los `dañoPorTipo`.
- Modularidad para añadir más tipos de daño o efectos futuros.

---

### 🧪 **Criterios de aceptación**

- El daño se aplica correctamente al impactar un objetivo vivo.
- Las defensas y penetraciones modifican el resultado de forma visible.
- El objetivo reduce su vida y se destruye si llega a 0.
- El evento de daño (`OnDamageReceived`) se puede suscribir desde sistemas externos (UI, audio, efectos).
- Se pueden ejecutar efectos visuales al recibir daño (opcional, configurables).
- El sistema puede extenderse a unidades IA y estructuras en el futuro.

# Cambiar formación en tiempo real por orden del ju 215df9df71028033935ff0f0c47b3b40

# Cambiar formación en tiempo real por orden del jugador

Descripción: Permitir que el jugador seleccione una formación táctica predefinida para su escuadra durante la partida; las posiciones son fijas y asignadas automáticamente.


Prioridad: Alta
Etiquetas: Formaciones, Gameplay, Gestión de Escuadra
Etapa: Backlog
Sistema Principal: Formaciones
Fase: Mecánicas de Combate
ítem principal: Implementar slots dinámicos para formaciones (Implementar%20slots%20dina%CC%81micos%20para%20formaciones%20214df9df7102817fbf5be4d9d6334072.md)

### 🧭 **Tarea:** Cambiar formación en tiempo real por orden del jugador

**Descripción técnica detallada:**

Implementar la lógica que permite al jugador seleccionar entre distintas formaciones tácticas predefinidas durante la partida, aplicándolas a su escuadra. Las posiciones dentro de la formación no son personalizables: cada unidad ocupa un slot asignado automáticamente según el diseño definido por los datos de la escuadra. En caso de bajas, las unidades supervivientes reordenan sus posiciones para mantener la estructura de la formación lo más íntegra posible, sin dejar huecos arbitrarios.

---

### 🎮 **Funcionalidades requeridas:**

- El jugador puede seleccionar una **formación táctica** predefinida en tiempo real:
    - Entrada por hotkeys (`F1`, `F2`, `F3`, etc.) o UI simple con botones.
    - Las formaciones disponibles dependen del tipo de unidad o escuadra.
- La formación seleccionada:
    - Proviene directamente de los datos de la escuadra (`FormationData`).
    - Define **slots fijos** (posición relativa al líder o centro).
- Cada unidad:
    - Es asignada automáticamente a un slot, sin intervención del jugador.
    - Se reposiciona dinámicamente al cambiar de formación.
- Si un miembro de la escuadra muere:
    - Las unidades restantes **reanidan** la formación ocupando los siguientes slots disponibles.
    - El orden de reubicación puede ser por índice, rol o proximidad.

---

### ⚙️ **Requisitos técnicos**

- `FormationData` por tipo de escuadra:
    - Definida en JSON o `ScriptableObject`.
    - Cada escuadra conoce de antemano sus formaciones válidas.
- Script `SquadController`:
    - Método `SetFormation(FormationData formation)` para aplicar nueva formación.
    - Método `ReassignSlots()` para reubicar unidades tras una baja.
- Mapeo fijo entre unidades y `FormationSlot` según orden lógico (índice de spawn o jerarquía).
- Transición suave entre formaciones:
    - `NavMeshAgent` se actualiza al nuevo slot sin frenar el flujo de combate.

---

### 🧪 **Criterios de aceptación**

- El jugador puede cambiar entre formaciones válidas para su escuadra en cualquier momento.
- Cada unidad se mueve automáticamente a su slot sin posibilidad de reordenamiento manual.
- Las formaciones solo pueden cambiarse por selección, no personalizarse.
- Al morir una unidad, las restantes reacomodan sus posiciones para preservar la estructura.
- No se permiten formaciones inválidas para el tipo de escuadra.
- El sistema es robusto ante cambios dinámicos de tamaño de escuadra y sigue operando sin errores.

# Colocar obstáculos básicos 214df9df71028123bf22d99d42dfe995

# Colocar obstáculos básicos

Descripción: Añadir elementos físicos simples como rocas, muros o árboles para limitar o condicionar el movimiento de unidades.
Prioridad: Media
Etiquetas: Diseño
Etapa: Por hacer
Sistema Principal: Terreno y Navegación
Bloqueado por: Crear terreno de prueba (250x250m) (Crear%20terreno%20de%20prueba%20(250x250m)%20214df9df7102819d85d8daf06673b3ec.md)
Bloqueando: Integrar con NavMesh (Integrar%20con%20NavMesh%20214df9df7102815f841ada1409e0313d.md)
Fase: Entrada y Presencia en Feudo
orden: 15

### 🧭 **Tarea:** Colocar obstáculos básicos

**Descripción técnica detallada:**

Diseñar y distribuir un conjunto mínimo de obstáculos en el terreno de prueba para simular condiciones de combate realista, bloquear rutas y probar comportamiento de navegación. Los obstáculos deben tener colisionadores adecuados, influir en el horneado del NavMesh y representar desafíos posicionales para escuadras e IA. Sirven como prueba funcional de interacción entre terreno, colisión y pathfinding.

---

### 🎮 **Funcionalidades requeridas:**

- Colocar al menos 3 tipos de obstáculos:
    - Muros bajos (para simular defensa o cobertura).
    - Rocas grandes (para bloquear paso y generar rutas alternativas).
    - Árboles u objetos verticales (para visibilidad, no colisión completa).
- Todos los obstáculos deben tener `Collider` activo.
- Algunos deben incluir `NavMeshObstacle` para afectar la navegación.
- Posicionamiento estratégico: centros, esquinas y rutas de borde del mapa.
- Agrupados lógicamente por zona para facilitar edición o eliminación.

---

### ⚙️ **Requisitos técnicos**

- Prefabs básicos de obstáculos en `/Prefabs/Environment/Obstacles/`.
- Uso de `BoxCollider`, `CapsuleCollider` o malla simplificada para colisión.
- Componentes de navegación (`NavMeshObstacle`) deben usar `Carve` si bloquean paso dinámicamente.
- Escala consistente con el entorno (no exagerado ni microobjetos).
- Organizados en la jerarquía bajo un GameObject padre: `ObstaclesRoot`.

---

### 🧪 **Criterios de aceptación**

- Las unidades no pueden atravesar los obstáculos al caminar.
- El NavMesh respeta los espacios ocupados (carved) por los obstáculos.
- Las colisiones físicas son naturales al contacto (no flotan ni atraviesan el terreno).
- Es posible modificar o mover los obstáculos fácilmente desde editor.
- Se pueden usar como referencia táctica en pruebas de formaciones o flanqueo.

# Comportamiento en formación rota o pérdida parci 217df9df710280079bbbc96e4189d73c

# Comportamiento en formación rota o pérdida parcial

Descripción: Reorganizar posiciones cuando hay bajas en la escuadra sin romper completamente la formación.
Etiquetas: Combate, Formaciones, Gestión de Escuadra, IA
Etapa: Backlog
Sistema Principal: Formaciones, Gestión de Escuadra
Fase: Batalla
ítem principal: Gestión de Escuadras (Órdenes Básicas) (Gestio%CC%81n%20de%20Escuadras%20(O%CC%81rdenes%20Ba%CC%81sicas)%20214df9df7102810bae94d0178b87ec78.md)

### 🧭 **Tarea:** Comportamiento en formación rota o pérdida parcial

**Descripción técnica detallada:**

Durante el combate, es común que unidades dentro de una escuadra mueran. Para mantener la coherencia táctica, la escuadra debe poder reorganizar automáticamente a sus miembros restantes para mantener la estructura de la formación lo más estable posible. Esto implica reasignar posiciones vacías, cerrar huecos, y reordenar a los sobrevivientes de forma fluida y sin interrupciones notables en el comportamiento general.

Este sistema no implica una reconfiguración total ni genera nuevas formaciones, sino que preserva la actual reorganizando a los miembros existentes.

---

### 🎮 **Funcionalidades requeridas:**

- Detectar cuando una unidad muere dentro de una escuadra.
- Marcar su posición de formación como “vacía”.
- Identificar al miembro más cercano y libre para ocupar ese espacio (según orden).
- Actualizar internamente el orden de slots ocupados sin romper la formación.
- Evitar animaciones o movimientos bruscos: transición debe ser suave.
- Mantener el mismo patrón de frente y dirección de formación.

---

### ⚙️ Requisitos técnicos

- Script `FormationManager.cs` o `SquadFormationHandler.cs`:
    - Contiene `List<FormationSlot>` con asignaciones actuales.
    - Método: `ReassignSlotsAfterLoss()`
- Cada unidad debe tener un `SlotID` dentro de la formación.
- Cuando una unidad muere:
    - Se libera su `SlotID`
    - Se identifica el miembro más próximo para cubrirlo, desplazando si es necesario.
- Opcional:
    - Si hay muchos huecos, se puede "cerrar filas" reduciendo columnas.

---

### 🧪 **Criterios de aceptación**

- Cuando una o más unidades mueren, el resto se reagrupa manteniendo la coherencia visual de la formación.
- El cambio de posiciones se realiza de forma fluida y sin glitches.
- El sistema no rompe la estructura general (ej: de línea a cuña).
- No se crean unidades nuevas ni se desorganiza completamente la escuadra.
- Si la escuadra queda con 1–2 miembros, mantienen una posición válida relativa al héroe o líder.

# Conectar cambios de equipo con visualización en 3 215df9df7102806bafe0f08656b617bc

# Conectar cambios de equipo con visualización en 3D

Descripción: Actualizar en tiempo real el modelo 3D del héroe para reflejar el equipamiento activo.
Prioridad: Alta
Etiquetas: Control del Héroe, UI
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

### 🧭 **Tarea:** Conectar cambios de equipo con visualización en 3D

**Descripción técnica detallada:**

Conectar el sistema de equipamiento con la representación visual del modelo del héroe en la interfaz. Cada vez que el jugador cambie de arma o armadura, el modelo debe actualizar sus piezas visuales, mostrando el objeto equipado con la malla y materiales correctos. Este sistema es esencial para asegurar que las elecciones del jugador tengan retroalimentación directa en la vista previa del personaje.

---

### 🎮 **Funcionalidades requeridas:**

- Cargar el modelo 3D del héroe en una posición fija del panel (`RenderTexture` o `WorldCanvas`).
- Equipar piezas visuales en tiempo real:
    - Cambiar malla de armadura (torso, piernas si aplica).
    - Cambiar malla o modelo del arma visible (en mano o espalda).
- Materiales o colores deben actualizarse con cada cambio.
- Visual coherente: el modelo debe mantener animación idle o pose de combate.
- Debe poder cambiar múltiples piezas sin conflictos de renderizado o jerarquía.
- Las piezas deben estar alineadas correctamente con el esqueleto.

---

### ⚙️ **Requisitos técnicos**

- Uso de sistema de slots visuales (`ArmorSlot`, `WeaponSlot`).
- Los objetos equipables deben tener referencias a sus meshes y materiales.
- Separación entre datos (`HeroEquipmentComponent`) y visual (`HeroVisualUpdater`).
- Prefabs de mallas almacenados por categoría en `/Models/Equipment/`.
- Modelo del héroe cargado en instancia independiente (no en gameplay directo).
- Cambio visual debe ejecutarse al seleccionar nuevo equipo desde UI.

---

### 🧪 **Criterios de aceptación**

- Al seleccionar una nueva arma o armadura, el cambio se refleja visualmente.
- El modelo se mantiene en una pose estable durante los cambios.
- No hay errores de renderizado, clipping o mal posicionamiento de piezas.
- Se pueden combinar diferentes piezas sin conflictos.
- El sistema está desacoplado del sistema de combate en tiempo real (solo aplica a visualización).

# Configuración del entorno de trabajo 214df9df710281a28347d34d216fdd5c

# Configuración del entorno de trabajo

Descripción: Establecer una configuración unificada de Unity y del entorno de desarrollo para todos los miembros del equipo, basada en la versión técnica oficial.
Prioridad: Alta
Etiquetas: Multiplayer, pasos iniciales
Etapa: En progreso
Sistema Principal: pasos iniciales
Bloqueando: Configurar repositorio Git (Configurar%20repositorio%20Git%20214df9df71028195939fc774e6593a5b.md)
Fase: Setup Técnico Inicial
orden: 1

### 🧭 **Tarea:** Configuración del entorno de trabajo

**Descripción técnica detallada:**

Establecer un entorno base común para todo el equipo de desarrollo, asegurando que todos trabajen con la **misma versión de Unity (2022.3.62f1)** y una estructura de proyecto coherente. Esto incluye configuración de capas y etiquetas, calidad visual, input, escena base y estructura de carpetas. También se debe validar que el entorno es funcional desde el primer clonado del repositorio.

---

### 🎮 **Funcionalidades requeridas:**

- Instalar y usar **Unity 2022.3.62f1** como versión estándar del proyecto.
- Carpeta base del proyecto Unity organizada:
    
    ```
    arduino
    CopiarEditar
    /Assets/
      ├── Art/
      ├── Audio/
      ├── Data/
      ├── Prefabs/
      ├── Scenes/
      ├── Scripts/
      ├── UI/
      └── Tests/
    
    ```
    
- Escena inicial `MainDevelopmentScene` con terreno básico y setup de prueba.
- Layers y Tags estandarizados:
    - `Units`, `Hero`, `Enemy`, `Ground`, `Obstacle`, `Interactable`, etc.
- Calidad visual y física:
    - Ajustes base de calidad (`QualitySettings`)
    - Time settings (`Fixed Timestep`, `Max Delta Time`)
    - Física básica para colisiones y navegación
- Configuración del sistema de input (`Input System`)
- Proyecto sincronizado con sistema de control de versiones (`Git + LFS`).

---

### ⚙️ **Requisitos técnicos**

- Confirmar que todos los miembros tienen instalada la versión 2022.3.62f1.
- Crear y mantener archivo `/Documentation/project-config.md` con:
    - Instrucciones para instalar Unity Hub y esta versión exacta.
    - Listado de paquetes instalados.
    - Convenciones de capas, etiquetas y carpetas.
- Verificar que la escena inicial se carga sin errores tras clonar el repo.
- Compartir plantilla `.editorconfig` o configuración de IDE recomendada (Rider, VS Code, etc.).

---

### 🧪 **Criterios de aceptación**

- Todos los miembros trabajan en Unity 2022.3.62f1 sin conflictos de versión.
- El proyecto se abre correctamente desde un clonado limpio.
- Las estructuras de carpetas, capas y escenas están sincronizadas.
- Existe documentación clara del entorno y se encuentra versionada.
- Se puede crear una nueva escena funcional siguiendo los estándares definidos.

# Configurar layers y tags del proyecto 214df9df710281cba959fa9e97a1b845

# Configurar layers y tags del proyecto

Descripción: 
Definir y registrar capas (Layers) y etiquetas (Tags) esenciales para el manejo de colisiones, navegación y filtrado de entidades en Unity.
Prioridad: Media
Etiquetas: Unity, pasos iniciales
Etapa: Por hacer
Sistema Principal: Gestión de Escuadra
Bloqueando: Construcción del escenario base (Construccio%CC%81n%20del%20escenario%20base%20214df9df710281ecbc1ffe683fff08be.md)
Fase: Setup Técnico Inicial
orden: 8

### 🧭 **Tarea:** Configurar layers y tags del proyecto

**Descripción corta:**

Definir y registrar capas (`Layers`) y etiquetas (`Tags`) esenciales para el manejo de colisiones, navegación y filtrado de entidades en Unity.

---

**Descripción técnica detallada:**

Establecer la configuración de `Tags` y `Layers` del proyecto Unity para garantizar un sistema de clasificación claro y funcional desde el inicio. Esto permitirá diferenciar entre el jugador, las unidades, el terreno, proyectiles, obstáculos, entre otros, tanto para lógica de gameplay como para colisiones, físicas y navegación. Es fundamental para el correcto funcionamiento de sistemas como la IA, las formaciones, el combate y las cámaras.

---

### 🎮 **Funcionalidades requeridas:**

- Crear y registrar las siguientes **Tags**:
    - `Player`
    - `Enemy`
    - `Unit`
    - `Projectile`
    - `Interactive`
    - `SpawnPoint`
- Crear y registrar las siguientes **Layers**:
    - `Player`
    - `Units`
    - `Terrain`
    - `Obstacles`
    - `VisionBlocker`
    - `UI`
    - `IgnoreRaycast` (si no existe ya)
- Asignar `Player` como tag por defecto al prefab del héroe.
- Asegurar que los colliders del terreno usen la capa `Terrain`.

---

### ⚙️ **Requisitos técnicos**

- Acceder a `Edit > Project Settings > Tags and Layers`.
- Crear nuevas entradas en slots vacíos para capas personalizadas (más allá de las 8 primeras que son reservadas).
- Verificar que ninguna capa importante sobrescriba capas internas de Unity.
- Documentar el uso previsto de cada Layer/Tag en el README técnico del proyecto.

---

### 🧪 **Criterios de aceptación**

- Todos los Tags y Layers listados están creados sin errores.
- El héroe y al menos una unidad están correctamente etiquetados.
- La capa `Terrain` está correctamente asignada al objeto del terreno.
- El sistema de colisiones puede filtrar entre capas (ej: `Player` no colisiona con `UI`).
- Scripts de movimiento, raycasts o cámaras reconocen correctamente los filtros por capa/tag.

# Configurar LFS en Git 214df9df710281e08865eb6744825797

# Configurar LFS en Git

Descripción: Configurar Git LFS (Large File Storage) para manejar archivos binarios y pesados del proyecto Unity, como modelos, texturas y sonidos.
Prioridad: Alta
Etiquetas: Técnica, pasos iniciales
Etapa: Backlog
Sistema Principal: Multiplayer
Fase: Setup Técnico Inicial
ítem principal: Configurar repositorio Git (Configurar%20repositorio%20Git%20214df9df71028195939fc774e6593a5b.md)

### 🧭 **Tarea:** Configurar LFS en Git

**Descripción técnica detallada:**

Git no está diseñado para manejar archivos binarios grandes como `.psd`, `.fbx`, `.png`, `.wav`, `.mp4` o `.unitypackage`, ya que los trata como texto y su rendimiento cae rápidamente. Git LFS permite almacenar estos archivos de manera más eficiente, subiéndolos a un sistema paralelo que mantiene el rendimiento del repositorio. Esta tarea asegura que el equipo pueda trabajar con assets pesados sin dañar la estructura del proyecto o sobrecargar el historial de versiones.

---

### 🎮 **Funcionalidades requeridas:**

- Instalar Git LFS localmente en las máquinas de cada desarrollador.
- Inicializar Git LFS en el repositorio del proyecto Unity.
- Registrar los tipos de archivo que deben ser gestionados por LFS.
- Confirmar que los commits de estos archivos son redirigidos al sistema LFS.
- Verificar que el repositorio funcione correctamente al clonar.

---

### ⚙️ **Requisitos técnicos**

1. **Instalar Git LFS**
    
    Ejecutar en terminal o línea de comandos:
    
    ```bash
    bash
    CopiarEditar
    git lfs install
    
    ```
    
2. **Inicializar LFS en el proyecto**
    
    Dentro del repositorio:
    
    ```bash
    bash
    CopiarEditar
    git lfs track "*.psd"
    git lfs track "*.fbx"
    git lfs track "*.png"
    git lfs track "*.wav"
    git lfs track "*.mp4"
    git lfs track "*.unitypackage"
    git lfs track "*.anim"
    git lfs track "*.mat"
    
    ```
    
3. **Verificar `.gitattributes`**
    
    Git creará o modificará automáticamente un archivo `.gitattributes` con reglas como:
    
    ```
    sql
    CopiarEditar
    *.fbx filter=lfs diff=lfs merge=lfs -text
    *.png filter=lfs diff=lfs merge=lfs -text
    
    ```
    
4. **Confirmar y subir cambios**
    
    ```bash
    bash
    CopiarEditar
    git add .gitattributes
    git commit -m "chore: configurar Git LFS para archivos grandes"
    git push origin main
    
    ```
    
5. **Validación**
    - Al clonar el proyecto, verificar que los archivos se descargan correctamente con:
        
        ```bash
        bash
        CopiarEditar
        git lfs pull
        
        ```
        

---

### 🧪 **Criterios de aceptación**

- Git LFS está habilitado en el proyecto y correctamente configurado.
- Los archivos pesados ya rastreados están versionados a través de LFS.
- Todos los miembros del equipo tienen Git LFS instalado y funcional.
- Al clonar el proyecto desde cero, no se pierden referencias a assets ni se rompen escenas.
- `.gitattributes` está versionado y refleja todos los tipos de archivo relevantes para Unity.

# Configurar NavMesh y horneado 214df9df7102811c88badd39043adaa7

# Configurar NavMesh y horneado

Descripción: Activar sistema de navegación y hornear el terreno para permitir desplazamiento de unidades e IA.
Prioridad: Alta
Etiquetas: IA, Unity
Etapa: Por hacer
Sistema Principal: Terreno y Navegación
Bloqueado por: Crear terreno de prueba (250x250m) (Crear%20terreno%20de%20prueba%20(250x250m)%20214df9df7102819d85d8daf06673b3ec.md), Integrar con NavMesh (Integrar%20con%20NavMesh%20214df9df7102815f841ada1409e0313d.md)
Fase: Entrada y Presencia en Feudo
orden: 17

### 🧭 **Tarea:** Configurar NavMesh y horneado

**Descripción técnica detallada:**

Preparar el entorno de navegación utilizando el sistema de NavMesh de Unity, habilitando a las unidades controladas por IA (y opcionalmente al jugador) para desplazarse por el terreno. Esto incluye definir las superficies navegables, ajustar los parámetros del agente de navegación, y hornear (bake) el NavMesh para reflejar el terreno y obstáculos. Es un prerrequisito para IA básica y sistemas de escuadra en movimiento.

---

### 🎮 **Funcionalidades requeridas:**

- Marcado del terreno como `Navigation Static` y tipo `Walkable`.
- Inclusión de obstáculos con `NavMeshObstacle` o `Not Walkable`.
- Uso de la ventana `Navigation` para hornear el NavMesh de la escena.
- Ajuste de parámetros de agente (altura, radio, paso, pendiente máxima).
- Inclusión opcional de zonas no navegables o límites de escena.
- Verificación visual del NavMesh generado en escena (`Bake > Show NavMesh`).

---

### ⚙️ **Requisitos técnicos**

- Uso del sistema de navegación incorporado de Unity (`AI.Navigation`).
- El terreno (`Terrain`) debe estar marcado como navegable.
- Obstáculos como muros, rocas o props deben estar definidos como "Not Walkable" o usar `NavMeshObstacle`.
- Agente de prueba (héroe o dummy) con componente `NavMeshAgent` funcional.
- Versión mínima compatible: Unity 2022.3.x con módulo de navegación activo.

---

### 🧪 **Criterios de aceptación**

- El NavMesh se genera correctamente sin huecos ni errores visibles.
- Las unidades con `NavMeshAgent` pueden desplazarse desde un punto A a B.
- El terreno y los obstáculos afectan la navegación como se espera.
- El sistema puede ser horneado sin errores desde editor o por script.
- El NavMesh se puede modificar y volver a hornear si cambian condiciones del mapa.
- El entorno está listo para uso por la IA de escuadras en pruebas.

# Configurar repositorio Git 214df9df71028195939fc774e6593a5b

# Configurar repositorio Git

Descripción: Inicializar y estructurar el repositorio Git del proyecto Unity con soporte para trabajo colaborativo, incluyendo LFS, .gitignore, ramas base y documentación.
Prioridad: Alta
Etiquetas: Gestión, Técnica, pasos iniciales
Etapa: En progreso
Sistema Principal: pasos iniciales
Bloqueado por: Configuración del entorno de trabajo (Configuracio%CC%81n%20del%20entorno%20de%20trabajo%20214df9df710281a28347d34d216fdd5c.md)
Fase: Setup Técnico Inicial
Subítem: Configurar LFS en Git (Configurar%20LFS%20en%20Git%20214df9df710281e08865eb6744825797.md)
orden: 5

### 🧭 **Tarea:** Configurar repositorio Git

**Descripción técnica detallada:**

Crear y estructurar correctamente el repositorio Git que se usará para el control de versiones del proyecto Unity. Este repositorio servirá como base para el flujo de trabajo del equipo, permitiendo colaboración ordenada, seguimiento de cambios y despliegue seguro. La configuración debe incluir manejo de archivos binarios (con Git LFS), definición de ramas estándar y documentación mínima para nuevos miembros.

---

### 🎮 **Funcionalidades requeridas:**

- Inicializar repositorio Git funcional y público/privado según necesidad.
- Definir estructura básica:
    - Rama principal `main`
    - Rama de integración `develop` (si aplica)
    - Ramas `feature/*`, `fix/*`, `hotfix/*`
- Incluir `.gitignore` específico para Unity (evitar `Library`, `Temp`, etc.)
- Configurar Git LFS (subtarea ya definida).
- Subir versión inicial del proyecto Unity con estructura base (sin librerías locales).
- Agregar archivo `README.md` explicativo.
- Documentar buenas prácticas de commits y flujos de trabajo (`CONTRIBUTING.md`, opcional).
- Validar que el repositorio puede clonarse sin errores y ejecutarse en Unity.

---

### ⚙️ **Requisitos técnicos**

- Estructura base de archivos al inicializar:
    
    ```
    /
    ├── .git/
    ├── .gitignore
    ├── .gitattributes
    ├── README.md
    ├── ProjectSettings/
    ├── Assets/
    ├── Packages/
    └── Docs/
    ```
    
- `.gitignore` basado en plantilla oficial Unity:
    - Ignorar: `Library/`, `Temp/`, `Logs/`, `Build/`, `.vsconfig`, `.vs/`, `obj/`
- Comandos de configuración mínima:
    
    ```bash
    git init
    git lfs install
    git lfs track "*.fbx" "*.psd" "*.png" "*.wav"
    git add .gitattributes
    git commit -m "Initial commit with LFS and Unity project structure"
    git remote add origin <repo-url>
    git push -u origin main
    ```
    
- Validar con un clon limpio en otra máquina.

---

### 🧪 **Criterios de aceptación**

- El repositorio está online y accesible por todos los miembros del equipo.
- Puede clonarse y abrirse en Unity 2022.3.62f1 sin errores.
- El proyecto tiene `.gitignore` y `.gitattributes` correctamente configurados.
- Los assets pesados se versionan por Git LFS sin problemas.
- Existe documentación mínima (`README.md`) que describe:
    - Cómo clonar el proyecto
    - Qué versión de Unity usar
    - Cómo configurar Git LFS
- El historial de commits inicial está limpio y bien estructurado.

# Construcción del escenario base 214df9df710281ecbc1ffe683fff08be

# Construcción del escenario base

Descripción: Crear terreno, navegación y entorno base para probar funcionalidades del prototipo.
Prioridad: Alta
Etiquetas: Terreno y Navegación, pasos iniciales
Etapa: Por hacer
Sistema Principal: Terreno y Navegación
Bloqueado por: Configurar layers y tags del proyecto (Configurar%20layers%20y%20tags%20del%20proyecto%20214df9df710281cba959fa9e97a1b845.md)
Bloqueando: Crear terreno de prueba (250x250m) (Crear%20terreno%20de%20prueba%20(250x250m)%20214df9df7102819d85d8daf06673b3ec.md)
Fase: Setup Técnico Inicial
Fecha: 24 de junio de 2025 → 26 de junio de 2025
orden: 9

# Crear bases de proyecto Unity 214df9df71028106a6c3d460834154ed

# Crear bases de proyecto Unity

Descripción: Consolidar todos los elementos iniciales del proyecto en Unity para habilitar el desarrollo de mecánicas y sistemas.
Prioridad: Alta
Etiquetas: Control del Héroe, pasos iniciales
Etapa: En progreso
Sistema Principal: pasos iniciales
Bloqueando: Crear estructura de carpetas del proyecto (Crear%20estructura%20de%20carpetas%20del%20proyecto%20214df9df7102817da309cbd241c7f806.md)
Fase: Setup Técnico Inicial
orden: 3

### 🧭 **Tarea:** Crear bases de proyecto Unity

**Descripción técnica detallada:**

Establecer el entorno base unificado para el desarrollo del juego en Unity. Esta tarea agrupa subtareas fundamentales como la creación del proyecto, instalación de paquetes esenciales, estructura de carpetas y configuración básica que será reutilizada por todos los sistemas del prototipo.

---

### 🎮 **Funcionalidades requeridas:**

- Proyecto de Unity funcional, guardado en control de versiones.
- Estructura de carpetas organizada por áreas de desarrollo (scripts, UI, arte, etc.).
- Paquetes base instalados: Input System, Cinemachine, TextMeshPro, Mirror.
- Tags y capas configuradas para entidades clave del juego: Player, Terrain, Enemy, Obstacle, Units.

---

### ⚙️ **Requisitos técnicos**

- Unity 2022.3 LTS o superior.
- Uso del nuevo sistema de entrada (`Input System Package`).
- Configuración compatible con URP o HDRP, según decisión de dirección artística.
- Proyecto subido a repositorio Git y compatible con Git LFS para assets pesados.

---

### 🧪 **Criterios de aceptación**

- El proyecto abre correctamente sin errores de compilación ni advertencias.
- Se pueden crear escenas nuevas y guardar prefabs sin conflictos.
- La navegación por carpetas es clara y permite escalabilidad modular.
- Todos los paquetes requeridos están listos para usar desde el Package Manager.
- La escena `MainScene` tiene un entorno mínimo: terreno plano, luz y cámara base.

# Crear documentación técnica básica del proyecto 215df9df710280e68cc8c26ad5d0830b

# Crear documentación técnica básica del proyecto

Descripción: Establecer los documentos fundamentales que describen la arquitectura, convenciones, sistemas y estructura del proyecto para uso interno del equipo.
Prioridad: Alta
Etiquetas: pasos iniciales
Etapa: En progreso
Sistema Principal: pasos iniciales
Fase: Documentación
orden: 0

### 🧭 **Tarea:** Crear documentación técnica básica del proyecto

**Descripción técnica detallada:**

Desarrollar y mantener un conjunto inicial de archivos de documentación técnica que detallen los aspectos más importantes del proyecto. Esto incluye la arquitectura general de sistemas, convenciones de codificación, estructura de carpetas, descripciones de módulos principales, flujo de escenas y procesos de integración. Esta documentación servirá como punto de entrada para nuevos miembros del equipo y como referencia viva para evitar malentendidos técnicos durante el desarrollo.

---

### 🎮 **Contenido requerido:**

### 📁 Estructura de archivos sugerida:

- `/Docs/`
    - `README.md` – Visión general del proyecto + instrucciones de instalación y ejecución.
    - `architecture.md` – Mapa general de sistemas y dependencias clave.
    - `coding_conventions.md` – Guía de estilo para C#, nombres de clases, prefabs, carpetas.
    - `workflow.md` – Flujo de trabajo colaborativo, ramas, commits, pull requests.
    - `scene_structure.md` – Escenas clave del proyecto, propósito y responsables.
    - `module_guides/` – Subcarpeta con documentación por sistema (combate, escuadras, UI, etc.).
    - `GDD/` - Subcarpeta con toda la definicion de los sistemas desde el punto de vista de diseño

---

### ⚙️ **Requisitos técnicos**

- Archivos Markdown editables y versionados en Git.
- Redacción clara, en lenguaje técnico accesible y uniforme.
- Estructura modular para permitir crecimiento de la documentación.
- Organización reflejada dentro del proyecto Unity (carpetas espejo si aplica).
- Debe ser revisado por al menos otro miembro del equipo antes de oficializar.

---

### 🧪 **Criterios de aceptación**

- Existe una carpeta `/Docs/` en el proyecto con archivos iniciales.
- Toda persona nueva en el equipo puede comprender la base del proyecto al leerlos.
- La documentación describe correctamente:
    - Cómo correr el proyecto.
    - Qué sistema hace qué.
    - Cómo extender funcionalidades sin romper estructura base.
- La documentación se mantiene bajo control de versiones y se actualiza cuando un sistema clave cambia.
- No existen contradicciones entre la documentación y la implementación actual.

# Crear estructura de carpetas del proyecto 214df9df7102817da309cbd241c7f806

# Crear estructura de carpetas del proyecto

Descripción: Organizar carpetas: /Scripts, /Prefabs, /Scenes, /Art, /UI, /Animations, etc.
Prioridad: Alta
Etiquetas: Técnica, pasos iniciales
Etapa: En progreso
Sistema Principal: pasos iniciales
Bloqueado por: Crear bases de proyecto Unity (Crear%20bases%20de%20proyecto%20Unity%20214df9df71028106a6c3d460834154ed.md)
Bloqueando: Crear proyecto Unity (2022.3 LTS) (Crear%20proyecto%20Unity%20(2022%203%20LTS)%20214df9df710281e1a4b1d1893842a462.md)
Fase: Setup Técnico Inicial
orden: 4

### 🧭 **Tarea:** Crear estructura de carpetas del proyecto

**Descripción técnica detallada:**

Diseñar e implementar una jerarquía coherente de carpetas dentro del proyecto Unity, siguiendo estándares de escalabilidad y colaboración multirol (programadores, artistas, diseñadores).

---

### 🎮 **Funcionalidades requeridas:**

- Separación clara de assets por tipo y propósito.
- Inclusión de carpetas base: `/Scripts`, `/Prefabs`, `/Art`, `/UI`, `/Scenes`, `/Animations`, `/Audio`, `/Materials`, `/Editor`.

---

### ⚙️ **Requisitos técnicos**

- Estructura debe permitir aislar cambios por módulo/sistema.
- Nomenclatura clara en inglés (ej. `Characters`, `Props`, `Abilities`).
- Compatible con integraciones externas (git, CI/CD si aplica).

---

### 🧪 **Criterios de aceptación**

- Toda nueva funcionalidad o asset puede ser categorizado en una carpeta existente.
- No hay redundancia ni nombres ambiguos.
- El equipo de desarrollo puede trabajar en paralelo en distintos directorios sin conflicto.

---

# Crear estructura de escuadra base (clase y prefab) 214df9df7102818e9484eacdeab50adb

# Crear estructura de escuadra base (clase y prefab)

Descripción: Diseñar la estructura lógica y el prefab de una escuadra funcional, lista para recibir órdenes, moverse y formar parte de un despliegue táctico.
Prioridad: Alta
Etiquetas: Gestión de Escuadra, Unity
Etapa: Por hacer
Sistema Principal: Gestión de Escuadra
Bloqueando:  Vincular escuadra al héroe jugador (Vincular%20escuadra%20al%20he%CC%81roe%20jugador%20214df9df7102817db0e9c135014e9e91.md)
Fase: Mecánicas de Combate
orden: 41

### 🧭 **Tarea:** Crear estructura de escuadra base (clase y prefab)

**Descripción técnica detallada:**

Construir el modelo base de una escuadra que pueda ser instanciado, vinculado a un héroe y controlado mediante órdenes básicas. La estructura incluye la lógica de agrupamiento, la definición de líder/miembros, la navegación conjunta y los puntos de formación o posición relativa. Este prefab será la base reutilizable para todas las escuadras jugables y de IA en el sistema.

---

### 🎮 **Funcionalidades requeridas:**

- Prefab raíz de escuadra con:
    - GameObject padre `SquadRoot`.
    - Referencias a unidades miembro (`Unit1`, `Unit2`, etc.).
    - Posiciones relativas o puntos de formación (`FormationSlot_1`, ...).
- Script `SquadController.cs`:
    - Contiene lista de miembros.
    - Maneja órdenes externas (`Follow`, `Hold`, `Attack`).
    - Gestiona asignación de líder.
- Cada unidad debe:
    - Tener componente `UnitAIController`.
    - Tener `NavMeshAgent` activado.
    - Saber a qué escuadra pertenece.
- El prefab debe poder ser instanciado desde código o cargado desde selección de tropas (`loadout`).

---

### ⚙️ **Requisitos técnicos**

- Carpeta: `/Prefabs/Squads/BaseSquad.prefab`
- Estructura mínima:
    
    ```
    SquadRoot
    ├── Unit_01 (Prefab de tropa)
    ├── Unit_02
    ├── FormationSlot_1 (Empty)
    ├── FormationSlot_2 (Empty)
    └── SquadController.cs
    ```
    
- `SquadController` debe exponer:
    
    ```csharp
    public void AssignLeader(Transform hero);
    public void ReceiveOrder(SquadOrderType order);
    public List<UnitAIController> Members;
    ```
    
- Lógica interna para que las unidades se alineen con sus slots de formación (para MVP puede ser estática).
- Validación de estados (`Idle`, `Moving`, `Engaging`) por unidad.

---

### 🧪 **Criterios de aceptación**

- El prefab puede ser instanciado sin errores en escena.
- Todas las unidades están referenciadas y listas para recibir comandos.
- El sistema puede recibir una orden y todas las unidades responden sincronizadamente.
- El prefab está desacoplado del héroe (puede vincularse dinámicamente).
- Puede usarse como base para escuadras de distintos tipos (melee, arqueros, etc.).

# Crear pantalla de selección de personajes 216df9df71028105b63dc4b84af9efc9

# Crear pantalla de selección de personajes

Descripción: UI para visualizar, crear y elegir personajes existentes del usuario.
Prioridad: Alta
Etiquetas: Personajes, UI, Usuario
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md)
Fase: Login y Selección de Personaje
orden: 11

### 🧭 **Tarea:** Crear pantalla de selección de personajes

**Descripción técnica detallada:**

La pantalla de selección de personajes es el primer punto de entrada al mundo del juego. Debe mostrar los personajes creados por el jugador, permitir seleccionar uno para jugar, y ofrecer la opción de crear un nuevo personaje. Esta interfaz es crítica, ya que determina qué perfil se utilizará durante toda la sesión, y debe conectarse con el sistema de visualización en 3D, botón de entrada al juego y almacenamiento del perfil activo.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar una lista de personajes disponibles:
    - Cada uno como card visual (nombre, nivel, clase, ícono o miniatura).
    - Opción para seleccionar (resalta visualmente).
- Mostrar botón “Crear nuevo personaje” si el límite no se ha alcanzado.
- Mostrar panel de visualización 3D con equipo y skin del personaje seleccionado.
- Mostrar botón “Entrar” solo si hay un personaje válido seleccionado.
- Validar selección activa y guardar como perfil para sesión actual.

---

### ⚙️ **Requisitos técnicos**

- Prefab de UI principal: `CharacterSelectionScreenUI`
    - Contiene:
        - `CharacterListPanel` con scroll o paginación.
        - `CreateCharacterButton`
        - `EnterGameButton` (deshabilitado por defecto).
        - `HeroViewerUI` para renderizado 3D.
- Script: `CharacterSelectionManager.cs`
    - Carga personajes desde `PlayerProfile.Characters`
    - Llama `SetActiveHero()` al confirmar selección.
- Prefabs individuales: `CharacterCardUI`
- Debe prevenir selección de personajes dañados o bloqueados.
- Integración con `FeudoLoader` para iniciar carga tras confirmar.

---

### 🧪 **Criterios de aceptación**

- Todos los personajes del jugador aparecen correctamente listados.
- Al hacer clic en uno, este se selecciona visual y lógicamente.
- El botón “Entrar” se activa solo si hay un personaje válido seleccionado.
- El jugador puede visualizar en 3D el personaje activo.
- La transición a Feudo se realiza desde esta pantalla al confirmar.
- La experiencia visual es clara, fluida y sin bugs de selección múltiple.

# Crear prefab base del héroe 214df9df7102816db180fa4dc3173155

# Crear prefab base del héroe

Descripción: Modelo placeholder con Collider, Rigidbody y Animator.
Prioridad: Alta
Etiquetas: Unity, pasos iniciales
Etapa: En progreso
Sistema Principal: Control del Héroe
Bloqueando: Implementar controlador de cámara del héroe (Implementar%20controlador%20de%20ca%CC%81mara%20del%20he%CC%81roe%20214df9df7102819e97d6fd1375f01854.md),  Vincular escuadra al héroe jugador (Vincular%20escuadra%20al%20he%CC%81roe%20jugador%20214df9df7102817db0e9c135014e9e91.md), Sistema de Combate (Sistema%20de%20Combate%20214df9df71028168a6bfd00b49d24c34.md), Implementar detección de impacto (raycast o hitbox) (Implementar%20deteccio%CC%81n%20de%20impacto%20(raycast%20o%20hitbo%20214df9df7102816090f9c5fd43a0e534.md), Sistema de Perks y Talentos (Sistema%20de%20Perks%20y%20Talentos%20214df9df710281ce965ffbc441d224d1.md), Crear pantalla de selección de personajes (Crear%20pantalla%20de%20seleccio%CC%81n%20de%20personajes%20216df9df71028105b63dc4b84af9efc9.md), Visualizar personaje en 3D con equipo y skin (Visualizar%20personaje%20en%203D%20con%20equipo%20y%20skin%20216df9df710281c4a592c8a006b97f08.md)
Fase: Configurar Personaje y Unidades
orden: 20

### 🧭 **Tarea:** Crear prefab base del héroe

**Descripción técnica detallada:**

Diseñar y construir un prefab funcional del héroe controlable que sirva como punto de partida para implementar todas las mecánicas de jugador: movimiento, animaciones, habilidades y vinculación con escuadras. Este prefab debe ser reutilizable, modular y apto para pruebas de navegación, combate y órdenes tácticas.

---

### 🎮 **Funcionalidades requeridas:**

- GameObject principal con jerarquía limpia: raíz + cuerpo + collider + animator.
- Componente `Rigidbody` configurado para física básica (con restricciones de rotación si aplica).
- Collider de tipo cápsula o box collider en tamaño humano.
- Animator Controller vacío pero referenciado para futura vinculación de animaciones.
- Asignación de layer `Player` y tag `Player`.
- Placeholder visual (capsule o modelo simple) para pruebas iniciales.
- Espacio para futura vinculación de cámaras, escuadra y UI.

---

### ⚙️ **Requisitos técnicos**

- Prefab guardado en la carpeta `/Prefabs/Characters/Hero`.
- Nomenclatura estandarizada: `HeroBase.prefab`.
- Compatible con scripts de movimiento y habilidades.
- Pivot central correctamente alineado para navegación y transformaciones.
- Sin referencias rotas ni dependencias externas no validadas.

---

### 🧪 **Criterios de aceptación**

- El prefab se puede instanciar desde la escena `MainScene` sin errores.
- El prefab responde correctamente al input de movimiento (una vez vinculado).
- El prefab se puede mover sobre NavMesh si se agrega NavMeshAgent.
- Todos los componentes clave están organizados, referenciados y nombrados correctamente.
- Está listo para recibir animaciones, scripts de control, cámaras y otras extensiones.

# Crear prefab de pantalla de resultados 216df9df710280e1a154e1b67b1628f4

# Crear prefab de pantalla de resultados

Descripción: Construir la interfaz en Unity como un prefab reutilizable basado en el layout diseñado.
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Crear prefab de pantalla de resultados

**Descripción técnica detallada:**

Tomar el diseño visual aprobado y convertirlo en un prefab de Unity, usando sistema de UI (Canvas, Layout Groups, etc.). Esta pantalla será cargada al finalizar la batalla.

---

### 🎮 Funcionalidades requeridas:

- Canvas a pantalla completa
- Elementos UI: Textos, Imágenes, Scroll, Botón
- Anidado por secciones (héroe, unidades, controles)

---

### ⚙️ Requisitos técnicos:

- Prefab ubicado en `/Prefabs/UI/Results/`
- Escalable con `Canvas Scaler` y `AspectRatioFitter`
- Soporte para múltiples resoluciones

---

### 🧪 Criterios de aceptación:

- Prefab se carga correctamente desde escena
- Todos los elementos están organizados y alineados
- Se adapta a pantallas 16:9 y 21:9

# Crear proyecto Unity (2022 3 LTS) 214df9df710281e1a4b1d1893842a462

# Crear proyecto Unity (2022.3 LTS)

Descripción: Crear y subir base Unity con render pipeline definido (URP/HDRP).
Prioridad: Alta
Etiquetas: Técnica, Unity, pasos iniciales
Etapa: En progreso
Sistema Principal: pasos iniciales
Bloqueado por: Crear estructura de carpetas del proyecto (Crear%20estructura%20de%20carpetas%20del%20proyecto%20214df9df7102817da309cbd241c7f806.md)
Bloqueando: Instalar paquetes esenciales (Instalar%20paquetes%20esenciales%20214df9df7102818d9303dbfc770fd502.md)
Fase: Setup Técnico Inicial
orden: 2

### 🧭 **Tarea:** Crear proyecto Unity (2022.3 LTS)

**Descripción técnica detallada:**

Inicializar el proyecto principal de Conquest Tactics con Unity 2022.3 LTS, asegurando que las configuraciones gráficas, de entrada y físicas están optimizadas para producción y soporte a largo plazo.

---

### 🎮 **Funcionalidades requeridas:**

- Proyecto vacío funcional con escena principal (`MainScene`).
- Pipeline gráfico definido (URP o HDRP).
- Configuración base aplicada: resolución, physics layers, quality settings.
- Compatible con el nuevo sistema de input.

---

### ⚙️ **Requisitos técnicos**

- Versión recomendada: Unity 2022.3.x LTS.
- Plataforma objetivo: PC (Windows, con vistas a multiplataforma).
- El proyecto debe integrarse con Git y Git LFS.
- Configuración para trabajar en modo 3D.

---

### 🧪 **Criterios de aceptación**

- El proyecto compila y se ejecuta correctamente en Unity.
- Tiene una escena funcional que puede guardarse y testearse.
- Se encuentra listo para comenzar implementación de sistemas de gameplay.

# Crear terreno de prueba (250x250m) 214df9df7102819d85d8daf06673b3ec

# Crear terreno de prueba (250x250m)

Descripción: Construir plano o mesh de terreno básico navegable.
Prioridad: Alta
Etiquetas: Diseño, Unity, pasos iniciales
Etapa: Por hacer
Sistema Principal: Terreno y Navegación
Bloqueado por: Construcción del escenario base (Construccio%CC%81n%20del%20escenario%20base%20214df9df710281ecbc1ffe683fff08be.md)
Bloqueando: Configurar NavMesh y horneado (Configurar%20NavMesh%20y%20horneado%20214df9df7102811c88badd39043adaa7.md), Agregar puntos de referencia (spawn, zonas) (Agregar%20puntos%20de%20referencia%20(spawn,%20zonas)%20214df9df7102815ba355e0a0f32687cd.md), Colocar obstáculos básicos (Colocar%20obsta%CC%81culos%20ba%CC%81sicos%20214df9df71028123bf22d99d42dfe995.md), Diseñar layout base del Mapa de Batalla de Feudo (Disen%CC%83ar%20layout%20base%20del%20Mapa%20de%20Batalla%20de%20Feudo%20216df9df7102803f8cfee8d9d0d48f52.md)
Fase: Entrada y Presencia en Feudo
orden: 14

### 🧭 **Tarea:** Crear terreno de prueba (250x250m)

**Descripción técnica detallada:**

Construir un entorno de terreno básico en Unity que sirva como espacio funcional para probar los sistemas de navegación, movimiento del héroe, formación de escuadras y combates iniciales. Este terreno debe tener las dimensiones y condiciones necesarias para simular una partida en escala reducida, con espacio para desplazamiento, obstáculos y zonas de referencia.

---

### 🎮 **Funcionalidades requeridas:**

- Creación de un `Terrain` de tamaño 250x250 metros (Unity units).
- Aplicación de textura base (grass o tierra) para visibilidad.
- Ajuste de resolución del terreno para rendimiento.
- Configuración de colisiones para ser navegable por héroes y escuadras.
- Inclusión de detalles mínimos opcionales: elevación simple, zona plana central, espacio de prueba despejado.

---

### ⚙️ **Requisitos técnicos**

- Usar el sistema de `Terrain` de Unity (no plano 3D tradicional).
- Terreno guardado dentro de `/Scenes` como parte de `MainScene` o escena auxiliar (`TestTerrainScene`).
- Compatible con `NavMesh` para horneado de navegación.
- Sin árboles ni detalles pesados en esta fase.
- Sin iluminación adicional compleja.

---

### 🧪 **Criterios de aceptación**

- El terreno aparece correctamente en escena sin errores.
- El jugador puede colocar el prefab del héroe y moverse sobre su superficie.
- Es posible hornear un NavMesh funcional sobre este terreno.
- El terreno se encuentra en proporción con los personajes y escuadras (escala 1:1).
- Tiene suficiente espacio despejado para probar formaciones y combate a pequeña escala.

# Crear UI de entrada a batalla 215df9df71028061a527d08c625790bf

# Crear UI de entrada a batalla

Descripción: Interfaz previa al combate donde el jugador selecciona las **tropas** (plantillas `Troop`) y el arma que llevará a la partida, respetando su límite de liderazgo por escuadras.
Prioridad: Alta
Etiquetas: Preparación, UI
Etapa: Backlog
Sistema Principal: Barracón
Bloqueando: Guardar selección como loadout (Guardar%20seleccio%CC%81n%20como%20loadout%20214df9df7102817d8763c03c6a84caf2.md), Mostrar botón de “Batalla” (mini castillo) en HUD (Mostrar%20boto%CC%81n%20de%20%E2%80%9CBatalla%E2%80%9D%20(mini%20castillo)%20en%20HUD%20216df9df710281308ad4f6437e24712d.md), Mostrar interfaz de preparación de batalla (pantalla completa) (Mostrar%20interfaz%20de%20preparacio%CC%81n%20de%20batalla%20(panta%20216df9df710281fc8693ed3e6a0fb537.md), Botón “Continuar” y bloqueo de selección (Boto%CC%81n%20%E2%80%9CContinuar%E2%80%9D%20y%20bloqueo%20de%20seleccio%CC%81n%20216df9df71028188b713c698e38880a1.md), Transición automática si no se presiona continuar a tiempo (Transicio%CC%81n%20automa%CC%81tica%20si%20no%20se%20presiona%20continua%20216df9df71028137ae7fe7b8775365e8.md), Transición de fase preparación a combate (Transicio%CC%81n%20de%20fase%20preparacio%CC%81n%20a%20combate%20216df9df7102801da210cc64064ff1b8.md), Activar fase previa de preparación (3 minutos) (Activar%20fase%20previa%20de%20preparacio%CC%81n%20(3%20minutos)%20216df9df710280448e18da3cf76d68ff.md)
Fase: Preparación de Combate
orden: 26

### 🧭 **Tarea:** Crear UI de entrada a batalla

**Descripción técnica detallada:**

Diseñar una interfaz funcional y clara que permita al jugador configurar su despliegue táctico justo antes de entrar en partida. Esta interfaz debe mostrar todas las unidades disponibles (ya desbloqueadas), permitir armar un grupo manualmente respetando el límite de liderazgo, o cargar un loadout guardado previamente en el barracón. Además, el jugador debe poder seleccionar entre las armas disponibles para su héroe, ya sea por preferencia o estrategia.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar todas las unidades **disponibles del jugador**:
    - Icono, nombre, tipo, rareza, coste de liderazgo por escuadra.
- Permitir **selección manual de tropas**, validando en tiempo real el total de liderazgo.
- Mostrar **barra de liderazgo restante** (ej. “Liderazgo: 5/10”).
- Botón para cargar un **loadout guardado** desde el barracón (si aplica).
- Lista de **armas disponibles para el héroe**:
    - Mostrar nombre, ícono y tipo (espada, arco, guja, etc.).
    - Permitir elegir solo una como arma activa.
- Botón “Confirmar” que inicia la partida si la selección es válida.
- Botón “Cancelar / Volver al Barracón” que regresa a la interfaz de gestión.
- Indicadores de error o advertencia:
    - Liderazgo excedido.
    - Ninguna tropa seleccionada.
    - Ninguna arma seleccionada.

---

### ⚙️ **Requisitos técnicos**

- Prefab `BattleEntryPanel` dentro de `/UI/Battle/`.
- Script controlador: `BattleEntryUIController.cs`.
- Interacción con:
    - `BarracksManager` para consultar unidades desbloqueadas.
    - `LoadoutManager` para cargar configuraciones guardadas.
    - `HeroInventory` o equivalente para lista de armas disponibles.
- Debe guardar:
    - Lista de **tropas** seleccionadas para despliegue.
    - Arma activa seleccionada del héroe.
- Validaciones en tiempo real antes de habilitar el botón "Confirmar".

---

### 🧪 **Criterios de aceptación**

 - El jugador puede seleccionar **tropas** hasta agotar su liderazgo sin pasarse.
 - Puede alternar entre elegir **tropas** manualmente o cargar un loadout.
- Puede elegir un arma válida para el héroe.
- Si la selección es válida, el botón “Confirmar” permite avanzar a partida.
- Si hay errores (sin tropas, sin arma, liderazgo excedido), se muestra retroalimentación clara.
- La configuración seleccionada se transfiere correctamente a la escena de combate.

# Crear UI de Stats del heroe 214df9df710281d8b145d7c68a9e1e63

# Crear UI de Stats del heroe

Descripción: Interfaz para visualizar y modificar atributos, equipamiento y aspecto del héroe, con vista previa en tiempo real.
Prioridad: Media
Etiquetas: Control del Héroe, UI
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
Subítem: Diseñar layout de interfaz de estadísticas del héroe (Disen%CC%83ar%20layout%20de%20interfaz%20de%20estadi%CC%81sticas%20del%20h%20215df9df71028022964ae194517d6134.md), Implementar visualización y edición de stats (Implementar%20visualizacio%CC%81n%20y%20edicio%CC%81n%20de%20stats%20215df9df710280d0bfc3d601a3f3a02a.md), Mostrar equipamiento actual y lista de objetos disponibles (Mostrar%20equipamiento%20actual%20y%20lista%20de%20objetos%20dis%20215df9df71028048b164c92244a678ad.md), Conectar cambios de equipo con visualización en 3D (Conectar%20cambios%20de%20equipo%20con%20visualizacio%CC%81n%20en%203%20215df9df7102806bafe0f08656b617bc.md), Integrar sistema de skins y selector de apariencia (Integrar%20sistema%20de%20skins%20y%20selector%20de%20apariencia%20215df9df710280099dbcdb7c694e87fa.md), Implementar viewer 3D del héroe en la interfaz (Implementar%20viewer%203D%20del%20he%CC%81roe%20en%20la%20interfaz%20215df9df710280fa8ae0c9a5ef1a7a8d.md), Guardar y aplicar los cambios al perfil del jugador (Guardar%20y%20aplicar%20los%20cambios%20al%20perfil%20del%20jugado%20215df9df710280bfbb8ecc54ef9c74cd.md)
orden: 22

### 🧭 **Tarea:** Crear UI de Stats del héroe

**Descripción técnica detallada:**

Desarrollar una interfaz integrada donde el jugador pueda ver y editar las estadísticas principales del héroe, cambiar su equipamiento y aplicar skins cosméticas. Esta interfaz debe también mostrar en tiempo real el modelo del héroe con las armas, armaduras y aspecto visual aplicados. La UI permite al jugador modificar atributos si tiene puntos disponibles (según su nivel o sistema de perks) y cambiar entre objetos desbloqueados.

---

### 🎮 **Funcionalidades requeridas:**

### 📊 Visualización y edición de stats

- Mostrar atributos base y derivados del héroe:
    - Fuerza, Destreza, Vitalidad, Armadura.
    - Vida total, Daño por tipo (cortante, perforante, contundente).
    - Liderazgo total y usado.
- Permitir modificar los stats si el jugador tiene puntos disponibles.
- Mostrar botones para asignar puntos a cada atributo (sólo si hay disponibles).

### 🛡️ Gestión de equipamiento

- Mostrar equipamiento actual:
    - Arma principal, armadura, accesorio (si aplica).
- Mostrar lista de objetos disponibles por tipo.
- Permitir hacer clic en un objeto disponible y equiparlo instantáneamente.

### 🎨 Cambio de skins

- Mostrar las skins desbloqueadas del jugador.
- Aplicar skin seleccionada visualmente al modelo del héroe.
- Las skins deben ser sólo cosméticas, sin modificar stats.

### 🧍 Vista previa en 3D

- Mostrar modelo 3D del héroe con todo lo que tiene equipado.
- Reflejar en tiempo real cambios de armadura, arma y skin.
- Rotación de cámara libre en el viewer (mouse arrastrable o botones).

---

### ⚙️ **Requisitos técnicos**

- Prefab: `HeroStatsPanel` ubicado en `/UI/Hero/`.
- Scripts: `HeroStatsUIController.cs`, `HeroEquipmentDisplay.cs`.
- Acceso a:
    - `HeroData`: atributos actuales y puntos disponibles.
    - `InventoryManager`: lista de objetos desbloqueados.
    - `SkinManager` (o equivalente): para cosméticos disponibles.
- Viewer 3D embebido:
    - Prefab del héroe cargado en tiempo real.
    - Cámara rotatoria o ángulo ajustable.
- Cambios aplicados deben persistir al cerrar la UI.

---

### 🧪 **Criterios de aceptación**

- El jugador puede ver todos los stats del héroe y sus modificadores.
- Puede asignar puntos de atributo si tiene disponibles.
- Puede cambiar entre armas y armaduras disponibles.
- Puede aplicar skins y ver el cambio reflejado de inmediato en el modelo.
- El modelo 3D del héroe se muestra con rotación libre o fija.
- Cambios aplicados se guardan y se mantienen entre sesiones.
- La interfaz es clara, funcional y no se superpone con otras secciones del HUD.

# Curación progresiva dentro del rango del Supply P 217df9df7102805794dafefcb6b5fc1d

# Curación progresiva dentro del rango del Supply Point

Descripción: Regenerar lentamente la salud del héroe y su escuadra mientras estén en un Supply Point aliado.
Prioridad: Media
Etiquetas: Gestión de Escuadra, Mapa de batalla, Supply
Etapa: Backlog
Sistema Principal: Mapas
Fase: Batalla
ítem principal: Sistema de Supply Points con control territorial (Sistema%20de%20Supply%20Points%20con%20control%20territorial%20217df9df710280748412c06ee0ecfc6e.md)

### 🧭 **Tarea:** Curación progresiva dentro del rango del Supply Point

**Descripción técnica detallada:**

Cuando el héroe del jugador se encuentra dentro del área de un Supply Point aliado, tanto él como su escuadra activa deben recibir curación progresiva a lo largo del tiempo. Esta regeneración ocurre mientras se mantenga dentro del rango del punto y solo si pertenece al mismo bando. La curación se aplica en intervalos regulares ("ticks") y debe estar acompañada de una retroalimentación visual sutil para reforzar la mecánica sin distraer al jugador.

---

### 🎮 **Funcionalidades requeridas:**

- Detectar al jugador y su escuadra dentro del rango del Supply Point aliado.
- Iniciar un ciclo de curación mientras se mantengan en el área:
    - Héroe: +X HP cada Y segundos.
    - Cada unidad viva de la escuadra: +X HP cada Y segundos.
- Mostrar visual de regeneración:
    - Efecto en el Supply Point (brillo, anillo pulsante).
    - Efecto leve sobre las unidades curadas (resplandor, partículas).
- Interrumpir el proceso al salir del área.
- No aplicar curación si el Supply Point es enemigo o neutral.

---

### ⚙️ **Requisitos técnicos**

- `SupplyPointController.cs`:
    - `OnTriggerStay(Collider c)` → detecta héroe.
    - `if (isAlly && isInside)` → inicia `Coroutine` de curación.
    - `HealTarget(target, amount)` para héroe y cada unidad viva.
- `HealthComponent.cs` en Héroe y unidades:
    - `ApplyHealing(int amount)`
- Visuales:
    - Prefab de `HealingEffect` (shader glow o partículas).
    - Mostrar sobre cada entidad afectada durante el tick de curación.
- Configurable:
    - `healAmountHero`, `healAmountUnit`, `tickRate`

---

### 🧪 **Criterios de aceptación**

- Si el jugador está dentro del rango de un Supply Point aliado, recibe curación continua.
- La escuadra activa también se regenera mientras esté viva.
- No se aplica curación si el punto no es del mismo bando.
- Al salir del área, el efecto se detiene sin errores.
- El jugador ve claramente que está siendo curado, pero sin efectos intrusivos.

# Desarrollar combate normal según sistemas existen 216df9df7102817b9c2add18bc5ddc1e

# Desarrollar combate normal según sistemas existentes

Descripción: Activación de movimiento, formaciones, IA, daño, etc.
Prioridad: Alta
Etiquetas: Combate, Sistemas
Etapa: Planeación
Sistema Principal: Mapas
Fase: Mecánicas de Combate
orden: 60

### 🧭 **Tarea:** Desarrollar combate normal según sistemas existentes

**Descripción técnica detallada:**

Unificar e integrar los sistemas ya implementados del prototipo para habilitar el combate funcional dentro de una partida real. Esto implica la activación coordinada del control del héroe, escuadra, IA enemiga, sistema de detección de impacto, cálculo de daño, formaciones tácticas, y entrada del jugador. El objetivo es que, una vez cargado el mapa de batalla, el jugador pueda jugar una partida real con interacción completa entre héroes, unidades e IA.

---

### 🎮 **Funcionalidades requeridas:**

- El jugador debe tener control inmediato de su héroe tras la fase de preparación.
- La escuadra del jugador debe responder a órdenes básicas (seguir, atacar).
- La IA enemiga debe patrullar o reaccionar al jugador automáticamente.
- Las unidades deben moverse y atacar según sus formaciones y alcance.
- El sistema de combate debe aplicar daño real entre entidades (héroe vs escuadra, escuadra vs escuadra).
- Habilidades y animaciones básicas deben estar activas si están implementadas.

---

### ⚙️ **Requisitos técnicos**

- Activar `PlayerInput`, `HeroController` y `SquadController` al finalizar la fase de preparación.
- Las escuadras deben tener un `StateMachine` funcional (`Idle`, `Follow`, `Attack`).
- IA básica (`EnemyAIController`) debe usar NavMesh y FSM.
- Asegurar que el sistema de detección de impacto (`Hitbox`, `Raycast`, `DamageReceiver`) está activo.
- Integrar `FormationManager` para aplicar la estructura de combate de cada escuadra.
- Habilitar HUD o control si hay sistema visual de salud o energía.

---

### 🧪 **Criterios de aceptación**

- El jugador puede mover, atacar y controlar su héroe normalmente.
- Las unidades responden a comandos o IA de manera coherente.
- El daño se aplica al impactar entre unidades o al héroe.
- No hay errores críticos al ejecutar una partida completa de combate.
- Todos los sistemas activos conviven correctamente y no se bloquean entre sí.
- El jugador puede ganar o perder con base en la lógica implementada.

# Diseñar entidad Supply Point en el mapa (con esta 217df9df71028011948ddb977d4689a6

# Diseñar entidad Supply Point en el mapa (con estados visuales)

Descripción: Crear el objeto interactivo Supply Point con visual dinámico y detección de entrada de jugadores.
Prioridad: Media
Etiquetas: Mapa de batalla, Prefab, Supply, Terreno y Navegación, Visualización
Etapa: Backlog
Sistema Principal: Mapas
Fase: Batalla
ítem principal: Sistema de Supply Points con control territorial (Sistema%20de%20Supply%20Points%20con%20control%20territorial%20217df9df710280748412c06ee0ecfc6e.md)

### 🧭 **Tarea:** Diseñar entidad Supply Point en el mapa (con estados visuales)

**Descripción corta:**

Crear el objeto interactivo Supply Point con visual dinámico y detección de entrada de jugadores.

---

**Descripción técnica detallada:**

El Supply Point debe existir como una entidad física en la escena del mapa de batalla. Este objeto debe tener un área de efecto detectable por el jugador (trigger), y un sistema visual que represente su estado de control: **Aliado (azul)**, **Enemigo (rojo)** o **Neutral (gris)**. La zona también será usada para curación, cambio de escuadra, captura, etc., por lo que debe ser fácilmente identificable en el campo. Esta entidad no incluye todavía la lógica funcional, solo su representación y estructura básica.

---

### 🎮 **Funcionalidades requeridas:**

- Crear un prefab `SupplyPoint` que incluya:
    - Collider en modo `Trigger` para detección de entrada/salida.
    - Modelo o base visual (bandera, pedestal, anillo).
    - Materiales o colores asignables dinámicamente.
- Exponer variable de estado (`Ally`, `Enemy`, `Neutral`).
- Cambiar color o elemento visual dependiendo del estado actual.
- Colocar al menos un Supply Point en el mapa de batalla para pruebas.
- Preparar eventos `OnPlayerEnter`, `OnPlayerExit` para los siguientes sistemas (curación, captura, cambio de escuadra/arma).

---

### ⚙️ **Requisitos técnicos**

- Crear carpeta `/Prefabs/Supply/` con:
    - `SupplyPoint.prefab`
- Script `SupplyPoint.cs`:
    - Variables:
        
        ```csharp
        enum SupplyOwnership { Neutral, Ally, Enemy }
        public SupplyOwnership currentState;
        public Renderer visualIndicator;
        ```
        
    - Métodos:
        - `UpdateVisualState()`
        - `SetState(SupplyOwnership newState)`
        - `OnTriggerEnter(Collider other)` (filtrar por jugador)
- Materiales de color: azul, rojo, gris (pueden ser materiales básicos o shaders ligeros).
- Escena `/Scenes/Battlefield/` con al menos un `SupplyPoint` colocado.

---

### 🧪 **Criterios de aceptación**

- El Supply Point es visible y tiene su área de acción bien definida en el mapa.
- Cambia visualmente entre los tres estados (Neutral, Aliado, Enemigo).
- El jugador puede entrar/salir del área y los eventos se disparan correctamente.
- El prefab es modular y se puede replicar en el mapa sin conflictos.
- No hay errores de colisión, posicionamiento o activación múltiple.

# Diseñar layout base del Mapa de Batalla de Feudo 216df9df7102803f8cfee8d9d0d48f52

# Diseñar layout base del Mapa de Batalla de Feudo

Descripción: Crear una escena con geometría básica que represente los extremos de spawn y la zona central de combate.
Prioridad: Alta
Etiquetas: Mapa de batalla
Etapa: Backlog
Sistema Principal: Mapas
Bloqueado por: Crear terreno de prueba (250x250m) (Crear%20terreno%20de%20prueba%20(250x250m)%20214df9df7102819d85d8daf06673b3ec.md)
Bloqueando: Implementar sistema de selección de punto de spawn (atacante/defensor) (Implementar%20sistema%20de%20seleccio%CC%81n%20de%20punto%20de%20spaw%20216df9df7102806583a4fa71bc27d052.md)
Fase: Mecánicas de Combate
orden: 65

### 🧭 **Tarea:** Diseñar layout base del Mapa de Batalla de Feudo

**Descripción técnica detallada:**

Este mapa sirve como campo de batalla principal en el MVP. Su diseño debe reflejar de forma funcional y simple las necesidades del sistema de combate: dos extremos opuestos para ubicar a atacantes y defensores, un área central abierta para el enfrentamiento y zonas con obstáculos para cobertura o navegación. No requiere arte final ni decoración avanzada, pero sí debe permitir pruebas reales de movimiento, combate, escuadras y formaciones. El diseño también debe incluir los puntos de spawn por bando.

---

### 🎮 **Funcionalidades requeridas:**

- Crear una escena Unity independiente llamada `MapaBatallaFeudo`.
- Composición mínima del layout:
    - Zona de spawn para atacantes (3 puntos).
    - Zona de spawn para defensores (3 puntos).
    - Zona central abierta.
    - Obstáculos simétricos o dispersos para navegación táctica.
- Escala funcional (ej: 150–250 metros de ancho, distancia realista de combate).
- El terreno debe permitir navegación fluida para escuadras e IA.
- Integración posterior con:
    - NavMesh
    - SpawnPoints
    - Sistemas de detección de colisiones

---

### ⚙️ **Requisitos técnicos**

- Crear escena nueva: `/Scenes/Maps/MapaBatallaFeudo.unity`
- Usar:
    - `ProBuilder` o geometría básica (`Cubes`, `Planes`, `Spheres`) para muros y estructuras.
    - `NavMeshSurface` para validar navegación.
- Añadir:
    - 3 GameObjects con tag `AttackerSpawn`
    - 3 GameObjects con tag `DefenderSpawn`
    - Marcadores visibles para pruebas (`Gizmos`, íconos)
- Agrupar objetos en jerarquías claras: `SpawnPoints`, `Obstacles`, `Ground`, etc.
- Añadir luz, skybox y volumen de cámara funcional para pruebas visuales.

---

### 🧪 **Criterios de aceptación**

- El mapa se carga correctamente como escena jugable.
- Hay 3 puntos de aparición por bando bien distribuidos.
- El jugador y sus unidades pueden navegar sin obstáculos rotos.
- El diseño permite formaciones, combate a distancia y movimiento de escuadras.
- El entorno es claro, funcional y sin elementos visuales finales (bloqueo blanco o gris).

# Diseñar layout de interfaz de estadísticas del h 215df9df71028022964ae194517d6134

# Diseñar layout de interfaz de estadísticas del héroe

Descripción: Crear el diseño visual estructurado de la UI donde se mostrarán y modificarán stats, equipamiento, skins y el modelo 3D del héroe.
Prioridad: Alta
Etiquetas: Control del Héroe, UI
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

### 🧭 **Tarea:** Diseñar layout de interfaz de estadísticas del héroe

**Descripción técnica detallada:**

Diseñar el esqueleto visual de la interfaz de estadísticas del héroe, donde se integrarán todos los elementos funcionales del sistema. Este layout debe ser claro, escalable, compatible con navegación por mouse o gamepad, y visualmente organizado para facilitar la implementación modular de cada bloque: atributos, equipo, skins y vista previa del personaje.

---

### 🎮 **Funcionalidades requeridas:**

- Zona para mostrar atributos básicos (Fuerza, Destreza, Vitalidad, Armadura).
- Panel para mostrar equipamiento actual (arma, armadura).
- Lista lateral o desplegable con objetos disponibles por categoría.
- Sección dedicada para cambiar skins desbloqueadas.
- Ventana o subpanel con el modelo 3D del héroe (espacio libre de UI encima).
- Botones de navegación o pestañas para cambiar entre secciones si el espacio es limitado.
- Diseño responsive para distintas resoluciones y escalas UI.

---

### ⚙️ **Requisitos técnicos**

- Diseño hecho en Unity (Canvas + layout system) o entregado en mockup (Figma/Adobe XD).
- Componentes UI estándar: `TextMeshPro`, `Image`, `Button`, `ScrollView`, `ToggleGroup`.
- Diseño modular dividido por secciones para que los programadores puedan integrar funcionalidad por partes.
- Uso de layout groups (`Vertical/Horizontal Layout`) y anchors bien definidos.

---

### 🧪 **Criterios de aceptación**

- El diseño permite integrar visualmente todos los elementos funcionales requeridos.
- El layout se ve consistente en diferentes resoluciones (mínimo 16:9 y 21:9).
- Cada sección de la UI tiene suficiente espacio visual para los datos que mostrará.
- Está validado por el equipo técnico para garantizar que sea implementable sin rediseño.
- Está listo para comenzar conexión con datos reales y scripts funcionales.

# Diseñar layout visual del resumen de batalla 216df9df710280059926e794346c3d1f

# Diseñar layout visual del resumen de batalla

Descripción: Diseñar visualmente la estructura de la interfaz de resumen, incluyendo héroe, unidades, estadísticas y acción final.
Prioridad: Alta
Etiquetas: Batalla, Diseño
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Diseñar layout visual del resumen de batalla

**Descripción técnica detallada:**

Crear un diseño claro y funcional para la pantalla de resumen de batalla. Debe representar toda la información clave de forma jerárquica y legible. Es una tarea de UX/UI, no de código.

---

### 🎮 Funcionalidades requeridas:

- Secciones para:
    - Resultado (Victoria / Derrota)
    - Info del héroe (nombre, retrato, XP)
    - Unidades usadas con kills y XP
    - Botón “Continuar”
- Diseño adaptativo y visualmente jerárquico

---

### ⚙️ Requisitos técnicos:

- Mockup en Figma, XD, Illustrator, etc.
- Incluye márgenes, alineaciones, jerarquía visual
- Exportado como imagen + fuente editable

---

### 🧪 Criterios de aceptación:

- El diseño es completo, funcional y aprobado
- Sirve como guía clara para implementación técnica

# Disparar fin de partida y transicionar a pantalla  217df9df7102807a9b9fdf51c76833e6

# Disparar fin de partida y transicionar a pantalla de resultados

Descripción: Finalizar la partida cuando se cumple una condición de victoria y mostrar la pantalla de resultados con los datos del combate.
Prioridad: Alta
Etiquetas: Batalla, Condiciones de victoria, Fin partida, Mapa de batalla
Etapa: Backlog
Sistema Principal: Batalla
Fase: Batalla
orden: 54

### 🧭 **Tarea:** Disparar fin de partida y transicionar a pantalla de resultados

**Descripción técnica detallada:**

Una vez se cumple alguna condición de victoria (atacante captura las 3 banderas, o el tiempo llega a 0), el sistema debe cerrar el estado de juego activo, bloquear entradas, detener toda acción en curso (movimiento, combate, AI), y cargar la pantalla de resultados.

Esta pantalla muestra el resumen de desempeño del jugador (unidades usadas, bajas infligidas, experiencia ganada, resultado del combate) y permite continuar hacia el mapa de feudo.

El disparador del fin de partida debe estar unificado, y su entrada debe venir exclusivamente desde el `BattleManager`.

---

### 🎮 **Funcionalidades requeridas:**

- Desde `BattleManager`, al determinar una victoria:
    - Ejecutar `EndBattleHandler.TriggerEndSequence()`
- Detener:
    - Input del jugador (movimiento, cámara, combate)
    - Acciones de IA de escuadras
    - HUD de batalla (desactivar cronómetro, selector, etc.)
- Activar transición:
    - Fade visual o corte limpio
    - Mostrar `BattleResultsUI`
- Cargar información dinámica:
    - Bandera de resultado (Victoria/Derrota)
    - Estadísticas por unidad (bajas infligidas, sobrevivientes)
    - Exp del héroe y de cada unidad
- Mostrar botón “Continuar” que devuelve al mapa de feudo

---

### ⚙️ **Requisitos técnicos**

- Script `EndBattleHandler.cs`:
    - Métodos:
        
        ```csharp
        void TriggerEndSequence(Team winner)
        void DisplayResults(BattleData data)
        ```
        
- Interfaz `BattleResultsUI`:
    - Panel de resumen general
    - Listado de unidades con desempeño
    - Exp ganada (visual por unidad y por héroe)
    - Botón de “Continuar” → `ReturnToFeudoScene()`
- Integración con:
    - `BattleManager` para llamada de activación
    - `MatchSession` o `PlayerProfile` para registrar progreso

---

### 🧪 **Criterios de aceptación**

- Al ganar el atacante (captura de 3 banderas), se muestra la pantalla de resultados.
- Al ganar el defensor (cronómetro llega a 0), ocurre lo mismo.
- Toda acción en juego se detiene en el momento de la victoria.
- El jugador puede ver sus estadísticas detalladas y continuar.
- No hay forma de seguir interactuando con el combate después de la victoria.

# Establecer flujo de trabajo colaborativo 214df9df710281d58c75fcbf29f9285a

# Establecer flujo de trabajo colaborativo

Descripción: Definir y documentar las reglas y herramientas que guiarán el trabajo en equipo dentro del entorno de desarrollo (Unity + control de versiones).
Prioridad: Alta
Etiquetas: Gestión
Etapa: Backlog
Sistema Principal: pasos iniciales
Fase: Setup Técnico Inicial
orden: 6

### 🧭 **Tarea:** Establecer flujo de trabajo colaborativo

**Descripción técnica detallada:**

Establecer una estructura de trabajo clara y funcional para todos los miembros del equipo (programadores, artistas, diseñadores) al colaborar dentro del proyecto Unity. Esto incluye la organización del repositorio, uso de ramas, convenciones de carpetas y nombres, reglas de commits y fusiones, así como la documentación del proceso. El objetivo es evitar conflictos, facilitar la integración de tareas paralelas y permitir escalar el equipo sin caos.

---

### 🎮 **Funcionalidades requeridas:**

- Configuración inicial de control de versiones:
    - Uso de **Git** (con LFS activado para assets pesados).
    - Repositorio en GitHub, GitLab o similar.
- Convenciones de ramas:
    - `main`: rama de producción.
    - `develop`: rama de integración continua.
    - `feature/nombre-tarea`: ramas para nuevas funciones.
    - `hotfix/nombre`: para correcciones urgentes.
- Normas de commits:
    - Mensajes descriptivos y coherentes (`feat:`, `fix:`, `refactor:`, etc.).
    - Ej: `feat: implementar sistema de perks pasivos`
- Estrategia de fusiones:
    - Pull requests obligatorios.
    - Revisión por otro miembro del equipo antes de merge.
- Manejo de escenas en Unity:
    - Uso de escenas compartimentadas para evitar conflictos.
    - Una escena principal (`MainScene`) y escenas individuales por sistema (`CombatTestScene`, `BarracksScene`, etc.).
- Carpeta `/Sandbox/` para pruebas individuales sin interferencia.
- Sistema de control de cambios por etiquetas y comentarios en Prefabs.

---

### ⚙️ **Requisitos técnicos**

- Archivo `.gitignore` específico para Unity (evita librerías, caches, builds locales).
- Activación de Git LFS (`.psd`, `.fbx`, `.png`, `.wav`, `.unitypackage`, etc.).
- Archivo `README.md` explicando el flujo de trabajo.
- Opcional: plantilla para PRs (`PULL_REQUEST_TEMPLATE.md`) y commits convencionales.
- Uso de herramientas opcionales:
    - GitKraken, Sourcetree, Fork (GUI)
    - Unity Plastic SCM (si se prefiere por el equipo)

---

### 🧪 **Criterios de aceptación**

- El repositorio es funcional y permite clonar y ejecutar el proyecto sin errores.
- Al menos un miembro ajeno puede seguir las instrucciones del `README.md` y hacer su primer commit correctamente.
- Las ramas están organizadas y no hay conflictos graves frecuentes.
- Las escenas de Unity no se sobrescriben accidentalmente entre miembros.
- El equipo conoce y respeta las reglas básicas del flujo de trabajo establecido.

# Estructurar sistema de perks (JSON ScriptableObjec 214df9df7102810f8c64f342447c1cf8

# Estructurar sistema de perks (JSON / ScriptableObject)

Descripción: Definir y organizar la estructura de perks del héroe usando datos externos o ScriptableObjects, permitiendo su lectura y aplicación dinámica.
Prioridad: Media
Etiquetas: Técnica
Etapa: Backlog
Sistema Principal: Perks y Talentos
Bloqueando: Sistema de Perks y Talentos (Sistema%20de%20Perks%20y%20Talentos%20214df9df710281ce965ffbc441d224d1.md)
Fase: Mecánicas de Combate
orden: 51

### 🧭 **Tarea:** Estructurar sistema de perks (JSON / ScriptableObject)

**Descripción técnica detallada:**

Diseñar la base de datos estructurada del sistema de perks que contendrá las habilidades pasivas y activas desbloqueables por el jugador. Este sistema debe utilizar un formato de datos externo (como JSON) o interno (como ScriptableObject) para definir la información de cada perk: su efecto, tipo, categoría, condición de activación, y modificadores. El objetivo es establecer un backend modular y legible que permita gestionar perks de forma escalable e integrarlos fácilmente al perfil del héroe.

---

### 🎮 **Funcionalidades requeridas:**

- Definición de perks con los siguientes atributos:
    - ID único
    - Nombre
    - Descripción
    - Tipo: pasivo / activable / aura / situacional
    - Categoría: ofensivo, defensivo, utilidad, liderazgo
    - Requisitos de nivel o desbloqueo (si aplica)
    - Efectos: `+x% daño`, `+y armadura`, `+z liderazgo`, etc.
- Sistema capaz de leer perks desde:
    - Archivos `.json` externos o
    - ScriptableObjects (`PerkData`).
- Soporte para múltiples perks activos en paralelo.
- Perks referenciables desde otras interfaces: árbol de talentos, vista de héroe, loadouts.

---

### ⚙️ **Requisitos técnicos**

- Estructura `PerkData`:
    
    ```csharp
    public class PerkData {
        public string id;
        public string name;
        public string description;
        public PerkType type;
        public PerkCategory category;
        public List<StatModifier> modifiers;
    }
    ```
    
- Si se usa JSON:
    - Archivo cargado desde `Resources/Perks/PerkList.json`.
    - Parseo con `JsonUtility` o `Newtonsoft.Json`.
- Si se usa ScriptableObject:
    - Crear un asset por perk o lista de perks agrupada.
    - Ubicar en `/Assets/Data/Perks/`.
- Soporte para `StatModifier` estructurado:
    
    ```csharp
    public enum StatType { Damage, Armor, Health, Leadership }
    public class StatModifier {
        public StatType stat;
        public float value;
        public bool isPercent;
    }
    ```
    

---

### 🧪 **Criterios de aceptación**

- Los perks pueden ser definidos, cargados y accedidos en tiempo de ejecución.
- El sistema puede consultar perk por ID y obtener sus modificadores.
- Los datos se pueden usar tanto en gameplay como en UI sin duplicación.
- El sistema es extensible para futuras ramas de perks o talentos.
- No hay errores de carga al modificar, agregar o quitar perks del sistema.

# Evaluar rendimiento base 214df9df7102815f8790f53c3751b770

# Evaluar rendimiento base

Descripción: Medir FPS y estabilidad con escena básica y red activa.
Prioridad: Alta
Etiquetas: QA, Técnica
Etapa: Por hacer
Sistema Principal: Multiplayer
Fase: Validación Prototipo
orden: 70

# Generar y almacenar escuadra seleccionada como Squ 217df9df710280458480e1c6cb9c52df

# Generar y almacenar escuadra seleccionada como SquadLoadout

Descripción: Unificar la selección manual o por loadout en una sola estructura persistente usada en combate.
Prioridad: Alta
Etiquetas: Gestión de Escuadra, Liderazgo, Loadout, Preparación
Etapa: Backlog
Sistema Principal: Gestión de Escuadra
Fase: Preparación de Combate
ítem principal: Botón “Continuar” y bloqueo de selección (Boto%CC%81n%20%E2%80%9CContinuar%E2%80%9D%20y%20bloqueo%20de%20seleccio%CC%81n%20216df9df71028188b713c698e38880a1.md)

### 🧭 **Tarea:** Generar y almacenar escuadra seleccionada como SquadLoadout

**Descripción técnica detallada:**

Durante la fase de preparación, el jugador puede armar su escuadra eligiendo unidades una por una o cargando un loadout guardado previamente. Independientemente del método, toda selección debe traducirse en un objeto unificado del tipo `SquadLoadout`. Esta estructura temporal será almacenada al presionar “Continuar” o al agotarse el tiempo, y será utilizada posteriormente para instanciar la escuadra real al cargar el mapa de batalla.

Esto evita duplicación de lógica entre selección manual y por plantilla, y asegura coherencia entre la UI de preparación y la lógica de combate.

---

### 🎮 **Funcionalidades requeridas:**

- Durante la selección:
    - Al agregar unidades manualmente → se añaden al objeto `PreparedSquadLoadout`.
    - Al cargar un loadout → se clona directamente a `PreparedSquadLoadout`.
- Al presionar “Continuar”:
    - Validar liderazgo y unicidad de unidades.
    - Guardar `PreparedSquadLoadout` en memoria global:
        
        ```csharp
        MatchSession.Instance.PlayerSquadLoadout = PreparedSquadLoadout;
        ```
        
- Esta estructura será utilizada en la escena de combate para instanciar la escuadra.
- Debe ser capaz de representar:
    - ID de cada tipo de unidad
    - Cantidad
    - (Opcional) referencias de nivel, skin o equipo si aplica

---

### ⚙️ Requisitos técnicos

- Clase `SquadLoadout`:
    - `Dictionary<UnitID, int> composition`
    - Métodos `AddUnit()`, `RemoveUnit()`, `Clone()`, `IsValid()`
- Script `PreparationUIManager.cs`:
    - Crea y modifica `PreparedSquadLoadout` en tiempo real.
- Integración con:
    - `LoadoutSelectorUI.cs`
    - `UnitSelectionPanel.cs`
- Validaciones antes de guardar:
    - Total de liderazgo ≤ máximo del héroe
    - Unidades válidas y disponibles

---

### 🧪 **Criterios de aceptación**

- La estructura `SquadLoadout` refleja exactamente la selección del jugador.
- Al presionar “Continuar”, se guarda automáticamente para uso posterior.
- Tanto la selección manual como la selección por loadout actualizan la misma variable.
- En combate, la escuadra generada corresponde a esta estructura sin errores.
- No se permiten duplicados, sobrepasos de liderazgo ni datos vacíos.

# Gestión de Escuadras (Órdenes Básicas) 214df9df7102810bae94d0178b87ec78

# Gestión de Escuadras (Órdenes Básicas)

Descripción: Permitir al jugador emitir órdenes simples a su escuadra como seguir, esperar o atacar.
Prioridad: Alta
Etiquetas: Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Gestión de Escuadra, IA de Tropas
Bloqueado por: Implementar sistema de órdenes básicas (Implementar%20sistema%20de%20o%CC%81rdenes%20ba%CC%81sicas%20214df9df71028178b6e0d76c81158398.md)
Bloqueando: Implementar cambio de formación (hotkey o menú) (Implementar%20cambio%20de%20formacio%CC%81n%20(hotkey%20o%20menu%CC%81)%20214df9df71028191b074cb0500d6b1b1.md), Sistema de Formaciones (Estructura Táctica) (Sistema%20de%20Formaciones%20(Estructura%20Ta%CC%81ctica)%20214df9df710281898045ff92b43d8fea.md), Implementar slots dinámicos para formaciones (Implementar%20slots%20dina%CC%81micos%20para%20formaciones%20214df9df7102817fbf5be4d9d6334072.md)
Fase: Mecánicas de Combate
Subítem: Implementar sistema de órdenes básicas (Implementar%20sistema%20de%20o%CC%81rdenes%20ba%CC%81sicas%20214df9df71028178b6e0d76c81158398.md), Comportamiento en formación rota o pérdida parcial (Comportamiento%20en%20formacio%CC%81n%20rota%20o%20pe%CC%81rdida%20parci%20217df9df710280079bbbc96e4189d73c.md)
orden: 44

## 🧭 **Tarea:** Gestión de Escuadras (Órdenes Básicas)

**Descripción técnica detallada:**

Desarrollar el sistema que permite al jugador controlar una escuadra básica de unidades a través de órdenes directas. Estas órdenes deben ser simples, ejecutables mediante teclas o interfaz, y reflejarse inmediatamente en el comportamiento de la escuadra. La escuadra debe estar vinculada al héroe y responder de forma lógica a las acciones del jugador, como seguir su movimiento, detenerse en formación, o atacar a un objetivo designado.

---

### 🎮 **Funcionalidades requeridas:**

- Asociación de una escuadra de unidades al jugador como líder.
- Órdenes disponibles:
    - **Seguir**: las unidades siguen al héroe (en grupo o en formación).
    - **Esperar**: las unidades se detienen y mantienen posición.
    - **Atacar**: las unidades atacan al objetivo marcado (enemigo, posición).
- Sistema de entrada por hotkeys (`1`, `2`, `3`) o panel táctico (futuro).
- Las unidades deben:
    - Cambiar de estado internamente según la orden.
    - Adaptar su navegación o comportamiento en consecuencia.
- Transiciones suaves entre órdenes (sin glitches ni reinicios abruptos).
- Feedback visual opcional (ícono sobre las unidades o indicador de estado).

---

### ⚙️ **Requisitos técnicos**

- Script `SquadController.cs` para interpretar y ejecutar órdenes.
- Componente `UnitAIController` en cada miembro de la escuadra con FSM básica.
- Estados mínimos:
    - `Idle`, `FollowLeader`, `HoldPosition`, `EngageTarget`.
- Acceso al `NavMeshAgent` de cada unidad para navegación.
- Las órdenes se pueden emitir desde:
    - Input directo (`Input System`).
    - Evento externo (p.ej. selección desde UI).
- Lógica para evitar colisiones y mantener agrupamiento básico.

---

### 🧪 **Criterios de aceptación**

- El jugador puede emitir las órdenes mediante input definido.
- La escuadra responde en tiempo real a cada orden.
- Las unidades siguen al héroe con lógica coherente (sin atascarse ni separarse demasiado).
- Las órdenes de ataque son ejecutadas si hay objetivos válidos visibles.
- El sistema puede ampliarse en el futuro para órdenes más complejas o estratégicas.

# Guardar selección como loadout 214df9df7102817d8763c03c6a84caf2

# Guardar selección como loadout

Descripción: Sistema para almacenar selección de tropas como configuración reutilizable.
Prioridad: Media
Etiquetas: Técnica
Etapa: Backlog
Sistema Principal: Barracón
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md)
Bloqueando: Selector de loadouts de tropas (Selector%20de%20loadouts%20de%20tropas%20216df9df7102813aafd3c7e898ab6c0f.md)
Fase: Configurar Personaje y Unidades
orden: 24

### 🧭 **Tarea:** Guardar selección como loadout

**Descripción técnica detallada:**

Implementar un sistema que permita al jugador guardar combinaciones de **tropas completas** (*Troops*) previamente seleccionadas en el barracón o en la UI de entrada a batalla. Estas combinaciones, llamadas *loadouts*, deben almacenarse de forma persistente y poder recuperarse fácilmente para su uso en futuras partidas. Cada loadout debe respetar el límite de liderazgo del jugador (sumando el coste de cada escuadra) y contener metainformación suficiente para mostrarse en interfaces previas al combate.

---

### 🎮 **Funcionalidades requeridas:**

- Posibilidad de guardar hasta 3 loadouts diferentes (mínimo para MVP).
- Cada loadout debe almacenar:
    - Lista de **tropas** (`Troops`) seleccionadas.
    - Fecha/hora de creación o nombre personalizado (opcional).
- Mostrar botón “Guardar como Loadout” desde:
    - UI del barracón.
    - UI de entrada a batalla.
- Validación: el loadout no debe superar el límite de liderazgo.
- Opción para sobrescribir un loadout existente o guardar en un slot libre.

---

### ⚙️ **Requisitos técnicos**

- Clase `LoadoutData` con:
    - Lista de `TroopID`s o referencias a `TroopData`.
    - Campo `loadoutName` o `slotIndex`.
    - Coste total de liderazgo.
- Sistema de almacenamiento persistente:
    - Puede ser `PlayerPrefs`, `ScriptableObject` o archivo JSON para MVP.
- Integración con:
    - `BarracksManager` para validar unidades activas.
    - `LoadoutManager` para acceder a slots existentes y su estado.
- Validaciones antes de guardar:
    - No guardar loadouts vacíos.
    - Rechazar si excede el límite de liderazgo permitido.

---

### 🧪 **Criterios de aceptación**

- El jugador puede guardar una configuración válida de tropas como loadout.
- El sistema permite guardar en un nuevo slot o sobrescribir uno existente.
- Al volver a la partida, los loadouts están disponibles y cargan correctamente.
- El coste de liderazgo total se conserva y se puede validar antes de aplicar.
- Los datos persistidos pueden ser leídos por la UI de entrada a batalla.
- No se permiten loadouts vacíos o inválidos (exceso de liderazgo).

# Guardar y aplicar los cambios al perfil del jugado 215df9df710280bfbb8ecc54ef9c74cd

# Guardar y aplicar los cambios al perfil del jugador

Descripción: Persistir los cambios de atributos, equipamiento y apariencia seleccionados por el jugador en su perfil de héroe.
Prioridad: Alta
Etiquetas: Control del Héroe, Técnica
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

### 🧭 **Tarea:** Guardar y aplicar los cambios al perfil del jugador

**Descripción técnica detallada:**

Implementar la lógica que permite almacenar de forma persistente todas las configuraciones realizadas por el jugador en la interfaz del héroe. Esto incluye los atributos asignados, los objetos equipados (arma, armadura), y la skin cosmética activa. Al volver a abrir el juego o cargar el perfil, el héroe debe aparecer con la misma configuración aplicada anteriormente. Este sistema garantiza coherencia entre la interfaz, el gameplay y los datos del jugador.

---

### 🎮 **Funcionalidades requeridas:**

- Guardar atributos modificados (fuerza, destreza, vitalidad, armadura).
- Guardar ID de arma y armadura actualmente equipadas.
- Guardar ID de skin cosmética activa.
- Aplicar automáticamente esta configuración al iniciar sesión o cargar escena.
- Soporte para múltiples perfiles si aplica (uno por cuenta o slot de héroe).
- Integración directa con el sistema de combate y visualización.

---

### ⚙️ **Requisitos técnicos**

- Sistema de persistencia:
    - MVP: `PlayerPrefs`, JSON local o `ScriptableObject`.
    - Futuro: sincronización con backend o base de datos de cuenta.
- Datos a almacenar agrupados en una estructura `HeroProfile` o `HeroSaveData`.
- Funciones:
    - `SaveHeroProfile()`: llamada al confirmar cambios.
    - `LoadHeroProfile()`: llamada al iniciar sesión o escena.
- Debe validar integridad (ej: si un ítem equipado ya no está disponible).
- Acceso al sistema de estadísticas, inventario y skins para actualizar UI/modelo.

---

### 🧪 **Criterios de aceptación**

- El jugador puede cerrar la UI y al volver, su configuración se mantiene.
- Los cambios se reflejan en la próxima partida automáticamente.
- El sistema no permite guardar configuraciones inválidas (equipamiento inexistente).
- Al cargar el juego, el héroe se instancia con la apariencia y equipo correctos.
- No se pierden datos tras cerrar el juego o cambiar de escena.

# IA de Tropas (FSM básica) 214df9df7102811c840aec710dddef31

# IA de Tropas (FSM básica)

Descripción: Diseñar e implementar una máquina de estados finita (FSM) simple para controlar el comportamiento de tropas no jugables (NPCs) en combate.
Prioridad: Alta
Etiquetas: IA
Etapa: Por hacer
Sistema Principal: IA de Tropas
Fase: Mecánicas de Combate
Subítem:  IA para comportamiento autónomo en ausencia de órdenes (IA%20para%20comportamiento%20auto%CC%81nomo%20en%20ausencia%20de%20o%CC%81%20217df9df71028044b47dcc6197ce01ae.md)
orden: 46

## 🧭 **Tarea:** IA de Tropas (FSM básica)

**Descripción técnica detallada:**

Crear una arquitectura FSM (Finite State Machine) que permita a las unidades controladas por IA comportarse de forma lógica y autónoma en escenarios de combate. La FSM debe manejar transiciones entre estados como patrullar, buscar enemigos, atacar y mantenerse en posición, y debe estar diseñada para ser ligera y fácilmente ampliable en el futuro.

Esta IA se aplicará a las tropas que componen escuadras tanto enemigas como aliadas que no están directamente controladas por el jugador.

---

### 🎮 **Estados básicos incluidos en la FSM:**

- **Idle**
    - La unidad permanece en su posición y monitorea el entorno.
    - Espera órdenes o estímulos.
- **Seek**
    - Busca enemigos dentro de su rango de visión.
    - Se activa al no tener objetivo pero estar en alerta.
- **MoveToTarget**
    - Camina hacia un enemigo detectado hasta quedar a rango de ataque.
- **Attack**
    - Ejecuta ataques cuerpo a cuerpo o a distancia si el enemigo está dentro de alcance.
    - Incluye manejo de cooldown y animación.
- **Retreat (futuro)**
    - Planeado para situaciones de baja moral o daño crítico.

---

### ⚙️ **Requisitos técnicos**

- Script base: `UnitAIController.cs` o `UnitFSM.cs`
- Enum `AIState`: `Idle`, `Seek`, `MoveToTarget`, `Attack`, etc.
- Método de transición de estados:
    
    ```csharp
    csharp
    CopiarEditar
    void SetState(AIState newState);
    void UpdateState();
    
    ```
    
- Componente `EnemyDetector` o `VisionSensor` que use `Physics.OverlapSphere` o `Physics.Raycast` con filtro de tags para detectar enemigos.
- Acceso al `NavMeshAgent` para movimiento.
- Acceso al sistema de combate para iniciar `ApplyDamage()` al atacar.
- Cada unidad debe tener un objetivo actual (`Transform target`) y saber cuándo desecharlo o cambiarlo.

---

### 🧪 **Criterios de aceptación**

- Las tropas entran en estado `Idle` por defecto.
- Al detectar un enemigo, cambian a `MoveToTarget` y se aproximan.
- Si alcanzan rango de ataque, cambian a `Attack` y aplican daño.
- Si el objetivo muere o se aleja, regresan a `Seek` o `Idle`.
- El sistema puede manejar múltiples unidades de forma simultánea sin errores.
- Cada estado está desacoplado y puede extenderse fácilmente (ej: añadir coberturas, retirada, flanqueo).

# IA para comportamiento autónomo en ausencia de ó 217df9df71028044b47dcc6197ce01ae

# IA para comportamiento autónomo en ausencia de órdenes

Descripción: Permitir que la escuadra actúe de forma básica si no recibe órdenes directas del jugador.
Prioridad: Alta
Etiquetas: Combate, Gestión de Escuadra, IA, Unidades
Etapa: Backlog
Sistema Principal: Gestión de Escuadra
Fase: Batalla
ítem principal: IA de Tropas (FSM básica) (IA%20de%20Tropas%20(FSM%20ba%CC%81sica)%20214df9df7102811c840aec710dddef31.md)

### 🧭 **Tarea:** IA para comportamiento autónomo en ausencia de órdenes

**Descripción técnica detallada:**

Cuando el jugador no emite órdenes activas a su escuadra, esta no debe quedar pasiva o inmóvil, especialmente en situaciones de combate o defensa. Se requiere una lógica de IA por defecto que le permita actuar de manera coherente: mantenerse cerca del héroe, defender su posición, responder a enemigos cercanos o mantener la formación mientras se desplaza. Este comportamiento autónomo no debe ser tan complejo como el de un ejército controlado por IA, pero sí funcional y reactivo.

---

### 🎮 **Funcionalidades requeridas:**

- Si no hay una orden explícita activa:
    - La escuadra sigue automáticamente al héroe manteniendo una distancia media.
    - Si un enemigo se acerca dentro del rango de alerta:
        - La escuadra entra en modo defensivo.
        - Puede contraatacar si está configurada para ello.
- Si está en formación:
    - Intenta mantenerla mientras se mueve con el héroe.
- Opcional: comportamiento configurable por tipo de escuadra (agresiva, pasiva, defensiva).

---

### ⚙️ Requisitos técnicos

- Sistema de estados por escuadra:
    - `Idle` → sin órdenes, esperando
    - `FollowHero` → movimiento en paralelo con el héroe
    - `AutoEngage` → reacción básica a amenazas cercanas
- Script `SquadAIController.cs`:
    - Método `UpdateBehavior()` que evalúa:
        - ¿Hay órdenes activas?
        - ¿Hay enemigos cerca?
        - ¿El héroe se está moviendo?
- Configurable desde datos de unidad o tipo de escuadra (`AutoResponse = true/false`)

---

### 🧪 **Criterios de aceptación**

- La escuadra no se queda inmóvil sin razón cuando no tiene órdenes.
- Si el jugador se mueve, la escuadra lo acompaña.
- Si un enemigo se acerca, la escuadra reacciona de forma básica (bloquea, ataca o retrocede).
- Las reacciones no interfieren con órdenes manuales si estas son emitidas después.
- El comportamiento puede escalar con complejidad en el futuro, pero en el MVP es simple y funcional.

# Implementar cambio de formación (hotkey o menú) 214df9df71028191b074cb0500d6b1b1

# Implementar cambio de formación (hotkey o menú)

Descripción: (Permitir al jugador cambiar entre formaciones tácticas válidas para su escuadra mediante teclas rápidas o una interfaz de selección durante la partida.Transición entre Línea, Cuña, Círculo.)
Prioridad: Alta
Etiquetas: Gameplay, Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Formaciones
Bloqueado por: Gestión de Escuadras (Órdenes Básicas) (Gestio%CC%81n%20de%20Escuadras%20(O%CC%81rdenes%20Ba%CC%81sicas)%20214df9df7102810bae94d0178b87ec78.md), Sistema de Formaciones (Estructura Táctica) (Sistema%20de%20Formaciones%20(Estructura%20Ta%CC%81ctica)%20214df9df710281898045ff92b43d8fea.md)
Fase: Mecánicas de Combate
Subítem: Animaciones sincronizadas por tipo de formación (Animaciones%20sincronizadas%20por%20tipo%20de%20formacio%CC%81n%20217df9df710280449482c875e2fa3adf.md)
orden: 50

### 🧭 **Tarea:** Implementar cambio de formación (hotkey o menú)

**Descripción técnica detallada:**

Desarrollar el sistema de entrada y visualización que permite al jugador cambiar la formación de su escuadra en tiempo real, utilizando teclas rápidas o una UI mínima. El sistema debe verificar qué formaciones son válidas para la escuadra seleccionada (según su tipo o datos de configuración) y actualizar automáticamente la distribución de unidades. No se permite personalización de slots, y la reorganización debe mantener la estructura definida, incluso tras bajas.

---

### 🎮 **Funcionalidades requeridas:**

- El jugador puede cambiar de formación:
    - Usando hotkeys asignadas (`F1`, `F2`, `F3`, etc.).
    - O mediante una interfaz de botones visibles (`FormationSelectionPanel`).
- El cambio de formación:
    - Aplica una estructura predefinida (`FormationData`).
    - Reasigna automáticamente a cada unidad un slot según índice fijo.
- El sistema solo muestra o activa formaciones válidas para esa escuadra.
- Retroalimentación visual:
    - Indicador de formación activa (nombre, ícono o resaltado).
    - (Opcional) animación breve o sonido al cambiar formación.
- Permitir cambios de formación en cualquier estado: en movimiento, en espera, o antes de combate.

---

### ⚙️ **Requisitos técnicos**

- Input configurado:
    - Sistema `InputAction` para teclas `F1`, `F2`, etc., con acciones: `ChangeFormation1`, `ChangeFormation2`, ...
- UI (si se incluye):
    - Prefab `FormationSelectionPanel` con botones vinculados a métodos públicos.
- Lógica en `SquadController`:
    - Método `SetFormation(FormationData newFormation)` para reubicar unidades.
- Acceso a `FormationDatabase` o lista local de formaciones válidas por escuadra.
- Comprobación al presionar una tecla o clic:
    - Que la formación existe y es válida para la escuadra actual.
    - Que no está ya activa (para evitar cambios innecesarios).

---

### 🧪 **Criterios de aceptación**

- El jugador puede cambiar la formación de su escuadra usando teclas o botones sin errores.
- Solo se puede seleccionar entre las formaciones definidas para la escuadra.
- El cambio reorganiza a las unidades de forma inmediata y coherente.
- Si una unidad ha muerto, las restantes se reubican para mantener la forma.
- El indicador visual de formación activa se actualiza correctamente.
- El sistema ignora entradas inválidas o repetidas sin causar errores de lógica ni navegación.

# Implementar controlador de cámara del héroe 214df9df7102819e97d6fd1375f01854

# Implementar controlador de cámara del héroe

Descripción: Programar la lógica de desplazamiento del héroe en tercera persona, integrando entrada del jugador, rotación y animaciones sincronizadas en un entorno de prueba.


Prioridad: Alta
Etiquetas: Gameplay
Etapa: Por hacer
Sistema Principal: Control del Héroe
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md)
Bloqueando: Implementar movimiento de héroe (Implementar%20movimiento%20de%20he%CC%81roe%20214df9df7102817aa696f1bf9ad434c9.md)
Fase: Configurar Personaje y Unidades
orden: 21

### 🧭 **Tarea:** Implementar movimiento de héroe

**Descripción técnica detallada:**

Desarrollar el sistema de locomoción del personaje héroe utilizando el nuevo Input System de Unity. El sistema debe permitir desplazamiento fluido, rotación, y sincronización con animaciones de movimiento. Esta funcionalidad representa el primer pilar jugable del prototipo y será la base sobre la que se integrarán mecánicas como combate, habilidades y control de escuadras.

---

### 🎮 **Funcionalidades requeridas:**

- Movimiento en 8 direcciones usando teclado (`WASD`) y/o gamepad.
- Integración con cámara libre o de seguimiento (Cinemachine).
- Rotación automática del héroe en dirección del movimiento o hacia la cámara.
- Sincronización con animaciones de Idle, Walk y Run vía Blend Tree.
- Input gestionado mediante `PlayerInput` y `InputActionAsset`.
- Implementación de ground check (detección de suelo).
- Código desacoplado del input para posible uso por IA más adelante.

---

### ⚙️ **Requisitos técnicos**

- Uso obligatorio del `Input System Package`.
- Script modular, nombrado por convención: `HeroMovementController.cs`.
- Uso de `CharacterController` o `Rigidbody` con física controlada (según estándar del proyecto).
- `InputActions` definidos: `Move`, `Look`, `Run` (opcional).
- Animator debe estar conectado a los valores de velocidad/estado (`float blend`, `bool isMoving`).

---

### 🧪 **Criterios de aceptación**

- El héroe se desplaza fluidamente en 360°.
- Rotación responde al movimiento sin jitter o errores.
- Las animaciones cambian según el estado (idle ↔ walk ↔ run).
- Input responde sin retraso perceptible.
- El sistema se integra sin conflictos en la escena de prueba (`MainScene`).
- El código es reutilizable, comentado y pasa testeo visual en editor.

# Implementar detección de impacto (raycast o hitbo 214df9df7102816090f9c5fd43a0e534

# Implementar detección de impacto (raycast o hitbox)

Descripción: Detectar colisiones entre ataques del héroe o unidades y entidades enemigas, usando raycast o colliders con trigger.
Prioridad: Alta
Etiquetas: Gameplay
Etapa: Por hacer
Sistema Principal: Sistema de Combate
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md)
Fase: Mecánicas de Combate
orden: 43

### 🧭 **Tarea:** Implementar detección de impacto (raycast o hitbox)

**Descripción técnica detallada:**

Implementar la lógica para detectar si un ataque (de héroe o unidad) impacta sobre un objetivo válido. Esta detección puede realizarse mediante colisiones físicas (`OnTriggerEnter`) o raycasts proyectados desde el arma o la animación del personaje. Esta tarea marca el inicio de cualquier proceso de combate y es responsable de enviar la información necesaria al sistema de cálculo de daño para aplicar los efectos correspondientes.

---

### 🎮 **Funcionalidades requeridas:**

- Métodos de detección:
    - **Hitbox física**: collider con `isTrigger` activado (arma o efecto).
    - **Raycast/SphereCast** desde la posición del ataque.
    - **Animation Event** opcional para activar detección en momentos precisos.
- Filtro de objetivos válidos:
    - Por `Tag` (Enemy, Unit).
    - Por `LayerMask` (para evitar impacto a aliados o a uno mismo).
- Al detectar un impacto:
    - Registrar entidad objetivo.
    - Ejecutar `ApplyDamage()` con los datos del atacante.
    - Disparar feedback visual (opcional): flash, número flotante, sonido.

---

### ⚙️ **Requisitos técnicos**

- Script `DamageTriggerZone` o `AttackColliderHandler` para detección por collider.
- Script `RaycastAttackDetector` para ataques por rango o habilidad dirigida.
- Prefabs de armas o habilidades deben tener collider `Trigger` o punto de emisión del raycast.
- El atacante debe contener un `DamageData` o `WeaponStats` activo.
- Tiempo de activación controlado por:
    - Animación (via Event).
    - Ventana de impacto (delay desde inicio de ataque).
- En combate melee, el hitbox debe activarse solo durante la ventana de daño.

---

### 🧪 **Criterios de aceptación**

- Los ataques del héroe detectan correctamente al colisionar con una unidad enemiga.
- La detección se produce solo una vez por ataque (no múltiples hits por frame).
- No se generan impactos con el mismo equipo o con el propio atacante.
- El sistema de daño es invocado al detectar un objetivo válido.
- El tipo de daño (cortante, contundente, perforante) es enviado correctamente al siguiente paso del sistema de combate.

# Implementar detección de impacto 215df9df71028027839ff538b6753904

# Implementar detección de impacto

Descripción: Detectar colisiones entre ataques físicos (melee o proyectiles) y entidades vulnerables para disparar el cálculo de daño.
Prioridad: Alta
Etiquetas: Sistema de Combate, Técnica
Etapa: Por hacer
Sistema Principal: Control del Héroe
Fase: Mecánicas de Combate
ítem principal: Sistema de Combate (Sistema%20de%20Combate%20214df9df71028168a6bfd00b49d24c34.md)

### 🧭 **Tarea:** Implementar detección de impacto

**Descripción técnica detallada:**

Programar el sistema responsable de detectar cuándo un ataque conecta con una entidad, ya sea mediante colisiones físicas (`OnTriggerEnter`), raycasts, o eventos sincronizados con animaciones. Este sistema actúa como primer paso del pipeline de combate: al validar un impacto, delega la aplicación de daño al componente correspondiente y genera eventos de retroalimentación visual o lógica.

---

### 🎮 **Funcionalidades requeridas:**

- Sistema de detección flexible para:
    - Ataques cuerpo a cuerpo (espada, lanza, guja).
    - Ataques a distancia (proyectiles físicos en futuro).
- Métodos soportados:
    - `OnTriggerEnter()` en colisionadores de armas.
    - `Physics.Raycast()` o `SphereCast()` desde el punto de ataque.
    - `Animation Event` para disparar detección en frames clave.
- Filtro por `LayerMask` y `Tag` para evitar auto-impactos y limitar alcance.
- Registro del objetivo impactado con validación de vida y vulnerabilidad.
- Llamada al sistema de combate para ejecutar cálculo de daño.

---

### ⚙️ **Requisitos técnicos**

- Collider tipo `Trigger` en la zona activa del arma (puede ser activado/desactivado).
- Script `DamageTriggerZone` o equivalente conectado al arma o habilidad.
- Posibilidad de asignar tipo de daño desde la fuente (`DamageComponent`, `WeaponData`).
- Integración con `HealthComponent` del objetivo.
- Debe respetar reglas de tiempo: no aplicar daño múltiple por frame a la misma entidad.

---

### 🧪 **Criterios de aceptación**

- Un arma equipada por el héroe puede generar impacto en una unidad objetivo.
- El impacto se detecta exactamente cuando la animación lo indica.
- El sistema registra al objetivo impactado y llama a `ApplyDamage()`.
- No hay autoimpactos ni impactos duplicados en un mismo frame.
- Es posible habilitar y deshabilitar zonas de daño dinámicamente (ej. al principio y fin de un ataque).

# Implementar estados básicos (Idle, Follow, Attack 214df9df7102819283ddd6bf487eb4b0

# Implementar estados básicos (Idle, Follow, Attack)

Descripción: Establecer la lógica de estados mínima para que una unidad o escuadra responda a órdenes y actúe de manera coherente en el entorno de combate.
Prioridad: Alta
Etiquetas: Gameplay, Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Gestión de Escuadra, IA de Tropas
Bloqueado por: Implementar sistema de órdenes básicas (Implementar%20sistema%20de%20o%CC%81rdenes%20ba%CC%81sicas%20214df9df71028178b6e0d76c81158398.md)
Fase: Mecánicas de Combate
orden: 47

### **🧭 Tarea:** Implementar estados básicos (Idle, Follow, Attack)

**Descripción técnica detallada:**

Implementar una **máquina de estados simple y robusta** que controle el comportamiento de cada unidad o escuadra, comenzando con tres estados fundamentales: **Idle**, **Follow**, y **Attack**. Esta lógica permite que las unidades permanezcan en reposo, sigan a su líder (ej. héroe), o se enfrenten a un enemigo cuando reciben una orden de ataque. La transición entre estados debe ser fluida, sin conflictos, y capaz de ejecutarse en tiempo real durante la partida.

---

### 🎮 **Funcionalidades requeridas:**

### Estados:

- **Idle**
    - La unidad se mantiene en posición, con animación base o pose pasiva.
    - Escucha nuevas órdenes.
- **Follow**
    - La unidad sigue al líder (ej. héroe o escuadra) manteniendo distancia/formación.
    - Usa `NavMeshAgent` para navegar.
    - Alineación con slots de formación si está activo el sistema.
- **Attack**
    - La unidad se mueve hacia un objetivo hostil y lo ataca al estar dentro de rango.
    - Verifica constantemente rango y línea de visión.
    - Cambia a Idle si el objetivo muere o se pierde.

---

### ⚙️ **Requisitos técnicos**

- Script `UnitAIController.cs` o `UnitStateMachine.cs`:
    - Sistema FSM (Finite State Machine) interno por unidad.
    - Estado actual (`UnitState` enum): `Idle`, `Follow`, `Attack`.
    - Métodos:
        
        ```csharp
        csharp
        CopiarEditar
        void SetState(UnitState newState);
        void UpdateState();
        
        ```
        
- Transiciones válidas:
    - Idle → Follow (por orden de movimiento).
    - Idle → Attack (por orden o proximidad enemiga).
    - Follow → Idle (al detenerse o llegar).
    - Attack → Idle (objetivo muerto/fuera de rango).
- Acceso al `NavMeshAgent`, `Animator`, y `TargetDetector`.

---

### 🧪 **Criterios de aceptación**

- Las unidades se encuentran en `Idle` por defecto y esperan órdenes.
- Al recibir orden de seguir, entran en estado `Follow` y se mueven hacia su líder.
- Al recibir orden de ataque, se aproximan al objetivo y lo atacan si es posible.
- Los estados cambian correctamente sin interferencias ni loops erróneos.
- El sistema es extensible a nuevos estados (ej. `Retreat`, `Flank`, `Patrol`).
- El comportamiento visual (animación, orientación) refleja el estado actual.

# Implementar movimiento de héroe 214df9df7102817aa696f1bf9ad434c9

# Implementar movimiento de héroe

Descripción: Desarrollar el sistema de locomoción del héroe, desde el prefab hasta el comportamiento visual completo.
Prioridad: Alta
Etiquetas: Control del Héroe
Etapa: En progreso
Sistema Principal: Control del Héroe
Bloqueado por: Implementar controlador de cámara del héroe (Implementar%20controlador%20de%20ca%CC%81mara%20del%20he%CC%81roe%20214df9df7102819e97d6fd1375f01854.md)
Bloqueando: Vincular animaciones de movimiento (Vincular%20animaciones%20de%20movimiento%20214df9df71028186a99dddcaace1292a.md)
Fase: Mecánicas de Combate
orden: 40

### 🧭 **Tarea:** Implementar movimiento de héroe

**Descripción técnica detallada:**

Desarrollar el sistema de locomoción del personaje héroe en tercera persona utilizando el nuevo Input System de Unity. El sistema debe permitir desplazamiento fluido, rotación, y sincronización con animaciones de movimiento. Esta funcionalidad representa el primer pilar jugable del prototipo y será la base sobre la que se integrarán mecánicas como combate, habilidades y control de escuadras.

---

### 🎮 **Funcionalidades requeridas:**

- Movimiento en 8 direcciones usando teclado (`WASD`) y gamepad.
- Integración con cámara libre o de seguimiento (Cinemachine).
- Rotación automática del héroe en dirección del movimiento o hacia la cámara.
- Sincronización con animaciones de Idle, Walk y Run vía Blend Tree.
- Controlado mediante `PlayerInput` y `InputActionAsset`.
- Soporte para sistema de ground check (para evitar flotar).
- Limitación de velocidad por tipo de superficie o estado (future-proof).
- Código desacoplado para facilitar testeo y mantenimiento.

---

### ⚙️ **Requisitos técnicos**

- Uso del `Input System Package` de Unity.
- Sistema implementado en componente `HeroMovementController` o equivalente.
- Movimiento basado en `CharacterController` o `Rigidbody` (según preferencia de física).
- Input Actions configurados: `Move`, `Look`, `Run` (opcional).
- Interacción con Animator Controller por parámetro de velocidad.

---

### 🧪 **Criterios de aceptación**

- El héroe se mueve con fluidez en 8 direcciones.
- La cámara sigue correctamente al personaje mientras se mueve.
- Las animaciones cambian de Idle a caminar/correr según la velocidad.
- El input responde sin latencia visible (< 100ms).
- El sistema puede pausar o desactivarse sin errores.
- Código implementado es modular, comentado y probado en escena.

# Implementar pantalla de login (usuario y contrasen 216df9df710281ee9993f49d1070f145

# Implementar pantalla de login (usuario y contraseña)

Descripción: Interfaz para ingresar credenciales y validarlas en sistema local o servidor.
Prioridad: Alta
Etiquetas: Login, Usuario
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Bloqueando: Botón “Entrar” para confirmar personaje seleccionado (Boto%CC%81n%20%E2%80%9CEntrar%E2%80%9D%20para%20confirmar%20personaje%20seleccion%20216df9df71028101adcaefbc3da79d52.md)
Fase: Login y Selección de Personaje
orden: 10

### 🧭 **Tarea:** Implementar pantalla de login (usuario y contraseña)

**Descripción técnica detallada:**

La pantalla de login es el primer paso del flujo de usuario en el juego. Permite a los jugadores ingresar sus credenciales para iniciar sesión con su cuenta. Esta pantalla valida los datos ingresados, y si son correctos, permite el acceso a la selección de personajes. En este MVP, la validación puede realizarse localmente con datos simulados o conectarse a un backend si ya está disponible.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar campos:
    - `InputField` de nombre de usuario.
    - `InputField` de contraseña (con enmascarado).
- Botón “Iniciar sesión”:
    - Validación de campos llenos.
    - Feedback visual en caso de error o éxito.
- Opción de guardar credenciales (opcional).
- Transición automática a la pantalla de selección de personajes tras login exitoso.
- Mensaje de error si las credenciales no son válidas.

---

### ⚙️ **Requisitos técnicos**

- Prefab: `LoginScreenUI`
    - Contiene:
        - Campos de texto
        - Botón
        - Mensaje de estado (`ErrorText`, `LoadingIcon`)
- Script: `LoginManager.cs`
    - Método `ValidateCredentials(string user, string pass)`
    - Simulación local: comparación contra archivo de perfiles (`/Resources/LocalAccounts.json`)
    - Alternativa online: enviar `POST` a endpoint API de login
- Transición con:
    
    ```csharp
    SceneManager.LoadScene("CharacterSelection")
    ```
    
- Seguridad mínima: enmascarar campos, bloquear múltiples clics.

---

### 🧪 **Criterios de aceptación**

- El usuario puede ingresar texto en ambos campos sin errores.
- Al presionar “Iniciar sesión”:
    - Se bloquea la UI temporalmente.
    - Se muestra mensaje de carga.
    - Si es válido, pasa a la siguiente escena.
    - Si es inválido, muestra mensaje claro y reactiva la UI.
- Funciona en flujo continuo con el resto del sistema de usuario.
- Está visualmente alineado con el resto del diseño general del juego.

# Implementar puntos de captura (Banderas) con lógi 217df9df7102801e81e8c94bca1bc621

# Implementar puntos de captura (Banderas) con lógica de conquista unilateral

Descripción: Agregar banderas en el mapa de batalla que pueden ser capturadas por el atacante, pero no reconquistadas por el defensor.
Prioridad: Alta
Etiquetas: Batalla, Captura, Condiciones de victoria, Mapa de batalla
Etapa: Backlog
Sistema Principal: Batalla
Fase: Batalla
orden: 59

### 🧭 **Tarea:** Implementar puntos de captura (Banderas) con lógica de conquista unilateral

**Descripción técnica detallada:**

Las Banderas representan los objetivos principales del equipo atacante en la batalla de feudo. Son puntos de control estáticos, colocados previamente en el mapa y en poder del defensor al inicio. Cada bandera tiene una zona de acción que detecta la presencia de héroes enemigos (atacantes).

Si un atacante permanece dentro de esta zona sin interrupciones durante un tiempo determinado, la bandera se considera capturada. Una vez capturada, **el equipo defensor ya no puede recuperarla**, ni siquiera si vuelve a tener control del área.

La lógica de conquista debe incluir una barra de progreso visual (en UI o en mundo), bloqueo por múltiples jugadores, y eventos que permitan al sistema evaluar si se ha ganado la partida.

---

### 🎮 **Funcionalidades requeridas:**

- Crear prefab `CapturePoint_Bandera` con:
    - Área de captura (Trigger).
    - Estado: `ControladaPorDefensor`, `Capturándose`, `CapturadaPorAtacante`.
    - Visual (bandera, color, ícono).
- Lógica:
    - Solo héroes del equipo atacante pueden activar la captura.
    - Si un atacante entra en el área y permanece durante `X` segundos sin salir → captura exitosa.
    - Se muestra barra de progreso de captura (en UI y/o sobre la bandera).
    - Una vez capturada:
        - Se cambia el estado visual (por ejemplo, bandera cambia de color).
        - El defensor no puede volver a capturarla.
- Notificación del evento a un sistema global de control de batalla.

---

### ⚙️ **Requisitos técnicos**

- Script `CapturePointController.cs`:
    - Campos:
        
        ```csharp
        enum CaptureState { Defended, InProgress, Captured }
        Team ownerTeam;
        float captureTimer;
        bool canBeRecaptured = false;
        ```
        
    - Métodos:
        - `OnTriggerEnter(Collider c)` → verifica si es un atacante
        - `UpdateCaptureProgress()`
        - `FinalizeCapture()`
- UI opcional:
    - `CaptureProgressUI` anclada sobre el punto o HUD.
- Visual:
    - `FlagMaterialSwitcher` o `Animator` para cambiar el emblema/bandera.
- Integración con sistema de condición de victoria (ver futura tarea).

---

### 🧪 **Criterios de aceptación**

- Las banderas inician en control del defensor y aparecen correctamente en el mapa.
- Solo los héroes del bando atacante pueden iniciar la captura.
- La barra de progreso se incrementa solo si el atacante está en el área.
- Si sale antes de terminar, el progreso se reinicia.
- Una vez capturada:
    - La bandera cambia visualmente.
    - No puede ser reconquistada por el defensor.
- El evento de captura se puede registrar para lógica de victoria.

# Implementar sistema de cronómetro global de batal 217df9df710280e0a05ddafdd72909a1

# Implementar sistema de cronómetro global de batalla

Descripción: Crear un temporizador visible que determine la duración de la partida y dispare la victoria del defensor si el atacante no conquista las banderas a tiempo.
Prioridad: Alta
Etiquetas: Condiciones de victoria, Feudo, Tiempo, UI
Etapa: Backlog
Sistema Principal: Batalla
Fase: Batalla
orden: 56

### 🧭 **Tarea:** Implementar sistema de cronómetro global de batalla

**Descripción técnica detallada:**

La batalla de feudo tiene una duración fija. Si el equipo atacante **no logra capturar todas las banderas** antes de que el tiempo llegue a cero, la victoria debe ser otorgada automáticamente al equipo defensor.

Este sistema requiere un temporizador central que se inicie al comenzar el combate, actualice una visual en pantalla y dispare la condición de victoria defensiva al finalizar. Debe integrarse con el sistema de control de batalla para evitar conflictos si el atacante gana antes de que el tiempo se agote.

---

### 🎮 **Funcionalidades requeridas:**

- Al comenzar la batalla (fase de combate), iniciar el temporizador global (ej. 10 minutos).
- Mostrar el cronómetro al jugador en pantalla (HUD).
- El temporizador cuenta hacia atrás en tiempo real.
- Al llegar a cero:
    - Verificar si el atacante **no ha capturado todas las banderas**.
    - Si es así, declarar victoria del defensor.
- Si el atacante gana antes de que el tiempo termine, detener el cronómetro y no disparar condición doble.

---

### ⚙️ **Requisitos técnicos**

- Script `BattleTimer.cs`:
    - Variables:
        
        ```csharp
        float timeRemaining;
        bool isRunning;
        ```
        
    - Métodos:
        - `StartTimer(float duration)`
        - `UpdateTimer()` en `Update()`
        - `OnTimerFinished()` → llama a `BattleManager.TriggerVictoryForDefender()`
- Integración con:
    - `BattleManager`: para sincronizar con captura de banderas.
    - `UIBattleTimer`: componente UI que muestra el tiempo restante.
- Interacción:
    - Si `BattleManager.battleEnded == true`, detener el cronómetro.

---

### 🧪 **Criterios de aceptación**

- El cronómetro se inicia correctamente al comienzo del combate.
- El jugador ve el tiempo restante en pantalla en todo momento.
- Al llegar a cero, si el atacante no capturó las 3 banderas, el defensor gana.
- Si el atacante gana antes, el cronómetro se detiene sin errores.
- No se disparan condiciones de victoria contradictorias.

# Implementar sistema de órdenes básicas 214df9df71028178b6e0d76c81158398

# Implementar sistema de órdenes básicas

Descripción: Desarrollar la lógica que permite emitir, interpretar y ejecutar órdenes simples sobre la escuadra del jugador.
Prioridad: Alta
Etiquetas: Gameplay, Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Gestión de Escuadra
Bloqueado por:  Vincular escuadra al héroe jugador (Vincular%20escuadra%20al%20he%CC%81roe%20jugador%20214df9df7102817db0e9c135014e9e91.md)
Bloqueando: Gestión de Escuadras (Órdenes Básicas) (Gestio%CC%81n%20de%20Escuadras%20(O%CC%81rdenes%20Ba%CC%81sicas)%20214df9df7102810bae94d0178b87ec78.md), Implementar estados básicos (Idle, Follow, Attack) (Implementar%20estados%20ba%CC%81sicos%20(Idle,%20Follow,%20Attack%20214df9df7102819283ddd6bf487eb4b0.md)
Fase: Mecánicas de Combate
ítem principal: Gestión de Escuadras (Órdenes Básicas) (Gestio%CC%81n%20de%20Escuadras%20(O%CC%81rdenes%20Ba%CC%81sicas)%20214df9df7102810bae94d0178b87ec78.md)

### 🧭 **Tarea:** Implementar sistema de órdenes básicas

**Descripción técnica detallada:**

Construir el núcleo funcional del sistema de control de escuadras. Esta tarea se centra en la arquitectura lógica y los estados de comportamiento que permiten a una escuadra recibir una orden del jugador (como seguir, esperar o atacar) y actuar en consecuencia. El sistema debe ser robusto, fácilmente ampliable, y orientado a modularidad por estado.

---

### 🎮 **Funcionalidades requeridas:**

- Tipos de orden mínima:
    - **Seguir** (`FollowLeader`)
    - **Esperar** (`HoldPosition`)
    - **Atacar** (`EngageTarget`)
- Cada unidad de la escuadra debe cambiar su estado de IA de forma sincronizada.
- Las órdenes pueden recibirse mediante:
    - Teclas (`1`, `2`, `3`)
    - Función externa (`IssueOrder(SquadOrderType)`).
- Las unidades deben:
    - Cambiar comportamiento según la orden.
    - Conservar su posición relativa si es necesario.
    - Ignorar órdenes si están en condición de no respuesta (morale baja, muerte, etc.).

---

### ⚙️ **Requisitos técnicos**

- Enumerador `SquadOrderType` con valores: `Follow`, `Hold`, `Attack`.
- Script `SquadOrderSystem` o controlador centralizado en el `SquadController`.
- FSM interna en cada unidad con estados coincidentes.
- Eventos enviados desde el controlador a cada miembro: `unit.ReceiveOrder(SquadOrderType)`.
- Método de validación de objetivo para orden de ataque (raycast, selección, distancia).
- Sistema desacoplado de la UI o input específico (puede recibir órdenes desde otros sistemas).

---

### 🧪 **Criterios de aceptación**

- La escuadra cambia su comportamiento correctamente según la orden recibida.
- Todos los miembros actualizan su estado sincronizadamente.
- No se reciben múltiples órdenes al mismo tiempo (deben ser secuenciales o sobrescritas).
- Las órdenes no aplican si la unidad está muerta o deshabilitada.
- El sistema es modular y puede ampliarse para órdenes complejas (flanquear, mantener posición, reagrupar).

# Implementar sistema de selección de punto de spaw 216df9df7102806583a4fa71bc27d052

# Implementar sistema de selección de punto de spawn (atacante/defensor)

Descripción: Permitir al jugador elegir entre 3 puntos válidos según su bando antes del combate.
Prioridad: Alta
Etiquetas: Preparación, UI
Etapa: Backlog
Sistema Principal: Mapas
Bloqueado por: Diseñar layout base del Mapa de Batalla de Feudo (Disen%CC%83ar%20layout%20base%20del%20Mapa%20de%20Batalla%20de%20Feudo%20216df9df7102803f8cfee8d9d0d48f52.md)
Bloqueando: Selector de punto de spawn por bando (mini mapa interactivo) (Selector%20de%20punto%20de%20spawn%20por%20bando%20(mini%20mapa%20in%20216df9df710281e3afcbf2a79012e9d7.md)
Fase: Preparación de Combate
orden: 30

### 🧭 **Tarea:** Implementar sistema de selección de punto de spawn (atacante/defensor)

**Descripción técnica detallada:**

Antes del inicio del combate, cada jugador debe poder elegir en qué punto de spawn desea iniciar la partida. Estos puntos están predefinidos y asociados a un bando (atacante o defensor). El sistema debe cargar y mostrar solamente los puntos válidos para el bando del jugador. Al hacer clic sobre un punto, debe registrarse la selección de forma confiable para ser utilizada al momento de hacer spawn del héroe y su escuadra.

---

### 🎮 **Funcionalidades requeridas:**

- Determinar el bando del jugador (atacante o defensor).
- Cargar solo los puntos de spawn válidos para ese bando.
- Mostrar visualmente los puntos en pantalla de preparación.
- Permitir al jugador seleccionar solo uno.
- Destacar visualmente el punto seleccionado.
- Guardar internamente el `SpawnPointID` elegido por el jugador.

---

### ⚙️ **Requisitos técnicos**

- Script `SpawnPointSelector.cs`:
    - Recibe datos del jugador (`PlayerSide`)
    - Filtra puntos con etiqueta/tag `AttackerSpawn` o `DefenderSpawn`
    - Expone función `SelectSpawn(SpawnPoint point)`
- Prefabs de `SpawnPoint`:
    - Contienen datos como ID, posición, orientación y bando.
- Integración con:
    - `PreparationPhaseManager` para confirmar selección válida.
    - `CombatInitializer` para instanciar al jugador en ese punto.

---

### 🧪 **Criterios de aceptación**

- El jugador solo puede ver y seleccionar puntos válidos según su bando.
- Una vez seleccionado, el punto queda visualmente marcado.
- El sistema recuerda el punto elegido y lo usa correctamente en el spawn real.
- No se puede cambiar el punto después de confirmar.
- La lógica funciona tanto en local como en red (si aplica).

# Implementar slots dinámicos para formaciones 214df9df7102817fbf5be4d9d6334072

# Implementar slots dinámicos para formaciones

Descripción: Asignar posiciones relativas a cada unidad de la escuadra según la formación activa, con adaptabilidad al movimiento y cambios de orden.
Prioridad: Alta
Etiquetas: Gameplay, Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Formaciones, Gestión de Escuadra
Bloqueado por: Gestión de Escuadras (Órdenes Básicas) (Gestio%CC%81n%20de%20Escuadras%20(O%CC%81rdenes%20Ba%CC%81sicas)%20214df9df7102810bae94d0178b87ec78.md), Sistema de Formaciones (Estructura Táctica) (Sistema%20de%20Formaciones%20(Estructura%20Ta%CC%81ctica)%20214df9df710281898045ff92b43d8fea.md)
Fase: Mecánicas de Combate
Subítem: Cambiar formación en tiempo real por orden del jugador (Cambiar%20formacio%CC%81n%20en%20tiempo%20real%20por%20orden%20del%20ju%20215df9df71028033935ff0f0c47b3b40.md)
orden: 48

### 🧭 **Tarea:** Implementar slots dinámicos para formaciones

**Descripción técnica detallada:**

Desarrollar un sistema de slots dinámicos que permita posicionar a las unidades de una escuadra según una formación definida (ej: línea, columna, cuña, escudo). Cada slot representa una posición relativa al líder de la escuadra o al centro de la formación, y se actualiza automáticamente cuando la escuadra se mueve, se detiene o cambia de estado. El sistema debe ser modular, reutilizable y capaz de cambiar entre distintas configuraciones durante la partida.

---

### 🎮 **Funcionalidades requeridas:**

- Definir **estructuras de formación** como conjuntos de `slots`:
    - Posiciones relativas a un origen (centro o líder).
    - Capacidad de almacenar transformaciones 2D/3D (posición, rotación).
- Permitir **cambiar de formación** durante la partida:
    - Recalcular posiciones destino de cada unidad.
    - Realinear sin colisiones ni bloqueos.
- Las unidades deben:
    - Navegar a su `slot` asignado según la formación activa.
    - Reajustar su posición en tiempo real si la escuadra se desplaza o gira.
- Formaciones mínimas para MVP:
    - Línea
    - Columna
    - Cuña (en V)
    - Escudo (defensiva, cerrada)
- Integración con sistema de órdenes: `Hold`, `MoveTo`, `Engage`.

---

### ⚙️ **Requisitos técnicos**

- Clase `FormationData` o `FormationProfile`:
    
    ```csharp
    public class FormationSlot {
        public Vector3 localPosition;
        public Quaternion rotation;
    }
    
    public class FormationData {
        public string formationName;
        public List<FormationSlot> slots;
    }
    ```
    
- Cada escuadra tiene una formación activa y referencia a `List<FormationSlot>`.
- Script `FormationController` o función dentro de `SquadController` para asignar slots a unidades.
- Las unidades usan `NavMeshAgent.SetDestination()` hacia su slot actualizado.
- Cambio de formación debe:
    - Reasignar unidades por índice o rol.
    - Reposicionar sin glitches (tiempo de transición opcional).

---

### 🧪 **Criterios de aceptación**

- Cada unidad mantiene su posición relativa dentro de la formación activa.
- Al cambiar de formación, todas las unidades se reubican correctamente.
- La escuadra puede moverse y mantener su cohesión en tiempo real.
- Se pueden definir nuevas formaciones fácilmente sin reescribir lógica central.
- El sistema está desacoplado del sistema de animación o combate directo.
- La lógica funciona con diferentes tamaños de escuadra (3, 5, 8 unidades, etc.).

# Implementar verificador de condición de victoria 217df9df710280e58d33cb6416499ce3

# Implementar verificador de condición de victoria

Descripción: Detectar cuándo se cumplen las condiciones para terminar la batalla y declarar un ganador.
Prioridad: Alta
Etiquetas: Batalla, Condiciones de victoria, Feudo, Mapa de batalla, Tiempo
Etapa: Backlog
Sistema Principal: Batalla
Fase: Batalla
orden: 55

### 🧭 **Tarea:** Implementar verificador de condición de victoria

**Descripción técnica detallada:**

La batalla de feudo puede terminar de dos formas:

1. **Victoria del atacante** si logra capturar las 3 banderas del defensor.
2. **Victoria del defensor** si el tiempo del cronómetro llega a cero y el atacante no completó su objetivo.

Este verificador debe centralizar la evaluación del estado de la batalla en un solo punto del código (`BattleManager`) y disparar el cierre de partida en función del estado de banderas o tiempo restante. También debe **prevenir condiciones múltiples**, asegurándose de que una vez se ha declarado un ganador, no se pueda activar otra condición.

---

### 🎮 **Funcionalidades requeridas:**

- Registrar cada vez que se captura una bandera o se termina el tiempo.
- Verificar si una condición de victoria se ha cumplido:
    - `capturedFlags == 3` → atacante gana.
    - `timeRemaining == 0 && capturedFlags < 3` → defensor gana.
- Una vez disparada, bloquear más interacciones y acciones de combate.
- Enviar resultado al sistema de fin de partida para mostrar la pantalla de resultados.
- Marcar la batalla como cerrada.

---

### ⚙️ **Requisitos técnicos**

- Script `BattleManager.cs`:
    - Campo: `bool battleEnded`
    - Métodos:
        
        ```csharp
        void CheckVictoryCondition();
        void TriggerVictoryForAttacker();
        void TriggerVictoryForDefender();
        ```
        
    - Todos los sistemas (cronómetro, captura de bandera) llaman a `CheckVictoryCondition()` tras su evento.
- Sistema debe garantizar que `battleEnded == true` evita nuevas evaluaciones.
- Integración con:
    - `EndBattleHandler` para pasar datos al resumen final.
    - `BattleTimer`, `CapturePointController` → todos reportan aquí.

---

### 🧪 **Criterios de aceptación**

- Al capturar la tercera bandera, se dispara correctamente la victoria del atacante.
- Al agotarse el tiempo sin cumplir el objetivo, gana el defensor.
- Solo se puede disparar una condición de victoria por partida.
- El estado `battleEnded` previene condiciones múltiples.
- El flujo hacia la pantalla de resultados se inicia automáticamente.

# Implementar viewer 3D del héroe en la interfaz 215df9df710280fa8ae0c9a5ef1a7a8d

# Implementar viewer 3D del héroe en la interfaz

Descripción: Mostrar en la UI un modelo 3D interactivo del héroe con su equipamiento y apariencia actual.
Prioridad: Alta
Etiquetas: Control del Héroe, UI
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

### 🧭 **Tarea:** Implementar viewer 3D del héroe en la interfaz

**Descripción técnica detallada:**

Agregar una ventana de visualización en tiempo real dentro de la interfaz de stats del héroe que renderice su modelo completo, equipado con los objetos y skin seleccionados. Esta vista debe permitir rotar la cámara libremente alrededor del personaje para inspeccionar su apariencia. Este viewer debe ser independiente del gameplay, instanciado solo para propósitos de interfaz y visualización estática o animada.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar modelo 3D completo del héroe:
    - Equipamiento actual (arma, armadura).
    - Skin cosmética aplicada.
- Pose idle o animación de espera.
- Cámara orbitante con rotación por mouse o controles UI.
- Posibilidad de hacer zoom o ajustar ángulo (opcional).
- Viewer encapsulado para evitar interferencia con cámaras de gameplay.
- Espacio bien definido en la UI, sin superposiciones ni recortes.

---

### ⚙️ **Requisitos técnicos**

- RenderTexture o subescena 3D dentro de un panel de la UI.
- Instanciación del modelo en un `HeroPreviewScene` o `PreviewHolder` oculto al mundo principal.
- Uso de `PreviewCameraController` para rotación horizontal, vertical y zoom.
- Carga automática de visual del héroe cuando se abre el panel.
- Sin lógica de input o gameplay activa en este modelo.

---

### 🧪 **Criterios de aceptación**

- El modelo del héroe se muestra correctamente al abrir la UI.
- Cambiar de equipo o skin actualiza el modelo al instante.
- El jugador puede rotar la cámara y observar el personaje desde todos los ángulos.
- La vista 3D no interfiere con gameplay ni con otras cámaras.
- El sistema puede desinstanciar el modelo al cerrar la UI sin fugas de memoria.

# Implementar visualización y edición de stats 215df9df710280d0bfc3d601a3f3a02a

# Implementar visualización y edición de stats

Descripción: Mostrar los atributos base del héroe y permitir modificarlos si el jugador tiene puntos disponibles.
Prioridad: Alta
Etiquetas: Control del Héroe, UI
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

## 🧭 **Tarea:** Implementar visualización y edición de stats

**Descripción técnica detallada:**

Construir la lógica funcional de la sección de estadísticas del héroe en la UI. Esta sección debe mostrar los valores actuales de los atributos modificables (Fuerza, Destreza, Vitalidad, Armadura), así como los atributos derivados (Vida, Daño por tipo, Liderazgo). Si el jugador tiene puntos de mejora disponibles, podrá asignarlos directamente mediante botones en la misma interfaz.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar valores actuales de los siguientes atributos:
    - **Base**: Fuerza, Destreza, Vitalidad, Armadura.
    - **Derivados**: Vida máxima, Daño cortante/perforante/contundente, Liderazgo.
- Mostrar puntos disponibles para asignar (`Puntos: 3`).
- Botones + para cada atributo base si hay puntos disponibles.
- Al hacer clic en un botón +:
    - Aumenta el atributo en +1.
    - Resta 1 punto disponible.
    - Recalcula y actualiza valores derivados en pantalla.
- Deshabilitar botones si no hay puntos disponibles.
- Opción de “Reiniciar” o “Restablecer” (opcional, si se permite reconfigurar).

---

### ⚙️ **Requisitos técnicos**

- Referencia al objeto `HeroData` o `HeroStats` para lectura y escritura de valores.
- Script `HeroStatsUIController.cs` que maneje los eventos de la interfaz.
- UI vinculada a los campos con `TextMeshProUGUI` y `Button`.
- Los cálculos deben ser en tiempo real:
    - Vida = base + Vitalidad × n
    - Daño = base + (Fuerza o Destreza) según tipo
- Evitar modificaciones si la UI está bloqueada (modo visualización).

---

### 🧪 **Criterios de aceptación**

- Los atributos se visualizan correctamente al abrir la interfaz.
- Si el jugador tiene puntos, puede asignarlos y ver el cambio al instante.
- El sistema previene asignaciones inválidas (sin puntos disponibles).
- Los valores derivados cambian correctamente al modificar un atributo.
- Todos los cambios permanecen visibles hasta confirmar o salir de la interfaz.

# Instalar paquetes esenciales 214df9df7102818d9303dbfc770fd502

# Instalar paquetes esenciales

Descripción: Agregar Input System, Cinemachine, TextMeshPro, Mirror.
Prioridad: Alta
Etiquetas: Técnica, Unity
Etapa: En progreso
Sistema Principal: Control del Héroe, Multiplayer
Bloqueado por: Crear proyecto Unity (2022.3 LTS) (Crear%20proyecto%20Unity%20(2022%203%20LTS)%20214df9df710281e1a4b1d1893842a462.md)
Fase: Setup Técnico Inicial
orden: 7

### 🧭 **Tarea:** Instalar paquetes esenciales

**Descripción técnica detallada:**

Instalar e integrar los paquetes de Unity fundamentales para las funcionalidades del prototipo. Estos paquetes son necesarios para manejar entradas del jugador, cámaras de seguimiento, texto en pantalla y funcionalidad de red. Todos deben ser importados desde el Package Manager y validados en su compatibilidad con la versión actual del proyecto.

---

### 🎮 **Funcionalidades requeridas:**

- **Input System**: manejo de entrada moderna multiplataforma.
- **Cinemachine**: control de cámara en tercera persona con seguimiento y look-around.
- **TextMeshPro**: sistema de texto UI avanzado y optimizado.
- **Mirror**: sistema de networking cliente-servidor para futuras pruebas multijugador.

---

### ⚙️ **Requisitos técnicos**

- Todos los paquetes deben ser instalados desde Unity Package Manager (no manualmente).
- Confirmar compatibilidad con Unity 2022.3 LTS.
- Crear carpeta `/Packages/Configs` para almacenar settings personalizados si aplica.
- Configurar `Input System` como modo activo de entrada en `Project Settings > Player > Active Input Handling = Input System Package`.
- Validar que `TextMeshPro` tenga fuentes y assets iniciales generados.
- Mirror debe instalarse desde Git URL (`https://github.com/MirrorNetworking/Mirror.git#release`) o asset store si disponible.

---

### 🧪 **Criterios de aceptación**

- Todos los paquetes figuran en el `manifest.json` y están listos para usar.
- No se presentan conflictos con URP/HDRP ni con otras dependencias.
- El sistema de input puede crear `InputActionAsset` y responder en escena.
- Cinemachine puede crear una cámara funcional desde plantilla.
- TextMeshPro se encuentra disponible en UI Toolkit y Canvas.
- El proyecto compila y ejecuta correctamente luego de la instalación.

# Integrar con NavMesh 214df9df7102815f841ada1409e0313d

# Integrar con NavMesh

Descripción: Conectar el sistema de movimiento de tropas e IA con la malla de navegación (NavMesh) para permitir desplazamientos realistas por el terreno.
Prioridad: Alta
Etiquetas: IA
Etapa: Por hacer
Sistema Principal: IA de Tropas
Bloqueado por: Colocar obstáculos básicos (Colocar%20obsta%CC%81culos%20ba%CC%81sicos%20214df9df71028123bf22d99d42dfe995.md)
Bloqueando: Configurar NavMesh y horneado (Configurar%20NavMesh%20y%20horneado%20214df9df7102811c88badd39043adaa7.md)
Fase: Entrada y Presencia en Feudo
orden: 16

### 🧭 **Tarea:** Integrar con NavMesh

**Descripción técnica detallada:**

Conectar las unidades del juego (tanto del jugador como de la IA) al sistema de navegación mediante `NavMeshAgent`. Esta integración permite que las unidades puedan desplazarse eficientemente por el entorno, evitando obstáculos y respetando las zonas navegables del mapa. El objetivo es asegurar una navegación fluida, compatible con el sistema de formaciones, detección de enemigos y ejecución de órdenes como moverse, seguir o atacar.

---

### 🎮 **Funcionalidades requeridas:**

- Cada unidad debe contar con un componente `NavMeshAgent` configurado adecuadamente.
- El agente debe:
    - Respetar el terreno horneado como navegable (`NavMesh`).
    - Evitar colisionar con obstáculos (`NavMeshObstacle`).
    - Poder seguir puntos de destino dinámicos (enemigos, puntos de formación, jugador).
- Integración con los siguientes sistemas:
    - **FSM de IA** → `MoveToTarget`, `Seek`, `Retreat`
    - **Órdenes del jugador** → `Follow`, `HoldPosition`
    - **Slots de formación** → unidad navega al slot correspondiente
- Ajustes recomendados:
    - Velocidad, aceleración y radio adaptados al tipo de unidad.
    - Avoidance Priority para evitar que unidades se empujen entre sí.
- Compatibilidad con `NavMesh Bake` de la escena (ya definido previamente).

---

### ⚙️ **Requisitos técnicos**

- En cada prefab de unidad:
    - Agregar `NavMeshAgent`
    - Definir propiedades:
        
        ```csharp
        csharp
        CopiarEditar
        agent.speed = 3.5f;
        agent.acceleration = 8f;
        agent.stoppingDistance = 1.5f;
        agent.angularSpeed = 120f;
        
        ```
        
- En los scripts de IA o escuadra:
    - Método `MoveTo(Vector3 destination)`
        
        ```csharp
        csharp
        CopiarEditar
        agent.SetDestination(destination);
        
        ```
        
- Verificar que el terreno y obstáculos están correctamente horneados (`Navigation Static`, `Not Walkable`, `Obstacle`).
- Agregar `NavMeshObstacle` a objetos móviles si se requiere evasión (como el héroe).

---

### 🧪 **Criterios de aceptación**

- Todas las unidades con IA pueden moverse correctamente sobre el `NavMesh`.
- Las unidades evitan obstáculos definidos en la escena.
- Al recibir una orden o entrar en estado de movimiento, las unidades usan el `NavMeshAgent`.
- Las unidades pueden llegar a su destino sin atascarse, sin salirse de la malla.
- El sistema se mantiene estable bajo múltiples unidades en escena.
- Se pueden ajustar dinámicamente los parámetros del agente según tipo de unidad.

# Integrar sistema de skins y selector de apariencia 215df9df710280099dbcdb7c694e87fa

# Integrar sistema de skins y selector de apariencia

Descripción: Permitir al jugador aplicar skins cosméticas desbloqueadas al héroe y ver el cambio reflejado en tiempo real.
Prioridad: Baja
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

### 🧭 **Tarea:** Integrar sistema de skins y selector de apariencia

**Descripción técnica detallada:**

Agregar una sección dentro de la UI del héroe que permita al jugador visualizar, seleccionar y aplicar diferentes aspectos visuales (skins) para su personaje. Estas skins afectan únicamente la estética del modelo del héroe (materiales, texturas o modelos alternativos), sin modificar sus estadísticas ni equipamiento funcional. Las opciones deben estar limitadas a las skins desbloqueadas por el jugador y aplicarse directamente sobre el modelo en vista previa.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar lista o galería de skins desbloqueadas:
    - Nombre, ícono, rareza (si aplica).
- Permitir seleccionar una skin activa con clic.
- Al cambiar de skin:
    - Actualizar visualmente el modelo del héroe en el viewer.
    - Aplicar el nuevo material o mesh según la skin.
- Las skins no deben interferir con el equipamiento real.
- Debe mantenerse la skin seleccionada en futuras sesiones.
- Posibilidad de “Revertir a apariencia por defecto”.

---

### ⚙️ **Requisitos técnicos**

- Acceso a lista de skins desbloqueadas por jugador (`SkinInventory`, `HeroCosmeticsData`).
- Cada skin debe tener una definición estructurada con:
    - ID, nombre, tipo (visual total o parcial), mesh/materials asociados.
- `SkinApplier` o `HeroAppearanceManager` responsable de aplicar la apariencia sin alterar el equipamiento funcional.
- Persistencia local del ID de skin activa (`PlayerPrefs`, JSON o save file).
- UI colocada en sección separada del panel de equipo para evitar confusión.

---

### 🧪 **Criterios de aceptación**

- El jugador puede ver todas sus skins desbloqueadas.
- Al hacer clic en una skin, el modelo se actualiza inmediatamente.
- La skin no modifica estadísticas, ni interfiere con el sistema de equipamiento.
- La skin se conserva al cerrar y volver a abrir el juego.
- Cambiar de skin no causa errores ni visuales rotos en el modelo.

# Lógica de carga de datos del resultado de batalla 216df9df7102806992f4d7c903822828

# Lógica de carga de datos del resultado de batalla

Descripción: Conectar los resultados de combate con la interfaz de resumen.
Prioridad: Media
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Lógica de carga de datos del resultado de batalla

**Descripción técnica detallada:**

Recibir los datos generados al finalizar la batalla y distribuirlos a la interfaz: héroe, unidades, XP, resultado.

---

### 🎮 Funcionalidades requeridas:

- Entrada de datos tipo `BattleResult`
- Carga y vinculación automática a la UI

---

### ⚙️ Requisitos técnicos:

- `BattleSummaryController.cs`
- Métodos: `LoadResult(BattleResult result)`
- Vinculación con scripts de UI de héroe y unidades

---

### 🧪 Criterios de aceptación:

- Todos los datos se presentan sin intervención manual
- No hay errores ni información faltante

# Lógica de exclusividad de escuadra activa 217df9df71028095b0d7c5fe406da52f

# Lógica de exclusividad de escuadra activa

Descripción: Asegurar que cada jugador tenga solo una escuadra activa en el campo al mismo tiempo y gestionar su reemplazo de forma segura. Cada escuadra es una instancia derivada de una *Troop* seleccionada en el loadout.
Prioridad: Media
Etiquetas: Supply, Unidades
Etapa: Backlog
Sistema Principal: Mapas
Fase: Batalla
ítem principal: Sistema de Supply Points con control territorial (Sistema%20de%20Supply%20Points%20con%20control%20territorial%20217df9df710280748412c06ee0ecfc6e.md)

### 🧭 **Tarea:** Lógica de exclusividad de escuadra activa

**Descripción técnica detallada:**

Durante una partida, cada jugador debe tener **una única escuadra activa** en el campo de batalla. Esta escuadra representa su fuerza táctica actual y está ligada funcionalmente al héroe. Al cambiar de escuadra mediante un Supply Point, la anterior debe **desactivarse y desaparecer tras un retardo**, asegurando que nunca haya dos escuadras activas simultáneamente. Esta exclusividad es una **regla inquebrantable** del MVP, y el sistema debe garantizar que se respete en toda circunstancia, evitando errores de duplicación, desincronización o reentrada.

---

### 🎮 **Funcionalidades requeridas:**

- Validación global al intentar instanciar una escuadra:
    - Si ya hay una activa → bloquear, o reemplazarla correctamente.
- Al cambiar escuadra desde Supply:
    - La escuadra activa actual pasa a estado `Desactivándose`.
    - Se le impide recibir órdenes o atacar durante esos 5 segundos.
    - Luego es destruida visual y lógicamente.
- La nueva escuadra es instanciada solo si no hay ninguna activa.
- El sistema evita que se interrumpa la destrucción con inputs o exploits.
- El héroe siempre está asociado a una sola escuadra activa.

---

### ⚙️ **Requisitos técnicos**

- En `SquadManager.cs`:
    - Campo: `GameObject activeSquad`
    - Métodos:
        
        ```csharp
        bool HasActiveSquad();
        void DeactivateCurrentSquad(float delay);
        void SpawnSquadFromLoadoutAt(Vector3 pos);
        ```
        
- Proceso de transición:
    1. `DeactivateCurrentSquad()` inicia timer.
    2. Desactiva inputs y lógica de combate de la escuadra.
    3. Al terminar, destruye la instancia.
    4. Activa nueva escuadra desde `SquadLoadout`.
- Validaciones:
    - No permitir `Spawn` si `activeSquad != null && !isDestroying`.

---

### 🧪 **Criterios de aceptación**

- Solo una escuadra está activa por jugador en todo momento.
- Al hacer cambio:
    - La anterior se desactiva inmediatamente (sin responder a comandos).
    - Desaparece sin errores tras el tiempo definido.
    - La nueva aparece correctamente.
- No se pueden hacer múltiples llamados a `SpawnSquad` en paralelo.
- El sistema es robusto ante spam de inputs o errores de red (si aplica).
- El héroe siempre tiene referencia válida a su única escuadra activa.

# Mostrar botón de “Batalla” (mini castillo) en HUD 216df9df710281308ad4f6437e24712d

# Mostrar botón de “Batalla” (mini castillo) en HUD

Descripción: Botón fijo en pantalla que permite unirse a la cola de batalla.
Prioridad: Alta
Etiquetas: Batalla, Feudo, UI
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md)
Fase: Preparación de Combate
orden: 67

### 🧭 **Tarea:** Mostrar botón de “Batalla” (mini castillo) en HUD

**Descripción técnica detallada:**

Este botón forma parte de la interfaz permanente del jugador mientras se encuentra en el Mapa de Feudo. Su función principal es permitir el acceso inmediato al sistema de cola para iniciar una batalla. El botón debe ser claramente visible, ubicado en la parte superior derecha del HUD, con una forma o ícono distintivo (por ejemplo, un castillo). Al hacer clic, se inicia el proceso de matchmaking y se muestra un mensaje visual de estado mientras el jugador espera.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar el botón en pantalla siempre que el jugador esté en el Feudo.
- Al hacer clic:
    - Llamar a la función de `MatchmakingManager.JoinQueue()`.
    - Ocultar el botón y mostrar una UI alternativa: “Buscando batalla…”.
- Deshabilitar el botón si ya se está en cola.
- Cambiar a estado “En partida” una vez se cree el lobby.
- Permitir cancelar mientras se está en cola (opcional).
- Animación o efecto de hover/click si aplica.

---

### ⚙️ **Requisitos técnicos**

- Prefab: `BattleButtonUI` con:
    - Ícono gráfico (castillo u otro símbolo claro).
    - Tooltip o texto flotante: “Entrar en batalla”.
    - Controlador `BattleButtonController.cs`.
- Componente debe estar vinculado a:
    - `MatchmakingManager`
    - `FeudoHUDController` o similar
- Lógica:
    - `OnClickJoinBattle()` → cambia estado interno a `Searching`.
    - Escucha evento `OnLobbyCreated` para transicionar.
- Asegurar visibilidad y escalado correcto en distintos tamaños de pantalla.

---

### 🧪 **Criterios de aceptación**

- El botón se muestra correctamente cuando el jugador entra al Feudo.
- Es visualmente identificable, accesible y funcional.
- Al presionar, inicia el proceso de matchmaking sin errores.
- Cambia de estado correctamente y evita múltiples clics.
- Si el jugador entra en una partida, el botón desaparece o queda desactivado.
- El diseño se mantiene consistente en distintas resoluciones y estilos de HUD.

# Mostrar equipamiento actual y lista de objetos dis 215df9df71028048b164c92244a678ad

# Mostrar equipamiento actual y lista de objetos disponibles

Descripción: Mostrar el equipo que lleva el héroe (arma, armadura) y permitir cambiarlo desde una lista de ítems desbloqueados.
Prioridad: Alta
Etiquetas: Control del Héroe, UI
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Configurar Personaje y Unidades
ítem principal: Crear UI de Stats del heroe (Crear%20UI%20de%20Stats%20del%20heroe%20214df9df710281d8b145d7c68a9e1e63.md)

### 🧭 **Tarea:** Mostrar equipamiento actual y lista de objetos disponibles

**Descripción técnica detallada:**

Implementar la sección de la interfaz donde se visualiza el equipamiento actual del héroe y se muestra una lista de objetos disponibles en el inventario para cada tipo de equipo. El jugador podrá seleccionar otro ítem de la lista y equiparlo instantáneamente, viendo reflejado el cambio en las estadísticas y en la visualización 3D del personaje.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar íconos, nombres y rareza del equipo actualmente equipado:
    - Arma (tipo: espada/arco/guja)
    - Armadura (ligera/media/pesada)
- Listas o paneles colapsables con todos los objetos disponibles por categoría.
- Seleccionar un objeto de la lista:
    - Actualiza la vista del equipo equipado.
    - Recalcula los atributos afectados (daño, defensa, penetración).
    - Actualiza visualmente el modelo del héroe en 3D.
- Filtrado por tipo o rareza (opcional).
- Tooltips al pasar el mouse con estadísticas del equipo.

---

### ⚙️ **Requisitos técnicos**

- Lectura del inventario desde `InventoryManager` o clase equivalente.
- Componentes:
    - `EquipmentSlotUI` para mostrar ítem equipado.
    - `EquipmentListUI` para ítems disponibles (scrollable o grid).
- Cada ítem debe tener una estructura:
    
    ```json
    {
      "name": "Espada de Acero",
      "type": "Arma",
      "statModifiers": {
        "damage": 10,
        "penetration": 5
      },
      "rarity": "común"
    }
    ```
    
- Al seleccionar un nuevo ítem:
    - Se actualiza el `HeroEquipmentComponent`.
    - Se refresca el modelo en tiempo real (evento visual).

---

### 🧪 **Criterios de aceptación**

- El jugador ve correctamente su arma y armadura equipada.
- La lista muestra todos los ítems que tiene desbloqueados.
- Seleccionar un nuevo objeto cambia inmediatamente el estado y el modelo del héroe.
- Los modificadores de stats se actualizan visualmente en el panel de estadísticas.
- Cambiar de equipo no genera errores ni conflictos entre slots.

# Mostrar información del héroe y su experiencia 216df9df71028009ae16cfeaa4c788f9

# Mostrar información del héroe y su experiencia

Descripción: Visualizar el nombre, retrato, XP ganada y progreso de nivel del héroe tras la batalla.
Prioridad: Media
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Mostrar información del héroe y su experiencia

**Descripción técnica detallada:**

Mostrar los datos del héroe principal en un panel dedicado: nombre, imagen/avatar, cantidad de XP ganada y barra de progreso animada si aplica.

---

### 🎮 Funcionalidades requeridas:

- Textos dinámicos para nombre y XP
- Imagen del retrato
- Barra de progreso animada (UI Slider o custom)

---

### ⚙️ Requisitos técnicos:

- Script `HeroResultUI` que recibe y muestra los datos
- Integración con `BattleResult.HeroXP`
- Soporte visual para casos con y sin subida de nivel

---

### 🧪 Criterios de aceptación:

- La sección del héroe refleja los datos correctamente
- La barra de XP es coherente con el valor recibido

# Mostrar interfaz de preparación de batalla (panta 216df9df710281fc8693ed3e6a0fb537

# Mostrar interfaz de preparación de batalla (pantalla completa)

Descripción: UI previa donde el jugador elige unidades, respawn y loadout.
Prioridad: Alta
Etiquetas: Batalla, Preparación, UI
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md)
Fase: Preparación de Combate
orden: 27

### 🧭 **Tarea:** Mostrar interfaz de preparación de batalla (pantalla completa)

**Descripción técnica detallada:**

Al ingresar a una batalla desde el lobby, los jugadores deben pasar por una **fase de preparación** representada por una **pantalla de interfaz completa**. Esta UI debe contener todos los componentes necesarios para que el jugador configure su escuadra: selección de **tropas** (sin superar el liderazgo por escuadras), punto de spawn y uso opcional de loadouts. La interfaz debe ocupar toda la pantalla, suspender el control del personaje y mantenerse visible durante la cuenta regresiva. Además, debe integrarse con los botones “Continuar” y mostrar un temporizador visible.

---

### 🎮 **Funcionalidades requeridas:**

- **Estructura principal (pantalla completa):**
    - Bloquea input de juego.
    - Fondo neutro o mapa estilizado como fondo.
- **Componentes integrados:**
    - **Selector de tropas (slots + panel modal)** con liderazgo limitado.
    - **Mini mapa con puntos de spawn** interactivos.
    - **Selector de loadouts** si el jugador tiene alguno guardado.
    - **Contador de tiempo** restante para confirmar selección.
    - **Botón “Continuar”** habilitado solo con selección válida.
    - Mensaje visual “Esperando a otros jugadores…” al confirmar.
- **Comportamientos:**
    - Oculta HUD de juego.
    - Desactiva movimiento y cámara.
    - Desaparece automáticamente al finalizar la fase o presionar “Continuar”.

---

### ⚙️ **Requisitos técnicos**

- Prefab principal `PreparationScreenUI`:
    - Contiene subcomponentes:
        - `UnitSelectionPanel`
        - `SpawnSelectorUI`
        - `LoadoutSelectorUI`
        - `TimerDisplay`
        - `ContinueButton`
- Manager de fase `PreparationPhaseManager.cs`:
    - Controla inicio, tiempo, transiciones y comunicación con el backend/lobby.
- Comunicación entre componentes:
    - Emitir eventos `OnSelectionChanged`, `OnContinuePressed`, `OnTimeout`.
- Visual adaptado a 16:9, 21:9 y ultra-wide.
- Compatible con input de mouse y mando (si aplica).

---

### 🧪 **Criterios de aceptación**

- La interfaz aparece automáticamente al cargar la fase de preparación.
- Todos los componentes visuales están integrados y son funcionales.
- El jugador puede completar todas las selecciones desde esta pantalla.
- El botón “Continuar” responde correctamente a las condiciones de validación.
- Al presionar continuar o finalizar el tiempo, la interfaz se cierra y da paso a la batalla.

# Mostrar resultado de la partida (victoria o derrot 216df9df710280b7a494fd19629ca6bc

# Mostrar resultado de la partida (victoria o derrota)

Descripción: Indicar claramente el resultado de la batalla.
Prioridad: Alta
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Mostrar resultado de la partida (victoria o derrota)

**Descripción técnica detallada:**

Mostrar un título visual (texto o gráfico) que indique si el jugador ganó o perdió la batalla, destacando este mensaje como parte superior del resumen.

---

### 🎮 Funcionalidades requeridas:

- Texto grande tipo “Victoria” o “Derrota”
- Colores o íconos diferenciados por resultado

---

### ⚙️ Requisitos técnicos:

- Campo de texto vinculado a `result.outcome`
- Estilo visual variable según el resultado

---

### 🧪 Criterios de aceptación:

- El jugador puede ver inmediatamente si ganó o perdió
- El resultado es visualmente claro y sin ambigüedad

# Mostrar unidades utilizadas y kills por unidad 216df9df7102804681edc7778e0e6539

# Mostrar unidades utilizadas y kills por unidad

Descripción: Listar todas las unidades del jugador y su desempeño en combate.
Prioridad: Media
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Post Combate
ítem principal: Pantalla de resultados de batalla (pantalla completa) (Pantalla%20de%20resultados%20de%20batalla%20(pantalla%20comple%20216df9df710281a196bce985bb8d0511.md)

### 🧭 **Tarea:** Mostrar unidades utilizadas y kills por unidad

**Descripción técnica detallada:**

Generar una lista dinámica que muestre cada unidad usada por el jugador con su ícono, kills y XP ganada. Debe ordenarse visualmente y escalar bien en diferentes cantidades.

---

### 🎮 Funcionalidades requeridas:

- Contenedor scrollable
- Prefab de ítem individual por unidad
- Datos mostrados: nombre, ícono, kills, XP

---

### ⚙️ Requisitos técnicos:

- Script `UnitResultUI` que instancie y alimente los datos
- Scroll rect para manejo de muchas unidades
- Estructura basada en `BattleResult.Units`

---

### 🧪 Criterios de aceptación:

- Todas las unidades usadas aparecen listadas
- La información es clara, alineada y sin errores

# Pantalla de carga del mapa de batalla (carga de he 216df9df7102812d9711dabbba9a293d

# Pantalla de carga del mapa de batalla (carga de héroes y unidades)

Descripción: Transición hacia la escena de combate con los datos de todos los jugadores.
Prioridad: Alta
Etiquetas: Batalla, Mapa de batalla
Etapa: Planeación
Sistema Principal: Mapas
Fase: Preparación de Combate
orden: 36

### 🧭 **Tarea:** Pantalla de carga del mapa de batalla (carga de héroes y unidades)

**Descripción técnica detallada:**

Esta tarea consiste en implementar una pantalla de carga que se active después de la fase de preparación de batalla, durante la cual se carga la escena del mapa de batalla junto con todos los datos relevantes de los jugadores: héroes, escuadras seleccionadas, equipo, posición inicial. Esta pantalla debe mostrar progreso visual o una animación de espera, y garantizar que todos los objetos necesarios estén listos antes de liberar el control al jugador.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar una pantalla de carga completa al finalizar la preparación.
- Cargar la escena del mapa de batalla de forma asincrónica.
- Instanciar:
    - Héroe del jugador con su configuración visual.
    - Escuadra activa con las unidades seleccionadas.
    - Punto de spawn elegido por el jugador.
- Mostrar mensaje de espera o animación mientras se carga.
- Liberar el control solo cuando todo esté listo (evitar popping).

---

### ⚙️ **Requisitos técnicos**

- Script `BattleLoader.cs` o `MatchSceneLoader.cs` que:
    - Reciba los datos del jugador (`HeroData`, `SquadLoadout`, `SpawnPointID`)
    - Cargue la escena con `SceneManager.LoadSceneAsync()`
    - Monitoree estado de carga hasta `allowSceneActivation`
- Prefab `LoadingScreenUI` con animación o barra de progreso.
- Lógica de inicialización tras carga:
    - Instanciar héroe en punto válido.
    - Instanciar escuadra al frente.
    - Activar input y cámara solo al completar carga.

---

### 🧪 **Criterios de aceptación**

- La pantalla de carga aparece al terminar la preparación y antes del combate.
- Todos los jugadores cargan sus datos correctamente sin errores.
- No se muestra el entorno ni entidades antes de estar completamente listo.
- El jugador empieza la partida ya con el control activo y su configuración aplicada.
- No hay sobreposición ni errores de instanciación múltiple.

# Pantalla de carga del Mapa de Feudo tras selecció 216df9df7102817e9e34ef693930c7d6

# Pantalla de carga del Mapa de Feudo tras selección

Descripción: Mostrar progreso de carga y transicionar al mapa central.
Prioridad: Media
Etiquetas: Feudo, Transición
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Entrada y Presencia en Feudo
orden: 19

### 🧭 **Tarea:** Pantalla de carga del Mapa de Feudo tras selección

**Descripción técnica detallada:**

Después de que el jugador selecciona su personaje en la pantalla de selección, y presiona “Entrar”, el sistema debe mostrar una pantalla de carga que informe visualmente que el Mapa de Feudo se está cargando. Esta carga debe bloquear la interacción del jugador, preparar el entorno, y activar correctamente la escena de ciudad. La transición debe ser fluida y sin mostrar elementos incompletos.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar una pantalla completa con:
    - Fondo (imagen o animación de carga).
    - Barra de progreso o indicador animado.
    - Nombre del mapa o mensaje tipo “Entrando a Feudo…”.
- Iniciar carga asincrónica de la escena del Feudo.
- Instanciar el personaje seleccionado solo al completar la carga.
- Evitar duplicaciones, flickering o errores visuales durante la transición.
- Bloquear cualquier input del jugador durante la carga.

---

### ⚙️ **Requisitos técnicos**

- Prefab de UI: `FeudoLoadingScreenUI`
    - Contiene: texto, barra de progreso o animación.
- Script `FeudoLoader.cs`:
    - Llama `SceneManager.LoadSceneAsync("Feudo")`
    - Monitorea el progreso con `async.progress`.
    - Usa `allowSceneActivation = false` hasta que se complete la carga del personaje.
- El personaje a instanciar se toma desde:
    - `PlayerProfile.ActiveHero` o equivalente.
- Activación de la escena solo cuando:
    - El entorno está cargado.
    - El personaje está instanciado y listo.
    - Se inicializa la cámara y el HUD.

---

### 🧪 **Criterios de aceptación**

- Al presionar “Entrar”, se muestra inmediatamente la pantalla de carga.
- El progreso visual (barra o animación) indica que algo está ocurriendo.
- No hay pantallas negras prolongadas ni parpadeo de escena.
- La escena del Feudo se carga completamente antes de mostrar al jugador.
- El personaje del jugador aparece correctamente al finalizar la carga.
- El flujo visual es suave, sin cortes ni congelamientos.

# Pantalla de resultados de batalla (pantalla comple 216df9df710281a196bce985bb8d0511

# Pantalla de resultados de batalla (pantalla completa)

Descripción: Mostrar unidades usadas, kills por unidad, experiencia ganada.
Prioridad: Media
Etiquetas: Batalla, Resultados, UI
Etapa: Planeación
Sistema Principal: Mapas
Fase: Post Combate
Subítem: Diseñar layout visual del resumen de batalla (Disen%CC%83ar%20layout%20visual%20del%20resumen%20de%20batalla%20216df9df710280059926e794346c3d1f.md), Crear prefab de pantalla de resultados (Crear%20prefab%20de%20pantalla%20de%20resultados%20216df9df710280e1a154e1b67b1628f4.md), Mostrar información del héroe y su experiencia (Mostrar%20informacio%CC%81n%20del%20he%CC%81roe%20y%20su%20experiencia%20216df9df71028009ae16cfeaa4c788f9.md), Mostrar unidades utilizadas y kills por unidad (Mostrar%20unidades%20utilizadas%20y%20kills%20por%20unidad%20216df9df7102804681edc7778e0e6539.md),  Lógica de carga de datos del resultado de batalla (Lo%CC%81gica%20de%20carga%20de%20datos%20del%20resultado%20de%20batalla%20216df9df7102806992f4d7c903822828.md), Mostrar resultado de la partida (victoria o derrota) (Mostrar%20resultado%20de%20la%20partida%20(victoria%20o%20derrot%20216df9df710280b7a494fd19629ca6bc.md), Animar entrada progresiva de elementos (opcional) (Animar%20entrada%20progresiva%20de%20elementos%20(opcional)%20216df9df71028020947be633a3ffd14a.md), Agregar botón “Continuar” con transición al Feudo (Agregar%20boto%CC%81n%20%E2%80%9CContinuar%E2%80%9D%20con%20transicio%CC%81n%20al%20Feud%20216df9df710280848bb4f699b895d5bb.md)
orden: 61

### 🧭 **Tarea:** Pantalla de resultados de batalla (pantalla completa)

**Descripción técnica detallada:**

Diseñar e implementar una pantalla de interfaz que se muestra al finalizar una batalla, ocupando toda la pantalla, en la que se presenta al jugador un resumen detallado de su desempeño. Debe incluir estadísticas personales, rendimiento por unidad usada, experiencia obtenida por el héroe y cada escuadra, así como un botón “Continuar” que permite salir de esta vista. Esta pantalla debe ser clara, atractiva y fácilmente navegable.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar información de batalla del jugador:
    - Nombre del héroe.
    - Unidades seleccionadas y su desempeño (kills, daño).
    - Experiencia ganada por héroe y por cada unidad.
    - Resultado (victoria / derrota) si aplica.
- Componentes visuales:
    - Nombre e íconos de cada unidad usada.
    - Contador de kills por unidad.
    - Barras o números de experiencia.
    - Iconografía del héroe y su progresión.
- Integración del botón “Continuar” para cerrar la vista.
- Ocultar o desactivar HUD del combate anterior.

---

### ⚙️ **Requisitos técnicos**

- Prefab `BattleSummaryUI` en `/Prefabs/UI/Results/`.
- Script `BattleSummaryController.cs` para poblar los datos.
- Estructura de datos esperada:
    
    ```csharp
    class BattleResult {
        public string HeroName;
        public int HeroXP;
        public List<UnitResult> Units;
    }
    
    class UnitResult {
        public string UnitName;
        public int Kills;
        public int XP;
    }
    ```
    
- Debe recibir `BattleResult` desde el sistema de combate o controlador de partida (`BattleManager.EndBattle()`).
- Transición suave desde escena de batalla a esta pantalla (sin parpadeos).
- Soporte para múltiples resoluciones y escalado UI.

---

### 🧪 **Criterios de aceptación**

- Al finalizar la batalla, se muestra una pantalla con resumen completo sin errores.
- Todos los datos del héroe y las unidades se presentan correctamente.
- El botón “Continuar” permite salir sin retraso ni bugs.
- El HUD del combate anterior está oculto o destruido.
- El jugador no puede interactuar con el juego hasta cerrar esta pantalla.
- Es posible añadir estilos o gráficos extra sin romper el layout.

# Permitir cambio de arma del héroe interactuando c 217df9df710280808f6ef7200484b166

# Permitir cambio de arma del héroe interactuando con el Supply Point

Descripción: El jugador cambia su arma accediendo directamente al Supply Point y usando una UI integrada que también permite cambiar escuadra.
Prioridad: Media
Etiquetas: Control del Héroe, Gestión de Escuadra, Supply
Etapa: Backlog
Sistema Principal: Control del Héroe, Gestión de Escuadra
Fase: Batalla
ítem principal: Sistema de Supply Points con control territorial (Sistema%20de%20Supply%20Points%20con%20control%20territorial%20217df9df710280748412c06ee0ecfc6e.md)

### 🧭 **Tarea:** Permitir cambio de arma del héroe interactuando con el Supply Point

**Descripción técnica detallada:**

El cambio de arma no se activa por teclado libre, sino al **interactuar con el elemento central del Supply Point** (ej. una carreta de suministros). Esta interacción abre una **UI integrada** reutilizada del sistema de preparación de batalla, que muestra tanto la selección de escuadra como el arma actual del héroe, con la opción de cambiarla. Solo se muestran armas válidas según clase del personaje y desbloqueadas en su inventario. El cambio se aplica inmediatamente: el nuevo modelo se muestra en el personaje, y sus estadísticas de combate se actualizan.

---

### 🎮 **Funcionalidades requeridas:**

- El Supply Point tiene un prefab visible en su centro (carreta, tótem).
- Al presionar el botón de interacción (`F`, por ejemplo) sobre ese objeto:
    - Se abre una interfaz combinada:
        - Selector de escuadra (como en la preparación de batalla).
        - Visual del arma actual + botón para cambiar.
- Al presionar el botón de arma:
    - Se muestra lista horizontal con las armas desbloqueadas y válidas.
    - Al elegir una:
        - Se actualiza el modelo del héroe.
        - Se actualizan sus estadísticas ofensivas.
        - Se aplica override de animaciones si es necesario.
- La UI se cierra con `ESC` o al presionar “Confirmar”.

---

### ⚙️ **Requisitos técnicos**

- Prefab `SupplyPointObject` (carreta o similar):
    - Collider con componente `Interactable.cs`
    - Eventos: `OnPlayerInteract()`
- Reutilización de UI:
    - Reusar `PreparationBattleUI` parcial:
        - Panel de escuadra
        - Panel de arma (`WeaponSlot`, `ChangeButton`)
    - `WeaponChangePanel` muestra armas desde `PlayerProfile.UnlockedWeapons`
- `HeroEquipmentManager.cs`:
    - `EquipWeapon(WeaponID id)`
        - Cambia visual
        - Aplica efectos
        - Cambia animaciones si aplica

---

### 🧪 **Criterios de aceptación**

- Al interactuar con el objeto central del Supply Point, se abre una UI completa (reutilizada).
- El jugador ve su arma actual y puede cambiarla por cualquier otra válida.
- Al confirmar:
    - El arma se actualiza en el personaje visual y funcionalmente.
    - La UI se cierra sin errores.
- No se puede cambiar de arma si no se está dentro del área del Supply Point aliado.
- El flujo de interacción es claro, fluido y reutiliza componentes ya existentes.

# Permitir cambio de escuadra dentro de zona de Supp 217df9df71028004a9a0e901427ac380

# Permitir cambio de escuadra dentro de zona de Supply

Descripción: Reemplazar la escuadra activa del jugador desde una interfaz integrada accesible únicamente al interactuar con el objeto central del Supply Point. El sistema siempre mantiene una sola escuadra activa por jugador.
Prioridad: Media
Etiquetas: Spawning, Supply, UI
Etapa: Backlog
Sistema Principal: Mapas
Fase: Batalla
ítem principal: Sistema de Supply Points con control territorial (Sistema%20de%20Supply%20Points%20con%20control%20territorial%20217df9df710280748412c06ee0ecfc6e.md)

### 

### 🧭 **Tarea:** Permitir cambio de escuadra desde la interfaz del Supply Point

**Descripción técnica detallada:**

El jugador puede cambiar su escuadra activa mientras se encuentra en el rango de un Supply Point aliado. Para hacerlo, debe interactuar con el objeto central visible del Supply Point (ej. una carreta de suministros), lo cual abre una interfaz unificada. Esta UI muestra las escuadras disponibles que el jugador tiene desbloqueadas y aún en condiciones de combate, y permite reemplazar la actual. La escuadra anterior desaparece después de un breve retardo de 5 segundos, y la nueva es desplegada dentro del rango del Supply Point.

---

### 🎮 **Funcionalidades requeridas:**

- El jugador entra en el área del Supply Point **Aliado**.
- Interactúa con el objeto central (`SupplyPointObject`) usando una tecla (ej. `"F"`).
- Se abre una UI integrada que muestra:
    - Panel de selección de escuadra (como en fase de preparación).
    - Escuadra actual destacada.
    - Otras **tropas** válidas (con >10% de tropas vivas) independientemente de la escuadra activa.
- Al seleccionar una nueva escuadra:
    - La escuadra actual comienza un temporizador de desaparición (5 segundos).
    - La nueva escuadra se instancia dentro del área del Supply Point.
    - El sistema garantiza que solo haya una escuadra activa a la vez.

---

### ⚙️ **Requisitos técnicos**

- Prefab `SupplyPointObject`:
    - Componente `Interactable.cs`
    - Evento `OnInteract → OpenSupplyPointUI()`
- UI reutilizada:
    - Reusar el panel de escuadra de la preparación de batalla (`SquadSelectionPanel`)
    - Mostrar visual bloqueado para **tropas** inválidas (ver Subtarea 3)
- Script `SquadManager.cs`:
    - `DeactivateCurrentSquad(delay)`
    - `SpawnSquadFromLoadoutAt(Vector3 position)`
- Confirmación visual del reemplazo (fade, mensaje en pantalla).

---

### 🧪 **Criterios de aceptación**

- El jugador puede acceder al cambio de escuadra solo si está en un Supply Point aliado.
- La UI integrada muestra correctamente escuadra actual y opciones válidas.
- Escuadras con ≤10% efectivos están visibles pero no seleccionables.
- La escuadra activa actual no afecta qué tropas están disponibles para el cambio.
- Al hacer el cambio:
    - La escuadra anterior se desactiva y desaparece a los 5 segundos.
    - La nueva aparece en el rango del Supply Point y queda lista para usar.
- No puede haber dos escuadras activas al mismo tiempo.
- La interfaz es clara, fluida y se integra con el flujo general del Supply Point.

# Prueba de compilación en limpio 214df9df71028187ac69cfcee91e4287

# Prueba de compilación en limpio

Descripción: Verificar que el proyecto arranca sin errores ni warnings.
Prioridad: Alta
Etiquetas: QA
Etapa: Por hacer
Sistema Principal: Multiplayer
Fase: Validación Prototipo
orden: 66

# Restringir escuadras con menos de 10% de tropas vi 217df9df710280278ceede4bc6d7e977

# Restringir escuadras con menos de 10% de tropas vivas

Descripción: Bloquear escuadras como opción de reemplazo si sus unidades están casi totalmente eliminadas.
Prioridad: Media
Etiquetas: Supply, UI
Etapa: Backlog
Sistema Principal: Mapas
Fase: Batalla
ítem principal: Sistema de Supply Points con control territorial (Sistema%20de%20Supply%20Points%20con%20control%20territorial%20217df9df710280748412c06ee0ecfc6e.md)

### 🧭 **Tarea:** Restringir escuadras con menos de 10% de tropas vivas

**Descripción técnica detallada:**

Durante el proceso de cambio de escuadra en un Supply Point, el sistema debe filtrar automáticamente aquellas escuadras que ya no están en condiciones de combate. Si una escuadra tiene un 10% o menos de sus efectivos vivos, debe aparecer en la interfaz como **no seleccionable** (bloqueada o con visual apagado). Esta regla también debe aplicarse si el jugador intentó seleccionar esa escuadra desde el inicio del combate, pero sufre pérdidas antes de llegar al punto de cambio. El sistema evita el uso de unidades casi destruidas y fuerza una gestión táctica más activa.

---

### 🎮 **Funcionalidades requeridas:**

- Evaluar el estado de cada escuadra disponible al abrir la UI de cambio:
    - Calcular el porcentaje de unidades vivas de cada **tropa**.
    - Si es ≤10%, marcar como inhabilitada.
- Visual en la UI:
    - Desaturar o apagar visualmente la card de la escuadra.
    - Mostrar un tooltip: “Demasiado diezmada para ser desplegada”.
- La validación se aplica tanto si:
    - La escuadra fue seleccionada al inicio del combate.
    - Es una escuadra no activa pero disponible.
- El sistema impide la selección de escuadras inválidas incluso si el jugador intenta forzar el cambio.

---

### ⚙️ **Requisitos técnicos**

- `SquadChangeUI.cs`:
    - Recorre cada `SquadLoadout` disponible.
    - Llama `GetRemainingTroopPercentage(squad)` → devuelve `float`.
    - Si ≤10%, `SetSelectable(false)` en el botón.
- `SquadStatsTracker.cs`:
    - Método `GetAliveCount()` y `GetTotalCount()`
    - Maneja estado de baja severa (`bool isCombatViable`)
- Interfaz debe reflejar claramente qué escuadras están deshabilitadas.
- (Opcional) Registrar internamente que una escuadra fue completamente diezmada.

---

### 🧪 **Criterios de aceptación**

- Las escuadras con 10% o menos tropas vivas no se pueden seleccionar desde la UI del Supply Point.
- Estas aparecen en la lista pero están visualmente bloqueadas.
- Si una escuadra válida cae bajo el umbral en combate, deja de ser elegible para intercambio posterior.
- El jugador no puede abusar del sistema para revivir escuadras casi destruidas.
- No hay errores de visualización ni inconsistencias al reabrir la interfaz.

# Retornar al Mapa de Feudo con el mismo personaje a 216df9df71028169ab7edab822a1415d

# Retornar al Mapa de Feudo con el mismo personaje activo

Descripción: Sin pérdida de datos visuales ni cambio de instancia.
Prioridad: Alta
Etiquetas: Feudo, Retorno
Etapa: Planeación
Sistema Principal: Mapas
Fase: Post Combate
orden: 63

### 🧭 **Tarea:** Retornar al Mapa de Feudo con el mismo personaje activo

**Descripción corta:**

Sin pérdida de datos visuales ni cambio de instancia.

---

**Descripción técnica detallada:**

Al finalizar la batalla y cerrar la pantalla de resultados, el jugador debe volver automáticamente al Mapa de Feudo con su héroe tal como lo dejó: misma apariencia, mismo equipo y estado visual intacto. Esta transición no debe reiniciar sesión ni crear un nuevo personaje, y debe permitir que el jugador siga interactuando en el Feudo con el mismo control, sin interrupciones ni errores de carga.

---

### 🎮 **Funcionalidades requeridas:**

- Cierre automático de la escena de batalla al presionar "Continuar" en la pantalla de resultados.
- Carga de la escena del Feudo sin reinicio del juego ni del personaje.
- Instanciación del personaje activo con su equipo, skin y estado intacto.
- Posición de aparición en zona válida del Feudo (ej. plaza central o punto de retorno).
- El jugador retoma control automáticamente al terminar la carga.

---

### ⚙️ **Requisitos técnicos**

- Persistencia del personaje mediante:
    - `GameManager`, `PlayerProfile`, o `DontDestroyOnLoad`.
    - O recuperación desde servidor si aplica (ID, stats, equipo).
- Llamado a:
    
    ```csharp
    SceneManager.LoadScene("MapaFeudo");
    ```
    
- Instanciación del personaje en punto `PlayerSpawnFeudo` con:
    - `HeroController`
    - `EquipmentManager`
    - `VisualSync` (modelo y skin)
- El sistema debe mantener referencias a la configuración previa del héroe:
    - Nombre, apariencia, ítems activos, valores de stats.
- Uso de una pantalla de carga simple si el tiempo de carga excede los 2 segundos.

---

### 🧪 **Criterios de aceptación**

- El jugador vuelve automáticamente al Feudo al presionar "Continuar".
- El personaje reaparece con el mismo equipo, visual y nombre.
- No se crean duplicados ni se pierde progreso visual ni funcional.
- El jugador tiene control inmediato de su personaje al cargar la escena.
- El retorno es estable, sin errores de carga ni desconexiones.

# Script para cámara libre (debug) 214df9df710281fdb002e8b4068dfd59

# Script para cámara libre (debug)

Descripción: Control manual del mapa con teclado/ratón para explorar la escena sin seguir al personaje.
Prioridad: Media
Etiquetas: UX
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Otros
orden: 71

### 🧭 **Tarea:** Script para cámara libre (debug)

**Descripción técnica detallada:**

Desarrollar una cámara de depuración estilo libre (free-fly o top-down) que permita moverse de forma independiente por el entorno durante el desarrollo. Este sistema facilita pruebas de IA, validación de terreno, posicionamiento de unidades y observación de formaciones sin estar limitado por la perspectiva del jugador. Esta cámara puede activarse o desactivarse a voluntad y coexistir con la cámara principal del héroe.

---

### 🎮 **Funcionalidades requeridas:**

- Movimiento libre con teclas (`W`, `A`, `S`, `D`) + elevación (`Q`, `E`) y rotación con el mouse.
- Opción de desacoplar la cámara principal del jugador y activar esta en modo "debug".
- Configuración ajustable:
    - Velocidad de desplazamiento.
    - Aceleración opcional (shift para boost).
    - Clamp de altura mínima/máxima.
- Control suave y sin colisiones por defecto.
- Compatible con modo juego en editor (Play Mode) sin necesidad de UI.

---

### ⚙️ **Requisitos técnicos**

- Script llamado `FreeCameraController.cs` o equivalente.
- Anclado a una `Camera` independiente del prefab del héroe.
- Debe activarse/desactivarse por tecla (`F1`, por ejemplo).
- Movimiento basado en `transform.Translate` y rotación en `transform.Rotate` (no física).
- Encapsulado en un `#if UNITY_EDITOR` o `DEBUG_CAMERA` para limitar su uso en producción.

---

### 🧪 **Criterios de aceptación**

- Al activar la cámara libre, el usuario puede navegar toda la escena con fluidez.
- La rotación y traslación no afectan otras cámaras del juego.
- La cámara puede activarse/desactivarse sin generar errores o conflictos de control.
- No se producen bloqueos, colisiones ni restricciones de movimiento.
- Se puede mantener activa para revisar formaciones, IA o unidades en tiempo real.

# Script para reiniciar escena 214df9df710281ffb6e8e2a8bd5513f5

# Script para reiniciar escena

Descripción: Reset rápido desde el editor (botón o tecla).
Prioridad: Baja
Etiquetas: Técnica
Etapa: Backlog
Sistema Principal: Control del Héroe
Fase: Otros
orden: 69

### 🧭 **Tarea:** Script para reiniciar escena

**Descripción técnica detallada:**

Implementar una funcionalidad accesible desde el teclado o una UI auxiliar que permita recargar rápidamente la escena actual en tiempo de ejecución. Esto facilitará la iteración y pruebas continuas durante el desarrollo, permitiendo reiniciar la simulación sin necesidad de detener el juego manualmente y volver a hacer clic en Play.

---

### 🎮 **Funcionalidades requeridas:**

- Atajo de teclado (por ejemplo, `R` o `Ctrl+R`) que reinicie la escena actual.
- Alternativamente, botón visible en una UI debug (`EditorGUI`, `OnGUI` o `DebugOverlay`).
- Uso de `SceneManager.LoadScene()` apuntando a `SceneManager.GetActiveScene().name`.
- Opción para incluir delay o confirmación (configurable).
- Solo ejecutable en modo Play (no en Editor sin juego corriendo).
- Soporte para desactivar esta función en builds de producción o multiplayer.

---

### ⚙️ **Requisitos técnicos**

- UnityEngine.SceneManagement debe estar importado.
- El script puede estar en un GameObject con tag `GameManager` o similar.
- Si se usa tecla, el script debe escuchar desde `Update()` con `Input.GetKeyDown()`.
- Si se usa `Input System`, asociar una acción dedicada (`ResetScene`).
- Encapsular en clase `SceneResetter.cs` o similar.
- Compatible con versiones futuras del proyecto (debe estar desacoplado de gameplay directo).

---

### 🧪 **Criterios de aceptación**

- Al presionar la tecla definida, la escena se reinicia correctamente.
- El reinicio no genera errores de estado o múltiples cargas simultáneas.
- El objeto con el script puede desactivarse para pruebas en producción.
- El botón de reinicio aparece en pantalla si se habilita la UI debug.
- Todos los componentes y estados de la escena se restablecen al valor inicial al relanzarla.

# Selector de loadouts de tropas 216df9df7102813aafd3c7e898ab6c0f

# Selector de loadouts de tropas

Descripción: Opción para cargar una configuración guardada de escuadra.
Prioridad: Media
Etiquetas: Loadout, Preparación
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Guardar selección como loadout (Guardar%20seleccio%CC%81n%20como%20loadout%20214df9df7102817d8763c03c6a84caf2.md)
Fase: Configurar Personaje y Unidades
orden: 25

### 🧭 **Tarea:** Selector de loadouts de tropas

**Descripción técnica detallada:**

Durante la fase de preparación de batalla, el jugador puede elegir un loadout previamente guardado que contenga una combinación válida de **tropas** (escuadras completas) dentro de su límite de liderazgo. Este selector debe mostrar los loadouts disponibles, aplicar la configuración al instante y reflejarla en la interfaz de selección. Debe prevenir selecciones inválidas y asegurar sincronización visual.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar lista de loadouts previamente guardados por el jugador.
- Cada loadout debe contener:
    - Nombre personalizado.
    - Lista de **tropas** (escuadras) incluidas.
    - Coste total de liderazgo por escuadras.
- Al seleccionar un loadout:
    - Se aplica automáticamente la composición de **tropas**.
    - Se bloquean tropas que el jugador no tiene disponibles.
    - Se actualiza la UI para reflejar la nueva selección.
- Debe haber opción de volver a selección manual si se desea.

---

### ⚙️ **Requisitos técnicos**

- Script `LoadoutSelectorUI.cs`:
    - Lista dinámica que muestra cada loadout (`LoadoutData`).
    - Método `ApplyLoadout(LoadoutData loadout)` que:
        - Vacía la selección actual.
        - Añade cada **tropa** si está desbloqueada y no supera el liderazgo.
- Integración con `PlayerProfile.Loadouts` (estructura local o en servidor).
- Validación en tiempo real del liderazgo total (`maxLeadership`).
- Reflejo inmediato en el panel de unidades y coste total.

---

### 🧪 **Criterios de aceptación**

- Todos los loadouts disponibles del jugador se listan correctamente.
- Al seleccionar uno, la composición se aplica sin errores.
- Las unidades se reflejan en la UI como si fueran seleccionadas manualmente.
- No se permite aplicar un loadout si contiene unidades no disponibles o que superen el liderazgo.
- Se puede alternar entre loadout y selección manual sin bugs ni pérdida de datos.

# Selector de punto de spawn por bando (mini mapa in 216df9df710281e3afcbf2a79012e9d7

# Selector de punto de spawn por bando (mini mapa interactivo)

Descripción: El jugador elige su punto de aparición desde los permitidos por su bando.
Prioridad: Alta
Etiquetas: Bando, Mapa
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Implementar sistema de selección de punto de spawn (atacante/defensor) (Implementar%20sistema%20de%20seleccio%CC%81n%20de%20punto%20de%20spaw%20216df9df7102806583a4fa71bc27d052.md)
Fase: Preparación de Combate
orden: 31

### 🧭 **Tarea:** Selector de punto de spawn por bando (mini mapa interactivo)

**Descripción técnica detallada:**

Durante la fase de preparación de batalla, cada jugador debe seleccionar un punto de aparición dentro de los asignados a su bando (atacante o defensor). Esta selección se realiza a través de un mini mapa táctico que muestra visualmente los puntos disponibles como íconos interactivos. Solo debe poder seleccionarse uno y debe resaltarse visualmente la opción activa.

---

### 🎮 **Funcionalidades requeridas:**

- Mini mapa visible con representación del campo de batalla (simplificada).
- Mostrar íconos interactivos (`SpawnPointMarker`) en los 3 puntos válidos del bando actual.
- Permitir al jugador hacer clic/tap sobre uno de ellos:
    - El punto se resalta.
    - El anterior se deselecciona.
    - Se actualiza el estado del botón “Continuar” si todas las condiciones se cumplen.
- Los puntos del bando contrario no deben mostrarse ni ser seleccionables.
- El punto seleccionado debe guardarse para el uso en la escena de batalla.

---

### ⚙️ **Requisitos técnicos**

- Script `SpawnSelectorUI.cs` que controle:
    - El render de íconos interactivos en el minimapa.
    - El comportamiento visual al seleccionar uno.
    - El registro del punto seleccionado (`SelectedSpawnPointID`).
- `SpawnPointMarker`:
    - Prefab con botón y visual (ícono, color).
    - Cambia visual al ser seleccionado.
- Datos de spawn cargados desde `BattleMapConfig` que define:
    - Lista de puntos por bando.
    - Posiciones relativas.
- Validación en `PreparationManager` para impedir continuar sin selección.

---

### 🧪 **Criterios de aceptación**

- El minimapa muestra exactamente 3 puntos del bando del jugador.
- Al seleccionar uno, los demás se desactivan visualmente.
- El punto elegido se registra correctamente y se usa al iniciar la batalla.
- El jugador no puede seleccionar puntos del enemigo ni cambiar después de presionar “Continuar”.
- El sistema se comporta correctamente en distintas resoluciones.

# Selector de unidades sin superar liderazgo 216df9df71028193ab38e843aafb1229

# Selector de unidades sin superar liderazgo

Descripción: Interfaz que muestra unidades disponibles y bloquea si se excede el liderazgo.
Prioridad: Alta
Etiquetas: Liderazgo, Preparación, Unidades
Etapa: Planeación
Sistema Principal: Mapas
Fase: Preparación de Combate
orden: 29

### 🧭 **Tarea:** Selector de unidades sin superar liderazgo

**Descripción técnica detallada:**

Durante la fase de preparación de batalla, el jugador selecciona manualmente las unidades que llevará al combate mediante una interfaz intuitiva basada en **cards**. En vez de mostrar todas las unidades directamente, se presenta una sección donde el jugador ve los espacios vacíos como **botones “+”**, y al hacer clic, accede a un panel flotante donde puede elegir nuevas unidades. Cada unidad ocupa una card, muestra su coste de liderazgo y solo puede ser seleccionada si no supera el límite.

La lógica impide añadir unidades si el **liderazgo total actual + coste de nueva unidad > liderazgo máximo del héroe**. Además, las unidades ya elegidas no pueden volver a ser seleccionadas. Cada nueva unidad reemplaza visualmente un botón “+” y añade su coste al acumulador. El usuario puede eliminar una unidad si desea cambiarla.

---

### 🎮 **Funcionalidades requeridas:**

- Sección principal de selección:
    - Espacios vacíos representados como botón “+”.
    - Cada unidad seleccionada aparece como card en su lugar.
    - Posibilidad de remover unidades seleccionadas (ícono de cerrar o “X”).
- Al hacer clic en “+”:
    - Se abre una UI emergente tipo `UnitPicker`.
    - Muestra todas las unidades desbloqueadas **menos** las ya elegidas.
    - Cada unidad aparece como card con nombre, icono y coste de liderazgo.
- Comportamiento dinámico:
    - Si seleccionar la unidad excede el liderazgo máximo, esa card aparece deshabilitada visualmente.
    - Al seleccionar una unidad válida, la UI se cierra y se coloca la unidad en la ranura.
- Visualización del liderazgo usado:
    - Barra o contador en pantalla: `42 / 60 puntos de liderazgo`.
    - Cambio de color si el límite está cerca.

---

### ⚙️ **Requisitos técnicos**

- Componente principal: `UnitSelectionPanel.cs`
    - Maneja slots visuales, acumulador y actualización dinámica.
- UI flotante: `UnitPickerModal.cs`
    - Genera la lista de cards a partir de `PlayerProfile.Units` filtrando:
        - Unidades ya seleccionadas.
        - Unidades cuyo coste excede el margen restante de liderazgo.
- Validaciones:
    - No permitir selección duplicada.
    - No permitir añadir si se supera el máximo.
- Scripts auxiliares:
    - `UnitCardDisplay`, `UnitSelectionSlot`, `LeadershipCounter`

---

### 🧪 **Criterios de aceptación**

- El jugador puede añadir unidades solo usando los botones `+`.
- La selección se realiza a través de una UI secundaria clara e intuitiva.
- El total de liderazgo usado se actualiza en tiempo real y previene errores.
- No se puede elegir unidades duplicadas ni que excedan el liderazgo permitido.
- El botón “Continuar” solo se habilita si hay al menos una unidad válida.
- La experiencia visual es clara, accesible y funcional en resoluciones comunes.

# Sin título 216df9df71028059b884cfc1c23fb7da

# Sin título

# Sistema de cola de batalla y creación automática 216df9df710281f394aadd675262d876

# Sistema de cola de batalla y creación automática de lobby

Descripción: Agrupar jugadores al azar en partidas y distribuirlos en bandos.
Prioridad: Alta
Etiquetas: Batalla, Matchmaking
Etapa: Planeación
Sistema Principal: Mapas
Fase: Matchmaking y Creación de Partida
orden: 63

### 🧭 **Tarea:** Sistema de cola de batalla y creación automática de lobby

**Descripción técnica detallada:**

Este sistema permite que los jugadores entren a batallas automáticamente sin emparejamiento manual. Al hacer clic en el botón “Batalla” desde el Feudo, el jugador es colocado en una **cola de espera**. El servidor (o un controlador local en MVP) agrupa a los jugadores de la cola en lobbies cuando hay suficientes disponibles (ej. 3v3). Una vez conformado un lobby, los jugadores se asignan aleatoriamente a un bando (atacantes o defensores) y se inicia la fase de preparación.

---

### 🎮 **Funcionalidades requeridas:**

- Interfaz simple para unirse a la cola (botón “Batalla” desde el Feudo).
- El jugador ve mensaje “Buscando partida…” mientras espera.
- El sistema agrupa automáticamente jugadores según la cantidad requerida.
- Distribución automática y balanceada entre bandos:
    - Ej: 3 jugadores → atacantes; 3 jugadores → defensores.
- Al llenar un lobby, se transiciona a la fase de preparación.
- Opcional: Cancelar cola mientras se espera.

---

### ⚙️ **Requisitos técnicos**

- Script central `MatchmakingManager.cs` (puede ser local o conectado a backend).
- Variables:
    - `QueueList<PlayerProfile>` – lista de espera activa.
    - `LobbyInstance` – clase con lista de jugadores, bandos, ID de mapa.
- Flujo:
    1. Jugador entra a cola → se añade a `QueueList`.
    2. Si hay suficientes, se crea `LobbyInstance`.
    3. Se asignan bandos aleatorios (`AssignTeams()`).
    4. Se envía señal a todos los jugadores del lobby para iniciar la preparación.
- Eventos:
    - `OnLobbyCreated(LobbyInstance lobby)`
    - `OnMatchFound(PlayerProfile player, LobbyInstance lobby)`

---

### 🧪 **Criterios de aceptación**

- El jugador puede entrar a la cola desde el Feudo sin errores.
- Una vez llena la cantidad requerida, el sistema crea el lobby automáticamente.
- Cada jugador es asignado correctamente a un bando.
- El flujo avanza directamente a la fase de preparación de batalla.
- No se producen duplicaciones, errores de asignación ni conflictos de bando.
- La experiencia es fluida desde el punto de vista del jugador.

# Sistema de Combate 214df9df71028168a6bfd00b49d24c34

# Sistema de Combate

Descripción: Detecta colisiones e implementa el cálculo de daño entre entidades del juego (héroes, tropas, enemigos).
Prioridad: Alta
Etiquetas: Sistema de Combate
Etapa: Por hacer
Sistema Principal: Control del Héroe, Sistema de Combate
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md)
Fase: Mecánicas de Combate
Subítem:  Implementar detección de impacto (Implementar%20deteccio%CC%81n%20de%20impacto%20215df9df71028027839ff538b6753904.md), Calcular daño y aplicar efectos (Calcular%20dan%CC%83o%20y%20aplicar%20efectos%20215df9df710280598a3ad31ea94d5b6e.md)
orden: 42

### 🧭 **Tarea:** Sistema de Combate

**Descripción técnica detallada:**

Desarrollar un sistema de combate en tiempo real que registre colisiones ofensivas (golpes, proyectiles) entre unidades y héroes, aplique daño diferenciado según el tipo (Cortante, Perforante, Contundente), evalúe defensas específicas del objetivo para ese tipo de daño, y compute la penetración correspondiente. La arquitectura debe permitir futuras expansiones con efectos especiales, habilidades activas y auras de combate.

---

### 🎮 **Funcionalidades requeridas:**

- Soporte para **tres tipos de daño**: Cortante, Perforante, Contundente.
- Evaluación de **defensas separadas** por tipo de daño.
- Aplicación de **penalización defensiva** según penetración del arma.
- Posibilidad de que cada ataque tenga un **componente mixto** de daño (ej. 70% cortante + 30% perforante).
- Reducción final de daño por fórmula:
    
    ```
    DañoTotal = (DañoBase × (1 - DefensaTipo/100)) × (1 + PenetraciónTipo/100)
    ```
    
- Detección de impacto usando hitboxes, raycast o `Animation Events`.
- Registro de eventos: impacto, daño, muerte.
- Soporte para mostrar daño numérico flotante (si se desea).
- Modularidad para conectar perks, buffs o auras que modifiquen daño o defensa.

---

### ⚙️ **Requisitos técnicos**

- Componente `HealthComponent` en todas las entidades vivas.
- Componente `DamageComponent` o `WeaponProfile` en armas/habilidades.
- Tipos de daño definidos como enumeración (`enum DamageType`) o data asset.
- Los héroes y tropas deben tener stats de defensa para cada tipo:
    
    ```
    DefensaCortante, DefensaPerforante, DefensaContundente
    ```
    
- Penetración configurada por arma o habilidad:
    
    ```
    PenetracionCortante, PenetracionPerforante, PenetracionContundente
    ```
    
- Sistema debe ser compatible con IA y jugador, y funcionar en multiplayer.
- Eventos centralizados para efectos visuales (`OnHit`, `OnKill`).

---

### 🧪 **Criterios de aceptación**

- Un golpe de arma aplica daño según tipo y atributos del atacante/defensor.
- Se distingue entre los tres tipos de daño y sus defensas asociadas.
- La penetración afecta correctamente la reducción de daño.
- El mismo sistema funciona con ataques de IA, héroes y proyectiles.
- El sistema puede recibir modificadores desde perks, auras o formaciones.
- El sistema es desacoplado del input o animación específica (invocable por código).

# Sistema de Formaciones (Estructura Táctica) 214df9df710281898045ff92b43d8fea

# Sistema de Formaciones (Estructura Táctica)

Descripción: Diseñar e implementar el sistema de datos que define las formaciones tácticas disponibles, sus propiedades y distribución para cada tipo de escuadra
Prioridad: Alta
Etiquetas: Formaciones, Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Formaciones
Bloqueado por: Gestión de Escuadras (Órdenes Básicas) (Gestio%CC%81n%20de%20Escuadras%20(O%CC%81rdenes%20Ba%CC%81sicas)%20214df9df7102810bae94d0178b87ec78.md)
Bloqueando: Implementar slots dinámicos para formaciones (Implementar%20slots%20dina%CC%81micos%20para%20formaciones%20214df9df7102817fbf5be4d9d6334072.md), Implementar cambio de formación (hotkey o menú) (Implementar%20cambio%20de%20formacio%CC%81n%20(hotkey%20o%20menu%CC%81)%20214df9df71028191b074cb0500d6b1b1.md)
Fase: Mecánicas de Combate
orden: 49

## 🧭 **Tarea:** Sistema de Formaciones (Estructura Táctica)

**Descripción técnica detallada:**

Crear la base de datos y la arquitectura general para el sistema de formaciones. Este sistema define **qué formaciones existen**, **qué escuadras pueden usarlas**, **cuántos miembros pueden contener**, y **cómo se distribuyen los slots tácticos**. Cada formación posee características únicas que afectan el comportamiento, espacio de despliegue, tipo de unidad compatible y estrategia. Este sistema alimenta los controladores de escuadra con los datos necesarios para posicionar unidades correctamente.

---

### 🎮 **Funcionalidades requeridas:**

- Definir múltiples formaciones preconfiguradas:
    - Línea (alineación frontal)
    - Columna (movimiento estrecho)
    - Cuña (penetración frontal)
    - Escudo (defensiva, cerrada)
- Cada formación debe contener:
    - Lista fija de posiciones relativas (`FormationSlot[]`)
    - Tamaño máximo de escuadra compatible
    - Posición relativa al líder o centro
    - Tipo de unidad que puede usarla (infantería, arqueros, etc.)
- Las escuadras solo podrán usar las formaciones definidas como válidas en su perfil.
- Propiedades tácticas adicionales (futuras expansiones):
    - Bonificaciones defensivas/ofensivas
    - Coste de reagrupamiento
    - Tipo de terreno recomendado

---

### ⚙️ **Requisitos técnicos**

- Objeto `FormationData` (como `ScriptableObject` o JSON):
    
    ```csharp
    csharp
    CopiarEditar
    [System.Serializable]
    public class FormationData {
        public string formationName;
        public List<Vector3> relativeSlots;
        public int maxUnits;
        public string unitType; // "Infantry", "Archers", etc.
        public Sprite icon;
    }
    
    ```
    
- Base de datos: `FormationDatabase` (cargada al inicio del juego).
- Cada escuadra debe tener una lista de formaciones válidas para su tipo.
- Sistema desacoplado del controlador de escuadra (solo provee los datos).

---

### 🧪 **Criterios de aceptación**

- Todas las formaciones del juego están definidas en una fuente de datos clara.
- Las escuadras solo muestran y aplican las formaciones que les corresponden.
- Los `slots` de cada formación reflejan el diseño táctico esperado.
- El sistema puede extenderse fácilmente con nuevas formaciones o ajustes.
- Los datos son utilizados correctamente por el controlador para posicionar unidades en formación.

# Sistema de Perks y Talentos 214df9df710281ce965ffbc441d224d1

# Sistema de Perks y Talentos

Descripción: Infraestructura central para gestionar perks pasivos, talentos activos y progresión personalizada del héroe.
Prioridad: Media
Etiquetas: Perks y Talentos
Etapa: Backlog
Sistema Principal: Perks y Talentos
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md), Estructurar sistema de perks (JSON / ScriptableObject) (Estructurar%20sistema%20de%20perks%20(JSON%20ScriptableObjec%20214df9df7102810f8c64f342447c1cf8.md)
Bloqueando: Aplicar perks pasivos al héroe (Aplicar%20perks%20pasivos%20al%20he%CC%81roe%20214df9df710281b89828d83fd1e73bc1.md)
Fase: Mecánicas de Combate
orden: 53

### 🧭 **Tarea:** Sistema de Perks y Talentos

**Descripción técnica detallada:**

Construir el sistema que permite a los héroes desbloquear, equipar y beneficiarse de perks y talentos. Este sistema es responsable de aplicar modificadores estadísticos pasivos, gestionar habilidades activables, y reflejar visualmente la progresión del jugador. Debe ser lo suficientemente flexible como para manejar múltiples árboles de talentos, condiciones de activación y efectos acumulativos, y debe integrarse con el perfil del héroe, la UI de habilidades y el combate.

---

### 🎮 **Funcionalidades requeridas:**

- **Carga y estructura de datos**:
    - Lectura de perks desde JSON o ScriptableObjects.
    - Categorización: ofensivos, defensivos, liderazgo, utilidad.
- **Gestión del progreso**:
    - Almacenamiento de perks desbloqueados.
    - Puntos de talento ganados por nivel u otras condiciones.
- **Aplicación de efectos**:
    - Perks pasivos que modifican stats (daño, defensa, moral, liderazgo...).
    - Talentos activos que se pueden asignar a botones o usar desde la UI.
- **Interacción con UI**:
    - Árbol de talentos (navegable e interactivo).
    - Vista previa de efectos antes de activar o desbloquear.
    - Retroalimentación visual al desbloquear perks.

---

### ⚙️ **Requisitos técnicos**

- Base de datos de perks (`PerkData`) y sistema de gestión (`PerkManager`).
- Interfaz `IPerkEffect` para aplicar efectos a cualquier entidad (jugador o tropa).
- Sistema de `StatModifier` acumulable por tipo (flat o porcentaje).
- Integración con:
    - `HeroStats`: para aplicar mejoras.
    - `HeroProfile`: para guardar perks desbloqueados.
    - UI de árbol de talentos o selector de perks.
- Eventos:
    - `OnPerkUnlocked`, `OnPerkApplied`, `OnTalentUsed`.

---

### 🧪 **Criterios de aceptación**

- El sistema carga todos los perks disponibles sin errores.
- El jugador puede desbloquear y aplicar perks según reglas del sistema.
- Los efectos pasivos afectan correctamente los stats del héroe en runtime.
- Los talentos activos se pueden asignar y activar desde la interfaz.
- Las elecciones se conservan entre sesiones (persistencia funcional).
- Es posible añadir nuevos perks sin modificar el sistema base.

# Sistema de Supply Points con control territorial 217df9df710280748412c06ee0ecfc6e

# Sistema de Supply Points con control territorial

Descripción: Punto de reabastecimiento que permite curar, cambiar la escuadra activa por otra *Troop* disponible o cambiar de arma, aplicando restricciones tácticas.
Prioridad: Media
Etiquetas: Combate, Gestión de Escuadra, Supply
Etapa: Backlog
Sistema Principal: Mapas
Fase: Batalla
Subítem: Diseñar entidad Supply Point en el mapa (con estados visuales) (Disen%CC%83ar%20entidad%20Supply%20Point%20en%20el%20mapa%20(con%20esta%20217df9df71028011948ddb977d4689a6.md),  Permitir cambio de escuadra dentro de zona de Supply (Permitir%20cambio%20de%20escuadra%20dentro%20de%20zona%20de%20Supp%20217df9df71028004a9a0e901427ac380.md), Restringir escuadras con menos de 10% de tropas vivas (Restringir%20escuadras%20con%20menos%20de%2010%25%20de%20tropas%20vi%20217df9df710280278ceede4bc6d7e977.md), Curación progresiva dentro del rango del Supply Point (Curacio%CC%81n%20progresiva%20dentro%20del%20rango%20del%20Supply%20P%20217df9df7102805794dafefcb6b5fc1d.md), Permitir cambio de arma del héroe interactuando con el Supply Point (Permitir%20cambio%20de%20arma%20del%20he%CC%81roe%20interactuando%20c%20217df9df710280808f6ef7200484b166.md), Lógica de exclusividad de escuadra activa (Lo%CC%81gica%20de%20exclusividad%20de%20escuadra%20activa%20217df9df71028095b0d7c5fe406da52f.md)
orden: 64

## **🧭 Sistema de Supply Points con control territorial**

**Descripción técnica detallada:**

Los Supply Points son áreas dentro del mapa de batalla que funcionan como zonas de apoyo táctico para los jugadores. Están diseñados para ofrecer múltiples funcionalidades, pero solo cuando pertenecen al bando del jugador. Estas funcionalidades incluyen la curación progresiva del héroe y su escuadra, la posibilidad de cambiar la escuadra activa por otra aún disponible, y el intercambio de arma principal del héroe.

Cada Supply Point puede estar en uno de tres estados:

- **Aliado**: accesible y funcional para el jugador.
- **Enemigo**: bloqueado para el jugador.
- **Neutral**: sin propietario y sin efectos activos.

Los héroes jugadores pueden capturar un Supply Point si permanecen dentro de su rango de acción durante un tiempo continuo, siempre y cuando el punto esté en estado neutral o sea del bando enemigo. Una vez conquistado, el punto cambia su estado visual y funcional para reflejar el nuevo bando propietario.

 Una vez conquistado, el Supply Point cambia de estado, actualiza su visual, y habilita o bloquea las siguientes funcionalidades:

- Cambio de escuadra activa
- Cambio de arma del héroe
- Curación progresiva del héroe y su escuadra

Este sistema permite rotaciones tácticas, zonas seguras móviles y gestión avanzada del desgaste en combate, elevando la profundidad estratégica del MVP sin introducir complejidad de múltiples escuadras simultáneas.

---

## 🔨 Subtareas sugeridas:

---

### 1. **Diseñar entidad Supply Point en el mapa**

- Crear prefab `SupplyPoint` con:
    - Collider (rango de acción).
    - Visual distintivo (bandera, círculo, glow).
    - Tag: `SupplyZone`.

---

### 2. **Permitir cambio de escuadra dentro de zona de Supply**

- Mostrar interfaz de cambio cuando el jugador está en rango.
- Listar **tropas** disponibles y vivas (≥ 11% de efectivos).
- Al seleccionar una:
    - Escuadra actual se desactiva con retardo de 5 segundos.
    - Nueva escuadra aparece dentro del rango del supply point.
    - Estado de escuadra actual pasa a “inactiva”.

---

### 3. **Restringir escuadras con menos de 10% de tropas vivas**

- Al abrir selector de escuadra:
    - Filtrar todas con `vidaUnidades < 10%` y mostrarlas deshabilitadas.
    - Si una escuadra fue seleccionada en fase de preparación pero está debajo del umbral, no puede ser reactivada.

---

### 4. **Permitir cambio de arma del héroe dentro de supply**

- Al estar dentro del rango:
    - Mostrar botón de “Cambiar arma”.
    - Mostrar armas desbloqueadas en el perfil.
    - Al seleccionar otra, aplicar de inmediato y reflejar visualmente.

---

### 5. **Curación progresiva dentro del rango de Supply Point**

- Al estar en rango:
    - Curar al héroe y escuadra lentamente cada X segundos.
    - Mostrar visual de “regeneración” (icono, efecto glow, partículas).
    - Aplicar `regenAmount` cada `tick` mientras permanezca en rango.

---

### 6. **Lógica de exclusividad de escuadra activa**

- Solo una escuadra del jugador puede estar viva a la vez.
- Al cambiar escuadra:
    - `SquadManager.SwitchTo(newSquad)`
    - Escuadra anterior es desactivada y destruida después del delay.

---

## ⚙️ Requisitos técnicos globales:

- Componente: `SupplyPoint.cs`
    - `float range`, `List<PlayerInRange>`, `HealTickRate`, `AllowInteraction()`
- Sistema de cambio: `SquadSwitcher.cs`
- Validación: `UnitAvailabilityChecker` (para % de tropas vivas)
- Armas: `HeroEquipmentManager.ChangeWeapon(WeaponID)`
- Prefab `SupplyPoint` con:
    - Collider de zona (`Trigger`)
    - Visual dinámico (`Color`, `Emblema`, `Captura UI`)
- Script `SupplyPointController.cs` con:
    - Estado: `enum SupplyState { Neutral, Ally, Enemy }`
    - Métodos: `CaptureTick()`, `ApplyHealing()`, `AllowInteraction()`
- Script `SquadManager.SwitchSquad(newSquad)`
    - Verifica si hay reemplazo válido
    - Aplica lógica de desaparición y entrada
- Integración con:
    - `HeroEquipmentManager` (cambio de arma)
    - `PlayerProfile.AvailableSquads`
- Feedback visual/audio para: captura iniciada, completada, rechazada

---

## 🧪 Criterios de aceptación globales:

- Jugador puede cambiar escuadra solo desde zona Supply, y si cumple condiciones.
- Escuadras inválidas (≤10% vivas) no pueden seleccionarse.
- Escuadra anterior desaparece correctamente tras 5s.
- Nueva escuadra aparece dentro del rango.
- Curación progresiva ocurre visual y mecánicamente dentro del rango.
- Solo se mantiene una escuadra activa a la vez.
- Cambio de arma del héroe ocurre solo en Supply Zone.
- Los Supply Points muestran correctamente su estado (azul, rojo, gris) según el bando.
- El héroe puede capturar puntos enemigos o neutrales tras un tiempo en su área.
- Solo Supply Points aliados otorgan funcionalidad (curación, cambios).
- El jugador no puede usar puntos enemigos ni mientras se están capturando.
- El sistema permite solo una escuadra activa por jugador, y reemplaza correctamente desde Supply.
- Las funciones se integran correctamente sin errores visuales ni de sincronización.

# Spawn automático de héroe + unidad en punto sele 216df9df710280cdbaf9cd4f5fb657fc

# Spawn automático de héroe + unidad en punto seleccionado

Descripción: Al iniciar combate, instanciar héroe y escuadra juntos, con la escuadra alineada al frente del héroe.
Prioridad: Alta
Etiquetas: Mapa de batalla
Etapa: Backlog
Sistema Principal: Mapas
Bloqueado por: Activar fase previa de preparación (3 minutos) (Activar%20fase%20previa%20de%20preparacio%CC%81n%20(3%20minutos)%20216df9df710280448e18da3cf76d68ff.md)
Fase: Preparación de Combate
Subítem: Aplicación de atributos a miembros de la escuadra (Aplicacio%CC%81n%20de%20atributos%20a%20miembros%20de%20la%20escuadra%20217df9df71028025b4a2cbb6947c9ae5.md), Asignación de equipamiento visual y funcional a miembros (Asignacio%CC%81n%20de%20equipamiento%20visual%20y%20funcional%20a%20m%20217df9df7102800aa21efa5031e82157.md)
orden: 37

### 🧭 **Tarea:** Spawn automático de héroe + unidad en punto seleccionado

**Descripción técnica detallada:**

Cuando comienza la fase de combate tras la preparación, el héroe seleccionado por el jugador y su escuadra activa deben aparecer en el campo de batalla en el punto de spawn previamente elegido. La escuadra debe estar posicionada de forma alineada y coherente delante del héroe, respetando la formación preestablecida. Este spawn debe realizarse automáticamente sin requerir acción del jugador, y garantizar que ambas entidades estén listas para recibir input o instrucciones.

---

### 🎮 **Funcionalidades requeridas:**

- Determinar el `SpawnPoint` elegido por el jugador durante la fase de preparación.
- Instanciar:
    - Prefab del héroe con equipo y visual asignado.
    - Prefab de la escuadra seleccionada (formación activa).
- Posicionar el héroe sobre el punto seleccionado.
- Calcular la posición de la escuadra al frente del héroe, según orientación del `SpawnPoint`.
- Activar control del jugador sobre el héroe y su escuadra.
- Registrar internamente que el spawn ha sido completado.

---

### ⚙️ **Requisitos técnicos**

- Script `BattleSpawnManager.cs` o parte de `CombatInitializer.cs`:
    - `SpawnHeroAndSquad(PlayerProfile profile, SpawnPoint point)`
- Uso de `Instantiate()` con posicionamiento en `SpawnPoint.transform.position`.
- Héroe:
    - `HeroPrefab` con `HeroController`, `EquipmentManager`, `Animator`, etc.
- Escuadra:
    - `SquadPrefab` instanciado con su formación y cantidad de unidades.
    - `SquadController` y AI si aplica.
- El `SpawnPoint` debe tener una orientación definida para colocar correctamente la escuadra al frente.
- Si multijugador:
    - Usar `NetworkServer.Spawn()` o RPCs para sincronizar aparición.

---

### 🧪 **Criterios de aceptación**

- Al comenzar el combate, el héroe y su escuadra aparecen automáticamente sin intervención.
- Se instancian en la posición correcta (punto elegido por el jugador).
- La escuadra aparece orientada hacia el enemigo, alineada al frente del héroe.
- Ambos están activos y listos para recibir input o IA según el caso.
- No hay colisiones extrañas, errores de aparición múltiple ni entidades fuera de lugar.
- La transición es inmediata y coherente con la fase anterior.

# Spawnear jugador en el Mapa de Feudo 216df9df710281db94c4c5fb21f88bb9

# Spawnear jugador en el Mapa de Feudo

Descripción: Instanciar personaje jugable con su visual y control activo en la ciudad.
Prioridad: Alta
Etiquetas: Feudo, Spawning
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Fase: Entrada y Presencia en Feudo
orden: 18

### 🧭 **Tarea:** Spawnear jugador en el Mapa de Feudo

**Descripción técnica detallada:**

Al terminar la carga del Mapa de Feudo, el jugador debe aparecer automáticamente en una posición predefinida del escenario, con control total sobre su héroe, incluyendo movimiento, cámara y visualización completa del modelo. El personaje debe reflejar la configuración guardada: apariencia, equipamiento, y skin. Esta tarea establece el punto inicial de interacción en la ciudad centralizada.

---

### 🎮 **Funcionalidades requeridas:**

- Instanciar el personaje del jugador en el punto de aparición al cargar el Feudo.
- Aplicar los datos persistidos:
    - Nombre del personaje.
    - Atributos visuales (armadura, armas, skin).
    - Prefab correspondiente al héroe activo.
- Activar:
    - Control de movimiento (`HeroController`).
    - Cámara (`ThirdPersonCamera` o `FreeCam`).
    - HUD principal si aplica.
- Posicionar al jugador en una zona válida, sin colisión con NPCs u otros jugadores.
- Asegurar que múltiples jugadores no aparezcan en el mismo punto si hay sistema en red.

---

### ⚙️ **Requisitos técnicos**

- Prefab de héroe (`HeroPrefab`) con:
    - `Animator`, `HeroController`, `EquipmentManager`, `Rigidbody`, `Collider`.
- Script `FeudoSceneManager.cs` o `PlayerSpawnHandler.cs`:
    - Detecta final de carga de escena.
    - Instancia el personaje desde `PlayerProfile.ActiveHero`.
    - Usa `SpawnPointFeudo` como posición inicial.
- Configuración visual:
    - Llama a `EquipmentManager.ApplyEquipment(HeroData.Equipment)`
    - Aplica skin si está seleccionada.
- Si multijugador:
    - Utilizar `NetworkSpawn` y asignar autoridad.
    - Sincronizar con otros jugadores conectados.

---

### 🧪 **Criterios de aceptación**

- El personaje del jugador aparece en la ciudad al terminar la carga sin errores.
- El modelo refleja correctamente su configuración visual.
- El jugador tiene control inmediato (movimiento + cámara).
- No aparece colisionando con otros objetos o personajes.
- El flujo es transparente para el jugador y ocurre sin pantallas adicionales.

# Transición automática si no se presiona continua 216df9df71028137ae7fe7b8775365e8

# Transición automática si no se presiona continuar a tiempo

Descripción: Si el jugador no confirma, se usa su selección actual.
Prioridad: Media
Etiquetas: Batalla, Flujo
Etapa: Planeación
Sistema Principal: Mapas
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md), Botón “Continuar” y bloqueo de selección (Boto%CC%81n%20%E2%80%9CContinuar%E2%80%9D%20y%20bloqueo%20de%20seleccio%CC%81n%20216df9df71028188b713c698e38880a1.md)
Fase: Preparación de Combate
orden: 33

### 🧭 **Tarea:** Transición automática si no se presiona continuar a tiempo

**Descripción técnica detallada:**

Durante la fase de preparación de batalla, el jugador tiene un tiempo límite para seleccionar unidades, loadout y punto de respawn. Si este tiempo se agota sin que el jugador presione el botón “Continuar”, el sistema debe forzar la transición automáticamente utilizando los datos seleccionados hasta ese momento. Esta lógica debe ser segura, prever configuraciones incompletas y permitir que la batalla continúe sin interrupciones.

---

### 🎮 **Funcionalidades requeridas:**

- Temporizador visible durante la fase de preparación (ej. 60 segundos).
- Comprobación constante del estado del botón “Continuar”.
- Al llegar a 0 segundos:
    - Deshabilitar inputs de preparación.
    - Tomar la configuración seleccionada (aunque incompleta).
    - Continuar hacia la pantalla de carga de batalla.
- Comportamiento idéntico al presionar “Continuar” manualmente.

---

### ⚙️ **Requisitos técnicos**

- Temporizador en UI controlado por `PreparationPhaseManager`.
- Script `PreparationTimer.cs` que dispara evento `OnTimeout()`.
- `OnTimeout()` debe:
    - Verificar si el jugador ya confirmó.
    - Si no, capturar lo seleccionado: unidades, punto de spawn, loadout.
    - Ejecutar `ConfirmSelectionAndContinue()` (mismo método que botón).
- Validaciones mínimas:
    - Si no hay unidades seleccionadas, elegir automáticamente las primeras disponibles dentro del liderazgo.
    - Si no hay punto de spawn, seleccionar uno al azar entre los disponibles del bando.

---

### 🧪 **Criterios de aceptación**

- Si el tiempo se agota y el jugador no ha confirmado, el sistema continúa automáticamente.
- La configuración usada es válida y no produce errores en la batalla.
- La transición es fluida e idéntica a la de confirmación manual.
- No hay crash, freeze o pérdida de datos por inacción del jugador.
- El jugador es notificado (visualmente o con sonido) de que el tiempo se agotó y la partida está iniciando.

# Transición de fase preparación a combate 216df9df7102801da210cc64064ff1b8

# Transición de fase preparación a combate

Descripción: Al terminar el contador, activar input de combate, formaciones, y control completo del jugador.
Prioridad: Media
Etiquetas: Mapa de batalla
Etapa: Backlog
Sistema Principal: Mapas
Bloqueado por: Crear UI de entrada a batalla (Crear%20UI%20de%20entrada%20a%20batalla%20215df9df71028061a527d08c625790bf.md)
Fase: Preparación de Combate
orden: 35

### 🧭 **Tarea:** Transición de fase preparación a combate

**Descripción técnica detallada:**

Una vez finalizada la fase de preparación de batalla —ya sea porque todos los jugadores presionaron “Continuar” o porque se agotó el tiempo límite—, debe activarse la transición a la fase de combate. Esta transición implica ocultar la UI de preparación, habilitar controles del jugador, inicializar el HUD de combate, activar la IA de unidades y permitir que todas las entidades entren en modo activo. Esta fase debe comenzar de forma sincronizada en todos los clientes en caso de multijugador.

---

### 🎮 **Funcionalidades requeridas:**

- Detectar finalización de la fase de preparación por:
    - Todos los jugadores confirmaron.
    - El contador global llegó a 0.
- Ocultar y desactivar la interfaz de preparación.
- Instanciar u "activar" las unidades ya colocadas en sus puntos de spawn.
- Activar los siguientes sistemas:
    - `PlayerInput` (movimiento, ataques).
    - `SquadController` del jugador.
    - `SquadAIController` de las unidades enemigas.
    - `FormationController` de cada escuadra.
- Habilitar HUD de combate si aplica.
- Desbloquear cámara de combate.
- Emitir evento global de `OnCombatStart()`.

---

### ⚙️ **Requisitos técnicos**

- Script controlador: `PreparationPhaseManager.cs`
    - Monitorea el estado de todos los jugadores o el tiempo restante.
    - Al finalizar, llama a `StartCombatPhase()`.
- Lógica de transición:
    - `UIManager.HidePreparationUI()`
    - `CombatManager.ActivateCombatSystems()`
- Si en red:
    - El host o servidor debe emitir evento RPC `StartCombat()` sincronizado a todos los jugadores.
    - Usar `Mirror`, `Photon`, etc., según el backend.

---

### 🧪 **Criterios de aceptación**

- Al terminar la preparación, el jugador entra automáticamente en combate sin intervención extra.
- Todos los controles se activan correctamente (héroe, cámara, escuadra).
- No se puede seguir modificando unidades ni punto de spawn.
- Las unidades comienzan a reaccionar según su IA o formaciones establecidas.
- No hay congelamientos, errores visuales ni comportamientos fuera de sincronía (si multiplayer).
- El HUD cambia de preparación a combate, si aplica.

# Utilidades de desarrollo y depuración 214df9df710281f4917ce96ecbab9600

# Utilidades de desarrollo y depuración

Descripción: Scripts de apoyo para pruebas rápidas de funcionalidades.
Prioridad: Media
Etiquetas: Control del Héroe, pasos iniciales
Etapa: Backlog
Fase: Otros
orden: 73

# Validación técnica del prototipo 214df9df710281e9b8d7de6c5e4bc75f

# Validación técnica del prototipo

Descripción: Validar que el proyecto puede compilar, ejecutarse y correr de forma estable con lo implementado.
Prioridad: Alta
Etiquetas: Multiplayer
Etapa: Por hacer
Fase: Validación Prototipo
orden: 72

# Vincular animaciones de movimiento 214df9df71028186a99dddcaace1292a

# Vincular animaciones de movimiento

Descripción: Animaciones simples (idle, walk, run) conectadas por Blend Tree.
Prioridad: Media
Etiquetas: Animación
Etapa: Por hacer
Sistema Principal: Control del Héroe
Bloqueado por: Implementar movimiento de héroe (Implementar%20movimiento%20de%20he%CC%81roe%20214df9df7102817aa696f1bf9ad434c9.md)
Fase: Mecánicas de Combate
orden: 39

### 🧭 **Tarea:** Vincular animaciones de movimiento

**Descripción técnica detallada:**

Conectar el controlador de animaciones del héroe a un `Animator Controller` funcional que use un Blend Tree para interpolar entre los estados de movimiento básicos: idle, caminar y correr. Esta tarea permite que el movimiento del héroe tenga retroalimentación visual coherente en función de la velocidad o dirección del desplazamiento.

---

### 🎮 **Funcionalidades requeridas:**

- Creación de un `Animator Controller` asociado al prefab del héroe.
- Implementación de un Blend Tree en modo `2D Freeform Directional` o `1D` (según el caso).
- Transiciones suaves entre los clips `Idle`, `Walk` y `Run` con un único parámetro de entrada (`Speed` o `Velocity`).
- Conexión entre el script de movimiento y el `Animator` mediante `SetFloat()` o equivalente.
- Clips de animación placeholders o definitivos deben ser importados y correctamente escalados.
- El héroe debe detenerse visualmente cuando no recibe input.

---

### ⚙️ **Requisitos técnicos**

- `Animator Controller` guardado como `HeroMovement.controller` dentro de `/Animations/Controllers/`.
- Blend Tree funcional creado dentro del estado base (`Locomotion` o equivalente).
- Clips base almacenados en `/Animations/Clips/`.
- Controlador asignado al `Animator` del prefab del héroe.
- Escala y pivote de las animaciones deben ser coherentes con el modelo placeholder.

---

### 🧪 **Criterios de aceptación**

- El héroe reproduce la animación `Idle` sin input.
- Se transiciona correctamente a `Walk` y luego a `Run` con input creciente.
- No se generan errores de consola ni warnings por el `Animator`.
- El parámetro de velocidad (`Speed`, `Velocity`) cambia correctamente desde el script.
- La reproducción es fluida y sin reinicios visibles o saltos de estado.

# Vincular escuadra al héroe jugador 214df9df7102817db0e9c135014e9e91

# Vincular escuadra al héroe jugador

Descripción: Establecer la relación funcional entre el héroe del jugador y la escuadra instanciada a partir de la *Troop* seleccionada, asegurando que no pueda ser controlada por ningún otro héroe.
Prioridad: Alta
Etiquetas: Gameplay, Gestión de Escuadra
Etapa: Por hacer
Sistema Principal: Gestión de Escuadra
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md), Crear estructura de escuadra base (clase y prefab) (Crear%20estructura%20de%20escuadra%20base%20(clase%20y%20prefab)%20214df9df7102818e9484eacdeab50adb.md)
Bloqueando: Implementar sistema de órdenes básicas (Implementar%20sistema%20de%20o%CC%81rdenes%20ba%CC%81sicas%20214df9df71028178b6e0d76c81158398.md)
Fase: Mecánicas de Combate
orden: 45

## 🧭 **Tarea:** Vincular escuadra al héroe jugador

**Descripción técnica detallada:**

Implementar el vínculo lógico entre un héroe jugador y una escuadra seleccionada desde el loadout previo a la partida. Esta escuadra pasa a estar bajo control exclusivo del héroe, recibiendo sus órdenes tácticas. Una vez asignada, dicha escuadra queda bloqueada para otros héroes o controladores del juego. Esta lógica evita conflictos de control, duplicación o interferencia entre múltiples jugadores o entidades IA con capacidades similares.

---

### 🎮 **Funcionalidades requeridas:**

- Al comenzar la partida o tras despliegue:
    - Cada escuadra es instanciada desde su **Troop** y asignada al héroe correspondiente.
    - La escuadra pasa a un estado “controlada” y se vincula como propiedad exclusiva del héroe.
- El héroe puede emitir órdenes (`Follow`, `Hold`, `Attack`) únicamente a su escuadra asignada.
- La escuadra:
    - Responde solo a su líder vinculado.
    - Rechaza órdenes externas de otros héroes o sistemas.
- Impide la re-asignación una vez vinculada, salvo destrucción o reinicialización.

---

### ⚙️ **Requisitos técnicos**

- `SquadController` debe tener una propiedad:
    
    ```csharp
    public Transform AssignedLeader;
    public bool IsAssigned => AssignedLeader != null;
    ```
    
- En el `HeroController`:
    - Método `AssignSquad(SquadController squad)` verifica si ya está asignada.
    - Si lo está, se cancela o se lanza advertencia.
- En `SquadController`, validar en `ReceiveOrder()`:
    
    ```csharp
    if (sender != AssignedLeader) return;
    ```
    
- El sistema debe bloquear múltiples asignaciones desde UI, código o instanciación simultánea.

---

### 🧪 **Criterios de aceptación**

- Una escuadra se puede asignar solo una vez y solo a un héroe.
- El héroe puede controlar su escuadra, pero no otras.
- Intentos de múltiples asignaciones no causan errores ni colisiones de lógica.
- La escuadra no ejecuta órdenes de otro líder no autorizado.
- En multiplayer, la asignación se respeta de forma segura entre clientes/servidor.

# Visualizar personaje en 3D con equipo y skin 216df9df710281c4a592c8a006b97f08

# Visualizar personaje en 3D con equipo y skin

Descripción: Mostrar el modelo con su equipo y apariencia activa en la interfaz de selección.
Prioridad: Media
Etiquetas: Personajes, Visualización
Etapa: Planeación
Sistema Principal: Sistema de Usuario
Bloqueado por: Crear prefab base del héroe (Crear%20prefab%20base%20del%20he%CC%81roe%20214df9df7102816db180fa4dc3173155.md)
Fase: Login y Selección de Personaje
orden: 12

### 🧭 **Tarea:** Visualizar personaje en 3D con equipo y skin

**Descripción técnica detallada:**

Al seleccionar un personaje en la pantalla de selección, debe mostrarse su modelo 3D completo en tiempo real, con el equipamiento que tenga asignado (armadura, armas) y cualquier skin visual aplicada. Esta visualización permite al jugador ver exactamente cómo se verá en el juego antes de entrar. El modelo debe rotar opcionalmente, estar bien iluminado y representar con fidelidad la apariencia final en el mapa de Feudo y en combate.

---

### 🎮 **Funcionalidades requeridas:**

- Mostrar un modelo 3D del personaje seleccionado en una sección destacada de la pantalla.
- Visualizar:
    - Equipamiento (armas, armaduras).
    - Skins o personalización cosmética.
    - Animación base (idle en loop).
- Permitir que el modelo gire automáticamente o mediante control del usuario (opcional).
- Actualizar dinámicamente el modelo cada vez que se selecciona un personaje distinto.

---

### ⚙️ **Requisitos técnicos**

- Prefab del viewer: `HeroViewerUI`
    - Contiene:
        - Cámara específica (`ViewerCam`)
        - Light rig local
        - Render texture sobre panel de UI
- Script `CharacterPreviewManager.cs`:
    - Método: `DisplayHero(HeroData data)`
        - Instancia el modelo base
        - Aplica equipamiento (`EquipmentManager.ApplyTo(model)`)
        - Aplica skin si corresponde (`SkinManager.SetSkin`)
- Animación: Idle básica (`AnimatorController`) sin transición de estado.
- Zona de visualización sin colisiones ni físicas.

---

### 🧪 **Criterios de aceptación**

- Al seleccionar un personaje, se muestra su versión visual 3D con equipo y aspecto correcto.
- No hay errores visuales, modelos flotantes ni faltantes.
- El cambio entre personajes se refleja de inmediato en pantalla.
- El personaje está bien iluminado, visible y claramente identificado.
- El jugador puede rotar el modelo o verlo en movimiento idle según configuración.