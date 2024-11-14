Si usan el backup para recuperar la informacion:

Cuenta de RentHub:
-Nombre:RentHub
-Clave:1234

Cuenta de Closer:
-Nombre: PabloPerez
-Clave: 1234

Cuenta de Cliente:
-Nombre: JohnKennedy
-Clave: 1234

-Cuenta de Dueño:
-Nombre: JavierAsato
-Clave: 1234

Recomendaciones:
-Si van usar otros usuarios más viejos fijense los nombres en la BD, usualmente la contraseña es 1234
sino puede ser que sea el nombre del usuario 1234, ej: LolaPineiro es lolap1234 si no me equivoco
-No intenten modificar los usuarios desde la BD porque se van a romper el digito verificador
-Para eso usen el administrador de usuarios del sistema con la cuenta de RentHUb

EXPLICACIÓN DE COMO FUNCIONA EL SISTEMA:
El sistema es una especie de Airbnb de alquileres para una inmoviliaria
-Primero se deberia dar de alta una vivienda por parte de un dueño
-Luego un closer se postula
-Luego el dueño acepta o rechaza los closers postulados
-Luego los clientes envían solicitud de reunión para ver la casa
-El closer designado a esa casa acepta o rechaza las solicitudes de reunión
-Si se le acepta la reunión al cliente, el dueño puede decidir si cerrar un trato o no con el cliente por
un determinado tiempo.
-Si se cierra el trato el cliente es habilitado a pagar su primera cuota
(hay un plazo de 24hs para que se generé, nose xq sucede esto pero estoy trabando para ver si lo puedo 
cambiar para que sea al instante)(yo quería hacer que las cuotas se generen desde la BD, y que la BD
haga un chekeo diario para generarlas pero al usar SQL-SERVER-EXPRESS no puedo implementar un agente, aspi que
opte por que se verifiquen y generen cuando se abre la app, cosa q esta mal pero no es parte del objetivo.)
-Los pagos son dinero en cuentas falsas(no conozco acerca del tema de tecnológias de pago así que lo emule
de esta manera)
-Todo el sistema tiene envío de mails y tiene "responsive desing" si se puede decir así.
-Cuenta tmb con multiidioma.
-Puede ser que aparezcan errores que no haya visto. Cualquier cosa contactarme a tomy2003@gmail.com