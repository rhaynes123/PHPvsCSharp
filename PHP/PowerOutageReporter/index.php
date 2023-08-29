<?php 
require_once('layout.php');
require_once('models/incident.php');
require_once('data/dbconnection.php');
?>

<title>Home page</title>
<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://www.php.net/docs.php">building Web apps with PHP</a>.</p>
</div>

<div class="row">
    <div class="col-md-4">
        <form action="index.php" method="post">
            <input type="hidden" asp-for="Incident.Id" />
            <div class="form-group">
                <label class="control-label">Address</label>
                <input name="Address" class="form-control" />
                <span class="text-danger"></span>
            </div>
            <div class="form-group">
                <label class="control-label">Reason</label>
                <select name="Reason" class="form-control">
                <?php 
                    foreach (Reason::cases() as $reason) {
                        echo("<option value='{$reason->value}'>{$reason->name}</option>");
                    }
                ?>
                </select>
                <span class="text-danger"></span>
            </div>
            
            <div class="form-group">
                <button type="submit" class="btn btn-warning">Report Incident</button>
            </div>
        </form>
    </div>
</div>
<?php require_once('footer.php'); ?>
<?php 

if($_SERVER["REQUEST_METHOD"] == "POST") {
    $incident = new Incident();
    $incident->Address = $_POST['Address'];
    $incident->Reason = Reason::tryFrom($_POST['Reason']);
    $insertSql = "INSERT INTO Incidents(Address,Reason) VALUES(?,?)";
    $insertStatement = $db->prepare($insertSql);
    $insertStatement->execute([$incident->Address, $incident->Reason->value]);
}
?>
