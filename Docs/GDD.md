================================================================================
# GDD — Conquest Tactics 20ddf9df7102800ca583f536cedf593c
================================================================================

# GDD —  Conquest Tactics

### 🧠 1. Resumen General

- **Nombre del juego (tentativo)**: *Conquest Tactics*
- **Género**: Táctico / Estrategia en tercera persona con control de escuadras
- **Plataforma objetivo**: PC (a futuro: multiplataforma)
- **Motor de juego**: Unity 3D
- **Estilo de cámara**: Tercera persona, seguimiento al héroe
- **Inspiraciones/referencias**: *Conqueror’s Blade*, *Mount & Blade*, *Total War: Arena*
- **Resumen del juego**:
    
    Juego táctico por equipos en el que cada jugador controla un héroe y su escuadra. Combates PvP a gran escala con énfasis en la posición, moral y sinergia entre tropas.
    
- **Público objetivo**: Jugadores de estrategia y táctica, amantes de la historia y combate medieval, entre 16 y 40 años.

---

### 🛡️ 2. Ambientación & Estética

- **Época histórica o ficticia**: Medieval ficticio con inspiración europea
- **Lugar o región**: Continente ficticio dividido en regiones
- **Estilo visual**: Realista estilizado, semi-lowpoly
- **Lore o narrativa (si aplica)**: En desarrollo. Incluye facciones enfrentadas por el control de territorios clave
- **Facciones o casas jugables (si existen)**: No definidas aún

---

### ⚔️ 3. Jugabilidad principal

### Control del jugador:

- Movimiento libre: ✅ Sí
- Ataques cuerpo a cuerpo: ✅ Sí
- Habilidades especiales: ✅ Algunas disponibles por tipo de héroe
- Cámara controlada por el jugador: ✅ Sí

### Escuadrón:

- Máximo de unidades por jugador: 1 escuadra controlable (número variable según tipo)
- Tipos de tropas iniciales: Espadachines, lanceros, arqueros
- Órdenes disponibles: Seguir, esperar, atacar, mantener posición
- Formaciones: En desarrollo (formación básica por defecto)
- Composición: Editable desde el barracón
- IA: Táctica básica (sigue órdenes, combate automático)

---

### 🧠 4. Sistema de combate

- ¿Combate en tiempo real o por turnos?: Tiempo real
- ¿Control directo o semi-automático?: Control directo del héroe, semi-automático de escuadra
- ¿Cómo se calcula el daño?: Según tipo de arma, tipo de unidad, stats, moral
- **Stats principales de unidades**: Moral, daño, defensa, agresividad, temor, masa, velocidad, liderazgo
- ¿Moral y retirada?: ✅ Sí
- ¿Permite combos o habilidades encadenadas?: Habilidades especiales, no combos complejos

---

### 🗺️ 5. Escenarios y mapas

- Tipos de mapa: Bosques, fortalezas, campos abiertos, desfiladeros
- Tamaño estimado: 250m x 250m (aproximado)
- Objetos interactivos: Puntos de captura, puertas, murallas
- Obstáculos: Terreno, estructuras, colisiones físicas
- Altura, clima, visibilidad: Afecta estrategia y posicionamiento (visión en niebla)

---

### 🧩 6. Modos de juego

### Modo principal:

- Multijugador PvP: ✅ Sí
- Jugadores por equipo: 3v3 (ajustable en pruebas)
- Objetivo para ganar: Puntos de captura o eliminación total
- Tiempo límite: Sí (modo competitivo)

### Otros modos (futuro):

- IA vs jugador (entrenamiento)
- Campaña narrativa o escaramuza offline

---

### 🌐 7. Multiplayer

- Librería de red: Mirror
- Matchmaking: Por lobby (MVP) — futuro: automático por MMR
- Persistencia de datos: ✅ Sí (niveles, monedas, desbloqueos)
- Sistema de chat / ping: Básico en MVP (texto)
- Cross-platform: No en MVP
- Sincronización de unidades: Posición, animaciones, órdenes

---

### 🧭 8. Progresión y personalización

- Progreso del jugador: ✅ Nivel de cuenta (desbloquea perks)
- Tropas mejoran: ✅ Suben de nivel y se personalizan
- Desbloqueo de unidades nuevas: ✅ Por nivel de cuenta y monedas
- Personalización visual: ✅ Skins de héroe y escuadras
- Sistema de economía:
    - **Bronce**: Moneda base (NPCs)
    - **Plata**: Intercambio entre jugadores
    - **Oro**: Premium (dinero real)
- Tienda de NPCs y mercado entre jugadores
- Retos diarios/semanales

---

### ⚒️ 9. Crafteo y recursos

- Materiales: Hierro, cuero, tela, madera, acero templado, esencias mágicas (opcionales)
- Fuentes: Loot, desmantelar objetos, misiones
- Requiere: Planos, nivel de crafting, tiempo corto
- Rarezas de objetos: Común, poco común, raro, único

