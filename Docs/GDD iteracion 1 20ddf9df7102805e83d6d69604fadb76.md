# GDD iteracion 1

### 🎮 Game Design Document

---

### ⚔️ 1. Combate y Control

<details><summary>Ver sección</summary>

**¿El combate del jugador será basado en acción directa o en estadísticas?**

🡒 Acción directa: hack & slash

**¿Habilidades especiales?**

- *Jugador:* clases por armas (arco, lanza, hacha, etc.), con golpe normal, fuerte, esquivar, esprintar, etc.
- *Tropas:* habilidades como carga, flechas incendiarias, fuego sostenido, levantar escudos, etc.

**¿Cambio de tropa en medio del juego?**

🡒 No. El jugador elige una **composición fija** según su [Liderazgo]. Cada unidad cuesta cierta cantidad de Liderazgo.

**IA de tropas:**

- *Órdenes básicas:* seguir, atacar, defender, etc.
- *Auto-respuesta:* depende de la orden.
- *Defensas específicas:* levantan escudos ante proyectiles si son unidades con escudo.

</details>

---

### 🪖 2. Tipos de Unidades

<details><summary>Ver sección</summary>

**Estadísticas:**

Vida, defensa, alcance, liderazgo, velocidad, moral, bloqueo (si aplica), daño, peso.

**Tipos de tropa inicial:**

- Infantería pesada
- Lanceros
- Arqueros
- Ballesteros
- Caballería ligera
- Caballería pesada

**¿Jerarquía entre unidades?**

🡒 No.

**¿Suben de nivel?**

🡒 Sí. Mejoran estadísticas y equipo.

</details>

---

### 🗺️ 3. Mapas y Escenarios

<details><summary>Ver sección</summary>

**Tipos:** campos abiertos, castillos, aldeas, pasos montañosos.

**Terreno afecta el combate:**

- *Bonificación:* Altura (mejora daño), terreno fangoso o ríos (ralentiza, afecta velocidad).
- *Environment:* Cobertura física, cuellos de botella, etc.

**Recursos interactivos:** torres, puertas, trampas.

**Clima / ciclo día-noche:** No.

</details>

---

### 🎮 4. Sistema Multijugador

<details><summary>Ver sección</summary>

**Jugadores por equipo:** de 5vs5 hasta 15vs15.

**Conexión:** partidas privadas (MVP), luego matchmaking.

**Clases de jugador:**

- Armas (arco, hacha, lanza, ballesta, espada/escudo)
- Armaduras (ligera, media, pesada)

**Control de escuadra ajena:** No. Si el jugador muere, sus tropas se retiran tras segundos.

</details>

---

### 🏁 5. Condiciones de Victoria

<details><summary>Ver sección</summary>

**Modos:**

- *Campo abierto:* gana quien conserve más tropas o no se rinda antes del fin del tiempo.
- *Conquista:* defensores vs atacantes, con banderas encadenadas.

**Moral:**

🡒 Sí. Unidades pueden huir si baja demasiado. La presencia del jugador influye.

**Rendición:**

🡒 Posible si se cumplen condiciones y >51% vota “sí”.

</details>

---

### 🎨 6. Estética y Narrativa

<details><summary>Ver sección</summary>

**Narrativa/Lore:**

- Facciones jugables con historia
- Eventos ficticios pero verosímiles en época real

**Estética visual:**

- Low-poly
- No voces, solo sonidos y texto

</details>

---

### 🎯 7. Futuro y Escalabilidad

<details><summary>Ver sección</summary>

**Progresión del jugador:**

- Ranking competitivo
- Desbloqueo de nuevas tropas
- Sistema profundo de mejoras y progresión

**Personalización:**

- Skins, estandartes, armaduras visuales

**Plataformas:**

- Solo PC

</details>