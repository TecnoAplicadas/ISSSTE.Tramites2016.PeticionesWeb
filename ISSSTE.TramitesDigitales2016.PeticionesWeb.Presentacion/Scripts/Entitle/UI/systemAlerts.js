//Sistem alerts Created by Carlos Zavala
 function  SystemAlert (Type, Message, delay) {
        
     if (delay == ""){ delay = 3000;}
       var AlerType = "alert-info";
        
        if (Message == ""){"Uy parece que algo va mal"}
        switch(Type) {
            case "warning":
                AlerType = "alert-warning"
                break;
            case "info":
                AlerType = "alert-info"
                break;
            case "danger":
                AlerType = "alert-danger"
                break;
            case "success":
                AlerType = "alert-success"
                break;    
        }
    
/*se crea la alerta*/
        
   $( "#alertCont" ).append( "<div role='alert' class='alert " + AlerType + " alert-dismissible fade in'><button aria-label='Close' data-dismiss='alert' class='close' type='button'><span aria-hidden='true'>×</span></button>"+Message+"</div>");
    

     if(delay != "sticky"){
     $(".alert").delay(delay).fadeOut();
     }
     
 }

