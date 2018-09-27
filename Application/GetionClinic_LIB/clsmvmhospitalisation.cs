using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmvmhospitalisation 
{
  //***Les variables globales***
 private int   id ;
 private int?  temperature ;
 private DateTime?  date ;
 private int?  ta ;
 private int?  pls ;
 private string   resiration ;
 private int   id_hospitalisation ;
  //***Listes***
  public List<clsmvmhospitalisation> listes(){
 return clsMetier.GetInstance().getAllClsmvmhospitalisation();
}
 public  List<clsmvmhospitalisation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmvmhospitalisation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmvmhospitalisation(this);
 }
 public  int  update(clsmvmhospitalisation varscls){
 return clsMetier.GetInstance().updateClsmvmhospitalisation(varscls);
 }
 public  int  delete(clsmvmhospitalisation varscls){
 return clsMetier.GetInstance().deleteClsmvmhospitalisation(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmvmhospitalisation() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de temperature***
 public  int ?   Temperature {

get { return temperature; } 
set { temperature = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de ta***
 public  int ?   Ta {

get { return ta; } 
set { ta = value; }
}
  //***Accesseur de pls***
 public  int ?   Pls {

get { return pls; } 
set { pls = value; }
}
  //***Accesseur de resiration***
 public  string   Resiration {

get { return resiration; } 
set { resiration = value; }
}
  //***Accesseur de id_hospitalisation***
 public int Id_hospitalisation
 {

     get { return id_hospitalisation; }
     set { id_hospitalisation = value; }
 }

} //***fin class

} //***fin namespace
