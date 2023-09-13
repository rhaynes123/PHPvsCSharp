<?php
require_once('models/incident.php');
require_once('repositories/IncidentRepository.php');
final class IncidentsViewModel {
    private IncidentRepository $repo;

    public function __construct() {
        $this->repo = new IncidentRepository();
    }

    public function OnGet() : array {
        return $this->repo->ReturnIncidents();
    }
}
?>