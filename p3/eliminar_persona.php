php
 Archivo eliminar_persona.php

require_once('db_config.php');

if ($_SERVER['REQUEST_METHOD'] === 'DELETE') {
    parse_str(file_get_contents(phpinput), $_DELETE);

    $ci = $_DELETE['ci'];

    $sql = DELETE FROM persona WHERE ci='$ci';

    if ($conexion-query($sql) === TRUE) {
        echo Persona eliminada exitosamente.;
    } else {
        echo Error al eliminar persona  . $conexion-error;
    }
}

$conexion-close();

