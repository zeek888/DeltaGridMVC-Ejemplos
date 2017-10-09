param($installPath, $toolsPath, $package, $project)
$sourceFile = Split-Path -Path $project.FullName -Parent
$sourceFile=$sourceFile+ '\Global.asax.cs'
$F = Select-String -Path $sourceFile -Pattern "DeltaGridAPIConfig.Configurar"
$v=3
$ex=""
if($F.count -gt 0 -or -not $project.Type -eq "c#"){
}
else{
 (Get-Content $sourceFile -Encoding UTF8) | ForEach-Object {
	 if($_.Trim().StartsWith("RouteConfig.RegisterRoutes")){
		 $v=1000		 
	 }
    $v++;
    if($v -eq 1002){
    $ex=$_;
    $_="`n DeltaGridWebAPI.Servicios.DeltaGridAPIConfig.Configurar(o =>
            {
                o.SeguridadAPI = (contexto, tipoValidacion) => true;            
            });"+$ex+"`n";
    }
    $_
    
 }  | Set-Content $sourceFile -Encoding UTF8
}