---

### 🏅 10. Rangos Competitivos (PvP)

- Rangos:
    1. **Aspirante**
    2. **Guerrero**
    3. **Veterano**
    4. **Campeón**
    5. **Gran Campeón**
- Reinicio por temporada: ✅ Sí
- MMR: Solo basado en victorias
- Recompensas: Skins, consumibles exclusivos

---

### 🧱 11. Sistema de Barracón

- Gestión de unidades desbloqueadas
- Espacios limitados → se amplían con eventos/logros
- Permite movilizar nuevas unidades (si están desbloqueadas)
- Permite **desvandar** unidades para liberar espacio
- No se pueden fusionar ni perder por muerte
- Visualización de stats, skins, nivel, rareza
- 3 Loadouts configurables por tipo de escuadra

---

### 🎨 12. Arte y recursos

- Estilo artístico: Realista simplificado / estilizado
- Recursos iniciales:
    - Modelos 3D: Tropas, héroes, armas, entornos
    - Animaciones: Caminata, ataque, formación, moraleja
    - UI: Paneles de escuadra, menú barracón, HUD
    - HUD / Menús: Indicadores de orden, mapa, salud
    - Sonido / música: Ambientes medievales, tambores de guerra
- Fuentes: Mix de assets propios + packs de tiendas como Unity Asset Store

---

### 🛠 15. Herramientas y tecnologías

- **Motor :** Unity 3D 2022.3.62f1
- **Lenguaje**: C#
- **Multiplayer**: Mirror
- **Repositorio**: Git + GitHub
- **Modelado / Arte**: Blender (opcional), Asset Store
- **Gestión de proyecto**: Notion

---

[**Sistemas y Mecánicas Abordadas (Actualizado)**](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Sistemas%20y%20Meca%CC%81nicas%20Abordadas%20(Actualizado)%2020fdf9df7102807b98b1ef0e2a8b7e39.md)

[Héroes](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/He%CC%81roes%2020fdf9df7102808090add30f63ecd608.md)

[Liderazgo, Formaciones y Matchmaking](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Liderazgo,%20Formaciones%20y%20Matchmaking%2020ddf9df7102803a8f3bfdb61d1b7540.md)

[Sección: Unidades (Tropas)](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Seccio%CC%81n%20Unidades%20(Tropas)%2020ddf9df710280bd896bf6c0d611c830.md)

[Sección: Economía y Progresión del Jugador](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Seccio%CC%81n%20Economi%CC%81a%20y%20Progresio%CC%81n%20del%20Jugador%2020fdf9df7102800ba9c8ff4c92f2b478.md)

[Mecánica: El Barracón](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Meca%CC%81nica%20El%20Barraco%CC%81n%2020fdf9df7102803eabd4cd8343cbc234.md)

[Sistema de Formaciones y Reacciones Tácticas](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Sistema%20de%20Formaciones%20y%20Reacciones%20Ta%CC%81cticas%20210df9df7102802fbd2cf188630cc502.md)

[Sistema de Clanes / Gremios](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Sistema%20de%20Clanes%20Gremios%20210df9df71028093a2d1c956346eb5be.md)

[Sistema de Talentos / Perks](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Sistema%20de%20Talentos%20Perks%20210df9df710280afa270ec2a4b328cbc.md)

[Lógica de Mapas](GDD%20%E2%80%94%20Conquest%20Tactics%2020ddf9df7102800ca583f536cedf593c/Lo%CC%81gica%20de%20Mapas%20216df9df7102809496e4e2702f9ce069.md)

================================================================================
# Sistema de Clanes Gremios 210df9df71028093a2d1c956346eb5be
================================================================================

# Sistema de Clanes / Gremios

Los **Clanes** (o **Gremios**, nombre a definir) son organizaciones sociales dentro del juego formadas por jugadores. Representan una **estructura persistente de cooperación**, competencia y progreso compartido, con funcionalidades tanto sociales como estratégicas.

---

### 🧩 Funcionalidades Clave

| Sistema | Descripción |
| --- | --- |
| **Creación de Clan** | Requiere un mínimo de nivel e inversión en oro u otro recurso. El jugador que lo crea se convierte en el **Líder del Clan**. |
| **Miembros** | Límite inicial de miembros (ej. 20), ampliable mediante mejoras del clan. Roles jerárquicos: Líder, Oficiales, Veteranos, Miembros. |
| **Nombre, Estandarte y Lema** | Personalización visual y temática del clan. Aparece en combate, rankings y eventos. |
| **Chat y Comunicaciones** | Canales dedicados de texto y voz (integrados o vía plataformas externas enlazables). Notificaciones internas. |
| **Gestión y Roles** | Asignación de permisos por jerarquía (reclutar, expulsar, declarar guerras, editar el escudo del clan, etc.). |

---

### 🌍 Funciones de Clan en el Metajuego

