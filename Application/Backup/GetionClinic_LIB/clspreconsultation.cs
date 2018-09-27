using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clspreconsultation 
{
  //***Les variables globales***
 private int   id ;
 private int id_dossierpreconsultation;
 private double?  poid ;
 private double?  temperature ;
 private string  pressionarterielle ;
 private int?  pouls ;
 private double?  taille ;
 private string   observation ;
 private DateTime?  dateprecons ;
  //***Listes***
  public List<clspreconsultation> listes(){
 return clsMetier.GetInstance().getAllClspreconsultation();
}
 public  List<clspreconsultation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClspreconsultation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClspreconsultation(this);
 }
 public  int  update(clspreconsultation varscls){
 return clsMetier.GetInstance().updateClspreconsultation(varscls);
 }
 public  int  delete(clspreconsultation varscls){
 return clsMetier.GetInstance().deleteClspreconsultation(varscls);
 }
  //***Le constructeur par defaut***
  public    clspreconsultation() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}

  //***Accesseur de poid***
 public  double ?   Poid {

get { return poid; } 
set { poid = value; }
}
  //***Accesseur de temperature***
 public  double ?   Temperature {

get { return temperature; } 
set { temperature = value; }
}
  //***Accesseur de pressionarterielle***
 public  string   Pressionarterielle {

get { return pressionarterielle; } 
set { pressionarterielle = value; }
}
  //***Accesseur de pouls***
 public  int ?   Pouls {

get { return pouls; } 
set { pouls = value; }
}
  //***Accesseur de taille***
 public  double ?   Taille {

get { return taille; } 
set { taille = value; }
}
  //***Accesseur de observation***
 public  string   Observation {

get { return observation; } 
set { observation = value; }
}
  //***Accesseur de dateprecons***
 public  DateTime ?   Dateprecons {

get { return dateprecons; } 
set { dateprecons = value; }
}
  //***Dossier***
 public int Id_dossierpreconsultation
 {
     get { return id_dossierpreconsultation; }
     set { id_dossierpreconsultation = value; }
 }

} //***fin class

} //***fin namespace
