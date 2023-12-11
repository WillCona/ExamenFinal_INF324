<?php
// Archivo: actualizar_persona.php

require_once('db_config.php');

if ($_SERVER['REQUEST_METHOD'] === 'PUT') {
    parse_str(file_get_contents("php://input"), $_PUT);

    $ci = $_PUT['ci'];
    $nombre = $_PUT['nombre'];
    $fecha_nacimiento = $_PUT['fecha_nacimiento'];
    $telefono = $_PUT['telefono'];
    $departamento = $_PUT['departamento'];

    $sql = "UPDATE persona 
            SET nombre='$nombre', fecha_nacimiento='$fecha_nacimiento', telefono='$telefono', departamento='$departamento' 
            WHERE ci='$ci'";

    if ($conexion->query($sql) === TRUE) {
        echo "Persona actualizada exitosamente.";
    } else {
        echo "Error al actualizar persona: " . $conexion->error;
    }
}

$conexion->close();
?>
