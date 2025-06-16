# Sistema de Talentos / Perks

### 📜 Descripción General

Los talentos (perks) son **modificadores pasivos y activos** que el jugador desbloquea para personalizar su estilo de juego, su rol en combate y la sinergia con su escuadra. El sistema está basado en un **árbol de progresión tipo Path of Exile**, con rutas ramificadas y desbloqueo secuencial.

---

### 🌲 Estructura General

El árbol de talentos se divide en **5 ramas principales**:

| Rama | Enfoque | Afecta a… |
| --- | --- | --- |
| **Ofensiva** | Aumentar daño, presión, velocidad de carga | Héroe y algunas tropas |
| **Defensiva** | Resistencia, moral, aguante físico y contra cargas | Héroe y tropas |
| **Táctica** | Mejoras de formación, habilidades activas, reacción | Escuadras y control |
| **Liderazgo** | Buffs globales, economía de tropas, sinergias de unidades | Escuadras y aliados |
| **Especialización de Clase** | Talentos únicos según tipo de arma o rol | Solo al héroe |

---

### 🧩 Ejemplos por Rama

### 🗡️ **Ofensiva**

- **Ira Marcial**: +10% daño cuerpo a cuerpo si tu moral es superior a la del enemigo.
- **Carga Sanguinaria** *(Activa)*: Tu próxima carga inflige sangrado durante 5 s.
- **Presión Implacable**: -10% CD de habilidades ofensivas.

### 🛡️ **Defensiva**

- **Voluntad Inquebrantable**: +15% resistencia a daño de carga frontal.
- **Disciplina de Hierro**: Tropas aliadas tardan un 25% más en romper formación por moral baja.
- **Aguante del Vanguardia** *(Pasiva)*: Regeneras salud al permanecer cerca de 3+ aliados.

### 🧠 **Táctica**

- **Maniobra Rápida**: -30% tiempo al cambiar de formación.
- **Reacción Coordinada**: Al ser flanqueadas, tus tropas ganan +20% defensa temporal.
- **Grito Estratégico** *(Activa)*: Grito de batalla que aumenta moral aliada en radio cercano.

### 🎖️ **Liderazgo**

- **Inspiración de Batalla**: +1 punto de liderazgo permanente.
- **Veteranos Entrenados**: Unidades comienzan con +10% vida máxima.
- **Adaptabilidad**: Permite reemplazar una unidad durante la fase de despliegue.

### ⚔️ **Especialización de Clase** *(ejemplos por tipo)*

- **Arquero – Flecha Llameante** *(Activa)*: Disparo que inflige daño por quemadura.
- **Espada/Escudo – Guardián del Frente** *(Aura pasiva)*: Aliados en cono frontal ganan +10% moral.
- **Guja – Tajo Heroico**: Ataque en área que empuja enemigos y rompe formación.

---

### 🔄 Progresión y Desbloqueo

- **Puntos de talento** se obtienen al:
    - Subir de nivel.
    - Completar retos de clase.
    - Hitos de progresión narrativa.
    - Participar en eventos de clan/gremio.
- **Desbloqueo en cadena**:
    - Cada perk tiene prerequisitos que obligan a avanzar en ramas específicas.
    - Las rutas se bifurcan para permitir especialización sin encierro.
- **Activos vs. Pasivos**:
    - Algunos perks otorgan **habilidades activas** que se integran en el set de habilidades del héroe.
    - Otros son pasivos y se activan automáticamente.
- **Equipamiento y Perks**:
    - Algunos perks están **bloqueados por tipo de clase** o **arma equipada**.

---

### 🔁 Reseteo de Perks

- **Libre y sin coste** desde el menú principal o cuartel.
- Puedes experimentar con builds sin penalización.

---

### 🧬 Integración con Loadouts

- Cada **loadout** puede tener su propio set de perks.
- Permite adaptarse rápidamente al mapa, composición aliada o estilo de juego.

---

### 📊 Ejemplo de Escalado

