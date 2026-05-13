ASEDIO MEDIEVAL!

[INSTRUCCIONES]
ESPACIO - DISPARAR
FLECHAS - MOVIMIENTO CAÑÓN

MUNICIONES: AZUL (DAÑO MEDIO, ÁREA MEDIA), 
            ROJA (DAÑO ALTO, ÁREA BAJA),
            AMARILLA (DAÑO BAJO, ÁREA ALTA)

[GUÍA DETALLADA]

(PROYECTILES)
Tienen un daño y un área específicos. Hay 3.

(LANZAMIENTO DE PROYECTILES)
El cañón se encarga de calcular la trayectoria de los proyectiles que lanza mediante las fórmulas cinemáticas. Instancia la munición, le da una velocidad inicial, coge el ángulo del propio cañón y simula su posición dependiendo de la vida (Time.deltaTime) de la pelota.
El line renderer también usa estas mismas fórmulas cinemáticas para dibujar la trayectoria del proyectil.

(BLOQUES)
Los muros del castillo están formados por bloques, cada uno con un script. Estos son la win condition del juego y cada uno tiene su propia vida. Los bloques marrones tienen menos vida que los blancos.
Los bloques tienen un material de grietas cuya transparencia depende de su vida, creando un efecto de rotura.

(JOINTS)
Para simular un muro de castillo, cada bloque dentro de un muro está unido a otro cubo mediante un Fixed Joint. Algunos también están unidos al suelo.
Cuando la vida de un bloque baja del 50%, se rompen sus joints, simulando un efecto de destrozo.

(CALCULAR DAÑOS)
Cuando el Collider del proyectil choca con otro collider del castillo, la munición se destruye y se hace un Physics.Overlap (el área de efecto depende de la munición específica) que encuentra cubos, a cuyos rigidbody les aplica una fuerza de explosión relativa.
También les resta una cantidad de vida que depende de la munición.

(WIN CONDITION)
Para ganar el juego de base hay que destruir el 100% de los bloques del castillo. Sin embargo, si golpea al gameObject caballero, que está escondido en el castillo, el requisito baja al 50%. (Esto se ve cuando el color del medidor de puntuación cambia a azul)
El GameManager se encarga de llevar este cálculo de porcentajes entre otras cosas.
