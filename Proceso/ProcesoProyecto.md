# Proceso Proyecto
Aquí se describe el avance y aprotaciones que he tenido en el proyecto colaborativo de este bloque

## Movimiento básico y mecánica de salto 
### Fecha: 16 agosto
Lo primero fue empezar a implementar las mecánicas de movimiento básico para un juego plataforma en 3D de tercera persona, como se muestra a continuación:

![Script1](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Script1.png)

![Script2](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Script2.png)

Con esto, se pudo realizar un primer avance en el movimiento del personaje para testear otras mecánicas con respecto a su interacción con el mundo y enemigos.

También, se realizó una pequeña modificación al comportamiento del salto normal para que pueda recibir un mayor impulso del salto al mantener presionada la tecla de espacio:

![Script3](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Script3.png)

## Mecánicas de movimiento
### Fecha: 18 agosto
Posteriormente, complementando el movimiento básico ya implementado, se añadieron mecánicas como crouch, dive, dash, wall jump y un sistema para que pueda avanzar sobre planos inclinados

![Crouch](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Crouch.png)

![Dive](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Dive.png)

![Dash](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Dash.png)

![Walljump](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Walljump.png)

![Slope](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Slope.png)

## Ajuste de valores de movimiento de personaje
### Fecha: 25 agosto
Durante estas fechas me concentré especificamente en ajustar los valores del movimiento del personaje para que se sintiera más fluido y que se sienta bien al navegar el mapa, como se muestran en los valores finales que se le dejaron al personaje:

![Movement1](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Movement1.png)

![Movement2](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Movement2.png)

## Ataque melee
### Fecha: 29 Agosto
Se empezó a realizar un sistema de ataque melee para el personaje, tomando de base un objeto nativo de Unity y el componente de Animator:

![Script4](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Script4.png)

## Cajas explosivas
### Fecha: 2 Septiembre
Se añadió al escenario un prefab de una caja que al dispararle, esta se convierte en varios fragmentos pequeños y realiza una pequeña explosión desde dentro

![Boxes](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Boxes.png)

## Coleccionables
### Fecha: 4 Septiembre
Para seguir ayudando en la parte de decoración del mundo, se añadió un par de prefabs para los coleccionables de energía para recuperar vida, obteniendo los modelos 3D y animándolos por medio de Animator

![Collectibles](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Collectible.png)

## Tuberías
### Fecha: 7 septiembre
Para mejorar la zona del Grappling Hook, se añadieron modelos de tuberías en el escenario para mejorar la ambientación y darle al jugador una señal de donde se puede usar dicha arma, dejando simbólicamente, por medio del color rojo destacable de las llaves de las tuberías, que en esos lugares puede engancharse

![Tubes](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Tubes.png)

## UI Menu
### Fecha: 11 septiembre
Se agregó un nuevo diseño temporal para el menu junto con la lógica general del menu, siendo estas el menu de configuraciones y jugar. El diseño es parte de unos assets gratuitos y libres de uso que se encontraron adecuados para la temática del juego y partir de ellos para el diseño final

## UI Menu effects & Reduce assets
### Fecha: 13 septiembre
Se añadieron efectos de sonido y animaciones a los botones del menu principal. A su vez, se estuvieron haciendo refactorizaciones del movimiento del personaje y organización de archivos y carpetas

## Documentación PlayerMovement
### Fecha: 25 septiembre
Se realizó la documentación del script PlayerMovement.cs junto con los scripts referentes al personaje y enemigos de acuerdo al estándar que se estaba utilizando en el proyecto

## Implementación de PUN
### Fecha: 20 octubre
Se agregó la primera implementación de PUN en la lógica de conexión multijugador en el proyecto, para ello, se planea poder manejar la conexión con un simple botón durante la partida, en la que el jugador le de un nombre a la sala y crearla para poder empezar el modo online y dejar que los demás jugadores se conecten (en un máximo de 4)

## PlayerSpawner
### Fecha: 24 octubre
Una vez realizada la conexión de la sala, se realizó el código para spawnear al personaje tomando en consideración el modo online, así como empezar a sincronizar posición y animaciones

## Weapons RPC
### Fecha: 31 octubre
Se modificó el script de WeaponsManager.cs para poder manejar las armas y sincronizarlas en el modo online, agregando funciones RPC para que las balas y la activación de las armas se manejen de manera correcta

## Spawn enemigo
### Fecha: 10 noviembre
Se arregló el spawneo del enemigo final del Tutorial para que le aparezca a todos los jugadores, así como que se sincronice su posición, rotación y animaciones, dejando al host a cargo de su comportamiento y dejando que los clientes reciban su información necesaria para su despliegue

## Cambio de escena PUN
### Fecha: 15 noviembre
Se modificó la lógica para el cambio de escena para que se sincronice para todos los jugadores al terminar un nivel o al seleccionar un nivel en la escena de LevelSelect