<?php
// Archivo: agregar_persona.php

require_once('db_config.php');

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $ci = $_POST['ci'];
    $nombre = $_POST['nombre'];
    $fecha_nacimiento = $_POST['fecha_nacimiento'];
    $telefono = $_POST['telefono'];
    $departamento = $_POST['departamento'];

    $sql = "INSERT INTO persona (ci, nombre, fecha_nacimiento, telefono, departamento) 
            VALUES ('$ci', '$nombre', '$fecha_nacimiento', '$telefono', '$departamento')";

    if ($conexion->query($sql) === TRUE) {
        echo "Persona agregada exitosamente.";
    } else {
        echo "Error al agregar persona: " . $conexion->error;
    }
}

$conexion->close();
?>
