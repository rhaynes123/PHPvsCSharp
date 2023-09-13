<?php 
require_once('models/incident.php');
require_once('repositories/IncidentRepository.php');
class IndexViewModel {
    private IncidentRepository $repo;

    public function __construct() {
        $this->repo = new IncidentRepository();
    }

    public function OnPost() { 
        $incident = new Incident();
        $incident->Address = htmlspecialchars($_POST['Address']) ;
        $incident->Reason = intval(htmlspecialchars($_POST['Reason']));
        $this->repo->CreateIncident($incident);
    }

}
?>