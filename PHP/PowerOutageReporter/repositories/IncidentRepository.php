<?php
require_once('models/incident.php');
require_once('data/dbconnection.php');

interface Repository {
    public function ReturnIncidents() : array;
    public function CreateIncident(Incident $incident) : void;
}

final class IncidentRepository implements Repository {
    use PDODatabaseConnection;

    public function __construct($db = null) {
        if($db == null) {
            global $db;
        }
        $this->db = $db;
    }
    public function CreateIncident(Incident $incident) : void {
        $insertSql = "INSERT INTO Incidents(Address,Reason) VALUES(?,?)";
        $insertStatement = $this->db->prepare($insertSql);
        $insertStatement->execute([$incident->Address, $incident->Reason]);
    }
    public function ReturnIncidents() : array {
        $query = "SELECT Id, Address, Reason, ReportedOn FROM Incidents";
        $querySql = $this->db->prepare($query);
        $querySql->execute();
        $incidents = $querySql->fetchAll(PDO::FETCH_CLASS | PDO::FETCH_PROPS_LATE, Incident::class);
        return $incidents;
    }
}
?>