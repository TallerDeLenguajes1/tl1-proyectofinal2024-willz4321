
                                                  
                                                  
                                                       DESARROLLADO



EL VIDEO JUEGO ESTA DESARROLLADO CON .NET 8. y se utlizan diferentes dll para la interfaz grafica del mismo,
principalmente Tao.Sdl.dll para  las funcionalidades de SDL en C#, facilitando tareas como la creación de ventanas,
renderizado de gráficos, manejo de eventos, entre otras.

- Los eventos se manejan a traves de la clase Hardware, manipulando las entradas por teclado, renderizado de imagenes y fuentes.

- El Juego se inicia en la clase PantallaBienvenida donde se elige la clase del jugador y posteriormente lanza el juego.
 Se puede elegir entre 4 clases de personajes, añadiendo nombre, apodo, y nacimiento. Las estadisticas de cada personaje varian dependiendo
 del personaje seleccionado, ademas de los ataques. Una vez finalizado juego con una victoria, dicha victoria se almacena en el archivo json (HistorialJson)
 y el mismo puede ser leido a traves de la pantalla de bienvenida del juego.

- Para controlar el jugador se utilizan las flechas de direccion y para atacar se utiliza la tecla Z.

-Todos los assets que se encuentran en la carpeta assets fueron creados con inteligencia artifical y con editores PNG para la adapatacion 
y compatibilidad con el video juego.

- Los archivos dentro de la carpeta Archive son fundamental para el funcionamiento del video en ventana, acontinuacion se describe sus funcionalidades:

SDL.dll:

Esta es la biblioteca principal de SDL (Simple DirectMedia Layer). Proporciona las funciones básicas para manejar gráficos,
entrada de usuario (teclado, ratón, joystick), temporización, y creación de ventanas. Es el núcleo de SDL y es necesario para cualquier aplicación
que utilice esta biblioteca.


SDL_gfx.dll:

Esta extensión de SDL añade funcionalidades para operaciones gráficas más avanzadas, como la rotación, escalado y antialiasing de imágenes, 
además de proporcionar primitivas gráficas como líneas, círculos, y polígonos. Es útil para crear gráficos más complejos y detallados en juegos o aplicaciones.


SDL_image.dll:

Esta biblioteca extiende SDL para soportar la carga y manipulación de diversos formatos de imágenes (como PNG, JPEG, BMP, etc.). 
Permite a los desarrolladores cargar texturas e imágenes desde archivos en varios formatos, facilitando la creación de interfaces gráficas y la manipulación
de recursos visuales.


SDL_mixer.dll:

Proporciona funcionalidades avanzadas de audio, incluyendo la capacidad de reproducir música y efectos de sonido en diferentes formatos (como WAV, MP3, OGG, etc.). 
Esta biblioteca es ideal para gestionar el audio de manera eficiente en videojuegos, permitiendo la mezcla de múltiples canales de sonido.


SDL_ttf.dll:

Esta extensión añade soporte para el renderizado de fuentes TrueType (TTF) en SDL. Permite dibujar texto con diferentes tipografías y tamaños, 
lo cual es fundamental para mostrar información textual en juegos y aplicaciones multimedia.


zlib1.dll:

zlib es una biblioteca de compresión de datos utilizada para comprimir y descomprimir datos, especialmente archivos gráficos. 
En el contexto de SDL, zlib1.dll se utiliza como una dependencia para SDL_image.dll y otras bibliotecas que manejan archivos comprimidos, 
permitiendo la carga y manipulación de imágenes comprimidas.


                                                    *****Api**********

- Se utiliza la api Dungeons & Dragons 5e https://www.dnd5eapi.co/api/ para obtener los nombre de diferentes criaturas y poder
nombrar a los enemigos del juego, esto se realiza a traves de la la clase EnemigoApi y se ejecuta en la clase Partida.