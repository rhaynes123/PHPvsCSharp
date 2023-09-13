<?php 
require_once('layout.html');
require_once('models/incident.php');
require_once('viewModels/IncidentsViewModel.php');
$model = new IncidentsViewModel();
$incidents = $model->OnGet();
?>
<h1>Incidents</h1>

<p>
    <a href="Index.php">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                Address
            </th>
            <th>
                Reason
            </th>
            <th>
                Reported On
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <?php foreach($incidents as $incident) { ?>
            <tr>
            <td>
                <?php echo $incident->Address ?>
            </td>
            <td>
                <?php echo Reason::tryFrom($incident->Reason)->name ?>
            </td>
            <td>
                <?php echo $incident->ReportedOn ?>
            </td>
        </tr>
        <?php } ?>
        
    </tbody>
</table>