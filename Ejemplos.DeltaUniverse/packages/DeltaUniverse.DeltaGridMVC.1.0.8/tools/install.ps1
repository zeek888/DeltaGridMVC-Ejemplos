param($installPath, $toolsPath, $package, $project)
$sourceFile = Split-Path -Path $project.FullName -Parent
$sourceFile=$sourceFile+ '\Global.asax.cs'
$F = Select-String -Path $sourceFile -Pattern "PreApplicationStartMethod"
$v=3
$ex=""
$encabezado=0
if($F.count -gt 0 -or -not $project.Type -eq "c#"){
}
else{
 (Get-Content $sourceFile -Encoding UTF8) | ForEach-Object {
	 if($encabezado -eq 0 -and $_.Trim().StartsWith("namespace")){
		 $encabezado=1
		 $_="[assembly: PreApplicationStartMethod(typeof("+$project.ProjectName+".Global), ""Register"")] `n namespace "+$project.ProjectName
	 }
    if($_.Trim() -eq "public class Global : HttpApplication")
    {
    $v=-1
    }
    if($_.Trim() -eq "RouteConfig.RegisterRoutes(RouteTable.Routes);"){
    $v=1000;
    }
    $v++;
    if($v -eq 1){
    $_="{`n public static void Register()`n            {`nHttpApplication.RegisterModule(typeof(DeltaWebControlMVC.Helper.DeltaScriptModulo));`n            }`n";
    }
    if($v -eq 1002){  
     $ex=$_
    $_="`n            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new DeltaWebControlMVC.Helper.VistaProvider());`n            DeltaWebControlMVC.Configuracion.AplicacionDG.Configurar(o =>`n            {`no.Layout = ""~/Views/Shared/LayoutDG.cshtml"";`n            });`n"+$ex;
    }
    $_
    
 }  | Set-Content $sourceFile -Encoding UTF8
}

