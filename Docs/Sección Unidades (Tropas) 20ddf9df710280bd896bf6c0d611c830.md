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