<?php
class Incident {
    public Int $Id;
    public string $Address;
    public int $Reason;
    public string $ReportedOn;
}

enum Reason: Int {
    case Unknown = 0;
	case WindDamage = 1;
	case WaterDamage = 2;
	case TreeDamage = 3;
	case DownPowerLine = 4;
}
?>