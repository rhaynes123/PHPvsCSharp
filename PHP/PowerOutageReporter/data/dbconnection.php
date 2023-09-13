<?php
$connectionString = "mysql:host=127.0.0.1;dbname=Reporter";
$db = new \PDO($connectionString, "root", "Password1");
trait PDODatabaseConnection {
    private PDO $db;
}
?>