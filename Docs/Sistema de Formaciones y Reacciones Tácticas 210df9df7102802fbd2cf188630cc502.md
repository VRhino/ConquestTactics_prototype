# Sistema de Formaciones y Reacciones Tácticas

### 🧱 Formaciones Básicas

Cada escuadra puede adoptar una **formación**, que modifica su comportamiento, posición y rendimiento. Cambiar de formación toma un tiempo de maniobra (animación + reposicionamiento), y es fundamental para adaptarse a situaciones de combate dinámico.

| Formación | Uso principal | Ventaja táctica | Debilidad |
| --- | --- | --- | --- |
| **Línea** | Estándar, equilibrio ofensivo/defensivo | Buen daño frontal y cobertura básica | Vulnerable a flanqueo |
| **Cuña** | Ataque frontal agresivo | Aumenta penetración y velocidad de carga | Frágil si se detiene o queda aislada |
| **Círculo** | Defensa contra flanqueos o caballería | 360° de cobertura, buena moral y resistencia | Poca movilidad y capacidad ofensiva |
| **Testudo** | Defensa contra proyectiles | Altísima resistencia a proyectiles y moral alta | Muy lenta y débil en combate cuerpo a cuerpo directo |
| **Amplia** | Cobertura y visibilidad | Ocupa más espacio, mejor contra ataques a distancia, más movilidad | Muy frágil si es alcanzada cuerpo a cuerpo, difícil de reorganizar |

---

### 🧠 Reacciones Tácticas

### ⚔️ Flanqueo

- Si una unidad es **atacada desde los costados o por la retaguardia**, sufre efectos negativos adicionales:
    - **+30% de daño recibido**
    - **Pérdida acelerada de moral**
    - **Desorganización**: mayor tiempo para cambiar de formación o reagruparse

> 🔹 Las formaciones Círculo y Testudo reducen estos efectos, aunque no los anulan completamente.
> 

### 🧍‍♂️ Reacciones Automáticas

Las unidades pueden tener activadas **respuestas automáticas** ante amenazas, si están habilitadas por el jugador:

- **Ataque por el flanco** (en Línea):
    - Intentan **girar parcialmente** para enfrentar al enemigo, si el espacio lo permite.
    - Si la moral baja demasiado, la formación puede **romperse**.
- **Carga enemiga detectada** (caballería o infantería pesada):
    - Cambian automáticamente a una formación más defensiva:
        - A **Círculo** o **Testudo** si son unidades estáticas
        - A **Cuña** si están en ofensiva o son caballería

---

### 🎯 Control de Formaciones

- Se cambia de formación mediante **atajos (hotkeys)** o desde un **menú radial/contextual**.
- El cambio tiene:
    - **Tiempo de ejecución**: 1–3 segundos según tamaño y tipo de unidad.
    - **Riesgo de interrupción**: si la unidad está bajo ataque intenso.

> 🔸 Se pueden asignar formaciones preferidas por escuadra en los loadouts previos a la partida.
> 

---

### 🌍 Interacción con el Terreno

El tipo de terreno **modifica la efectividad** de cada formación:

- **Elevado**: mejora ataque de unidades a distancia.
- **Estrecho o urbano**: Testudo y Línea tienen ventaja al canalizar ataques.
- **Abierto**: Cuña y Amplia pueden explotar su movilidad.
- **Barro, agua, laderas**: reducen movilidad, aumentan el tiempo de formación.

---

### 🧬 Sinergias entre Formaciones

Ciertas combinaciones crean **estructuras tácticas avanzadas**:

- **Martillo y yunque**
    - Frente: Infantería en Línea o Testudo para aguantar.
    - Flancos: Caballería en Cuña o infantería ligera para rodear.
- **Flecha defensiva**
    - Frente: Testudo avanza cubriendo.
    - Retaguardia: Arqueros en Amplia disparan sin riesgo.
- **Trampa en Círculo**
    - Escuadra enemiga es contenida por una formación en Círculo.
    - Otras unidades rodean y atacan desde el exterior.
- **Línea con picas** *(nombre tentativo)*
    - Escudo pesado en línea al frente.
    - Justo detrás: lanceros o alabarderos para extender el alcance y daño.

---

### 📊 Comparativa de Formaciones (Explicada)

> Cada valor se representa en relación al estándar base (100%). Por ejemplo, 130% de ataque frontal significa +30% sobre el daño estándar. Son referencias para balance interno y toma de decisiones.
> 

| Atributo | Qué mide | Línea | Cuña | Círculo | Testudo | Amplia |
| --- | --- | --- | --- | --- | --- | --- |
| **Ataque frontal** | Daño infligido al enfrentar al enemigo directamente | 100% | **130%** (carga mejorada) | 70% | 30% | 90% |
| **Defensa frontal** | Capacidad de bloquear daño frontal | 100% | 80% | 90% | **130%** | 60% |
| **Resistencia a proyectiles** | Reducción de daño recibido por flechas y proyectiles | 80% | 50% | 70% | **150%** | 30% |
| **Moral base** | Moral inicial y resistencia al pánico | 100% | 110% | **120%** | 110% | 80% |
| **Movilidad** | Velocidad y capacidad de cambiar de posición | 100% | 120% | 60% | 40% | **130%** |
| **Tiempo de formación** | Tiempo en segundos para cambiar a esta formación | 1s | 1.5s | 2s | 2.5s | **0.5s** |