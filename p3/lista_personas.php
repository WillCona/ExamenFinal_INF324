<?php
// Archivo: lista_personas.php

require_once('db_config.php');

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $sql = "SELECT * FROM persona";
    $resultado = $conexion->query($sql);

    if ($resultado->num_rows > 0) {
        $personas = array();

        while ($fila = $resultado->fetch_assoc()) {
            $personas[] = $fila;
        }

        header('Content-Type: application/json');
        echo json_encode($personas);
    } else {
        echo "No se encontraron personas.";
    }
}

$conexion->close();
?>