| Función | Detalles |
| --- | --- |
| **Territorio y Control** | Algunos modos o mapas ofrecen control de regiones para clanes (castillos, fortalezas, rutas comerciales. |
| **Bonificaciones de Clan** | Al desbloquear ciertos hitos, el clan otorga pasivamente beneficios a sus miembros (exp extra, reducción de coste, liderazgo adicional, etc.). |
| **Misiones de Clan** | Tareas grupales: escoltar convoyes, asediar fortalezas, resistir oleadas, etc. Completarlas otorga recursos al clan y reputación. |
| **Economía Compartida** | Tesorería del clan gestionada por los líderes. Puede usarse para pagar recompensas, declarar guerras o mejorar estructuras. |
| **Ranking y Progresión** | Sistema de reputación o nivel de clan basado en actividad, victorias, posesiones y participación en eventos. |

---

### ⚔️ Guerra entre Clanes

- **Declaración de Guerra**: Un clan puede declarar guerra a otro, generando un **periodo de conflicto abierto** en zonas neutrales o de conquista.
- **Batallas Programadas**: Eventos PvP entre clanes organizados por horarios, con reglas y escenarios determinados.
- **Botines de Guerra**: El clan vencedor puede ganar recursos, territorio o prestigio.
- **Sistema de Truces y Alianzas**: Relaciones diplomáticas entre clanes, temporales o permanentes.

---

### 🏰 Base de Clan (opcional/futuro)

Si el sistema se expande, los clanes podrán tener su propia base visual/persistente, con elementos como:

- Sala del consejo (para reuniones y planificación).
- Campos de entrenamiento (bonos pasivos o pruebas internas).
- Archivo o biblioteca (registro de campañas, líderes, etc.).
- Forja o mercado (desbloqueo de objetos especiales por progreso de clan).

---

### 💠 Recompensas y Beneficios

- **Visuales**: Estandartes, capas, tatuajes, pinturas de guerra únicas.
- **Progresivas**: Bonificaciones pasivas según nivel del clan.
- **Competitivas**: Acceso a modos especiales, rankings de temporada, campeonatos.

---

### ⚙️ Integración con otros sistemas

- **Leaderboard global** y de temporada por clanes.
- **Sistema de reputación individual/clan** compartida (castigos por deserciones o traiciones).
- **Sinergia con Loadouts**: Los clanes pueden desbloquear equipamiento exclusivo de clan para sus miembros (skins, unidades mercenarias, perks únicos).

---

### 📌 UI/UX (Diseño de Interfaz esperado)

- Panel de Clan accesible desde el menú principal.
- Subsecciones: miembros, historial, calendario, economía, territorio, personalización.
- Notificaciones y alertas in-game sobre eventos del clan.
- Opcional: integración con apps móviles para gestión remota.

---

### 🔒 Requisitos y Limitaciones

- Requiere nivel mínimo para fundar un clan.
- Costos de mantenimiento si el clan posee territorio o fortalezas.
- Inactividad prolongada del líder puede generar **sucesión automática** a oficiales.

================================================================================
# Sistema de Formaciones y Reacciones Tácticas 210df9df7102802fbd2cf188630cc502
================================================================================

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

================================================================================
# Sistema de Talentos Perks 210df9df710280afa270ec2a4b328cbc
================================================================================

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

================================================================================
# Sistemas y Mecánicas Abordadas (Actualizado) 20fdf9df7102807b98b1ef0e2a8b7e39
================================================================================

# Sistemas y Mecánicas Abordadas (Actualizado)

## 🎮 **Sistemas de Juego Generales**

- Modos de juego: PvP, PvE
- Control táctico de héroes + escuadras
- Progresión estilo RPG por nivel + perks
- Mecánicas de posicionamiento, moral, colisiones físicas

---

### ⚔️ **Unidades (Tropas)**

- **Tipos**: infantería, piqueros, arqueros, ballesteros, caballería ligera/pesada
- **Categorías**:
    - **Milicia** *(Gris)*: básicas, bajo coste
    - **Veteranos** *(Plateado)*: balanceadas, mejor equipamiento
    - **Profesionales** *(Dorado)*: tropas regulares de alto nivel
    - **Élite** *(Morado)*: mejor moral y stats únicos
- Estadísticas completas: moral, daño (por tipo), defensa, agresividad, temor, masa, velocidad, liderazgo, etc.
- Bonificaciones por tipo de enfrentamiento (ej. lanceros vs caballería)
- Subida de nivel y progresión individual
- Equipamiento que modifica stats

---

### 🛡️ **Equipamiento**

- Afecta el rendimiento de la unidad
- Se consigue por loot postpartida o crafteo
- Rarezas para héroes: común, poco común, raro, único
- Unidades: su calidad está ligada a su categoría (no al equipamiento en sí)

---

### 🧱 **Barracón**

- Gestión central de tropas desbloqueadas
- Permite visualizar stats, nivel y aplicar skins
- Espacios limitados, ampliables por eventos/logros
- Puedes:
    - **Movilizar** unidades nuevas (si están desbloqueadas)
    - **Eliminar (desvandar)** tropas que no necesites
    - No se pueden perder por muerte, ni fusionar
- Loadouts: 3 configuraciones por tipo de tropa

---

### 🧬 **Progresión del Jugador**

- Nivel de cuenta desbloquea perks
- Todos los mapas accesibles desde el inicio
- Retos diarios/semanales con foco cooperativo

---

### 💰 **Economía**

- **Bronce**: moneda básica, compras a NPCs
- **Plata**: moneda de intercambio entre jugadores
- **Oro**: moneda premium (real money)
- Mercado entre jugadores con plata
- Tiendas NPC (crafteo, compras con bronce)
- NPCs esenciales en capitales
- (Futuro): NPCs especiales en ciudades, desbloqueables

---

### 🛠️ **Crafting**

- Usa materiales (pendiente lista detallada)
- Fuentes: loot postpartida, desmontar objetos, misiones
- Requiere planos + nivel de crafting + tiempo
- Rarezas del equipo influencian el resultado

---

### 🏅 **PvP y Rangos Competitivos**

- Rangos por habilidad:
    1. **Aspirante**
    2. **Guerrero**
    3. **Veterano**
    4. **Campeón**
    5. **Gran Campeón**
- Reinicio por temporadas
- Sistema de MMR solo basado en victorias
- Recompensas por clasificación: skins, consumibles

---

### 🧳 **Gestión Fuera de Partida**

- Inventario limitado
- Hasta 3 *loadouts* por tipo de escuadra
- Gestión de tropas desde el barracón
- Sin restricciones por rareza
- **Condiciones de batalla** pueden afectar a distintas unidades

================================================================================
# Héroes 20fdf9df7102808090add30f63ecd608
================================================================================

# Héroes

---

### 🎭 Rol del Héroe

- Cada jugador controla directamente un **Héroe en tercera persona**.
- El Héroe es el **comandante del escuadrón** y participa activamente en combate.
- Tiene un impacto directo en:
    - La moral y el desempeño de sus tropas.
    - El curso táctico del combate mediante habilidades y órdenes.
    - El frente de batalla, influyendo directamente con su presencia y daño.

---

### 🧱 Características Base del Héroe

- **Nombre / Clase**: Determinados principalmente por el arma equipada.
- **Tipo de combate**:
    - Cuerpo a cuerpo pesado
    - Cuerpo a cuerpo ligero
    - Rango (arco, ballesta)
    - Montado (planeado a futuro)
- **Habilidad pasiva**: Modifica atributos como moral, velocidad o regeneración.
- **2 habilidades activas**: Buffs, ataques especiales, cargas, etc.
- **Atributos modificables**:
    - Fuerza
    - Destreza
    - Armadura
    - Vitalidad
- **Atributos derivados (no modificables directamente)**:
    - **Daño por tipo**:
        - Contundente: base + 2×Fuerza
        - Cortante: base + 1×Fuerza + 1×Destreza
        - Perforante: base + 2×Destreza
    - **Penetración y defensa por tipo**: se determinan por el equipamiento.
    - **Vida**: base por clase + 1×Vitalidad
    - **Mitigación de daño**: armadura base + pasivas + 1×Armadura
    - **Capacidad de unidades**: liderazgo base + bonificaciones del equipo
    - **Influencia táctica**: afecta tropas cercanas (proporcionada por habilidades/perks)

---

### 🧪 Progresión del Héroe

- **Subida de Nivel**:
    - Se gana experiencia en PvP y eventos.
    - Permite desbloquear:
        - Nuevas habilidades o variantes
        - Mejoras de estadísticas
        - Loadouts adicionales
- **Perks (Pasivas)**:
    - Sistema en árbol o lista de perks desbloqueables.
    - Ejemplos:
        - +10% moral al cargar
        - Reducción de daño si está aislado
        - Recuperación más rápida tras caída
- **Equipamiento**:
    - Armas (espadas, lanzas, arcos, etc.)
    - Armaduras (ligera, media, pesada)
    - Equipos cosméticos
    - Todo el equipo puede ser crafteado, comprado o ganado

---

### 🧠 Clases de Héroe

| Clase | Rol | Armadura | Ventaja principal | Habilidad clave |
| --- | --- | --- | --- | --- |
| **Espada/Escudo** | Defensa frontal / tanque | Pesada | Bloqueo sólido, mantiene línea | Golpe de escudo + Grito de guerra |
| **Arco** | DPS a distancia | Ligera | Máximo alcance, buena movilidad | Flecha cargada + Salto hacia atrás |
| **Ballesta** | DPS a distancia pesado | Media | Alto daño, velocidad de ataque más lenta | Disparo perforante + Tajo giratorio |
| **Guja** | DPS de zona | Media | Alto alcance, mejora moral de tropas | Aura de moral + Golpe circular |
| **Alabarda** | Tanque ofensivo | Pesada | Gran mitigación, daño contundente pesado | (En desarrollo) |
| **Lancero** | DPS cuerpo a cuerpo | Media | Golpes largos, control de zona frontal | Golpe vertical derribante |

---

### 🎯 Funcionalidad en Partida

- El jugador controla a su Héroe activamente y da órdenes estratégicas a sus tropas.
- Si el Héroe muere:
    - Las tropas pierden moral.
    - El jugador no puede usar habilidades activas ni dar órdenes hasta reaparecer (modo-dependiente).
- Las habilidades funcionan con **cooldowns**, no usan maná.
- Algunas habilidades afectan directamente al escuadrón (ej: cargas sincronizadas).

---

### 🎒 Personalización del Héroe

- **Loadouts**:
    - Arma principal
    - Armadura
    - Habilidad 1 y 2
    - Perk activa
    - Tropas seleccionadas (según liderazgo)
- **Skins**: Solo cosméticas, sin efecto en jugabilidad.
- **Nombre y título**: Personalizables.
- **Interfaz**: Muestra estadísticas clave como daño, defensa, liderazgo y habilidad táctica.

================================================================================
# Liderazgo, Formaciones y Matchmaking 20ddf9df7102803a8f3bfdb61d1b7540
================================================================================

# Liderazgo, Formaciones y Matchmaking

## 🧮 1. Liderazgo y Escuadras

### 🎖️ ¿Qué es el liderazgo?

- Recurso que determina cuántas unidades puedes llevar a una partida.
- Cada unidad tiene un **costo de liderazgo**.

**Ejemplo:**
Si tienes 5 puntos de liderazgo:

- Puedes llevar 2 arqueros (2 pts cada uno) + 1 escudero (1 pt)

### 🛡️ ¿Cómo se obtiene / modifica?

- Determinado por estadísticas del jugador y de su armadura.

### ☠️ ¿Qué pasa si pierdes todas las unidades?

- Solo reapareces con tu héroe, sin tropas.
- Las unidades pueden reutilizarse si tienen al menos el 50% de su equipamiento.

### 🎒 Loadouts y gestión fuera de partida

- Sistema para revisar el estado de tus tropas.
- Permite armar **loadouts personalizados** para llevar a cada partida.

---

## 🧠 2. Formaciones y Órdenes

Las formaciones agregan profundidad táctica al manejo de escuadras.

### 🧱 Formaciones disponibles (dependen del tipo de unidad)

- Línea
- Cuña
- Círculo
- Testudo (formación de escudo)
- Amplia (para dispersión)

### ⚙️ Efectos de las formaciones

- Modifican estadísticas como velocidad, defensa o ataque según el tipo de unidad.
- Cambiar de formación no tiene cooldown, pero sí un **tiempo de ejecución** (animación/tiempo de maniobra).

### 🎮 Control

- Órdenes se dan por **hotkeys**.
- Solo se puede ordenar **por escuadra completa**, no individualmente.

---

## 🌐 4. Matchmaking y Modos de Juego

### 🎮 Modos actuales

- **Campo Abierto**: Gana el equipo con más tropas sobrevivientes al finalizar el tiempo.
- **Conquista**: Equipos atacan/defienden una serie de banderas estratégicas.

### 🛠️ Modos futuros

- **3v3 (sin unidades)**: Solo combate entre personajes.
- **Modo Guerra (PvPvE)**: Mapa persistente, control de territorios entre facciones.

### ⏱️ Duración y balanceo

- Partidas entre **15 y 30 minutos**.
- Emparejamiento considera:
    - Nivel
    - Rango
    - Composición
    - Premades

### 🎁 Recompensas

- **XP de personaje**
- **XP de unidades**
- **Monedas** para equipamiento y progresión

---

================================================================================
# Lógica de Mapas 216df9df7102809496e4e2702f9ce069
================================================================================

# Lógica de Mapas

## ⚔️ Mapa de Batalla de Feudo (Versión MVP)

### 🎯 Propósito

- Representa una batalla estructurada entre **dos gremios**:
    - **Atacante** vs **Defensor**
    - **Sin aliados**

### 🕒 Fase Previa (Preparación)

- Dura: **60 segundos**
- Cada jugador ve **3 puntos de spawn** asignados a su bando:
    - 3 puntos para atacantes (en un extremo del mapa)
    - 3 puntos para defensores (en el extremo opuesto)
- El jugador debe seleccionar uno de estos puntos para iniciar.

### 🧍 Despliegue

- El jugador elige **un punto de aparición**.
- Al iniciar el combate:
    - El **héroe y su unidad activa** aparecen **juntos** (como una sola entidad).
    - La unidad aparece automáticamente **al frente del héroe**.
    - No hay movimiento libre previo.

### ⚔️ Fase de Combate

- Se activa tras la preparación.
- Cada jugador controla **una unidad activa + su héroe**.
- Se permite combate, uso de habilidades, formaciones, etc.
- No hay aliados ni reservas. Solo 2 bandos.

---

## 🏘️ Mapa de Feudo / Ciudad (Versión MVP)

### 🎯 Propósito

- Espacio de descanso, socialización y preparación fuera de combate.

### 👁️ Visibilidad y Movimiento

- Se muestra el héroe completo (con equipo/skin).
- Todos los jugadores aparecen en **una sola ciudad** centralizada.

### 🏗️ Estructura

- Todos los edificios están **preconstruidos**.
- No hay personalización de feudo ni expansión.

### 🧑‍🤝‍🧑 NPCs Disponibles:

- **Armero** (armas)
- **Herrero** (armaduras)
- Funcionalidad básica de interacción (ej. menú de compra simple)

### ❌ Exclusiones (no están en el MVP)

- No hay caravanas.
- No hay mapa de mundo abierto.
- No hay sistemas de construcción o edificios especializados.

================================================================================
# Mecánica El Barracón 20fdf9df7102803eabd4cd8343cbc234
================================================================================

# Mecánica: El Barracón

### 📌 ¿Qué es el barracón?

El **barracón** es el sistema central de gestión de tropas del jugador. Es donde se almacenan, visualizan y organizan todas las unidades desbloqueadas, junto con su equipamiento, nivel, skins y estadísticas.

Funciona como el "cuartel general" del jugador, tanto para PvE como PvP.

---

### 🧱 Estructura del barracón

- 📦 **Espacios limitados**: El jugador empieza con un número inicial de espacios de unidad. Este número puede ampliarse mediante:
    - Eventos
    - Logros
    - Consumibles especiales
    - (Potencial futuro: expansión con oro)
- 📁 **Categorías de organización**:
    - **Por tipo**: Infantería, Caballería, Arqueros, etc.
    - **Por rareza**: Milicia, Regular, Veterano, Élite
    - **Por facción** (si aplican diferencias estéticas o estadísticas)

---

### ⚙️ Funcionalidades del barracón

1. **Visualización de unidades**
    - Muestra: nombre, tipo, nivel, moral, daño, velocidad, equipo actual, rareza
    - Posibilidad de ver estadísticas detalladas
2. **Gestión de equipamiento**
    - Equipar/des-equipar armaduras, armas, escudos
    - Visualizar impacto directo de las piezas sobre las estadísticas
    - Permite desmontar equipo viejo (para obtener materiales)
3. **Aplicación de skins**
    - Las skins se gestionan por unidad
    - Las skins aplicadas no afectan las estadísticas (cosméticas puras)
    - Se pueden cambiar libremente desde esta pantalla
4. **Asignación a escuadras / Loadouts**
    - El jugador puede asignar unidades a diferentes **loadouts predefinidos** (hasta 3 por tipo de momento)
    - Cambiar de loadout no consume recursos, pero sí requiere estar fuera de combate
5. **Subida de nivel y progresión**
    - Cuando una unidad gana experiencia, se muestra aquí su nivel actual
    - Las mejoras (buffs, perks de unidad) se desbloquean desde esta interfaz
    - También se pueden ver los *perks pasivos* que ha desbloqueado
6. **Barracón de reserva** *(potencial futura expansión)*:
    - Un espacio adicional donde se pueden guardar unidades no activas sin ocupar espacio principal.
    - Ideal para gestionar escuadras de evento o rotación estratégica.

---

### 📊 Sistema de mejora de unidades en el barracón

- Cada unidad puede:
    - Subir de nivel mediante XP de batalla
    - Obtener mejoras permanentes
    - Reforzarse con equipamiento de mayor nivel
    - Cambiar su categoría (por ejemplo, de **Milicia** a **Veterana** al llegar a cierto nivel)

---

### 🛠️ Expansión del barracón

- Aumentar la capacidad del barracón:
    - 🎖️ **Logros**: Completar metas específicas de juego.
    - 📅 **Eventos**: Participación en campañas o festividades especiales.
    - 🧪 **Consumibles**: Objetos que expanden el espacio de tropas (drop raro).
    - (📈 Futuro: mecánica de expansión mediante recursos premium)

---

### 💡 Opciones futuras (para considerar después del MVP)

- Integración de **favoritos** para marcar tropas clave.
- Posibilidad de **compartir tu escuadra** con otros jugadores.
- Ver estadísticas de uso y rendimiento histórico por unidad.
- Estética del barracón personalizada (skins de fondo, estandartes).

================================================================================
# Sección Economía y Progresión del Jugador 20fdf9df7102800ba9c8ff4c92f2b478
================================================================================

# Sección: Economía y Progresión del Jugador

---

### 1. 🧬 Progresión General del Jugador

- El jugador cuenta con un **nivel de cuenta** o “rango de mando” que sube con la experiencia obtenida al jugar partidas.
- La progresión de nivel desbloquea **perks** específicos para el héroe del jugador, pero no restringe acceso a mapas u otras funciones base.
- Existen **retos diarios y semanales** con recompensas asociadas, pensados para fomentar el trabajo en equipo, la rotación de escuadras y la participación constante.

---

### 2. 💰 Sistema de Monedas y Recompensas

**Tipos de moneda**:

- 🟤 **Bronce**: moneda básica del juego, se usa para interactuar con NPCs, comprar consumibles, y fabricar equipo común.
- ⚪ **Plata**: moneda usada en el mercado global entre jugadores. Es más valiosa y escasa, pero esencial para el comercio de objetos valiosos.
- 🟡 **Oro**: moneda premium obtenida solo mediante compra con dinero real.

**Obtención**:

- **Bronce**: jugando PvP, cumpliendo eventos, retos o misiones.
- **Plata**: en pequeñas cantidades por eventos o actividades especiales (PvP avanzado, logros, etc.).
- **Oro**: solo mediante transacciones reales.

**Economía**:

- **Trueque con NPCs** usando bronce.
- **Intercambio entre jugadores** vía el mercado usando plata.

**Tiendas**:

- 🛒 **Mercado global**: funcionalidad de compra/venta entre jugadores con filtro de precios, rarezas, etc.
- 🧑‍🌾 **NPC esenciales**: disponibles en todas las ciudades capital, con los que puedes comprar y fabricar equipo.
- (No MVP) **NPC especiales**: desbloqueables en determinadas ciudades o pueblos a medida que el jugador sube de nivel o reputación.

---

### 3. 🛠️ Crafting y Gestión de Recursos

**Materiales sugeridos** (siguiendo temática medieval realista):

- **Hierro bruto** / **Lingotes de hierro**
- **Acero templado**
- **Cuero curtido**
- **Madera dura**
- **Telas resistentes**
- **Aceite de arma**
- **Piedra pulida**
- **Fragmentos antiguos** (raros, para ítems únicos)

**Fuentes de materiales**:

- Loot de enemigos y cofres postpartida.
- Desmantelado de equipo viejo.
- Recompensas de misiones.
- Puntos de interés del mapa (minas, campamentos, caravanas).

**Requisitos de crafteo**:

- Planos (drop o compra)
- Nivel mínimo del jugador
- Tiempo breve de fabricación (instanciado, no en tiempo real continuo)

**Rarezas**:

- Para héroes:
    - 🟫 Común
    - 🟩 Poco común
    - 🟦 Raro
    - 🟪 Único
- Para unidades:
    - Depende de la categoría de tropa (Milicia, Regular, Veterana, Élite)

---

### 4. 🏅 Rangos Competitivos y PvP

**Sistema de rangos (de menor a mayor)**:

1. Aspirante
2. Guerrero
3. Veterano
4. Campeón
5. Gran Campeón
- Sistema se reinicia por **temporadas PvP**.
- Solo **victorias** afectan el MMR/ELO del jugador (modelo simple y competitivo).
- **Recompensas por ranking al final de temporada**:
    - Skins exclusivas
    - Consumibles
    - Medallas de prestigio (coleccionables o para mostrar en perfil)

---

### 5. 🧳 Inventario, Loadouts y Gestión fuera de Partida

- **Inventario limitado**: el jugador debe administrar espacio para armas, armaduras y consumibles.
- Se pueden crear hasta **3 loadouts de escuadra por tipo** (solo 1 tipo disponible por ahora).
- Las unidades están almacenadas en el **barracón**:
    - Espacios limitados.
    - Nuevos espacios desbloqueables con eventos, logros o consumibles.
- En el barracón el jugador puede:
    - Ver estadísticas y niveles de sus tropas.
    - Equipar skins desbloqueadas.
    - Gestionar cambios de armamento y formación.

================================================================================
# Sección Unidades (Tropas) 20ddf9df710280bd896bf6c0d611c830
================================================================================

# Sección: Unidades (Tropas)

Las unidades son el corazón del gameplay táctico. Cada jugador lleva un escuadrón de unidades seleccionadas según su capacidad de liderazgo. Estas tropas pueden personalizarse, subir de nivel, equiparse y tienen IA propia durante el combate.

---

### 🧩 1. Tipos de Unidades

Las unidades se dividen por tipo (función en combate) y por categoría (nivel de calidad):

### Tipos básicos:

- **Infantería pesada**: Alta defensa, ideal para mantener líneas.
- **Lanceros / Piqueros**: Buen alcance cuerpo a cuerpo, anti-caballería.
- **Arqueros**: Alcance medio-largo, débiles en cuerpo a cuerpo.
- **Ballesteros**: Daño perforante más alto, pero menos velocidad de disparo.
- **Caballería ligera**: Rápida y con buena movilidad, ideal para flanqueos.
- **Caballería pesada**: Alto daño por carga y gran impacto físico.

### Personalización:

Cada tipo incluye varias **variantes temáticas** con roles y estética distinta. Ejemplos:

- Arqueros ingleses de arco largo (más alcance, armadura ligera).
- Arqueros de leva (menor alcance, armadura media).
- Caballería normanda pesada vs. caballería tártara ligera.

### Facciones:

Aunque no se definen como “facciones jugables” al estilo tradicional, las unidades tendrán estilos visuales y stats ligeramente distintos según su origen cultural.

---

### 📊 2. Estadísticas y Atributos

Cada unidad posee un conjunto de atributos que determinan su comportamiento en batalla:

| Atributo | Descripción |
| --- | --- |
| **Vida** | HP base. |
| **Defensa** | Cortante, Perforante, Contundente. |
| **Daño** | Dividido en Cortante / Perforante / Contundente. |
| **Penetración** | Capacidad de ignorar defensas según tipo de daño. |
| **Alcance** | Solo para unidades a distancia o con armas largas. |
| **Velocidad** | Afecta desplazamiento y reacción. |
| **Moral** | Si llega a 0, la unidad huye. Principal stat progresivo. |
| **Bloqueo** | Solo si tienen escudo. |
| **Peso** | Influye en la movilidad y la masa. |
| **Masa** | Determina empuje al chocar, daño por carga y capacidad de aguante. |
| **Agresividad** | Influye en iniciativa al atacar. |
| **Temor** | Influye en propensión a huir. |
| **Liderazgo** | Coste de liderazgo de la unidad  |
| **Precision** | porcentaje de precision de las unidades de distancia |
| **Cadencia** | cadencia de disparo para unidades de distancia |
| **Velocidad de recarga** | tiempo que tarda una unidad de distancia en recargar el arma y volver a disparar |
| **Municion** | Cantidad total de proyectiles disponibles  |

### Buffs y Debuffs temporales:

- **Moral alta**: Mejora la moral base.
- **Miedo**: Baja la moral enemiga.
- **Enardecidos**: Más daño, menos defensa.

---

### ⚔️ 3. Equipamiento y Variantes

Cada unidad no es única, sino una clase que puede tener múltiples versiones. Estas variantes cambian estadísticas, habilidades y apariencia.

### Variantes por diseño:

Ejemplo con arqueros:

- **Arqueros ingleses**: Largo alcance, poca armadura.
- **Arqueros de leva**: Alcance medio, armadura media.
- **Ballesteros genoveses**: Alto daño perforante, recarga lenta.

### Equipamiento:

- Se obtiene por **crafteo** o **loot postpartida** (con probabilidad según los enemigos derrotados).
- Equipamiento modifica atributos y puede cambiar el rol de una unidad.
- No hay un sistema de rareza en el loot, pero sí diferencias claras en funcionalidad.

### Categorías de unidad:

| Categoría | Color | Descripción |
| --- | --- | --- |
| **Milicia** | Gris | Unidades básicas, bajo coste. |
| **Veteranos** | Plateado | Más balanceadas, mejor equipamiento. |
| **Profesionales** | Dorado | Tropas regulares de alto nivel. |
| **Élite** | Morado | Tropas de élite con mejor moral y stats únicos. |

> Puedes cambiar los nombres por términos históricos: "Leva", "Regulares", "Templarios", "Guardia", etc.
> 

---

### 🪙 4. Costos y Progresión

### Progresión:

- Las unidades **suben de nivel** con experiencia de combate.
- Al subir de nivel, todos los stats pueden mejorar, especialmente **moral**.
- La progresión es **persistente**, incluso si no se usan por varias partidas.

### Costos:

- Se adquieren unidades con **monedas** y **recursos**.
- Se mejora su equipo por **crafteo** o botín.
- No hay penalizaciones por no usarlas.
- **Perder unidades** implica perder equipamiento, pero no nivel ni tiempo de recuperación.

---

### 🧠 5. IA y Comportamiento en Combate

Las unidades operan en escuadras bajo las órdenes del jugador, pero reaccionan dinámicamente a la batalla.

### Moral y ruptura:

- Si una unidad baja su moral a 0, **huye**.
- Pueden **reagruparse** si la moral mejora y quedan soldados vivos.

### Agresividad y temor:

- Atributos internos que determinan si una unidad **espera**, **contraataca** o **huye**.
- Una unidad con alta agresividad reaccionará antes y perseguirá enemigos.

### Comportamiento por tipo:

- **Lanceros**: Bonus contra caballería, especialmente cargas frontales.
- **Arqueros**: Bonus contra infantería, se retiran si enemigos se acercan.
- **Caballería**: Bonus contra unidades ligeras (como arqueros), daño por carga aumenta con velocidad y masa.