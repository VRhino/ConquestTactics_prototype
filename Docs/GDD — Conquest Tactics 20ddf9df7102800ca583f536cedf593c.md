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

### ✅ 13. Lista de MVP (versión mínima jugable)

| Mecánica / Función | Estado | Notas |
| --- | --- | --- |
| Movimiento en tercera persona | 🔲 | Control del héroe |
| Control de escuadrón | 🔲 | 1 escuadra base |
| Órdenes básicas (seguir, esperar, atacar) | 🔲 | Sin formaciones |
| Sistema de ataque básico | 🔲 | Cuerpo a cuerpo |
| 3 tipos de unidades (espada, lanza, arco) | 🔲 | Categoría: Milicia |
| Escenario de prueba | 🔲 | Campo de batalla básico |
| Multiplayer básico | 🔲 | Lobby simple |

---

### 🛠 14. Backlog técnico

| Tarea técnica | Prioridad | Responsable | Estado |
| --- | --- | --- | --- |
| Sistema de input | Alta | Tú | 🔲 |
| Cámara 3D | Media | - | 🔲 |
| IA de escuadrón | Alta | - | 🔲 |
| Red con Mirror | Alta | - | 🔲 |
| Barracón e inventario | Media | - | 🔲 |
| Sistema de perks | Media | - | 🔲 |
| Sistema de combate (daño, colisiones) | Alta | - | 🔲 |

---

### 🛠 15. Herramientas y tecnologías

- **Motor**: Unity 3D (versión por definir)
- **Lenguaje**: C#
- **Multiplayer**: Mirror
- **Repositorio**: Git + GitHub
- **Modelado / Arte**: Blender (opcional), Asset Store
- **Gestión de proyecto**: Trello o Notion

[**Sistemas y Mecánicas Abordadas (Actualizado)**](Sistemas%20y%20Meca%CC%81nicas%20Abordadas%20(Actualizado)%2020fdf9df7102807b98b1ef0e2a8b7e39.md)

[GDD iteracion 1](GDD%20iteracion%201%2020ddf9df7102805e83d6d69604fadb76.md)

[Héroes](He%CC%81roes%2020fdf9df7102808090add30f63ecd608.md)

[Liderazgo, Formaciones y Matchmaking](Liderazgo,%20Formaciones%20y%20Matchmaking%2020ddf9df7102803a8f3bfdb61d1b7540.md)

[Sección: Unidades (Tropas)](Seccio%CC%81n%20Unidades%20(Tropas)%2020ddf9df710280bd896bf6c0d611c830.md)

[Sección: Economía y Progresión del Jugador](Seccio%CC%81n%20Economi%CC%81a%20y%20Progresio%CC%81n%20del%20Jugador%2020fdf9df7102800ba9c8ff4c92f2b478.md)

[Mecánica: El Barracón](Meca%CC%81nica%20El%20Barraco%CC%81n%2020fdf9df7102803eabd4cd8343cbc234.md)

[Sistema de Formaciones y Reacciones Tácticas](Sistema%20de%20Formaciones%20y%20Reacciones%20Ta%CC%81cticas%20210df9df7102802fbd2cf188630cc502.md)

[Sistema de Clanes / Gremios](Sistema%20de%20Clanes%20Gremios%20210df9df71028093a2d1c956346eb5be.md)

[Sistema de Talentos / Perks](Sistema%20de%20Talentos%20Perks%20210df9df710280afa270ec2a4b328cbc.md)