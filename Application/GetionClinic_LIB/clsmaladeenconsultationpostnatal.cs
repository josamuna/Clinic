using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmaladeenconsultationpostnatal :clsmalade
{
  //***Les variables globales***
 private int   id ;
 private int   numeronaissance ;
 private int   id_malade ;
 private double?  poidsnaisance ;
 private string   lieunaissance ;
 private string   nommere ;
 private string   nompere ;
 private DateTime? date;

  //***Listes***
  public new List<clsmaladeenconsultationpostnatal> listes(){
 return clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal();
}
 public  new List<clsmaladeenconsultationpostnatal>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsmaladeenconsultationpostnatal(this);
 }
 public  int  update(clsmaladeenconsultationpostnatal varscls){
 return clsMetier.GetInstance().updateClsmaladeenconsultationpostnatal(varscls);
 }
 public  int  delete(clsmaladeenconsultationpostnatal varscls){
 return clsMetier.GetInstance().deleteClsmaladeenconsultationpostnatal(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmaladeenconsultationpostnatal() 
{
}

  //***Accesseur de id***
 public  int   IdEnfant {

get { return id; } 
set { id = value; }
}
  //***Accesseur de numeronaissance***
 public  int   Numeronaissance {

get { return numeronaissance; } 
set { numeronaissance = value; }
}
  //***Accesseur de id_personne***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de poidsnaisance***
 public  double ?   Poidsnaisance {

get { return poidsnaisance; } 
set { poidsnaisance = value; }
}
  //***Accesseur de lieunaissance***
 public  string   Lieunaissance {

get { return lieunaissance; } 
set { lieunaissance = value; }
}
  //***Accesseur de nommere***
 public  string   Nommere {

get { return nommere; } 
set { nommere = value; }
}
  //***Accesseur de nompere***
 public  string   Nompere {

get { return nompere; } 
set { nompere = value; }
}
 //***Accesseur de date***
 public DateTime? Date
 {
     get { return date; }
     set { date = value; }
 }
} //***fin class

} //***fin namespace
