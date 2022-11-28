# Proceso
Aquí se desplegarán avances de actividades/tareas/proyectos conforme sea necesario

## Bloque TC3003C.71

### Actividad: Octaedro tesselado

Para realizar la tesselación del octaedro:

* Primero se tendría que adaptar el código que genera el octaedro al formato de la estructura que se creó en clase
* Posteriormente, se ejecutaría un for que recorra cada tres numeros del arreglo de triangulos del octaedro, en donde 
se crearía un nuevo triángulo con esos tres numeros y con los vertices del octaedro correspondientes al indice que indiquen dichos numeros
* Entonces, se ejecutaría el método de Tesselación con este nuevo triangulo, y se añadirían los vertices y triangulos resultantes a la figura 
final, y así desplegarla

### Actividad: Primer trabajo en Blender

Esta es la primera actividad que se realizó en el programa de modelado de Blender, aquí se vio el manejo del programa, importar modelos 3D, cambiar su rig y su estructura para crear una armadura, posteriormente se aprendió a pintar el modelo como se desee

Final:

![Primero](https://github.com/JoanDGG/Semestre-TEC/blob/c42b6609c73e8026fe751a2654571b0d57c74eb8/Proceso/Imagenes/Primero.png)

### Actividad: Render Texture

Dentro de Unity, se aprendió a realizar proyecciones en tiempo real de la vista de la cámara, exportándolo como una textura dentro de un objeto sólido

Final:

![Render Texture](https://github.com/JoanDGG/Semestre-TEC/blob/c42b6609c73e8026fe751a2654571b0d57c74eb8/Proceso/Imagenes/Render.png)

### Actividad: Modelado en Blender

Aquí se realizó una animación en Blenedr con el modelo pre fabricado de Snow, realizando una pose, manejando luces y ángulos de la cámara

Final:

![Snow Pose](https://github.com/JoanDGG/Semestre-TEC/blob/c42b6609c73e8026fe751a2654571b0d57c74eb8/Proceso/Imagenes/Snow.png)

### Actividad: Texturas y materiales

En esta actividad se realizó el texturizado utilizando la herramienta de UV Mapping de ProBuilder y el sistema de materiales de Unity para recrear distintas texturas como materiales transparentes, opacos, brillantes y luminicentes

Final:

![Textures](https://github.com/JoanDGG/Semestre-TEC/blob/426919c3e8cc42867e82c915a345bb3a82a4ee23/Proceso/Imagenes/Materiales.png)

### Actividad: Herramientas de modelado

En esta sección se muestra cómo se manejaron distintos formatos para modelos 3D por medio de Unity o Blender, siendo estos objetos creados con el plug-in de Unity de ProBuilder, archivos de tipo .OBJ, y objetos editados en Blender

Final:

ProBuilder  
![ProBuilder](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/ProBuilder.png)

OBJ 
![OBJ](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Blender.png)

Blender
![Blender](https://github.com/JoanDGG/Semestre-TEC/blob/51e5f07ff6d23a2588e5893982f6e21b271c4e2e/Proceso/Imagenes/Blender2.png)

## Bloque TC3005C.71

### Actividad: Minimundo

Aquí se realizó una escena en Unity usando todos los conocimientos que hemos adquirido de timelines, animaciones, efectos de sonido y manejo de inputs creando un escenario simple

Final:

[Carpeta del minijuego](../Modelado3D/Assets/Minimundo/)

![Minimundo](https://github.com/JoanDGG/Semestre-TEC/blob/cea1369c6685d9b79c0b6fa8d96321bb12f2cd61/Proceso/Imagenes/Minimundo.png)

### Actividad: Desarrollo de Plug-in

En esta actividad se desarrolló en equipo un paquete redistribuible de unity en el que se plantea un visualizador de espectro para un receptor de sonido

Final:

[Paquete del plug-in](../Proceso/Evidencias/SpectrumViewer.unitypackage)

[Video de demostracion](Plugin.mp4)

### Actividad: Introducción a servicios y librerías para desarrollo multijugador

En esta actividad en equipo se hizo una pequeña investigación de varios conceptos / tecnologías relativas al desarrollo de juegos multijugador. Tocando temas de conexión de peer-to-peer, cliente-servidor y protocolos que podríamos estar utilizando con Unity para el sistema multijugador

Final:

[Documento a la presentación](https://docs.google.com/presentation/d/1Kv981rIldvGvKRMKzdF86SA27yR5wVeqqOghsdRcz1g/edit?usp=sharing)

### Introducción a APIs gráficas de bajo nivel: Cubo Rubik

Dentro de esta actividad se simuló el comportamiento de un cubo Rubik creando los 9 cubos individuales y rotandolos con respecto a un pivote para hacer el giro correspondiente

Final

[Cube.cs](../Modelado3D/Assets/Scripts/Cube.cs)

[Transformaciones.cs](../Modelado3D/Assets/Scripts/Transformaciones.cs)

[Video Rubik](https://github.com/JoanDGG/Semestre-TEC/blob/6e2bbf15a552eeed7710befe7409b6aa2210b84a/Proceso/Imagenes/RubikVideo.mp4)

![Rubik](https://github.com/JoanDGG/Semestre-TEC/blob/ee09128fb7f9a95a4a301c14042b082b7df820f2/Proceso/Imagenes/Rubik.png)

### Pipeline de render en APIs de bajo nivel: Animación de 3 links

En esta actividad se siguió tocando el tema de rotación de pivotes, haciendo que una conexión de 3 bloques giraran con respecto al eje del cubo anterior 

Final

[Finger.cs](../Modelado3D/Assets/Scripts/Finger.cs)

[Transformaciones.cs](../Modelado3D/Assets/Scripts/Transformaciones.cs)

[Arm video](https://github.com/JoanDGG/Semestre-TEC/blob/6e2bbf15a552eeed7710befe7409b6aa2210b84a/Proceso/Imagenes/ArmVideo.mp4)

![Arm](https://github.com/JoanDGG/Semestre-TEC/blob/ee09128fb7f9a95a4a301c14042b082b7df820f2/Proceso/Imagenes/Arm.png)

### Operaciones gráficas en OpenGL con C++: Animación de robot

Esta actividad tiene como objetivo medir nuestros conocimientos completos sobre transformaciones para simular el movimiento de un robot caminando, con todas sus extremidades moviéndose en diferentes direcciones y rotaciones

Final

[Robot scripts](../Modelado3D/Assets/Scripts/Robot/)

[Robot video](https://github.com/JoanDGG/Semestre-TEC/blob/6e2bbf15a552eeed7710befe7409b6aa2210b84a/Proceso/Imagenes/RobotVideo.mp4)

![Robot](https://github.com/JoanDGG/Semestre-TEC/blob/ee09128fb7f9a95a4a301c14042b082b7df820f2/Proceso/Imagenes/Robot.png)

### Desarrollo de shaders en GLSL para OpenGL: Render de múltiples esferas

En esta última actividad se realizó un render en el que se puede determinar la información visual de una parte del mundo tomando en cuenta su posición e iluminación dentro de una zona de frustrum, logrando renderear en una imagen multiples esferas que se generan por código

Final

[RayCaster.cs](../Modelado3D/Assets/Scripts/RayCaster.cs)

Resultado en Unity

![Esferas Unity](https://github.com/JoanDGG/Semestre-TEC/blob/ee09128fb7f9a95a4a301c14042b082b7df820f2/Proceso/Imagenes/Esferas.png)

Imagen resultante

![Esferas](https://github.com/JoanDGG/Semestre-TEC/blob/ee09128fb7f9a95a4a301c14042b082b7df820f2/Modelado3D/SaveImages/render.png)

### Actividad: Herramientas para UX

Aquí se desarrolló con el equipo del proyecto un wireframe para el diseño de interfaz de Planet Crash, en el que, a partir de varios diseños, se seleccionaron los más apropiados para toda la aplicación

[Carpeta de Drive con el Wireframe](https://drive.google.com/drive/folders/1uIWcmWswvTmdr_VNORsSxEUhlVZRkT80?usp=share_link)

### Actividad: Proceso de diseño orientado al usuario

Desarrollo de un prototipo de diseño para una aplicación utilizando el programa de Invision como introducción al UX/UI

[Prototipo de Invision](../Proceso/Evidencias/Prototipo1.studio)

### Actividad: Diseño de interfaz gráfica

En el siguiente link se adjunta el proyecto de invision del proyecto de Planet Crash tomando en cuenta el Wireframe anterior y los comentarios realizados por usuarios finales

[Invision](https://ian641733.invisionapp.com/console/share/PDSCF9VX6AG/967227323)

### Actividad: Cell Shader

En esta actividad se desarrollaron dos shaders para hacer la ilusión de una textura cell shader, una por medio de la recepción de un rango de valores, y otro por la lectura de un mapa de texturas

[Script ToonShader](../Proceso/Evidencias/ToonShader.shader)

[Script ToonShader con textura](../Proceso/Evidencias/TextToonShader.shader)

![ToonShader](https://github.com/JoanDGG/Semestre-TEC/blob/ebc3748952fcda7c7955b11775b5f580ee843d91/Proceso/Imagenes/ToonShader.png)

### Actividad: Tanques FSM

Aquí se desarrolló un mini juego en donde tu manejas un tanque y tienes que derrotar a varios tanques enemigos, que se manejan por medio de una maquina de estados finito

[Repositorio del proyecto de Tanques FSM](https://github.com/JoanDGG/FSM-Example)

![Tanques](https://github.com/JoanDGG/Semestre-TEC/blob/ebc3748952fcda7c7955b11775b5f580ee843d91/Proceso/Imagenes/Tanques.png)

### Actividad: Parvadas

En esta actividad se manejó un sistema de parvadas en donde varios agentes se mueven siguiendo un determinado comportamiento para llegar a cierto destino, y poder esquivar obstáculos individualmente

[Script Flock](../Proceso/Evidencias/Flock.cs)

![Flock](https://github.com/JoanDGG/Semestre-TEC/blob/ebc3748952fcda7c7955b11775b5f580ee843d91/Proceso/Imagenes/Flock.png)