- Algunos perks escalan con atributos del héroe:
    - Ej.: Perk de daño escala +5% por cada 10 puntos de Fuerza.
- Otros modifican directamente habilidades activas o interacciones con tropas.

---

### ⚠️ Limitaciones activas

- Se puede limitar el número de **perks activos simultáneamente** (ej. 5 pasivos + 2 activos).
- El jugador puede gestionar qué perks prioriza dentro de un **espacio de slots**.

lista de talentos

| ID | Nombre | Rama | Tipo | Efecto | Afecta a | Requisitos | Clase requerida | Notas de balance |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| OF01 | Ira Marcial | Ofensiva | Pasivo | +10% daño cuerpo a cuerpo si moral aliada > moral enemiga | Ambos | Ninguno | - | Escala con moral |
| OF02 | Carga Sanguinaria | Ofensiva | Activo | La próxima carga inflige sangrado (5s) a enemigos en línea recta | Héroe | OF01 | - | Cooldown: 15s |
| OF03 | Presión Implacable | Ofensiva | Pasivo | -10% de enfriamiento de habilidades ofensivas | Héroe | Ninguno | - | Mejora versatilidad en combate |
| OF04 | Golpe Aplastante | Ofensiva | Pasivo | +20% daño a enemigos derribados o desorganizados | Héroe | OF01 | - | Ideal para sinergias con flanqueo |
| DEF01 | Voluntad Inquebrantable | Defensiva | Pasivo | +15% resistencia al daño de cargas frontales | Tropas | Ninguno | - | Contra caballería |
| DEF02 | Disciplina de Hierro | Defensiva | Pasivo | -25% probabilidad de romper formación por baja moral | Tropas | DEF01 | - | Solo cuando están en formación |
| DEF03 | Aguante del Vanguardia | Defensiva | Pasivo | +2% de regeneración de salud/seg si estás junto a 3+ aliados | Héroe | Ninguno | - | Solo fuera de combate |
| DEF04 | Guardia Inmóvil | Defensiva | Pasivo | +20% defensa al estar quieto por más de 3s | Héroe | DEF02 | - | Reinicia si el jugador se mueve |
| TAC01 | Maniobra Rápida | Táctica | Pasivo | -30% al tiempo de cambio de formación | Tropas | Ninguno | - | Aumenta eficiencia táctica |
| TAC02 | Reacción Coordinada | Táctica | Pasivo | +20% defensa durante 5s si tus tropas son flanqueadas | Tropas | TAC01 | - | Buff reactivo |
| TAC03 | Grito Estratégico | Táctica | Activo | Aumenta moral aliada cercana por 8s | Ambos | TAC01 | - | Cooldown: 30s |
| TAC04 | Comando Instintivo | Táctica | Pasivo | -1s de latencia en ejecución de órdenes a escuadras | Tropas | Ninguno | - | Mejora control en combate |
| LID01 | Inspiración de Batalla | Liderazgo | Pasivo | +1 punto de liderazgo base | Ambos | Ninguno | - | Permite comandar más unidades |
| LID02 | Veteranos Entrenados | Liderazgo | Pasivo | Tropas comienzan con +10% de vida base | Tropas | LID01 | - | Mejora durabilidad inicial |
| LID03 | Adaptabilidad | Liderazgo | Pasivo | Permite cambiar 1 unidad antes de la batalla | Tropas | LID01 | - | Solo 1 vez por combate |
| LID04 | Espíritu de Compañía | Liderazgo | Pasivo | Aura: +5% moral y daño a aliados cercanos | Tropas | LID01 | - | Radio de 8m, no acumulable |
| CL01 | Flecha Llameante | Especialización | Activo | Flecha cargada inflige quemadura durante 5s | Héroe | Nivel 3 | Arquero | No acumulable con otros efectos DOT |
| CL02 | Guardián del Frente | Especialización | Aura | +10% moral a aliados en cono frontal | Tropas | Nivel 4 | Espada y Escudo | Cono de 120°, útil en formaciones |